Imports System.Globalization

Module ModRemisiones

    ' query para buscar los registros sin marca de impresión
    ' aquellos que tengan facturado>0 y expedición>0 se les pone la marca
    'select ftcnce,ftclot,ftpedi,ftcran,ftccli,ftccar,ftcnom,ftcran,ftcare,ftcmre,ftcdre,ftcimp,
    '(select count(*) from lucmfile.exfd where g3pedi=f.ftpedi and g3cart=f.ftccar) as facturado, -- se localiza el pedido y articulo en las facturas
    '(select count(*) from lucfile.pcdlo where loarco=f.ftccar and lolote=f.ftclot and lopcnu=f.ftpedi) as expedicion
    'from lucfile.ftcac as f where
    'ftcare>0 and
    'ftcimp='' --and ftcran='CC'
    'order by ftcare, ftcmre, ftcdre

    Enum TipoOrden As Integer
        codigo_lote = 0
        idtran
        idrack
    End Enum

#Region " prueba setup "

    Public Function GetRunningInstances() As Integer
        Dim currentProcess As Process = Process.GetCurrentProcess()
        Dim instancesProcess() As Process = Process.GetProcessesByName(currentProcess.ProcessName)
        Return instancesProcess.Count
    End Function

    ''' <summary>
    ''' Obtiene los nombres de los procesos que incluyen parte del nombre proporcionado.
    ''' </summary>
    ''' <param name="applicationName">Nombre del proceso que se busca. Process.GetCurrentProcess.ProcessName para ver obtener la instancia actual.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRunningLike(ByVal applicationName As String) As String()
        Dim intResultado As Integer = 0
        Dim strResultado As String = ""
        If (IsNothing(applicationName)) Then applicationName = ""
        applicationName = applicationName.Trim.ToUpper
        For Each p As Process In Process.GetProcesses()
            If (p.ProcessName.ToUpper.Contains(applicationName)) Then
                intResultado += 1
                If (strResultado <> "") Then strResultado &= "|"
                strResultado &= p.ProcessName
            End If
            'starttime - fecha en que inición la ejecución
            'totalprocessortime
            'startinfo.arguments
            'startinfo.domain
            'stattinfo.filename
            'startinfo.username, password
            'startinfo.environmentvariables.contents
            'computername
            'processor_architecture
            'processor_identifier
            'number_of_processors 4
            'systemDrive c:
            'logonserver -- servidor de dominio 
            'os windows_nt
            'processor_revision 2a07
            '*directorios
            'systemroot c:\windows
            'windir c:\windows
            'programfiles c:\program files (x86)
            'public c:\users\public
            'programdata c:\programdata
            'userprofile -- directorio del usuario
            'username rzertuche
            'userdomain lustasp
            'userdnsdomain -- nombre del dominio 
            'sessionname console
            'comspec c:\windows\system32\cmd.exe
            'mainmodule.moduleinfo.filename
            'mainmodule.moduleinfo.sizeofimage
            'mainmodule.moduleinfo.basename
        Next
        Return Split(strResultado, "|")
    End Function

    ''' <summary>
    ''' Obtiene la cantidad de procesos que incluyen parte del nombre proporcionado.
    ''' </summary>
    ''' <param name="applicationName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CountRunningLike(ByVal applicationName As String) As Integer
        Dim arrInstancias() As String = Nothing
        arrInstancias = GetRunningLike(applicationName)
        Return arrInstancias.Count
    End Function


#End Region



    ''' <summary>
    ''' Arreglo con el nombre de los meses
    ''' </summary>
    ''' <remarks></remarks>
    ReadOnly ArrMes() As String = {"", "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"}
    ReadOnly ArrMesFull() As String = {"", "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre"}
    ReadOnly ArrMesEn() As String = {"", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}

    ''' <summary>
    ''' Incia si se debe mostar el encabezado con logo
    ''' </summary>
    Public verLogos As Boolean = True

    ''' <summary>
    ''' Diccionario con los parametros del sistema
    ''' </summary>
    ''' <remarks></remarks>
    Public dicParametros As New Diccionario

    ''' <summary>
    ''' Enumeración con las posibles personas que firman
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Firmante As Integer
        RaquelZapata
        UrielVazquez
        ValentinaSixto
        GabrielPosadas
    End Enum
    ''' <summary>
    ''' Arreglo con los nombres de las posibles personas que firman
    ''' </summary>
    ''' <remarks></remarks>
    Public arrFirmante() As String = {"Ing. Raquel Zapata Banda", "Ing. Uriel Levi Vázquez Ríos", "Ing. Valentina Sixto Gonzaga", "Ing. Gabriel Posadas Carranza"}

    ''' <summary>
    ''' Indica la impresora que por defecto utilizará el programa.
    ''' </summary>
    ''' <remarks></remarks>
    Public strImpresora As String = ""

    ''' <summary>
    ''' Path raiz en el servidor principal
    ''' </summary>
    Public strPathMaestro As String = "\\192.168.52.31\Lucta\Certificados\"


    ''' <summary>
    ''' Manda a la impresora el certificado generado
    ''' </summary>
    ''' <param name="reporte"></param>
    ''' <param name="closeOnPreviewExit"></param>
    Public Sub ImprimirCertificado(ByRef reporte As GrapeCity.ActiveReports.Document.SectionDocument, ByVal closeOnPreviewExit As Boolean)
        Dim strTemp As String = ""
        Dim TimeOut As Date = DateAdd("s", 3, Now)
        'sectionDocument.Document.Printer.Print()
        reporte.Printer.DocumentName = "Certificado-" & dicParametros.GetValue("L") & "-" & dicParametros.GetValue("P")
        'repCertificado.Document.Printer.Print() '.Print(False, False, False)

        'FrmPreview.Viewer.Document = repCertificado.Document
        FrmPreview.Viewer.LoadDocument(reporte)
        FrmPreview.CloseOnExit = closeOnPreviewExit
        ' FrmPreview.Show()
        FrmPreview.Viewer.Refresh()
        Application.DoEvents()
        FrmRemisiones.LblAvance.Text = "mcc1090 Generando impresión"
        If (Sesion.Log) Then
            strTemp = "Se imprime " & reporte.Printer.DocumentName & " en " & reporte.Printer.PrinterName
            WriteLog(strTemp,, strPathMaestro & "log\work_log" & Format(Now, "yyyyMMdd") & ".log")
        End If
        FrmPreview.Print()
        FrmRemisiones.LblAvance.Text = "mcc1092 Impresión completada"

        Application.DoEvents()
        ' espera a que termine o que pasen 10 segundos
        TimeOut = DateAdd("s", 3, Now)
        While (DateDiff("s", TimeOut, Now) < 0)
            Application.DoEvents()
            Application.DoEvents()
        End While
        TimeOut = Now
    End Sub

    Public Sub MyMsgBox(ByVal mensaje As Object,
                        Optional ByVal botones As Microsoft.VisualBasic.MsgBoxStyle = MsgBoxStyle.OkOnly,
                        Optional ByVal titulo As Object = Nothing,
                        Optional ByVal duracion As Integer = 1)
        Dim vencimiento As Date = Nothing
        If (IsNothing(titulo)) Then titulo = "Lucta"
        FrmMsgBox.Show()
        FrmMsgBox.Mensaje = mensaje
        FrmMsgBox.Tiempo = duracion
        FrmMsgBox.Titulo = titulo
        vencimiento = DateAdd(DateInterval.Second, duracion + 10, Now)
        While (FrmMsgBox.Tiempo > 1) And (DateDiff(DateInterval.Second, Now, vencimiento) > 0)
            Application.DoEvents()
        End While
    End Sub

    ''' <summary>
    ''' Determina el tipo de certificado a generar
    ''' </summary>
    ''' <param name="closeOnPreviewExit"></param>
    ''' <remarks></remarks>
    Public Sub FillCertificado(Optional ByVal closeOnPreviewExit As Boolean = True)

        'Sesion.LibEs = "PRUEBA."
        Dim strQuery As String = ""
        Dim as400 As New ADO_DB2
        Dim as400b As New ADO_DB2
        Dim pedido As String = ""
        Dim referencia As String = ""
        Dim idioma As String = ""
        Dim fecha As String = ""
        Dim strTemp As String = ""
        pedido = dicParametros.GetValue("P").ToUpper.Trim ' número de pedido
        referencia = dicParametros.GetValue("R").ToUpper.Trim ' número de lote
        fecha = dicParametros.GetValue("F").ToUpper.Trim ' número de lote
        idioma = dicParametros.GetValue("I").ToUpper.Trim ' idioma que se requiere
        If (idioma = "") Then idioma = "ES"
        If (pedido = "") Or (referencia = "") Then Exit Sub
        as400.ConnectionString = as400.GetConnectionString(AppSettings("ReadUserMX", True), AppSettings("ReadPasswordMX", True), AppSettings("ServerMX"))
        strQuery = "select 1910 + count(*) + 1 from LUCMFILE.PCMAN6"
        '           " (select ceclrut from lucmfile.cerclpdf where ceclpdf=f.ftccli) as ruta " &
        as400.Open(strQuery)

        FrmRemisiones.LblAvance.Text = "mcc129 query " & idioma
        'WriteLog("FillCertificado " & idioma & " " & CStr(as400.RecordCount) & " " &
        '         as400.QueryString,, strPathMaestro & "log\work_log" & Format(Now, "yyyyMMdd") & ".log")
        If (as400.RecordCount > 0) Then
            ' obtención de datos de operación parametrizada
            strQuery = "select p.*, " &
                " (select clnomb from lucfile.cl where clcodi = " & as400.StrCampo("ftccli") & ") as nombre " &
                " from lucmfile.cerclpdf as p where ceclpdf = " & as400.StrCampo("ftccli")
            as400b.Open(strQuery)
            If (as400b.RecordCount = 0) Then
                strQuery = "select p.*, " &
                    " (select clnomb from lucfile.cl where clcodi = " & as400.StrCampo("ftccli") & ") as nombre " &
                    " from lucmfile.cerclpdf as p where p.ceclpdf = 0"  ' datos por defecto
                as400b.Open(strQuery)

                Dim codigoArea As String = as400.StrCampo("division")
                Dim ruta As String = as400b.StrCampo("ceclrut")
                'Dim ruta As String = "C:\Certificados PFD Pruebas"

                Dim Area As String = codigoArea


                'A AROMAS
                'F FRAGANCIAS
                'Z ZOOTECNIA

                Select Case codigoArea
                    Case "A"
                        Area = "AROMAS"
                    Case "F"
                        Area = "FRAGANCIAS"
                    Case "Z"
                        Area = "ZOOTECNIA"
                End Select

                dicParametros.Add("RUTA", ruta & "\" & Area & "\" & DateTime.Now.Year & "-" & DateTime.Now.Month & "\Pedido " & FillZero(pedido, 5) & "\")

            Else

                dicParametros.Add("RUTA", strTemp & "\Certificados " & as400.StrCampo("ftcamo") & "\Pedido " & FillZero(pedido, 5) & "\") ' ruta para colocar los PDF DE LA ANTIGUA MANERA 

            End If
            If (as400b.RecordCount > 0) Then
                strTemp = as400b.StrCampo("nombre")
                strTemp = strTemp.Replace(".", "")
                strTemp = strTemp.Replace(",", "")
                strTemp = strTemp.Replace("  ", " ")
                If (as400b.IntCampo("ceclpdf") = 0) Then
                    strTemp = as400b.StrCampo("ceclrut") & strTemp.Trim
                Else
                    strTemp = as400b.StrCampo("ceclrut")
                End If
                dicParametros.Add("CLIENTE", as400b.StrCampo("nombre")) ' nombre del cliente



                'dicParametros.Add("RUTA", strTemp & "\Certificados " & as400.StrCampo("ftcamo") & "\Pedido " & FillZero(pedido, 5) & "\") ' ruta para colocar los PDF
                dicParametros.Add("APDF", as400b.StrCampo("CEPDF")) ' bandera para indicar si se genera PDF
                'dicParametros.Add("COPIAS", as400b.StrCampo("CEIMP")) ' número de copias a imprimir
                dicParametros.Add("COPIAS", "1") ' número de copias a imprimir siempre 1 a peticion de Armando Navarro
            End If
            dicParametros.Add("CL", as400.StrCampo("FTCCLI")) ' número de cliente

        Else
            FrmRemisiones.LblAvance.Text = "mcc154 no se localizó el certificado"
        End If
    End Sub



    ''' <summary>
    ''' Crea el certificado (formato Aromas-Fragancias), de acuerdo con la información pasada en dicParametros
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FillRemisiones(Optional ByVal EnvioQro As Boolean = True, Optional ByVal Lotes As Boolean = True, Optional ByVal Domicilio As String = "") '(ByVal pedido As String, ByVal lote As String, ByVal opciones As String)
        Dim repRemision As New RemisionLucta
        Dim intNumEtiqueta As Integer = 0
        Dim strMensaje As String = ""
        Dim strQuery As String = ""
        Dim as400 As New ADO_DB2
        Dim as400Cliente As New ADO_DB2
        Dim as400Remision As New ADO_DB2
        Dim as400Desglose As New ADO_DB2
        Dim as400Lotes As New ADO_DB2
        Dim as400Guardar As New ADO_DB2
        Dim strAnalisis As String = ""
        Dim strCodigo As String = ""
        Dim strCliente As String = ""
        Dim strParametro As String = ""
        Dim strEspecificacion As String = ""
        Dim strResultado As String = ""
        Dim intCopias As Integer = 0
        Dim strLeyendas As String = ""
        Dim strFormato As String = ""
        Dim suma As Double
        Dim EspacioKilo As Integer = 0
        Dim Xml As New Xml.XmlDocument

        Dim pedido As String = ""
        Dim referencia As String = ""
        Dim fecha As String = ""
        Dim sello As String = ""
        pedido = dicParametros.GetValue("P").ToUpper.Trim ' número de pedido
        referencia = dicParametros.GetValue("R").ToUpper.Trim ' número de lote
        fecha = dicParametros.GetValue("F").ToUpper.Trim ' número de lote
        sello = dicParametros.GetValue("S") ' sello que se requiere
        If (pedido = "") Or (referencia = "") Then Exit Sub
        Dim kiloStr = ""
        Dim cantidadStr = ""
        Dim tcStr = ""
        Dim importeStr = ""
        Dim idRemision = ""
        Dim FechaHoy As DateTime = DateTime.ParseExact(Today, "dd/MM/yyyy", CultureInfo.InvariantCulture)
        Dim FechaHoyProc As String = FechaHoy.ToString("yyyyMMdd", CultureInfo.InvariantCulture)
        Dim lngRegistros As Long = 0
        Dim espacio1 = " "
        Dim espacio2 = "  "
        Dim espacio3 = "   "
        Dim espacio4 = "    "
        Dim espacio5 = "     "
        Dim espacio6 = "      "
        Dim espacio7 = "       "
        Dim espacio8 = "        "
        Dim espacio9 = "         "
        Dim espacio10 = "          "
        Dim espacio11 = "           "
        Dim espacio12 = "            "
        Dim espacio13 = "             "
        Dim espacio14 = "              "
        Dim espacio15 = "               "

        FrmRemisiones.LblAvance.Text = "rem320 set pagesettings"
        Application.DoEvents()
        'Me.Cursor = Cursors.WaitCursor
        Dim pageSettings As GrapeCity.ActiveReports.PageSettings = repRemision.PageSettings
        Try
            With pageSettings
                .Margins.Left = 0
                .Margins.Right = 0
                .Margins.Top = 0
                .Margins.Bottom = 0
                .Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait
                '.PaperKind = Printing.PaperKind.Custom
                .PaperWidth = 8.4 ' en pulgadas 
                .PaperHeight = 10.8 ' en pulgadas
            End With
        Catch ex As Exception
            MyMsgBox("Error al configurar la página")
            Exit Sub
        End Try

        strMensaje = ""

        as400.ConnectionString = as400.GetConnectionString(AppSettings("ReadUserMX", True), AppSettings("ReadPasswordMX", True), AppSettings("ServerMX"))
        as400Cliente.ConnectionString = as400.ConnectionString
        as400Remision.ConnectionString = as400.ConnectionString
        as400Desglose.ConnectionString = as400.ConnectionString
        as400Lotes.ConnectionString = as400.ConnectionString
        as400Guardar.ConnectionString = as400.ConnectionString

#Region "Pruebas"
        'Dim strNoConforme = ""
        'Dim strTemp = ""
        'Dim strDescripcion As String = ""
        'Dim strArea As String = ""
        'Dim bolExpediciones As Boolean = False
        'Dim idrack As String = "ZKA011"
        'as400.Open("select * from " & Sesion.LibMx & "ubrack where idrack = '" & idrack & "'")
        'strTemp = as400.StrCampo("area")
        'For index As Integer = 1 To as400.RecordCount
        '    If (strTemp.Substring(4, 1) = "-") Then ' si tiene guion, indica que en el nombre se encuentra la descripción del almacen
        '        Dim strAlmacen = strTemp.Substring(0, 2)
        '        Dim strRack = as400.StrCampo("edific")
        '        Dim strColumna = as400.StrCampo("column")
        '        Dim strNivel = as400.StrCampo("nivel")
        '        Dim strUbrack = as400.StrCampo("idrack")
        '        ' strNoConforme = strTemp.Substring(2, 1)
        '        Select Case strTemp.Substring(2, 1)
        '            Case "C" ' conforme
        '                strNoConforme = "N"
        '            Case "N" ' no conforme
        '                strNoConforme = "S"
        '            Case Else ' por defecto es conforme
        '                strNoConforme = "N"
        '        End Select
        '        bolExpediciones = (strTemp.Substring(3, 1) = "E") ' para ver si se trata de expediciones
        '        Dim dblCapacidadRack = Format(CDbl("0" & as400.StrCampo("CAPACI")), "#0.000")
        '        '
        '        'strUbicacion &= as400.StrCampo("area").Substring(5) & "|"
        '        strDescripcion &= "Almacen:" & as400.StrCampo("area").Substring(0, 2) & "  "
        '        strDescripcion &= "Edif:" & as400.StrCampo("edific") & "  "
        '        strDescripcion &= "Col:" & as400.StrCampo("column") & "  "
        '        strDescripcion &= "Niv:" & as400.StrCampo("nivel") & "  "
        '        strDescripcion &= IIf((as400.StrCampo("area").Substring(2, 1) = "C"), "Conforme  ", "No conforme  ") 'CN
        '        strDescripcion &= IIf((as400.StrCampo("area").Substring(3, 1) = "E"), "Expediciones  ", "Materia prima  ") 'EM
        '    Else
        '        strDescripcion &= as400.StrCampo("area") & "|" & "No apto para inventario"
        '        strResultado &= AddNodoXML("error", "La información de la ubicación es incorrecta")
        '    End If
        'Next

        'as400.Open("select * from lucmfile.invfrct where ic_almace = '" & idrack.Substring(0, 2) & "' and ic_rack = '" & idrack.Substring(2, 1) & "' ")
        'If (as400.RecordCount > 0) Then
        '    strResultado &= "<prueba>"
        '    strResultado &= AddNodoXML("division", as400.StrCampo("ic_divis"))
        '    strResultado &= AddNodoXML("estatus", as400.StrCampo("ic_sts"))
        'Else ' no está en la lista de racks a revisar
        '    If (strArea.Substring(3, 1) = "E") Then ' se trata de expediciones
        '        strResultado &= AddNodoXML("division", strArea.Substring(1, 1)) ' puede ser aromas o fragancias
        '        strResultado &= AddNodoXML("estatus", "A") ' para simular que está en primer conteo
        '    End If
        'End If

        'strQuery = "select * from lucmfile.invfrct as invf, lucmfile.ubrack as ubr where " &
        '            " ubr.idrack = '" & idrack & "' and " &
        '            " invf.ic_almace = substring(ubr.idrack,1,2) And invf.ic_rack = substring(ubr.idrack,3,1)"
        'strQuery = "select * from lucmfile.ubrack as ubr where " &
        '            " ubr.idrack = '" & idrack & "' "
        'as400.Open(strQuery)
        'strQuery = "select * from lucmfile.invfrct as invf where " &
        '            " invf.ic_almace = '" & idrack.Substring(0, 2) & "' And " &
        '            " invf.ic_rack = '" & idrack.Substring(2, 1) & "'"
        'as400.Open(strQuery)


        ''Dim strResultado As String = ""
        'Dim strRow As String = ""
        ''Dim strQuery As String = ""
        'Dim codigo = "00100"
        ''Dim as400 As New ADO_DB2 'GenericTable(GetConnectionString())

        'If IsNumeric(codigo) Then
        '    strQuery = "" &
        '    " select ub.*, " &
        '    " mp.mpnomb as nombre, " &
        '    " mp.mpstpe as kgF, mp.mpsnpe as kgFnc, " &
        '    " mp.mpstal as kgA, mp.mpsnal as kgAnc, " &
        '    " mp.mpstzo as kgZ, mp.mpsnzo as kgZnc, " &
        '    " (select hc.fthnki from " & Sesion.LibEs & "fthc hc where" &
        '    "         hc.fthlot=ub.lote and hc.fthran in ('CC','AC') order by hc.fthord desc fetch first 1 row only) as kgLote " &
        '    " from " & Sesion.LibMx & "ubvig ub, " & Sesion.LibEs & "mp mp " &
        '    " where mp.mpcodi = ub.idmp and " &
        '    " ub.idmp = '" & codigo & "' order by ub.idrack"
        'Else
        '    strQuery = "" &
        '    " select ub.*, " &
        '    " ar.arnomb as nombre, " &
        '    " ar.arstpe as kgF, ar.arsnpe as kgFnc, " &
        '    " ar.arstal as kgA, ar.arsnal as kgAnc, " &
        '    " ar.arstzo as kgZ, ar.arsnzo as kgZnc, " &
        '    " (select ic.ftinki from " & Sesion.LibEs & "ftic ic where " &
        '    "         ic.ftilot = ub.lote) as kgLote " &
        '    " from " & Sesion.LibMx & "ubvig ub, " & Sesion.LibEs & "ar ar " &
        '    " where ar.arcodi = ub.idmp and " &
        '    " ub.idmp = '" & codigo & "' order by ub.idrack"
        'End If
        'as400.Open(strQuery)
        'If (as400.StrError = "") Then
        '    If (as400.RecordCount = 0) Then ' no había existencias, buscamos la información de ST
        '        If IsNumeric(codigo) Then ' materia prima
        '            strQuery = "" &
        '                " select " &
        '                " mp.mpnomb as nombre, " &
        '                " mp.mpstpe as kgF, mp.mpsnpe as kgFnc, " &
        '                " mp.mpstal as kgA, mp.mpsnal as kgAnc, " &
        '                " mp.mpstzo as kgZ, mp.mpsnzo as kgZnc, " &
        '                " 0 as kgLote " &
        '                " from " & Sesion.LibEs & "mp mp " &
        '                " where mp.mpcodi = '" & codigo & "' "
        '        Else ' artículo
        '            strQuery = "" &
        '                " select " &
        '                " ar.arnomb as nombre, " &
        '                " ar.arstpe as kgF, ar.arsnpe as kgFnc, " &
        '                " ar.arstal as kgA, ar.arsnal as kgAnc, " &
        '                " ar.arstzo as kgZ, ar.arsnzo as kgZnc, " &
        '                " 0 as kgLote " &
        '                " from " & Sesion.LibEs & "ar ar " &
        '                " where ar.arcodi = '" & codigo & "' "
        '        End If
        '        as400.Open(strQuery)
        '    End If
        '    If (as400.StrError = "") Then
        '        strResultado &= AddNodoXML("nombre", as400.StrCampo("NOMBRE")) ' nombre del producto
        '        strResultado &= AddNodoXML("codigo", codigo) ' codigo del producto
        '        strResultado &= AddNodoXML("KgF", as400.StrCampo("KGF"))
        '        strResultado &= AddNodoXML("kgFnc", as400.StrCampo("KGFNC"))
        '        strResultado &= AddNodoXML("KgA", as400.StrCampo("KGA"))
        '        strResultado &= AddNodoXML("kgAnc", as400.StrCampo("KGANC"))
        '        strResultado &= AddNodoXML("KgZ", as400.StrCampo("KGZ"))
        '        strResultado &= AddNodoXML("kgZnc", as400.StrCampo("KGZNC"))
        '        strResultado &= GetRowsUbicaciones(codigo)
        '        strResultado &= GetRowsUbicacionesNC(codigo)
        '        strResultado &= GetRowsTransito(codigo)
        '        'strResultado &= addNodoXML("error", "")
        '    Else
        '        strResultado &= AddNodoXML("error", as400.StrError)
        '    End If
        'Else
        '    strResultado &= AddNodoXML("error", as400.StrError)
        'End If
        'If (InStr(strResultado, "<error>") = 0) Then strResultado &= AddNodoXML("error", "")
        'strResultado &= "</prueba>"
        'Dim texto = strResultado
        'Xml.LoadXml(texto)
        'ShowDatosLote(Xml)

#End Region

        strQuery = "select max(remnfo)+1 from lucmfile.remfol" 'se obtiene el # de remisión
        as400.Open(strQuery)
        idRemision = as400.StrCampo(0)
        FrmRemisiones.LblAvance.Text = "Consulta Remisión"
        'If (as400.RecordCount > 0) Then
        intCopias = 1
        With repRemision
            'se obiente la dirección del cliente o si se recoge en planta
            If EnvioQro = True Then
                .lbCalle.Text = "Carretera Estatal 100, El colorado, Higuerillas N° 4200 3-M, 3-N."
                .lbColonia.Text = "Parque Industrial Aeropuerto, San Idelfonso, Colon Querétaro."
                .lbTelefono.Text = "Tel. (52) 55 53 33 60 03"
            End If
            '.lbFecha.Text = Format(CDate(fecha), "MMM dd, yyyy")
            .lbFecha.Text = Format(DateTime.Now, "MMMM dd, yyyy").ToUpper()
            .lbOrdenCompraNo.Text = referencia
            .lbPedidoNo.Text = pedido
            .lbRemisionNo.Text = idRemision
            .lbSelloSeguridad.Text = sello
            strQuery = "select CA.FTCCAR, CA.FTCNOM, sum(CA.FTCNKI) From lucfile.ftcac CA " &
                    " where CA.ftpedi = " & pedido &
                    " group by CA.FTCCAR, CA.FTCNOM, CA.FTCCLI"

            'se obienten los datos de la dirección del cliente
            as400Cliente.Open(strQuery)
            as400Cliente.Open("select CL.CLCODI, CL.CLNOMB, CL.CLDOMC, CL.CLONIA, CL.CLPOBC, " &
                            " varchar(CL.clproc) concat varchar(CL.CLDPOC), TBP.tbpdes " &
                            " From lucfile.ftcac CA, lucfile.cl CL, lucfile.tbp TBP " &
                            " where CA.ftpedi = " & pedido &
                            " and TBP.tbpcod = cl.clproc " &
                            " And ca.FTCCLI = CL.CLCODI " &
                            " group by CL.CLCODI,  CL.CLNOMB, CL.CLDOMC, CL.CLONIA, CL.CLPOBC, CL.clproc, CL.CLDPOC, TBP.tbpdes ")
            .LbClienteData.Text = 'as400Cliente.StrCampo(0) & vbCrLf &
            as400Cliente.StrCampo(1) & vbCrLf &
                as400Cliente.StrCampo(2) & vbCrLf &
                as400Cliente.StrCampo(3) & vbCrLf &
                as400Cliente.StrCampo(4) & vbCrLf &
                as400Cliente.StrCampo(5) & vbCrLf

            'se obtienen los datos de la remisión
            strQuery = "select PC.pccons, PC.pcdomi, PC.pconia, PC.pcpobl, PC.pcprov concat PC.pcdpos as CP, " &
                    " case when tbm.tbmdes = 'PESO MEXICANO' then 'PESO' else tbm.tbmdes end, PC.pcdepo, PC.PCCOCL, PC.pcreci, PC.pcrefc " &
                    " from lucfile.pc PC, lucfile.tbm tbm " &
                    " where PC.pcnume = " & pedido &
                    " And Pc.pcmone = tbm.tbmcod "
            as400Remision.Open(strQuery)

            .lbTCPunit.Text = as400Remision.StrCampo(5)
            .lbTCPimporte.Text = .lbTCPunit.Text

            If (Domicilio = "Recoger en planta") Then
                .lbConsignatarioData.Text = "LUCTA MEXICANA" & vbCrLf &
                    "CARRETERA ESTATAL 100, EL COLORADO" & vbCrLf &
                    "HIGUERILLAS N° 4200 3-M, 3-N." & vbCrLf &
                    "PARQUE INDUSTRIAL AEROPUERTO." & vbCrLf &
                    "SAN ILDEFONSO, COLON QUERETARO."
            Else
                .lbConsignatarioData.Text = as400Remision.StrCampo(0) & vbCrLf &
                    as400Remision.StrCampo(1) & vbCrLf &
                    as400Remision.StrCampo(2) & vbCrLf &
                    as400Remision.StrCampo(3) & vbCrLf &
                    as400Remision.StrCampo(4) & vbCrLf
            End If

            'se obitienen los datos del pedido
            strQuery = "select trim(PCD.PCDCOA) as PCDCOA, trim(PCD.PCDNOA) as PCDNOA, " &
                    " decimal(trim(pcd.pcdkar),9,2) as CANTIDAD, " &
                    " decimal(trim(pcd.pcdprd),9,2) as TC, " &
                    " decimal(trim(pcd.pcdkar * pcd.pcdprd),9,2) as IMPORTE " &
                    " From lucfile.pcd pcd " &
                    " where pcd.pcnume =" & pedido &
                    " order by decimal(trim(pcd.pcdkar * pcd.pcdprd),9,2)"

            as400Desglose.Open(strQuery)

            .lbDesglose.Text = ""
            For index As Integer = 1 To as400Desglose.RecordCount
                suma = suma + Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00")
                cantidadStr = ""
                tcStr = ""
                importeStr = ""
                If (Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00").Length = 1) Then
                    cantidadStr = espacio10 + Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00").Length = 2) Then
                    cantidadStr = espacio9 + Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00").Length = 3) Then
                    cantidadStr = espacio8 + Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00").Length = 4) Then
                    cantidadStr = espacio7 + Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00").Length = 5) Then
                    cantidadStr = espacio6 + Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00").Length = 6) Then
                    cantidadStr = espacio5 + Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00").Length = 7) Then
                    cantidadStr = espacio4 + Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00").Length = 8) Then
                    cantidadStr = espacio3 + Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00").Length = 9) Then
                    cantidadStr = espacio2 + Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00").Length = 10) Then
                    cantidadStr = espacio1 + Convert.ToDecimal(as400Desglose.StrCampo(2)).ToString("#,##0.00")
                End If

                If (Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00").Length = 1) Then
                    tcStr = espacio10 + Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00").Length = 2) Then
                    tcStr = espacio9 + Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00").Length = 3) Then
                    tcStr = espacio8 + Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00").Length = 4) Then
                    tcStr = espacio7 + Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00").Length = 5) Then
                    tcStr = espacio6 + Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00").Length = 6) Then
                    tcStr = espacio5 + Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00").Length = 7) Then
                    tcStr = espacio4 + Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00").Length = 8) Then
                    tcStr = espacio3 + Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00").Length = 9) Then
                    tcStr = espacio2 + Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00").Length = 10) Then
                    tcStr = espacio1 + Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00")
                End If

                If (Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00").Length = 1) Then
                    importeStr = espacio10 + Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00").Length = 2) Then
                    importeStr = espacio9 + Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00").Length = 3) Then
                    importeStr = espacio8 + Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00").Length = 4) Then
                    importeStr = espacio7 + Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00").Length = 5) Then
                    importeStr = espacio6 + Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00").Length = 6) Then
                    importeStr = espacio5 + Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00").Length = 7) Then
                    importeStr = espacio4 + Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00").Length = 8) Then
                    importeStr = espacio3 + Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00").Length = 9) Then
                    importeStr = espacio2 + Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00")
                ElseIf (Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00").Length = 10) Then
                    importeStr = espacio1 + Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00")
                End If

                .lbDesglose.Text &=
                as400Desglose.StrCampo(0).Replace("  ", " ").ToString & espacio12 &
                as400Desglose.StrCampo(1).Replace("  ", " ").ToString & espacio12 &
                cantidadStr & espacio12 &
                tcStr & espacio15 &
                importeStr & vbCrLf
                as400Desglose.MoveNext()

                'Convert.ToDecimal(as400Desglose.StrCampo(3)).ToString("#,##0.00") & "                 " &
                'Convert.ToDecimal(as400Desglose.StrCampo(4)).ToString("#,##0.00") & vbCrLf
            Next

            'se obtienen los datos de los lotes
            If Lotes = True Then
                strQuery = "select trim(DLO.loarco) as loarco, trim(DLO.lolote) as lolote, trim(decimal((DLO.lokilo),9,2)) as Kilo, " &
                    " substr(DLO.lofech,7,2) concat '/' concat substr(DLO.lofech,5,2) concat '/' concat substr(DLO.lofech,1,4) as FechaLote, " &
                    " (case when length(trim(IC.ftidre)) = 1 then '0' concat trim(IC.ftidre) else trim(IC.ftidre) end ) concat '/' concat (case when length(trim(IC.ftimre)) = 1 then '0' concat trim(IC.ftimre) else trim(IC.ftimre) end ) concat '/' concat IC.ftiare as Creacion, " &
                    " (case when length(trim(IC.FTIDCA)) = 1 then '0' concat trim(IC.FTIDCA) else trim(IC.FTIDCA) end ) concat '/' concat (case when length(trim(IC.FTIMCA)) = 1 then '0' concat trim(IC.FTIMCA) else trim(IC.FTIMCA) end ) concat '/' concat IC.FTIACA as Caducidad, length(trim(decimal((DLO.lokilo),9,2))) " &
                    " from lucfile.pcdlo DLO, lucfile.FTIC IC " &
                    " where DLO.lopcnu = " & pedido &
                    " And DLO.loarco=IC.fticar and DLO.lolote = IC.ftilot order by length(trim(decimal((DLO.lokilo),9,2)))"

                as400Lotes.Open(strQuery)

                .lbLotes.Text = ""
                For index As Integer = 1 To as400Lotes.RecordCount
                    kiloStr = ""
                    If (Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00").Length = 1) Then
                        kiloStr = espacio10 + Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00")
                    ElseIf (Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00").Length = 2) Then
                        kiloStr = espacio9 + Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00")
                    ElseIf (Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00").Length = 3) Then
                        kiloStr = espacio8 + Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00")
                    ElseIf (Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00").Length = 4) Then
                        kiloStr = espacio7 + Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00")
                    ElseIf (Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00").Length = 5) Then
                        kiloStr = espacio6 + Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00")
                    ElseIf (Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00").Length = 6) Then
                        kiloStr = espacio5 + Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00")
                    ElseIf (Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00").Length = 7) Then
                        kiloStr = espacio4 + Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00")
                    ElseIf (Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00").Length = 8) Then
                        kiloStr = espacio3 + Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00")
                    ElseIf (Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00").Length = 9) Then
                        kiloStr = espacio2 + Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00")
                    ElseIf (Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00").Length = 10) Then
                        kiloStr = espacio1 + Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00")
                    End If

                    .lbLotes.Text &=
                    as400Lotes.StrCampo(0) & espacio15 &
                    as400Lotes.StrCampo(1) & espacio15 &
                    kiloStr & espacio15 &
                    as400Lotes.StrCampo(3) & espacio15 &
                    as400Lotes.StrCampo(4) & espacio15 &
                    as400Lotes.StrCampo(5) & vbCrLf
                    as400Lotes.MoveNext()

                    'Convert.ToDecimal(as400Lotes.StrCampo(2)).ToString("#,##0.00") & "            " &
                Next
            Else
                .lbLotes.Visible = False
                .lbCodigoLt.Visible = False
                .lbLoteLt.Visible = False
                .lbCantidadLt.Visible = False
                .lbFeLote.Visible = False
                .lbFeCreacionLt.Visible = False
                .lbFeCaducidadLt.Visible = False
            End If

            .lbSubTotal.Text = Convert.ToString(suma.ToString("#,##0.00"))
            .lbTotal.Text = .lbSubTotal.Text
            .lbIVA.Text = ""
        End With
        'End If
        repRemision.Run(False)
        GestionaDestino(repRemision, True)

        'inserta en la tabla lucmfile.remfol para trazabilidad
        strQuery = "insert into lucmfile.remfol (remnfo, remnpe, remusu, remfec) values (" & idRemision & "," & pedido & ", '" & Sesion.Usuario & "', " & FechaHoyProc & ")"
        lngRegistros = as400.Execute(strQuery)
        If (lngRegistros = 0) Then
            MsgBox(as400.StrError)
        End If

    End Sub

    Private Sub ShowDatosLote(ByRef xml As System.Xml.XmlDocument, Optional ByVal muestraStatus As Boolean = True)
        ' niveles frmAvance: 3
        Dim strCalidad As String
        Dim arrUbicaciones() As String = Nothing
        Dim intI As Integer = 0
        Dim bolYaExiste As Boolean = False
        Dim arrRack() As String = Nothing
        'frmAvance.descripcion = "Analizando información"
        'frmAvance.incrementa()
        'Me.Codigo = GetNodo(xml, "//codigo")
        '_codigo = Me.Codigo
        'Me.Descripcion = GetNodo(xml, "//descripcion") & vbCrLf
        '_regBusStrFechaRecepcion = FormatFechaHora(GetNodo(xml, "//fechaRecepcion"))
        '_regBusStrFechaCaducidad = FormatFechaHora(GetNodo(xml, "//fechaCaducidad"))
        'Me.Cantidad = ""
        strCalidad = ""
        Select Case GetNodo(xml, "//calidad")
            Case "CC", "AC"
                strCalidad = "Aprobado "
            Case "RE"
                strCalidad = "Rechazado "
            Case Else
                strCalidad = "Pendiente "
        End Select
        If muestraStatus Then
            SetStatus("Lote: " & Format(GetDblNodo(xml, "//cantidad"), "#,##0.000") & " kgs.   Calidad:" & strCalidad & vbCrLf &
                      "Ubicados: " & Format(GetDblNodo(xml, "//kilosUbicados"), "#,##0.000") & "  Usados: " & Format(GetDblNodo(xml, "//kilosUsados"), "#,##0.000"), System.Drawing.Color.Red, , True)
        End If



    End Sub

    Public Sub SetStatus(ByVal texto As String,
                         ByVal color As System.Drawing.Color,
                         Optional ByVal espera As Double = 3,
                         Optional ByVal append As Boolean = False,
                         Optional ByVal saltarLinea As Boolean = False)
        Const maxLargo As Integer = 45
        texto = texto.Trim
        If (texto.Length > maxLargo) Then ' ajustar el tamaño
            If (InStrRev(texto, ChrW(10), maxLargo) = 0) Then
                Dim intI As Integer = 0
                intI = InStrRev(texto, " ", maxLargo)
                If (intI = 0) Then intI = maxLargo
                texto = texto.Substring(0, intI) & vbCrLf & texto.Substring(intI)
            End If
        End If
        If (append) Then texto = FrmRemisiones.LblAvance.Text & texto
        If (saltarLinea) Then texto &= vbCrLf
        FrmRemisiones.LblAvance.Text = texto
        'esperaTimer.Enabled = False
        If (espera < 0.1) Then
            espera = 0.1
        End If
        'esperaTimer.Interval = CInt(espera * 1000)
        'lblStatus.BackColor = color
        'esperaTimer.Enabled = True
    End Sub

    Public Sub GestionaDestino(ByRef repCertificado As GrapeCity.ActiveReports.SectionReport, ByVal closeOnPreviewExit As Boolean)
        If (strImpresora <> "") Then
            repCertificado.Document.Printer.PrinterName = strImpresora
            FrmPreview.Impresora = strImpresora
        End If
        FrmRemisiones.LblAvance.Text = "gd1351 Setting impresora"

        Dim intCopias As Integer = 0
        ' imprimir automáticamente
        intCopias = 1 'SIEMPRE 1 A PETICION DE A.NAVARRO'
        If (intCopias > 0) Then
            'intCopias = 1
            For intI = 1 To intCopias
                If dicParametros.ContainsKey("automatico") Then
                    'implementar caferacer
                    ExportaPDF("PA" & " " & dicParametros.GetValue("ARTICULO") & " " & dicParametros.GetValue("L") & " " & dicParametros.GetValue("P") & ".pdf", repCertificado, False)
                Else
                    ImprimirCertificado(repCertificado.Document, closeOnPreviewExit)
                End If
            Next intI
            If (closeOnPreviewExit) Then Exit Sub
        End If
        If True Then
        End If

        If (dicParametros.ContainsKey("PDF")) Then ' pdf
            ExportaPDF("Certificado-" & dicParametros.GetValue("L") & "-" & dicParametros.GetValue("P") & ".pdf", repCertificado, True)
            If (dicParametros.ContainsKey("QUIT")) Then Exit Sub
        End If

        If (dicParametros.ContainsKey("WORD")) Then ' pdf
            ExportaWord(dicParametros.GetValue("ARTICULO") & " " & dicParametros.GetValue("L") & " " & dicParametros.GetValue("P") & ".rtf", repCertificado, True)
            If (dicParametros.ContainsKey("QUIT")) Then Exit Sub
        End If

        If (dicParametros.ContainsKey("PREVIEW")) Then ' vista previa
            FrmPreview.Viewer.Document = repCertificado.Document
            FrmPreview.CloseOnExit = closeOnPreviewExit
            FrmPreview.Show()
            FrmRemisiones.LblProceso.Text = "Completo" 'GetMsgIdioma(FrmCertificados, "msgCompleto") '"Puede ahora imprimir" & vbCrLf & "el certificado."
        End If

    End Sub


    ''' <summary>
    ''' Valida que la fecha proporcionada sea válida y dentro de un lapso de 2 años
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EsFechaValida(ByVal anio As Integer, ByVal mes As Integer, Optional ByVal dia As Integer = 1, Optional ByVal permiteFuturo As Boolean = False, Optional ByVal maxAniosPrevios As Integer = 2) As Boolean
        Dim blnResultado As Boolean = True
        Dim dtFecha As Date = Now
        If (dia <= 0) Then blnResultado = False
        If (mes <= 0) Then blnResultado = False
        If (anio <= 0) Then blnResultado = False
        If (maxAniosPrevios < 1) Then maxAniosPrevios = 1
        If (blnResultado) Then
            Try
                dtFecha = New Date(anio, mes, dia)
                If Not permiteFuturo And (DateDiff(DateInterval.Day, dtFecha, Now.Date) < 0) Then blnResultado = False ' no se puede imprimir certificados a futuro
                If (DateDiff(DateInterval.Day, dtFecha, Now.Date) > (365 * maxAniosPrevios)) Then ' maximo se puede imprimir certificados de hace un año
                    If (dicParametros.ContainsKey("A")) Then
                        blnResultado = False
                    Else ' si no es un agente quien los genera, solamente se le avísa que es un certificado viejo
                        MyMsgBox("El análisis tiene mucho tiempo de haberser realizado.", MsgBoxStyle.Exclamation, "Lucta", 5)
                    End If
                End If
            Catch ex As System.ArgumentOutOfRangeException
                MyMsgBox("La fecha es inválida: " & CStr(anio) & "-" & CStr(mes) & "-" & CStr(dia), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Lucta", 10)
            Catch ex As Exception
                blnResultado = False
            End Try
        End If
        Return blnResultado
    End Function

    ''' <summary>
    ''' Elimina el código en el nombre del artículo
    ''' </summary>
    ''' <param name="codigo"></param>
    ''' <param name="nombre"></param>
    ''' <returns></returns>
    Public Function GetMuestraName(ByVal codigo As String, ByVal nombre As String) As String
        Dim strResultado As String = ""
        Dim arrTemp() As String
        Dim intI As Integer = 0

        ' validación de parámetros nulos
        If IsNothing(codigo) Then Throw New ArgumentNullException("codigo")
        If IsNothing(nombre) Then Throw New ArgumentNullException("nombre")
        codigo = codigo.Trim
        nombre = nombre.Trim
        arrTemp = Split(nombre, " ")
        strResultado = ""
        For intI = 0 To arrTemp.Length - 1
            If (InStr(codigo, arrTemp(intI)) <= 0) Then
                strResultado &= arrTemp(intI).Trim & " "
            End If
        Next
        Return strResultado.Trim
    End Function

    Public Function ExportaPDF(ByVal nom_rep As String, ByVal rpt As GrapeCity.ActiveReports.SectionReport, ByVal askRuta As Boolean) As Boolean
        Dim bolResultado As Boolean = True
        Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
        Dim sfd As New SaveFileDialog
        Dim sruta As String = ""
        Dim intIntentos As Integer = 0
        Dim bolCorrecto As Boolean = False
        Dim dtEspera As DateTime = Now
        Dim file As System.IO.FileInfo
        Try
            If (askRuta) Then
                With sfd
                    .Title = "Guardar como"
                    .InitialDirectory = "c:"
                    .FileName = nom_rep
                    .DefaultExt = ".pdf"
                    .Filter = "Documento PDF (*.pdf)|*.pdf"
                    .ShowDialog()
                End With
                sruta = sfd.FileName
            Else
                sruta = dicParametros.GetValue("RUTA") & nom_rep
            End If
            Dim fileInfo As New System.IO.FileInfo(sruta)
            Try



                If (Not System.IO.Directory.Exists(fileInfo.DirectoryName)) Then
                    System.IO.Directory.CreateDirectory(fileInfo.DirectoryName)
                End If
                While Not bolCorrecto
                    intIntentos += 1
                    p.Export(rpt.Document, sruta)
                    dtEspera = DateAdd(DateInterval.Second, 2, Now)
                    While (DateDiff(DateInterval.Second, Now, dtEspera) > 0)
                        'LblStatus.Text = "Faltan " & CStr(DateDiff(DateInterval.Second, Now, espera)) & " segs."
                        Application.DoEvents()
                        Application.DoEvents()
                    End While
                    ' verifica que se haya creado el archivo
                    If (System.IO.File.Exists(sruta)) Then
                        file = New System.IO.FileInfo(sruta)
                        If (file.Length > 0) Then
                            bolCorrecto = True
                        End If
                    Else
                        Application.DoEvents()
                        ' p.Refresh()
                        Application.DoEvents()
                        'p.Show()
                        Application.DoEvents()
                    End If
                    If (intIntentos > 10) Then
                        MsgBox("Se ha intentados varias veces generar el archivo, y no se ha podido")
                    End If
                End While

                MyMsgBox("El reporte se exportó correctamente.", MsgBoxStyle.Information, Proyecto)
                WriteLog("Certificado PDF generado " & sruta,, strPathMaestro & "log\work_log" & Format(Now, "yyyyMMdd") & ".log")
                bolResultado = True
            Catch ex As Exception
                bolResultado = False
            End Try
            p.Dispose()
        Catch ex As Exception
            ErrorGenerico(ex.ToString, ex.Message, ex.Source, ex.StackTrace)
            'sendError("funcionesGenerales.exportaPDF" & vbCrLf & _
            '          "ALERTA: " & ex.Message & vbCrLf & "DATOS TECNICOS: " & ex.StackTrace, , , ex)
            If p Is Nothing Then

            Else
                p.Dispose()
            End If
            MyMsgBox(ex.Message, MsgBoxStyle.Critical, Proyecto)
            bolResultado = False
        End Try
        Return bolResultado
    End Function

    ''' <summary>
    ''' Exporta el certificado en formato rtf (para word)
    ''' </summary>
    ''' <param name="nom_rep"></param>
    ''' <param name="rpt"></param>
    ''' <param name="askRuta"></param>
    ''' <returns></returns>
    Public Function ExportaWord(ByVal nom_rep As String, ByVal rpt As GrapeCity.ActiveReports.SectionReport, ByVal askRuta As Boolean) As Boolean
        Dim bolResultado As Boolean = True
        Dim p As New GrapeCity.ActiveReports.Export.Word.Section.RtfExport
        Dim sfd As New SaveFileDialog
        Dim sruta As String = ""
        Try
            If (askRuta) Then
                With sfd
                    .Title = "Guardar como"
                    .InitialDirectory = "c:"
                    .FileName = nom_rep
                    .DefaultExt = ".rtf"
                    .Filter = "Documento RTF (*.rtf)|*.rtf"
                    .ShowDialog()
                End With
                sruta = sfd.FileName
            Else
                sruta = dicParametros.GetValue("RUTA") & nom_rep
            End If
            Dim fileInfo As New System.IO.FileInfo(sruta)
            Try
                If (Not System.IO.Directory.Exists(fileInfo.DirectoryName)) Then
                    System.IO.Directory.CreateDirectory(fileInfo.DirectoryName)
                End If
                p.Export(rpt.Document, sruta)
                WriteLog("Certificado Word generado " & sruta,, strPathMaestro & "log\work_log" & Format(Now, "yyyyMMdd") & ".log")
                MyMsgBox("El reporte se exportó correctamente.", MsgBoxStyle.Information, Proyecto)
                bolResultado = True
            Catch ex As Exception
                bolResultado = False
            End Try
            p.Dispose()
        Catch ex As Exception
            ErrorGenerico(ex.ToString, ex.Message, ex.Source, ex.StackTrace)
            'sendError("funcionesGenerales.exportaPDF" & vbCrLf & _
            '          "ALERTA: " & ex.Message & vbCrLf & "DATOS TECNICOS: " & ex.StackTrace, , , ex)
            If p Is Nothing Then

            Else
                p.Dispose()
            End If
            MyMsgBox(ex.Message, MsgBoxStyle.Critical, Proyecto)
            bolResultado = False
        End Try
        Return bolResultado
    End Function


    'Public Function exportaWord(ByVal nom_rep As String, ByVal rpt As DataDynamics.ActiveReports.ActiveReport) As Boolean

    '    Dim archivoWord As New DataDynamics.ActiveReports.Export.Rtf.RtfExport
    '    Dim sfd As New SaveFileDialog
    '    Try

    '        With sfd
    '            .Title = "Guardar como"
    '            .InitialDirectory = "c:"
    '            .FileName = nom_rep
    '            .DefaultExt = ".doc"
    '            .Filter = "Documento de Word(*.doc)|*.doc"
    '            .ShowDialog()
    '        End With

    '        Dim sruta As String = sfd.FileName

    '        archivoWord.Export(rpt.Document, sruta)
    '        archivoWord.Dispose()
    '        MsgBox("El reporte se exportó correctamente.", MsgBoxStyle.Information, Proyecto)

    '    Catch exportException As DataDynamics.ActiveReports.Export.Rtf.RtfExportException
    '        MsgBox("La exportación no pudo ser completada.", MsgBoxStyle.Information)
    '        'sendError("funcionesGenerales.exportaWord" & vbCrLf & _
    '        '          "ALERTA: " & exportException.Message & vbCrLf & "DATOS TECNICOS: " & exportException.StackTrace, , , exportException)

    '    End Try

    'End Function

    '' <summary>
    '' Esta función no debería de existir. Debe sustituirse por trans (ver SOLDTL)
    '' </summary>
    '' <returns></returns>
    Public Function GetMsgIdioma(ByRef forma As System.Windows.Forms.Form, ByVal mensaje As String, Optional remplazos() As String = Nothing, Optional ByVal idioma As String = "") As String
        ' por defecto, regresa el mismo mensaje
        Return mensaje
    End Function

End Module

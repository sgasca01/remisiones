Imports System.Threading
Imports System.Globalization


' se hace liga a los siguientes dll para que se genere copia local
'C:\Program Files (x86)\IBM\Client Access\IBM.Data.DB2.iSeries.dll
'C:\Program Files (x86)\Common Files\GrapeCity\ActiveReports 6\ActiveReports.Document.dll
'C:\Program Files (x86)\Common Files\GrapeCity\ActiveReports 6\ActiveReports6.dll
'C:\Program Files (x86)\Common Files\GrapeCity\ActiveReports 6\ActiveReports6.dll

' parametros que puede recibir el sistema
' P:[pedido]
' L:[lote]
' A:[Agente]
' S:[quien firma], AP=Alejandro Parra, UV=Uriel Vazquez, GP=Gabriel Posadas
' PRINT:[], imprimir automáticamente. Si no existe, es vista previa
' PREVIEW:[], vista previa
' LOGOS:[], mostrar los logos del encabezado
' PDF:[], generar archivo pdf


Public Class FrmRemisiones

    Dim as400 As New ADO_DB2
    Dim as400temp As New ADO_DB2
    Dim lngRegistros As Long = 0

    ''' <summary>
    ''' Convierte una cadena a fecha-hora
    ''' </summary>
    ''' <param name="cadena"></param>
    ''' <returns></returns>
    Public Function GetDateFromString(ByVal cadena As String) As DateTime
        ' version 20200212
        ' falta validar que la fecha final esté dentro de un rango
        ' falta permitir otros formatos de fecha
        Dim dtFecha As DateTime = New System.DateTime(1900, 1, 1, 0, 0, 0)
        Dim arrFechaHora() As String = Nothing
        Dim arrFecha() As String = Nothing
        Dim arrHora() As String = Nothing
        Dim intI As Integer = 0
        Dim bolValido As Boolean = True
        cadena = cadena.ToUpper.Trim
        arrFechaHora = Split(cadena & " 0", " ") ' separa en fecha, hora, etc
        arrFecha = Split(arrFechaHora(0), "/")
        If (arrFecha.Length < 3) Then
            arrFecha = Split(arrFechaHora(0) & "-0-0-0", "-")
        End If
        arrHora = Split(arrFechaHora(1) & ":0:0:0", ":")
        If (arrFecha.Length < 3) Then
            bolValido = False
        End If
        If (bolValido) Then
            Try
                dtFecha = New System.DateTime(arrFecha(2), arrFecha(1), arrFecha(0), arrHora(0), arrHora(1), arrHora(2))
            Catch ex As Exception
                dtFecha = New System.DateTime(1900, 1, 1, 0, 0, 0)
            End Try
        End If
        Return dtFecha
    End Function

    ''' <summary>
    ''' Indica cuantos procesos existen con el nombre y los parámetros dados
    ''' </summary>
    ''' <param name="proceso">Nombre del proceso, sin incluir .exe</param>
    ''' <param name="parametros">Lista de parámetros, en el case necesario</param>
    ''' <returns></returns>
    Public Function AskProceso(ByVal proceso As String, ByVal parametros() As String, Optional ByVal caseExacto As Boolean = False) As Integer
        Dim intResultado As Integer = 0
        Dim bolInterno As Boolean = True
        Dim strComando As String = ""
        Dim strParametro As String = ""
        Dim strEjecutable As String = ""
        Dim arrParametros() As String = Nothing
        Dim intI As Integer = 0

        Dim algo As String = ""
        'Dim currentProcess As Process = Process.GetCurrentProcess()
        'Dim instancesProcess() As Process = Process.GetProcessesByName(proceso)
        Dim searcher As New System.Management.ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_Process WHERE Name='" & proceso & ".exe'")
        For Each p As System.Management.ManagementObject In searcher.[Get]()
            'https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-process
            'Dim commandLine As String = p("CommandLine")
            'Dim ExecutablePath As String = p("ExecutablePath")
            'Dim Handle As String = p("Handle")
            'Dim Name As String = p("Name")
            'Dim OSName As String = p("OSName")
            'Dim parametro As String = commandLine.Substring(ExecutablePath.Length + 2)
            strComando = p("CommandLine")
            strEjecutable = p("ExecutablePath")
            strParametro = strComando.Substring(strEjecutable.Length + 2)
            strParametro = Replace(strParametro, """", "")
            ' ajusta los parametros al case y elimina espacios
            If (caseExacto) Then
                arrParametros = Split(strParametro.Trim, " ")
            Else
                arrParametros = Split(strParametro.Trim.ToUpper, " ")
            End If
            ' ajusta la lista de parametros de referencia y elimina espacios
            For intI = 0 To parametros.Length - 1
                If (caseExacto) Then
                    parametros(intI) = parametros(intI).Trim
                Else
                    parametros(intI) = parametros(intI).Trim.ToUpper
                End If
            Next
            ' hace la comparación de parametros actuales contra los de referencia
            If (parametros.Length <= arrParametros.Length) Then
                bolInterno = True
                For intI = 0 To parametros.Length - 1
                    If (parametros(intI) <> arrParametros(intI)) Then
                        bolInterno = False
                    End If
                Next
                ' si coincidieron los parámetros, incrementa el contador
                If (bolInterno) Then
                    intResultado += 1
                End If
            End If
        Next
        Return intResultado
    End Function


    Private Sub FrmCertificados_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ' 12042021 - variable luctaApp debe estar en false si es para remisiones automáticas y en true para manuales 
        Dim luctaApp As Boolean = True

        Dim lineParameters As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
        Dim strTemp As String = ""
        Dim arrTemp() As String = Nothing
        Dim strParametro1 As String = ""
        Dim strParametro2 As String = ""
        Dim strParametro3 As String = ""
        Dim strQuery As String = ""
        Dim intTimeOut As Integer = 0
        Dim intI As Integer = 0

        Dim strRuta As String = "C:\VisualStudio\Visual Studio 2017\Projects\Lumina\SameCarga\bin\x86\Debug\"
        Dim intRespuesta As Integer = 0

        LblAvance.Text = ""
        LblProceso.Text = "Remisiones"
        Me.Text = LblProceso.Text
        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es-MX") 'New CultureInfo("en-US")

        CleanSesion()

        If (Sesion.Aplicacion = "") Then Sesion.Aplicacion = "TOOLS"
        If (Sesion.Proyecto = "") Then Sesion.Proyecto = "Aplicación Tools"
        WhereIAm()
        WhereIAm(SiglasPaises.Mexico)

        'Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
        Sesion.LibLoc = Sesion.LibMx
        LblProceso.Text = ""

        lineParameters = My.Application.CommandLineArgs
        If (Sesion.Log) Then ' se guarda la linea de parametros en el log
            strTemp = ""
            For intI = 0 To lineParameters.Count - 1
                strTemp &= CStr(intI) & "->" & lineParameters(intI) & " "
            Next
            If (strTemp = "") Then
                strTemp = "No hay parametros"
            End If
        End If
        as400.ConnectionString = as400.GetConnectionString(AppSettings("ReadUserMX", True), AppSettings("ReadPasswordMX", True), AppSettings("ServerMX"))
        as400temp.ConnectionString = as400.ConnectionString
        strImpresora = GetLocalSetting("impresora")
        Me.Hide()
        Me.Visible = False

        'If (GetRunningInstances() > 1) Then
        'strTemp = ""
        'End If

        Sesion.Usuario = NamedPipe.SendMessage("APP|" & Sesion.Aplicacion & "|SESION|USUARIO").ToUpper
        If (Sesion.Usuario.StartsWith("NO ESTÁ ACTIVO LUCTAWIN")) Then
            MsgBox("No está activa La sesion, volver a ingresar las credenciales de usuario.", 0, "Remisiones")
            Me.Close()
            Application.Exit()
            End
        Else
            Sesion.Password = NamedPipe.SendMessage("APP|" & Sesion.Aplicacion & "|SESION|PASSWORD")
            Sesion.Area = NamedPipe.SendMessage("APP|" & Sesion.Aplicacion & "|SESION|AREA")
            Sesion.Nombre = NamedPipe.SendMessage("APP|" & Sesion.Aplicacion & "|SESION|NOMBRE")
            Sesion.Correo = NamedPipe.SendMessage("APP|" & Sesion.Aplicacion & "|SESION|MAIL")
            Try
                Sesion.Nivel = CInt(NamedPipe.SendMessage("APP|" & Sesion.Aplicacion & "|SESION|NIVEL"))
            Catch ex As System.Exception
                Sesion.Nivel = 0
            End Try
            FrmCapturaManualRemision.ShowDialog()
        End If

        'If (NamedPipe.SendMessage("GET|SESION|USUARIO").StartsWith("No está activo LuctaWin")) Then
        '    MsgBox("No está activa La sesion, volver a ingresar las credenciales de usuario.", 0, "Remisiones")
        '    Me.Close()
        '    Application.Exit()
        '    End
        'Else
        '    FrmCapturaManualRemision.ShowDialog()
        'End If

        'If (luctaApp) Then
        ''dicParametros.Remove("A") ' para que permita cualquier tipo de resultado de análisis, no solo CC
        'FrmCapturaManualRemision.ShowDialog()
        'Exit Sub
        'End If
        Button1.Visible = True
        intTimeOut = 0
        End
    End Sub

    Public Class InformacionCertificado
        Public Property pedido As String
        Public Property lote As String
        Public Property errorInfo As String
        Public Property codCliente As String
        Public Property descCliente As String
        Public Property codArticulo As String
        Public Property descArticulo As String
        Public Property divicion As String
    End Class

    Public Sub EnviarCorreos(ByVal mensaje As String)

        Dim lngRegistros As Long = 0
        Dim strQuery As String = ""
        Dim strAsunto As String = "Aviso de Certificado no impreso"
        'Dim duracion As New TiempoEspera
        Dim notificador As String = "notificaciones"
        Dim pass As String = "Pers0nal01$"
        modCorreoOutlook.UsuarioRemitente = notificador & "@lucta.com"
        modCorreoOutlook.PasswordRemitente = pass
        modCorreoOutlook.CopiasOcultas = "sgasca@lucta.com"

        modCorreoOutlook.Firma = " "
        ' obtiene los CORREOS A ENVIAR 
        strQuery = "SELECT * FROM LUCmFILE.APPMAIL WHERE SOLUCI = 'CERTIFICADOS'"
        as400.Open(strQuery)

        While Not as400.EOF

            modCorreoOutlook.Asunto = strAsunto
            ' aqui irían los reemplazos del mensaje para personalizarlo
            modCorreoOutlook.Cuerpo = mensaje
            modCorreoOutlook.Destinatarios = as400.StrCampo("MAIL")
            modCorreoOutlook.envioOutlook("", "", "", "", "", "", "", notificador)

            as400.MoveNext()
        End While
    End Sub

    ''' <summary>
    ''' Termina la ejecución de la aplicación
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CmdSalir_Click(sender As System.Object, e As System.EventArgs) Handles CmdSalir.Click
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        FrmCapturaManualRemision.Show()
    End Sub
End Class
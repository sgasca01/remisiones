''' <summary>
''' El primero (X) se le conoce como versión mayor y nos indica la versión principal del software. Ejemplo: 1.0.0, 3.0.0
''' El segundo(Y) se le conoce como versión menor y nos indica nuevas funcionalidades. Ejemplo: 1.2.0, 3.3.0
''' El tercero(Z) se le conoce como revisión y nos indica que se hizo una revisión del código por algun fallo. Ejemplo: 1.2.2, 3.3.4
''' </summary>

Public Class FrmCapturaManualRemision
    Private Sub FrmCapturaManualCertificado_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'End
    End Sub

    Private Sub FrmCapturaManualCertificado_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'End
        FrmRemisiones.CmdSalir.Visible = True
    End Sub

    'parametros de prueba: manual pdf
    Private Sub FrmCapturaManual_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        CtPedido.Text = ""
        CcResultado.Text = ""
        ChkBox.Items.Clear()
        ChkCodigosCliente.Visible = False
        ChkTodos.Visible = False
        ChkRotatorio.Visible = False
        ChkWord.Visible = False
        ChkPdf.Visible = False
        ctSello.Text = ""
        ChkLogos.Visible = False
        CtPedido.Text = ""
        CcIdioma.Visible = False
        CtLote.Visible = False
        CtLote.Text = ""
        CtFactura.Visible = False
        CtFactura.Text = ""
        CmdGenerar.Visible = False
        CcIdioma.Carga({"ES", "EN"})
        CcResultado.Visible = True
        'CcResultado.Text = "Dirección"
        CcResultado.Carga({"", "Mismo Domicilio", "Recoger en planta"})
        'CcResultado.Text = "Todos"
        CmdGenerar.Visible = True
        CmdGenerar.Enabled = False

        'control de cambios en forma manual
        ' Versión mayor: 1  
        ' versión menor: 0  
        ' revisión: 0 - 
        lbError.Visible = False
        lbError.Text = "1.0.0"
        Me.Text = "Remisiones - Versión: " + lbError.Text

        CtPedido.Focus()

    End Sub

    Private Sub CmdGenerar_Click(sender As System.Object, e As System.EventArgs) Handles CmdGenerar.Click
        Dim strPedido As String = ""
        Dim strLote As String = ""
        Dim arrDatos() As String = Nothing
        Dim intI As Integer = 0
        Dim strTemp As String = ""
        For intI = 0 To ChkBox.Items.Count - 1
            If (ChkBox.GetItemChecked(intI)) Then
                strTemp = ChkBox.Items(intI).ToString
                arrDatos = Split(strTemp, " - ")
                ProcesarRemisiones(arrDatos(0), arrDatos(1), arrDatos(3), CcResultado.Text, ctSello.Text)
            End If
        Next
        CtPedido.Text = ""
        CcResultado.Text = ""
        ctSello.Text = ""
        ChkBox.Items.Clear()
        chkLote.Checked = False
        FrmRemisiones.Button1.Visible = True
        MsgBox("Se terminó la generación de remisiones", MsgBoxStyle.Information, "LUCTA")
    End Sub

    Public Sub ProcesarRemisiones(ByVal pedido As String, ByVal referencia As String, ByVal fecha As String, ByVal resultado As String, ByVal sello As String)

        dicParametros.Clear()
        dicParametros.Add("P", pedido.Trim.ToUpper)
        dicParametros.Add("R", referencia.Trim.ToUpper)
        dicParametros.Add("F", fecha.Trim.ToUpper)
        dicParametros.Add("L", resultado.Trim)
        dicParametros.Add("S", sello.Trim)
        dicParametros.Add("PREVIEW", "")
        'If (ChkLogos.Checked) Then ' incluir logotipos (banner)
        '    dicParametros.Add("LOGOS", "")
        'Else
        '    dicParametros.Remove("LOGOS") ' si explicitamente no se quieren los logos, se quitan
        'End If
        'If (ChkPdf.Checked) Then ' generación de archivo pdf
        '    dicParametros.Add("PDF", "")
        'Else
        '    dicParametros.Remove("PDF")
        'End If
        'If (ChkWord.Checked) Then ' generación de achivo word
        '    dicParametros.Add("WORD", "")
        'Else
        '    dicParametros.Remove("WORD")
        'End If
        'If (ChkRotatorio.Checked) Then ' incluir conceptos rotatorios
        '    dicParametros.Add("ROTATORIO", "")
        'Else
        '    dicParametros.Remove("ROTATORIO")
        'End If
        Me.Hide()
        FrmRemisiones.Show()
        FrmRemisiones.LblProceso.Text = "Generando Remisión." 'Trans(Me, "msgProceso", {dicParametros.GetValue("P"), dicParametros.GetValue("L")})
        FrmRemisiones.LblAvance.Text = "Llenando Remisión"
        Application.DoEvents()
        FillRemisiones(ChkTodos.Checked, chkLote.Checked, resultado)
        FrmRemisiones.Hide()
    End Sub

    Private Sub CmdSalir_Click(sender As System.Object, e As System.EventArgs) Handles CmdSalir.Click
        End
    End Sub

    Private Sub CmdImpresora_Click(sender As Object, e As EventArgs) Handles CmSeleccionarImpresora.Click
        frmSeleccionarImpresora.Show()
    End Sub

    Private Sub CmEspanol_Click(sender As Object, e As EventArgs) Handles CmEspanol.Click
        'CambiaIdioma("es-MX")
    End Sub

    Private Sub CmIngles_Click(sender As Object, e As EventArgs) Handles CmIngles.Click
        ' CambiaIdioma("en-US")
    End Sub

    Private Sub CmCatalan_Click(sender As Object, e As EventArgs) Handles CmCatalan.Click
        ' CambiaIdioma("ca-ES")
    End Sub

    Private Sub CmSeleccionarImpresora_Click(sender As Object, e As EventArgs) Handles CmSeleccionarImpresora.Click
        frmSeleccionarImpresora.Show()
    End Sub

    Private Sub CmAcercaDe_Click(sender As Object, e As EventArgs) Handles CmAcercaDe.Click
        MyMsgBox(Sesion.IPAddress & "/" & Sesion.EnvironmentMachineName & vbCrLf &
               Sesion.EnvironmentUserDomainName & "/" & Sesion.EnvironmentUserName & vbCrLf &
               NombreAplicacion & IIf(Sesion.Is64BitOperatingSystem, " 64 bits ", " 32 bits ") & System.Globalization.CultureInfo.CurrentCulture.Name & vbCrLf &
               FechaCompilacion, MsgBoxStyle.Information, "Lucta")
    End Sub


    Private Sub CtPedido_LostFocus(sender As Object, e As EventArgs) Handles CtPedido.LostFocus
        'Actualizar()
    End Sub

    Public Sub CargaLotes(ByVal pedido As String, ByVal estatus As String, ByVal sello As String)
        Dim as400 As New ADO_DB2
        Dim strQuery As String = ""
        Dim strTemp As String = ""
        Dim Remision As Boolean = False
        ChkBox.Items.Clear()
        strQuery = "select * from lucfile.pc where pcdepo='X' and pcnume = " & pedido
        as400.Open(strQuery)
        If (as400.RecordCount > 0) Then
            strTemp = as400.StrCampo("pcnume") & " - " &
                as400.StrCampo("pcrefc") & " - " &
                as400.StrCampo("pcreci") & " - " &
                as400.StrCampo("pcdipr") & "/" &
                as400.StrCampo("pcmepr") & "/" &
                as400.StrCampo("pcañop")

            If (CcResultado.Text = "Mismo Domicilio" And as400.StrCampo("PCCOCL") = "1225") Then
                lbError.Visible = True
                lbError.Text = "El pedido es inválido"
                Exit Sub
            ElseIf (as400.StrCampo("PCSITP") <> "S") Then
                MyMsgBox("El pedido no ha sido surtido.", MsgBoxStyle.Critical, "Lucta")
                CmdGenerar.Enabled = False
            Else
                ChkBox.Items.Add(strTemp)
                ChkBox.SetItemChecked(0, True)
                'as400.MoveNext()
                Remision = True
            End If
        Else
            Remision = False
        End If

        If Remision = False Then
            MyMsgBox("El pedido no es remisión.", MsgBoxStyle.Critical, "Lucta")
            CmdGenerar.Enabled = False
        Else
            CmdGenerar.Enabled = True
            CmdGenerar.Focus()
        End If

    End Sub

    Private Sub ChkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTodos.CheckedChanged
        Dim intI As Integer = 0
        For intI = 0 To ChkBox.Items.Count - 1
            ChkBox.SetItemChecked(intI, ChkTodos.Checked)
        Next
        CmdGenerar.Enabled = True
    End Sub

    Private Sub CmdActualizar_Click(sender As Object, e As EventArgs) Handles CmdActualizar.Click
        CmdGenerar.Enabled = True
        Actualizar()
    End Sub

    Public Sub Actualizar()
        If (CtPedido.Text = "") Then
            MyMsgBox("El campo PEDIDO debe tener un valor ingresado", MsgBoxStyle.Critical, "Lucta")
        ElseIf (CcResultado.Text = "") Then
            MyMsgBox("El campo ENTREGA debe tener un valor seleccionado", MsgBoxStyle.Critical, "Lucta")
        ElseIf (ctSello.Text = "") Then
            MyMsgBox("El campo SELLO debe tener un valor ingresado", MsgBoxStyle.Critical, "Lucta")
        ElseIf (CcResultado.Text = "" And CtPedido.Text = "" And ctSello.Text = "") Then
            MyMsgBox("Los campos PEDIDO, ENTREGA y SELLO deben tener valores", MsgBoxStyle.Critical, "Lucta")
        Else
            If (EsEnteroPositivo(CtPedido.Text)) Then
                CargaLotes(CtPedido.Text, CcResultado.Text, ctSello.Text)
                CmdGenerar.Visible = True
            End If
        End If
    End Sub
End Class

Public Class frmSeleccionarImpresora

    'Private Sub SetMsg()
    '    ' ayuda=ajuda, herramientas=eines, cerrar=tanca, ver=consulta
    '    Toolkit.Location.setMsg(Me, cultura.esMX, "$this", "Seleccionar impresora")
    '    Toolkit.Location.setMsg(Me, cultura.esMX, "CcImpresoras", "Impresoras")
    '    Toolkit.Location.setMsg(Me, cultura.esMX, "CmdAceptar", "Aceptar")
    '    Toolkit.Location.setMsg(Me, cultura.esMX, "CmdCancelar", "Cancelar")

    '    Toolkit.Location.setMsg(Me, cultura.enUS, "$this", "Select printer")
    '    Toolkit.Location.setMsg(Me, cultura.enUS, "CcImpresoras", "Printers")
    '    Toolkit.Location.setMsg(Me, cultura.enUS, "CmdAceptar", "Accept")
    '    Toolkit.Location.setMsg(Me, cultura.enUS, "CmdCancelar", "Cancel")

    '    Toolkit.Location.setMsg(Me, cultura.caES, "$this", "Seleccionar impressora")
    '    Toolkit.Location.setMsg(Me, cultura.caES, "CcImpresoras", "Impressores")
    '    Toolkit.Location.setMsg(Me, cultura.caES, "CmdAceptar", "Acceptar")
    '    Toolkit.Location.setMsg(Me, cultura.caES, "CmdCancelar", "Cancel·lar")
    'End Sub

    Private Sub frmSeleccionarImpresora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' SetMsg()
        'CambiaIdioma()
        CcImpresoras.Carga(getInstalledPrinters)
        If (getInstalledPrinters.Contains(strImpresora)) Then CcImpresoras.Text = strImpresora
    End Sub

    Private Sub CmdAceptar_Click(sender As Object, e As EventArgs) Handles CmdAceptar.Click
        strImpresora = CcImpresoras.Text
        SetLocalSetting("impresora", strImpresora)
        Me.Close()
    End Sub

    Private Sub CmdCancelar_Click(sender As Object, e As EventArgs) Handles CmdCancelar.Click
        Me.Close()
    End Sub

End Class
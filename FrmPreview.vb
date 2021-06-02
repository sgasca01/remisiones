Public Class FrmPreview

    Private _BlnCloseOnExit As Boolean = True
    Private _BlnProcesando As Boolean = True

    ''' <summary>
    ''' Obtiene o establece la impresora por defecto que se utilizará.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Impresora As String
        Get
            Impresora = Viewer.Document.Printer.PrinterName
        End Get
        Set(value As String)
            Viewer.Document.Printer.PrinterName = value
        End Set
    End Property

    ''' <summary>
    ''' Imprime el visor en la impresora asignada
    ''' </summary>
    Public Sub Print()
        Application.DoEvents()
        ' espera a que termine o que pasen 10 segundos
        Dim TimeOut As Date = DateAdd("s", 3, Now)
        While (DateDiff("s", TimeOut, Now) < 0) And (_BlnProcesando)
            Application.DoEvents()
            Application.DoEvents()
        End While
        TimeOut = Now
        Viewer.Print(False, False, False)
        If (_BlnCloseOnExit) Then
            'TimeOut = DateAdd("s", 2, Now) ' espera 3 segundos para cerrar
            'Application.DoEvents()
            'While (DateDiff("s", TimeOut, Now) < 0)
            '    Application.DoEvents()
            '    Application.DoEvents()
            '    Application.DoEvents()
            'End While
            'TimeOut = Now
            'End
            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' Obtiene o establece la bandera que indica si al cerrar la ventana se cierra la aplicación.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CloseOnExit As Boolean
        Get
            CloseOnExit = _BlnCloseOnExit
        End Get
        Set(value As Boolean)
            _BlnCloseOnExit = value
        End Set
    End Property

    Private Sub FrmPreview_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If (CloseOnExit) Then End ' termina el programa al cerrar la vista previa
    End Sub

    Private Sub FrmPreview_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Viewer.Top = 0
        Viewer.Left = 0
        Me.Width = 920 '440
        Me.Height = 680
        _BlnProcesando = True
        Me.Text = "Remisiones"
        ' Viewer.Document.Printer.PrinterName = ""
    End Sub

    Private Sub FrmPreview_SizeChanged(sender As Object, e As System.EventArgs) Handles Me.SizeChanged
        Viewer.Height = Me.Height
        Viewer.Width = Me.Width
    End Sub

    Private Sub Viewer_LoadCompleted(sender As Object, e As EventArgs) Handles Viewer.LoadCompleted
        Dim strTemp As String = ""
        _BlnProcesando = False
    End Sub

End Class
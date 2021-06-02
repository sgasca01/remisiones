Public Class FrmMsgBox

    Dim intContador As Integer = 5
    Dim strMensaje As String = ""

    ''' <summary>
    ''' Obtiene o establece el mensaje de la forma
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Mensaje As String
        Get
            Mensaje = strMensaje
        End Get
        Set(value As String)
            strMensaje = value
            LblMensaje.Text = strMensaje
            Application.DoEvents()
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el número de segundos que permanecerá abierta la forma
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Tiempo As Integer
        Get
            Tiempo = intContador
        End Get
        Set(value As Integer)
            If (value >= 0) And (value < 300) Then
                intContador = value
            Else
                intContador = 5
            End If
            LblTiempo.Text = CStr(intContador)
            Application.DoEvents()
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el título de la forma
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Titulo As String
        Get
            Titulo = Me.Text
        End Get
        Set(value As String)
            Me.Text = value
            Application.DoEvents()
        End Set
    End Property

    Private Sub FrmMsgBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        intContador = 15
        TimerCerrar.Enabled = True
        LblTiempo.Text = CStr(intContador)
        LblMensaje.Text = strMensaje
    End Sub

    Private Sub TimerCerrar_Tick(sender As Object, e As EventArgs) Handles TimerCerrar.Tick
        intContador -= 1
        If (intContador < 0) Then
            TimerCerrar.Enabled = False
            Me.Close()
        End If
        LblTiempo.Text = CStr(intContador)
        Application.DoEvents()
    End Sub

    Private Sub CmdOk_Click(sender As Object, e As EventArgs) Handles CmdOk.Click
        Me.Tiempo = 0
    End Sub

End Class
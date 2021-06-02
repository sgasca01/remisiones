<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMsgBox
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMsgBox))
        Me.LblMensaje = New System.Windows.Forms.Label()
        Me.CmdOk = New System.Windows.Forms.Button()
        Me.LblTiempo = New System.Windows.Forms.Label()
        Me.TimerCerrar = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'LblMensaje
        '
        Me.LblMensaje.AutoSize = True
        Me.LblMensaje.Location = New System.Drawing.Point(21, 17)
        Me.LblMensaje.Name = "LblMensaje"
        Me.LblMensaje.Size = New System.Drawing.Size(61, 13)
        Me.LblMensaje.TabIndex = 0
        Me.LblMensaje.Text = "LblMensaje"
        '
        'CmdOk
        '
        Me.CmdOk.Location = New System.Drawing.Point(178, 98)
        Me.CmdOk.Name = "CmdOk"
        Me.CmdOk.Size = New System.Drawing.Size(103, 42)
        Me.CmdOk.TabIndex = 1
        Me.CmdOk.Text = "Ok"
        Me.CmdOk.UseVisualStyleBackColor = True
        '
        'LblTiempo
        '
        Me.LblTiempo.AutoSize = True
        Me.LblTiempo.Location = New System.Drawing.Point(3, 158)
        Me.LblTiempo.Name = "LblTiempo"
        Me.LblTiempo.Size = New System.Drawing.Size(56, 13)
        Me.LblTiempo.TabIndex = 2
        Me.LblTiempo.Text = "LblTiempo"
        '
        'TimerCerrar
        '
        Me.TimerCerrar.Interval = 1000
        '
        'FrmMsgBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(293, 180)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblTiempo)
        Me.Controls.Add(Me.CmdOk)
        Me.Controls.Add(Me.LblMensaje)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMsgBox"
        Me.Text = "frmMsgBox"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblMensaje As System.Windows.Forms.Label
    Friend WithEvents CmdOk As System.Windows.Forms.Button
    Friend WithEvents LblTiempo As System.Windows.Forms.Label
    Friend WithEvents TimerCerrar As System.Windows.Forms.Timer
End Class

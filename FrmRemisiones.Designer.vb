<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRemisiones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRemisiones))
        Me.CmdSalir = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LblProceso = New System.Windows.Forms.Label()
        Me.LblAvance = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CmdSalir
        '
        Me.CmdSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CmdSalir.Location = New System.Drawing.Point(164, 116)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(143, 29)
        Me.CmdSalir.TabIndex = 0
        Me.CmdSalir.Text = "Salir de la aplicación"
        Me.CmdSalir.UseVisualStyleBackColor = True
        Me.CmdSalir.Visible = False
        '
        'LblProceso
        '
        Me.LblProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.LblProceso.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblProceso.Location = New System.Drawing.Point(12, 9)
        Me.LblProceso.Name = "LblProceso"
        Me.LblProceso.Size = New System.Drawing.Size(295, 92)
        Me.LblProceso.TabIndex = 1
        Me.LblProceso.Text = "LblProceso"
        Me.LblProceso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblAvance
        '
        Me.LblAvance.AutoSize = True
        Me.LblAvance.Location = New System.Drawing.Point(2, 151)
        Me.LblAvance.Name = "LblAvance"
        Me.LblAvance.Size = New System.Drawing.Size(58, 13)
        Me.LblAvance.TabIndex = 2
        Me.LblAvance.Text = "LblAvance"
        '
        'Button1
        '
        Me.Button1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1.Location = New System.Drawing.Point(16, 116)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(143, 29)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Regresar a la aplicación"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'FrmRemisiones
        '
        Me.AcceptButton = Me.CmdSalir
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(319, 170)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LblAvance)
        Me.Controls.Add(Me.LblProceso)
        Me.Controls.Add(Me.CmdSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRemisiones"
        Me.Text = "Certificados de Calidad"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents LblProceso As System.Windows.Forms.Label
    Friend WithEvents LblAvance As System.Windows.Forms.Label
    Friend WithEvents Button1 As Button
End Class

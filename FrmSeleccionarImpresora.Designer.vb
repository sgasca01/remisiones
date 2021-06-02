<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionarImpresora
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeleccionarImpresora))
        Me.CcImpresoras = New Toolkit.ControlCombo()
        Me.CmdAceptar = New System.Windows.Forms.Button()
        Me.CmdCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CcImpresoras
        '
        Me.CcImpresoras.AlinearCentrado = False
        Me.CcImpresoras.Autoajustar = True
        Me.CcImpresoras.Caption = "Impresoras"
        Me.CcImpresoras.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.CcImpresoras.CaptionFont = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.CcImpresoras.CaptionFontColor = System.Drawing.SystemColors.ControlText
        Me.CcImpresoras.CaptionFontName = "Segoe UI"
        Me.CcImpresoras.CaptionFontSize = 8.0!
        Me.CcImpresoras.CaptionPad = 3
        Me.CcImpresoras.CaptionPosition = Toolkit.Posicion.IzquierdaArriba
        Me.CcImpresoras.CaptionText = "Impresoras"
        Me.CcImpresoras.Culture = "es-MX"
        Me.CcImpresoras.Highlight = False
        Me.CcImpresoras.HighlightBackgroundColor = System.Drawing.Color.OrangeRed
        Me.CcImpresoras.LeftCenterPosition = 0
        Me.CcImpresoras.Location = New System.Drawing.Point(12, 12)
        Me.CcImpresoras.Name = "CcImpresoras"
        Me.CcImpresoras.Size = New System.Drawing.Size(472, 27)
        Me.CcImpresoras.TabIndex = 0
        Me.CcImpresoras.Tag = ""
        Me.CcImpresoras.TextBackColor = System.Drawing.SystemColors.Window
        Me.CcImpresoras.TextContentSize = 50
        Me.CcImpresoras.TextDefaultFontColor = System.Drawing.Color.Empty
        Me.CcImpresoras.TextFont = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.CcImpresoras.TextFontColor = System.Drawing.SystemColors.WindowText
        Me.CcImpresoras.TextFontName = "Segoe UI"
        Me.CcImpresoras.TextFontSize = 8.0!
        Me.CcImpresoras.TextHeight = 21
        Me.CcImpresoras.TextWidth = 400
        Me.CcImpresoras.TopCenterPosition = 0
        Me.CcImpresoras.WarningBackgroundColor = System.Drawing.Color.Yellow
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Location = New System.Drawing.Point(276, 56)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(80, 27)
        Me.CmdAceptar.TabIndex = 1
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Location = New System.Drawing.Point(404, 56)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(80, 27)
        Me.CmdCancelar.TabIndex = 2
        Me.CmdCancelar.Text = "Cancelar"
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'frmSeleccionarImpresora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 107)
        Me.Controls.Add(Me.CmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.CcImpresoras)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSeleccionarImpresora"
        Me.Text = "Seleccionar Impresora"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CcImpresoras As Toolkit.ControlCombo
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
End Class

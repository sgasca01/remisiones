<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCapturaManualRemision
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCapturaManualRemision))
        Me.CmdGenerar = New System.Windows.Forms.Button()
        Me.CmdSalir = New System.Windows.Forms.Button()
        Me.ChkLogos = New System.Windows.Forms.CheckBox()
        Me.CtLote = New Toolkit.ControlText()
        Me.CtPedido = New Toolkit.ControlText()
        Me.ContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CmEspanol = New System.Windows.Forms.ToolStripMenuItem()
        Me.CmIngles = New System.Windows.Forms.ToolStripMenuItem()
        Me.CmCatalan = New System.Windows.Forms.ToolStripMenuItem()
        Me.CmSeleccionarImpresora = New System.Windows.Forms.ToolStripMenuItem()
        Me.CmAcercaDe = New System.Windows.Forms.ToolStripMenuItem()
        Me.CcIdioma = New Toolkit.ControlCombo()
        Me.ChkPdf = New System.Windows.Forms.CheckBox()
        Me.ChkWord = New System.Windows.Forms.CheckBox()
        Me.ChkBox = New System.Windows.Forms.CheckedListBox()
        Me.CtFactura = New Toolkit.ControlText()
        Me.ChkTodos = New System.Windows.Forms.CheckBox()
        Me.CcResultado = New Toolkit.ControlCombo()
        Me.CmdActualizar = New System.Windows.Forms.Button()
        Me.ChkRotatorio = New System.Windows.Forms.CheckBox()
        Me.ChkCodigosCliente = New System.Windows.Forms.CheckBox()
        Me.lbError = New System.Windows.Forms.Label()
        Me.chkLote = New System.Windows.Forms.CheckBox()
        Me.ctSello = New Toolkit.ControlText()
        Me.ContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmdGenerar
        '
        Me.CmdGenerar.Location = New System.Drawing.Point(185, 295)
        Me.CmdGenerar.Name = "CmdGenerar"
        Me.CmdGenerar.Size = New System.Drawing.Size(100, 41)
        Me.CmdGenerar.TabIndex = 5
        Me.CmdGenerar.Text = "Procesar"
        Me.CmdGenerar.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Location = New System.Drawing.Point(317, 295)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(84, 41)
        Me.CmdSalir.TabIndex = 6
        Me.CmdSalir.Text = "Salir"
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'ChkLogos
        '
        Me.ChkLogos.AutoSize = True
        Me.ChkLogos.Checked = True
        Me.ChkLogos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkLogos.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkLogos.Location = New System.Drawing.Point(689, 61)
        Me.ChkLogos.Name = "ChkLogos"
        Me.ChkLogos.Size = New System.Drawing.Size(111, 17)
        Me.ChkLogos.TabIndex = 2
        Me.ChkLogos.Text = "Incluir logotipos"
        Me.ChkLogos.UseVisualStyleBackColor = True
        '
        'CtLote
        '
        Me.CtLote.AlinearCentrado = True
        Me.CtLote.Autoajustar = True
        Me.CtLote.Caption = "Lote"
        Me.CtLote.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.CtLote.CaptionFont = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.CtLote.CaptionFontColor = System.Drawing.SystemColors.ControlText
        Me.CtLote.CaptionFontName = "Segoe UI"
        Me.CtLote.CaptionFontSize = 8.0!
        Me.CtLote.CaptionPad = 3
        Me.CtLote.CaptionPosition = Toolkit.Posicion.IzquierdaArriba
        Me.CtLote.CaptionText = "Lote"
        Me.CtLote.Culture = "es-MX"
        Me.CtLote.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CtLote.Highlight = False
        Me.CtLote.HighlightBackgroundColor = System.Drawing.Color.OrangeRed
        Me.CtLote.LeftCenterPosition = 60
        Me.CtLote.Location = New System.Drawing.Point(670, 10)
        Me.CtLote.Margin = New System.Windows.Forms.Padding(0)
        Me.CtLote.MaxValue = 1.7976931348623157E+308R
        Me.CtLote.MinValue = -1.7976931348623157E+308R
        Me.CtLote.Name = "CtLote"
        Me.CtLote.Size = New System.Drawing.Size(143, 28)
        Me.CtLote.TabIndex = 1
        Me.CtLote.Tag = ""
        Me.CtLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.CtLote.TextBackColor = System.Drawing.SystemColors.Window
        Me.CtLote.TextContentSize = 50
        Me.CtLote.TextContentType = Toolkit.Validaciones.TextBoxTipo.Alfanumerico
        Me.CtLote.TextDefaultFontColor = System.Drawing.Color.Empty
        Me.CtLote.TextFont = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.CtLote.TextFontColor = System.Drawing.SystemColors.WindowText
        Me.CtLote.TextFontName = "Segoe UI"
        Me.CtLote.TextFontSize = 8.0!
        Me.CtLote.TextHeight = 22
        Me.CtLote.TextMultiline = False
        Me.CtLote.TextPasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.CtLote.TextReadOnly = False
        Me.CtLote.TextScrollBars = System.Windows.Forms.ScrollBars.None
        Me.CtLote.TextWidth = 80
        Me.CtLote.TopCenterPosition = 0
        Me.CtLote.WarningBackgroundColor = System.Drawing.Color.Yellow
        '
        'CtPedido
        '
        Me.CtPedido.AlinearCentrado = True
        Me.CtPedido.Autoajustar = True
        Me.CtPedido.Caption = "Pedido"
        Me.CtPedido.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.CtPedido.CaptionFont = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.CtPedido.CaptionFontColor = System.Drawing.SystemColors.ControlText
        Me.CtPedido.CaptionFontName = "Segoe UI"
        Me.CtPedido.CaptionFontSize = 8.0!
        Me.CtPedido.CaptionPad = 3
        Me.CtPedido.CaptionPosition = Toolkit.Posicion.IzquierdaArriba
        Me.CtPedido.CaptionText = "Pedido"
        Me.CtPedido.Culture = "es-MX"
        Me.CtPedido.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CtPedido.Highlight = False
        Me.CtPedido.HighlightBackgroundColor = System.Drawing.Color.OrangeRed
        Me.CtPedido.LeftCenterPosition = 60
        Me.CtPedido.Location = New System.Drawing.Point(9, 14)
        Me.CtPedido.Margin = New System.Windows.Forms.Padding(0)
        Me.CtPedido.MaxValue = 1.7976931348623157E+308R
        Me.CtPedido.MinValue = -1.7976931348623157E+308R
        Me.CtPedido.Name = "CtPedido"
        Me.CtPedido.Size = New System.Drawing.Size(143, 28)
        Me.CtPedido.TabIndex = 0
        Me.CtPedido.Tag = ""
        Me.CtPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.CtPedido.TextBackColor = System.Drawing.SystemColors.Window
        Me.CtPedido.TextContentSize = 50
        Me.CtPedido.TextContentType = Toolkit.Validaciones.TextBoxTipo.Alfanumerico
        Me.CtPedido.TextDefaultFontColor = System.Drawing.Color.Empty
        Me.CtPedido.TextFont = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.CtPedido.TextFontColor = System.Drawing.SystemColors.WindowText
        Me.CtPedido.TextFontName = "Segoe UI"
        Me.CtPedido.TextFontSize = 8.0!
        Me.CtPedido.TextHeight = 22
        Me.CtPedido.TextMultiline = False
        Me.CtPedido.TextPasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.CtPedido.TextReadOnly = False
        Me.CtPedido.TextScrollBars = System.Windows.Forms.ScrollBars.None
        Me.CtPedido.TextWidth = 80
        Me.CtPedido.TopCenterPosition = 0
        Me.CtPedido.WarningBackgroundColor = System.Drawing.Color.Yellow
        '
        'ContextMenu
        '
        Me.ContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CmEspanol, Me.CmIngles, Me.CmCatalan, Me.CmSeleccionarImpresora, Me.CmAcercaDe})
        Me.ContextMenu.Name = "ContextMenu"
        Me.ContextMenu.Size = New System.Drawing.Size(191, 114)
        '
        'CmEspanol
        '
        Me.CmEspanol.Name = "CmEspanol"
        Me.CmEspanol.Size = New System.Drawing.Size(190, 22)
        Me.CmEspanol.Text = "Español"
        '
        'CmIngles
        '
        Me.CmIngles.Name = "CmIngles"
        Me.CmIngles.Size = New System.Drawing.Size(190, 22)
        Me.CmIngles.Text = "Inglés"
        '
        'CmCatalan
        '
        Me.CmCatalan.Name = "CmCatalan"
        Me.CmCatalan.Size = New System.Drawing.Size(190, 22)
        Me.CmCatalan.Text = "Catalán"
        '
        'CmSeleccionarImpresora
        '
        Me.CmSeleccionarImpresora.Name = "CmSeleccionarImpresora"
        Me.CmSeleccionarImpresora.Size = New System.Drawing.Size(190, 22)
        Me.CmSeleccionarImpresora.Text = "Seleccionar impresora"
        '
        'CmAcercaDe
        '
        Me.CmAcercaDe.Name = "CmAcercaDe"
        Me.CmAcercaDe.Size = New System.Drawing.Size(190, 22)
        Me.CmAcercaDe.Text = "Acerca de"
        '
        'CcIdioma
        '
        Me.CcIdioma.AlinearCentrado = True
        Me.CcIdioma.Autoajustar = True
        Me.CcIdioma.Caption = "Idioma"
        Me.CcIdioma.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.CcIdioma.CaptionFont = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CcIdioma.CaptionFontColor = System.Drawing.SystemColors.ControlText
        Me.CcIdioma.CaptionFontName = "Segoe UI"
        Me.CcIdioma.CaptionFontSize = 10.0!
        Me.CcIdioma.CaptionPad = 3
        Me.CcIdioma.CaptionPosition = Toolkit.Posicion.IzquierdaArriba
        Me.CcIdioma.CaptionText = "Idioma"
        Me.CcIdioma.Culture = "es-MX"
        Me.CcIdioma.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CcIdioma.Highlight = False
        Me.CcIdioma.HighlightBackgroundColor = System.Drawing.Color.OrangeRed
        Me.CcIdioma.LeftCenterPosition = 60
        Me.CcIdioma.Location = New System.Drawing.Point(214, 77)
        Me.CcIdioma.Name = "CcIdioma"
        Me.CcIdioma.Size = New System.Drawing.Size(143, 31)
        Me.CcIdioma.TabIndex = 5
        Me.CcIdioma.Tag = ""
        Me.CcIdioma.TextBackColor = System.Drawing.SystemColors.Window
        Me.CcIdioma.TextContentSize = 50
        Me.CcIdioma.TextDefaultFontColor = System.Drawing.Color.Empty
        Me.CcIdioma.TextFont = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CcIdioma.TextFontColor = System.Drawing.SystemColors.WindowText
        Me.CcIdioma.TextFontName = "Segoe UI"
        Me.CcIdioma.TextFontSize = 10.0!
        Me.CcIdioma.TextHeight = 25
        Me.CcIdioma.TextWidth = 80
        Me.CcIdioma.TopCenterPosition = 0
        Me.CcIdioma.WarningBackgroundColor = System.Drawing.Color.Yellow
        '
        'ChkPdf
        '
        Me.ChkPdf.AutoSize = True
        Me.ChkPdf.Location = New System.Drawing.Point(689, 94)
        Me.ChkPdf.Name = "ChkPdf"
        Me.ChkPdf.Size = New System.Drawing.Size(47, 17)
        Me.ChkPdf.TabIndex = 6
        Me.ChkPdf.Text = "PDF"
        Me.ChkPdf.UseVisualStyleBackColor = True
        '
        'ChkWord
        '
        Me.ChkWord.AutoSize = True
        Me.ChkWord.Location = New System.Drawing.Point(742, 95)
        Me.ChkWord.Name = "ChkWord"
        Me.ChkWord.Size = New System.Drawing.Size(52, 17)
        Me.ChkWord.TabIndex = 7
        Me.ChkWord.Text = "Word"
        Me.ChkWord.UseVisualStyleBackColor = True
        '
        'ChkBox
        '
        Me.ChkBox.CheckOnClick = True
        Me.ChkBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkBox.FormattingEnabled = True
        Me.ChkBox.Location = New System.Drawing.Point(35, 124)
        Me.ChkBox.Name = "ChkBox"
        Me.ChkBox.Size = New System.Drawing.Size(396, 156)
        Me.ChkBox.TabIndex = 8
        '
        'CtFactura
        '
        Me.CtFactura.AlinearCentrado = True
        Me.CtFactura.Autoajustar = True
        Me.CtFactura.Caption = "Factura"
        Me.CtFactura.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.CtFactura.CaptionFont = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.CtFactura.CaptionFontColor = System.Drawing.SystemColors.ControlText
        Me.CtFactura.CaptionFontName = "Segoe UI"
        Me.CtFactura.CaptionFontSize = 8.0!
        Me.CtFactura.CaptionPad = 3
        Me.CtFactura.CaptionPosition = Toolkit.Posicion.IzquierdaArriba
        Me.CtFactura.CaptionText = "Factura"
        Me.CtFactura.Culture = "es-MX"
        Me.CtFactura.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CtFactura.Highlight = False
        Me.CtFactura.HighlightBackgroundColor = System.Drawing.Color.OrangeRed
        Me.CtFactura.LeftCenterPosition = 60
        Me.CtFactura.Location = New System.Drawing.Point(670, 126)
        Me.CtFactura.Margin = New System.Windows.Forms.Padding(0)
        Me.CtFactura.MaxValue = 1.7976931348623157E+308R
        Me.CtFactura.MinValue = -1.7976931348623157E+308R
        Me.CtFactura.Name = "CtFactura"
        Me.CtFactura.Size = New System.Drawing.Size(143, 28)
        Me.CtFactura.TabIndex = 9
        Me.CtFactura.Tag = ""
        Me.CtFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.CtFactura.TextBackColor = System.Drawing.SystemColors.Window
        Me.CtFactura.TextContentSize = 50
        Me.CtFactura.TextContentType = Toolkit.Validaciones.TextBoxTipo.Alfanumerico
        Me.CtFactura.TextDefaultFontColor = System.Drawing.Color.Empty
        Me.CtFactura.TextFont = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.CtFactura.TextFontColor = System.Drawing.SystemColors.WindowText
        Me.CtFactura.TextFontName = "Segoe UI"
        Me.CtFactura.TextFontSize = 8.0!
        Me.CtFactura.TextHeight = 22
        Me.CtFactura.TextMultiline = False
        Me.CtFactura.TextPasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.CtFactura.TextReadOnly = False
        Me.CtFactura.TextScrollBars = System.Windows.Forms.ScrollBars.None
        Me.CtFactura.TextWidth = 80
        Me.CtFactura.TopCenterPosition = 0
        Me.CtFactura.WarningBackgroundColor = System.Drawing.Color.Yellow
        '
        'ChkTodos
        '
        Me.ChkTodos.AutoSize = True
        Me.ChkTodos.Location = New System.Drawing.Point(317, 14)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(121, 17)
        Me.ChkTodos.TabIndex = 10
        Me.ChkTodos.Text = "Dirección Querétaro"
        Me.ChkTodos.UseVisualStyleBackColor = True
        '
        'CcResultado
        '
        Me.CcResultado.AlinearCentrado = True
        Me.CcResultado.Autoajustar = True
        Me.CcResultado.Caption = "Entrega"
        Me.CcResultado.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.CcResultado.CaptionFont = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.CcResultado.CaptionFontColor = System.Drawing.SystemColors.ControlText
        Me.CcResultado.CaptionFontName = "Segoe UI"
        Me.CcResultado.CaptionFontSize = 8.0!
        Me.CcResultado.CaptionPad = 3
        Me.CcResultado.CaptionPosition = Toolkit.Posicion.IzquierdaArriba
        Me.CcResultado.CaptionText = "Entrega"
        Me.CcResultado.Culture = "es-MX"
        Me.CcResultado.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CcResultado.Highlight = False
        Me.CcResultado.HighlightBackgroundColor = System.Drawing.Color.OrangeRed
        Me.CcResultado.LeftCenterPosition = 60
        Me.CcResultado.Location = New System.Drawing.Point(9, 77)
        Me.CcResultado.Name = "CcResultado"
        Me.CcResultado.Size = New System.Drawing.Size(143, 31)
        Me.CcResultado.TabIndex = 2
        Me.CcResultado.Tag = ""
        Me.CcResultado.TextBackColor = System.Drawing.SystemColors.Window
        Me.CcResultado.TextContentSize = 50
        Me.CcResultado.TextDefaultFontColor = System.Drawing.Color.Empty
        Me.CcResultado.TextFont = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CcResultado.TextFontColor = System.Drawing.SystemColors.WindowText
        Me.CcResultado.TextFontName = "Segoe UI"
        Me.CcResultado.TextFontSize = 10.0!
        Me.CcResultado.TextHeight = 25
        Me.CcResultado.TextWidth = 80
        Me.CcResultado.TopCenterPosition = 0
        Me.CcResultado.WarningBackgroundColor = System.Drawing.Color.Yellow
        '
        'CmdActualizar
        '
        Me.CmdActualizar.Location = New System.Drawing.Point(52, 295)
        Me.CmdActualizar.Name = "CmdActualizar"
        Me.CmdActualizar.Size = New System.Drawing.Size(100, 41)
        Me.CmdActualizar.TabIndex = 4
        Me.CmdActualizar.Text = "Consultar"
        Me.CmdActualizar.UseVisualStyleBackColor = True
        '
        'ChkRotatorio
        '
        Me.ChkRotatorio.AutoSize = True
        Me.ChkRotatorio.Location = New System.Drawing.Point(157, 47)
        Me.ChkRotatorio.Name = "ChkRotatorio"
        Me.ChkRotatorio.Size = New System.Drawing.Size(153, 17)
        Me.ChkRotatorio.TabIndex = 13
        Me.ChkRotatorio.Text = "Incluir conceptos rotatorios"
        Me.ChkRotatorio.UseVisualStyleBackColor = True
        '
        'ChkCodigosCliente
        '
        Me.ChkCodigosCliente.AutoSize = True
        Me.ChkCodigosCliente.Checked = True
        Me.ChkCodigosCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkCodigosCliente.Location = New System.Drawing.Point(317, 47)
        Me.ChkCodigosCliente.Name = "ChkCodigosCliente"
        Me.ChkCodigosCliente.Size = New System.Drawing.Size(146, 17)
        Me.ChkCodigosCliente.TabIndex = 14
        Me.ChkCodigosCliente.Text = "Utilizar códigos de cliente"
        Me.ChkCodigosCliente.UseVisualStyleBackColor = True
        Me.ChkCodigosCliente.Visible = False
        '
        'lbError
        '
        Me.lbError.AutoSize = True
        Me.lbError.Location = New System.Drawing.Point(364, 84)
        Me.lbError.Name = "lbError"
        Me.lbError.Size = New System.Drawing.Size(22, 13)
        Me.lbError.TabIndex = 15
        Me.lbError.Text = "2.0"
        '
        'chkLote
        '
        Me.chkLote.AutoSize = True
        Me.chkLote.Location = New System.Drawing.Point(155, 19)
        Me.chkLote.Name = "chkLote"
        Me.chkLote.Size = New System.Drawing.Size(148, 17)
        Me.chkLote.TabIndex = 3
        Me.chkLote.Text = "Imprimir Información Lotes"
        Me.chkLote.UseVisualStyleBackColor = True
        '
        'ctSello
        '
        Me.ctSello.AlinearCentrado = True
        Me.ctSello.Autoajustar = True
        Me.ctSello.Caption = "Sello"
        Me.ctSello.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ctSello.CaptionFont = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ctSello.CaptionFontColor = System.Drawing.SystemColors.ControlText
        Me.ctSello.CaptionFontName = "Segoe UI"
        Me.ctSello.CaptionFontSize = 8.0!
        Me.ctSello.CaptionPad = 3
        Me.ctSello.CaptionPosition = Toolkit.Posicion.IzquierdaArriba
        Me.ctSello.CaptionText = "Sello"
        Me.ctSello.Culture = "es-MX"
        Me.ctSello.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.ctSello.Highlight = False
        Me.ctSello.HighlightBackgroundColor = System.Drawing.Color.OrangeRed
        Me.ctSello.LeftCenterPosition = 60
        Me.ctSello.Location = New System.Drawing.Point(9, 46)
        Me.ctSello.Margin = New System.Windows.Forms.Padding(0)
        Me.ctSello.MaxValue = 1.7976931348623157E+308R
        Me.ctSello.MinValue = -1.7976931348623157E+308R
        Me.ctSello.Name = "ctSello"
        Me.ctSello.Size = New System.Drawing.Size(143, 28)
        Me.ctSello.TabIndex = 1
        Me.ctSello.Tag = ""
        Me.ctSello.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ctSello.TextBackColor = System.Drawing.SystemColors.Window
        Me.ctSello.TextContentSize = 10
        Me.ctSello.TextContentType = Toolkit.Validaciones.TextBoxTipo.Alfanumerico
        Me.ctSello.TextDefaultFontColor = System.Drawing.Color.Empty
        Me.ctSello.TextFont = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ctSello.TextFontColor = System.Drawing.SystemColors.WindowText
        Me.ctSello.TextFontName = "Segoe UI"
        Me.ctSello.TextFontSize = 8.0!
        Me.ctSello.TextHeight = 22
        Me.ctSello.TextMultiline = False
        Me.ctSello.TextPasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.ctSello.TextReadOnly = False
        Me.ctSello.TextScrollBars = System.Windows.Forms.ScrollBars.None
        Me.ctSello.TextWidth = 80
        Me.ctSello.TopCenterPosition = 0
        Me.ctSello.WarningBackgroundColor = System.Drawing.Color.Yellow
        '
        'FrmCapturaManualRemision
        '
        Me.AcceptButton = Me.CmdGenerar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 355)
        Me.ContextMenuStrip = Me.ContextMenu
        Me.Controls.Add(Me.ctSello)
        Me.Controls.Add(Me.chkLote)
        Me.Controls.Add(Me.lbError)
        Me.Controls.Add(Me.CmdActualizar)
        Me.Controls.Add(Me.ChkTodos)
        Me.Controls.Add(Me.CtFactura)
        Me.Controls.Add(Me.ChkBox)
        Me.Controls.Add(Me.ChkWord)
        Me.Controls.Add(Me.ChkPdf)
        Me.Controls.Add(Me.CcIdioma)
        Me.Controls.Add(Me.CtLote)
        Me.Controls.Add(Me.CtPedido)
        Me.Controls.Add(Me.ChkLogos)
        Me.Controls.Add(Me.CmdSalir)
        Me.Controls.Add(Me.CmdGenerar)
        Me.Controls.Add(Me.CcResultado)
        Me.Controls.Add(Me.ChkCodigosCliente)
        Me.Controls.Add(Me.ChkRotatorio)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmCapturaManualRemision"
        Me.Text = "Remisiones"
        Me.ContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdGenerar As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents ChkLogos As System.Windows.Forms.CheckBox
    Friend WithEvents CtPedido As Toolkit.ControlText
    Friend WithEvents CtLote As Toolkit.ControlText
    Shadows WithEvents ContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CmEspanol As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmIngles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmCatalan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmSeleccionarImpresora As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmAcercaDe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CcIdioma As Toolkit.ControlCombo
    Friend WithEvents ChkPdf As CheckBox
    Friend WithEvents ChkWord As CheckBox
    Friend WithEvents ChkBox As CheckedListBox
    Friend WithEvents CtFactura As ControlText
    Friend WithEvents ChkTodos As CheckBox
    Friend WithEvents CcResultado As ControlCombo
    Friend WithEvents CmdActualizar As Button
    Friend WithEvents ChkRotatorio As CheckBox
    Friend WithEvents ChkCodigosCliente As CheckBox
    Friend WithEvents lbError As Label
    Friend WithEvents chkLote As CheckBox
    Friend WithEvents ctSello As ControlText
End Class

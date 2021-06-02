<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPreview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreview))
        Me.Viewer = New GrapeCity.ActiveReports.Viewer.Win.Viewer()
        Me.SuspendLayout()
        '
        'Viewer
        '
        Me.Viewer.BackColor = System.Drawing.SystemColors.Control
        Me.Viewer.CurrentPage = 0
        Me.Viewer.Location = New System.Drawing.Point(0, 0)
        Me.Viewer.Name = "Viewer"
        Me.Viewer.PreviewPages = 0
        '
        '
        '
        '
        '
        '
        Me.Viewer.Sidebar.ParametersPanel.ContextMenu = Nothing
        Me.Viewer.Sidebar.ParametersPanel.Width = 200
        '
        '
        '
        Me.Viewer.Sidebar.SearchPanel.ContextMenu = Nothing
        Me.Viewer.Sidebar.SearchPanel.Width = 200
        '
        '
        '
        Me.Viewer.Sidebar.ThumbnailsPanel.ContextMenu = Nothing
        Me.Viewer.Sidebar.ThumbnailsPanel.Width = 200
        Me.Viewer.Sidebar.ThumbnailsPanel.Zoom = 0.1R
        '
        '
        '
        Me.Viewer.Sidebar.TocPanel.ContextMenu = Nothing
        Me.Viewer.Sidebar.TocPanel.Expanded = True
        Me.Viewer.Sidebar.TocPanel.Text = "Table Of Contents"
        Me.Viewer.Sidebar.TocPanel.Width = 200
        Me.Viewer.Sidebar.Width = 200
        Me.Viewer.Size = New System.Drawing.Size(582, 546)
        Me.Viewer.TabIndex = 13
        '
        'frmPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 605)
        Me.Controls.Add(Me.Viewer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPreview"
        Me.Text = "Vista preliminar"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Viewer As GrapeCity.ActiveReports.Viewer.Win.Viewer
End Class

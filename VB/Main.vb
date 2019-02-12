Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.BandedGrid

Namespace DXSample
    Partial Public Class Main
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private style As AppearanceObject

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            recordBindingSource.DataSource = DataHelper.GetData(10)

            style = New AppearanceObject()
            style.BackColor = Color.Orange
            style.Options.UseBackColor = True

            'try different paint styles
            'advBandedGridView1.PaintStyleName = "UltraFlat";
        End Sub

        Private Sub advBandedGridView1_FocusedColumnChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles advBandedGridView1.FocusedColumnChanged
            advBandedGridView1.InvalidateColumnHeader(e.PrevFocusedColumn)
            advBandedGridView1.InvalidateColumnHeader(e.FocusedColumn)
        End Sub

        Private Sub advBandedGridView1_CustomDrawColumnHeader(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs) Handles advBandedGridView1.CustomDrawColumnHeader
            Dim view As AdvBandedGridView = TryCast(sender, AdvBandedGridView)
            If e.Column = view.FocusedColumn Then
                e.Appearance.Assign(style)
                e.Info.AllowColoring = True
            Else
                e.Info.AllowColoring = False
                e.Appearance.Assign(view.PaintAppearance.HeaderPanel)
            End If
        End Sub
    End Class
End Namespace
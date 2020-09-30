Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Utils

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private style As AppearanceObject

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			' TODO: This line of code loads data into the 'nwindDataSet.Customers' table. You can move, or remove it, as needed.
			Me.customersTableAdapter.Fill(Me.nwindDataSet.Customers)

			style = New AppearanceObject()
			style.BackColor = Color.Orange
			style.Options.UseBackColor = True
		End Sub

		Private Sub advBandedGridView1_FocusedColumnChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles advBandedGridView1.FocusedColumnChanged
			advBandedGridView1.InvalidateColumnHeader(e.PrevFocusedColumn)
			advBandedGridView1.InvalidateColumnHeader(e.FocusedColumn)
		End Sub

		Private Sub advBandedGridView1_CustomDrawColumnHeader(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs) Handles advBandedGridView1.CustomDrawColumnHeader
			If e.Column = advBandedGridView1.FocusedColumn Then
				e.Appearance.Assign(style)
			Else
				e.Appearance.Assign(advBandedGridView1.Appearance.HeaderPanel)
			End If
		End Sub
	End Class
End Namespace
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace DXSample
{
    public partial class Main : XtraForm
    {
        public Main()
        {
            InitializeComponent();
        }

        AppearanceObject style;

        private void Form1_Load(object sender, EventArgs e)
        {
            recordBindingSource.DataSource = DataHelper.GetData(10);

            style = new AppearanceObject();
            style.BackColor = Color.Orange;
            style.Options.UseBackColor = true;

            //try different paint styles
            //advBandedGridView1.PaintStyleName = "UltraFlat";
        }

        private void advBandedGridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            advBandedGridView1.InvalidateColumnHeader(e.PrevFocusedColumn);
            advBandedGridView1.InvalidateColumnHeader(e.FocusedColumn);
        }

        private void advBandedGridView1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            AdvBandedGridView view = sender as AdvBandedGridView;
            if(e.Column == view.FocusedColumn) {
                e.Appearance.Assign(style);
                e.Info.AllowColoring = true;
            }
            else {
                e.Info.AllowColoring = false;
                e.Appearance.Assign(view.PaintAppearance.HeaderPanel);
            }
        }
    }
}
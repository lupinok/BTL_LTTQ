using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL_QLNS;
using BUS_QLNS;

namespace GUI_QLNS
{
    public partial class LyLich : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private SoYeuLiLich_DaoTao_BUS lylichBUS = new SoYeuLiLich_DaoTao_BUS();

		public LyLich()
        {
            InitializeComponent();
        }

		private void LyLich_Load(object sender, EventArgs e)
		{
            dgvSYLL.DataSource = lylichBUS.GetAllSoYeuLyLich();
		}
	}
}

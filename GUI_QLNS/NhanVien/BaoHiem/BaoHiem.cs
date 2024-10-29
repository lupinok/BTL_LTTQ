using DevExpress.Entity.Model;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLNS.NhanVien.BaoHiem
{
    public partial class BaoHiem : DevExpress.XtraEditors.XtraForm
    {
        public BaoHiem()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void BaoHiem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bTLMonLTTQDataSet.BaoHiem' table. You can move, or remove it, as needed.
            this.baoHiemTableAdapter.Fill(this.bTLMonLTTQDataSet.BaoHiem);

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
           
        }

        

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "gridColumn3") // Thay "DeleteButton" bằng tên trường bạn đã định nghĩa cho cột "Xóa"
            {
                int rowHandle = e.RowHandle; // Lấy chỉ số hàng hiện tại
                if (rowHandle >= 0) // Kiểm tra chỉ số hàng hợp lệ
                {
                    // Hiện hộp thoại xác nhận xóa
                    var result = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes) // Nếu người dùng chọn "Có"
                    {
                        gridView1.DeleteRow(rowHandle); // Xóa hàng
                    }
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new ThemBaoHiem();
            frm.ShowDialog();
        }
    }
}
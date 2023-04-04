using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doan.net
{
    public partial class CTDH : Form
    {
        public CTDH()
        {
            InitializeComponent();
        }

        private void laydulieu()
        {
            cl db = new cl();
            string sql = "SELECT * FROM Donhang";
            Dgv2.DataSource = db .getData(sql);
        }

        private void CTDH_Load(object sender, EventArgs e)
        {
            laydulieu();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string mdh = txtmadonhang.Text;
                    string mnv = txtmanhanvien.Text;
                    string mk = txtmakhach.Text;
                    string nb = txtngayban.Text;
                    string tt = txttongtien.Text;
                    string sql = string.Format("INSERT INTO Donhang (MaDh, MaNv, MaKhach, Ngayban,Tongtien) VALUES  (N'{0}', N'{1}', N'{2}', N'{3}','{4}')",mdh ,mnv ,mk ,nb ,tt );
                    cl db = new cl();
                    db.runQuery(sql);
                    laydulieu();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string mdh = txtmadonhang.Text;
            string mnv = txtmanhanvien.Text;
            string mk = txtmakhach.Text;
            string nb = txtngayban.Text;
            string tt = txttongtien.Text;
            string sql = string.Format("UPDATE Donhang SET " + "MaNv = N'{0}', " + "MaKhach=N'{1}'," + "Ngayban=N'{2}'," + "Tongtien=N'{3}' WHERE MaDh='{4}'", mnv , mk , nb, tt,mdh );
            cl db = new cl();
            db.runQuery(sql);
            laydulieu();
        }

        private void Dgv2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;

            if (i >= 0)
            {
                txtmadonhang.Text  = Dgv2 .Rows[i].Cells["MaDh"].Value.ToString();

               txtmanhanvien.Text  = Dgv2 .Rows[i].Cells["MaNv"].Value.ToString();

                txtmakhach.Text   = Dgv2 .Rows[i].Cells["MaKhach"].Value.ToString();
                txtngayban.Text   = Dgv2 .Rows[i].Cells["Ngayban"].Value.ToString();
                txttongtien .Text  = Dgv2 .Rows[i].Cells["Tongtien"].Value.ToString();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string mdh = txtmadonhang .Text;
            string sql = string.Format("DELETE FROM Donhang WHERE MaDh='{0}'", mdh );
            cl db = new cl();
            db.runQuery(sql);
            laydulieu();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            txtmadonhang .Text = "";
            txtmanhanvien .Text = "";
            txtmakhach .Text = "";
            txtngayban .Text = "";
            txttongtien .Text = "";
          
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

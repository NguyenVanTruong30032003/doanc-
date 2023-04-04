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
    public partial class QLNV : Form
    {
        public QLNV()
        {
            InitializeComponent();
        }

        private void loadGridData()
        {
            cl db = new cl();
            string sql = "SELECT * FROM Nhanvien ";
            dgv.DataSource = db.getData(sql);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadGridData();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                string mnv = txtNv.Text;
                string tnv = txtTnv.Text;
                string gt = txtGt.Text;
                string dc = txtDc.Text;
                string dt = txtdt.Text;
                string ns = txtNs.Text;
                string sql = string.Format("INSERT INTO Nhanvien (MaNv, TenNv, Gioitinh, Diachi, Tell,Ngaysinh) VALUES  (N'{0}', N'{1}', N'{2}', N'{3}','{4}',N'{5}')", mnv, tnv, gt, dc, dt, ns);
                cl db = new cl();
                db.runQuery(sql );
                loadGridData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {

            string mnv = txtNv.Text;
            string tnv = txtTnv.Text;
            string gt = txtGt.Text;
            string dc = txtDc.Text;
            
            string dt = txtdt.Text;
            string ns = txtNs.Text;
            string sql = string.Format("UPDATE Nhanvien SET "+"TenNv = N'{0}', " + "Gioitinh=N'{1}'," + "Ngaysinh=N'{4}'," +"Tell=N'{3}', " +" Diachi=N'{2}' WHERE MaNv='{5}'" , tnv, gt,dc, dt, ns, mnv);
            cl db = new cl();
            db.runQuery(sql);
            loadGridData();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;

            if (i >= 0)

            {

                txtNv.Text = dgv.Rows[i].Cells["MaNv"].Value.ToString();

                txtTnv.Text = dgv.Rows[i].Cells["TenNv"].Value.ToString();

                txtGt.Text = dgv.Rows[i].Cells["Gioitinh"].Value.ToString();
                txtDc.Text = dgv.Rows[i].Cells["Diachi"].Value.ToString();
                txtdt.Text = dgv.Rows[i].Cells["Tell"].Value.ToString();
                txtNs.Text = dgv.Rows[i].Cells["Ngaysinh"].Value.ToString();

                /*  txtDc.Text  = dgv.Rows[i].Cells["Diachi"].Value.ToString();


                  txtdt.Text = dgv.Rows[i].Cells["Tell"].Value.ToString();

                   txtNs.Text = dgv.Rows[i].Cells["Ngaysinh"].Value.ToString();*/
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string mnv = txtNv.Text;
            string sql = string.Format("DELETE FROM Nhanvien WHERE MaNv='{0}'", mnv) ;
            cl db = new cl();
            db.runQuery(sql);
            loadGridData();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtNv.Text = "";
            txtTnv.Text = "";
            txtGt.Text = "";
            txtNs.Text = "";
            txtdt.Text = "";
            txtGt.Text = "";
            txtDc.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

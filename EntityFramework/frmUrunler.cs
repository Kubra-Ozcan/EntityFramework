using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework
{
    public partial class frmUrunler : Form
    {
        public frmUrunler()
        {
            InitializeComponent();
        }

        dbSirketEntities db = new dbSirketEntities();

        void Listele()
        {
            dataGridView1.DataSource= db.tblUrunler.ToList();
            dataGridView1.Columns[4].Visible = false;
            txtID.Text = "";
            txtAD.Text = "";
            txtFiyat1.Text = "";
        }


            

        private void frmUrunler_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAD.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtFiyat1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAD.Text ==" " || txtFiyat1.Text == "")
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            {
                var x = new tblUrunler();
                x.ad = txtAD.Text;
                x.fiyat = float.Parse(txtFiyat1.Text);
                x.durum = true;

                db.tblUrunler.Add(x);
                db.SaveChanges();
                MessageBox.Show("Ürün akaydı başarıyla kaydedilmiştir.");
                Listele();

            }
        }

        private void btnSıl_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
                MessageBox.Show("Lütfen silinecek ürünü seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                int id = int.Parse(txtID.Text);
                var x = db.tblUrunler.Find(id);
                db.tblUrunler.Remove(x);
                db.SaveChanges();
                MessageBox.Show("Ürün Silindi.");
                Listele();
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = db.tblUrunler.Where(x => x.ad == txtAD.Text).ToList();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtAD.Text == "" || txtFiyat.Text == "")
                MessageBox.Show("Lütfen güncellenecek ürünün bilgilerini giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                int id = int.Parse(txtID.Text);
                var x = db.tblUrunler.Find(id);
                x.ad = txtAD.Text;
                x.fiyat = float.Parse(txtFiyat1.Text);
                db.SaveChanges();
                MessageBox.Show("Ürün güncellendi.");
                Listele();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSatisler frm = new frmSatisler();
            frm.Show();
        }
    }
}
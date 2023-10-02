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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        dbSirketEntities db = new dbSirketEntities();

        public void listele()
        {
            //datagride dtabase deki bilgileri otomatikolarak liste şeklinde getiri.

            dataGridView1.DataSource = db.tblMusteriler.ToList();
            dataGridView1.Columns[6].Visible = false;  //5.indekstekiikolnu gizledik
            txtID.Text = "";
            txtAD.Text = "";
            txtSoyad.Text = "";
            txtAdres.Text = "";
            txtTel.Text = "";
            //her yazzıp butona bastıktan sonara abuton üzerindeki alanları temziler

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAD.Text == "" || txtSoyad.Text == "" || txtAdres.Text == "" || txtTel.Text == "")
                MessageBox.Show("Lütfen tüm alanları giriniz ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                tblMusteriler x = new tblMusteriler();

                x.ad = txtAD.Text;
                x.soyad = txtSoyad.Text;
                x.adres = txtAdres.Text;
                x.tel = txtTel.Text;
                x.durum = true;

                db.tblMusteriler.Add(x);
                db.SaveChanges();
                MessageBox.Show("Kayıt işelmi tamalandı! ");
            }
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // form atıkladıgımızda data griddeki bilgileri getirme
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAD.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtAdres.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTel.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnSıl_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
                MessageBox.Show("Lütfen silmek istediğiniz kisşiyi seçiniz ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                int id = int.Parse(txtID.Text);

                var x = db.tblMusteriler.Find(id);
                db.tblMusteriler.Remove(x);
                db.SaveChanges();
                MessageBox.Show("Müsteri silindi");
            }
            listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtAD.Text == "" || txtSoyad.Text == "" || txtAdres.Text == "" || txtTel.Text == "")
                MessageBox.Show("Lütfen güncellenecek kişiyi  seçiniz: ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                int id = int.Parse(txtID.Text);
                var x = db.tblMusteriler.Find(id);

                x.ad = txtAD.Text;
                x.soyad = txtSoyad.Text;
                x.adres = txtSoyad.Text;
                x.tel = txtTel.Text;

                db.SaveChanges();
                MessageBox.Show("Güncelleme yapıldı.");

            }
            listele();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.tblMusteriler.Where(x => x.ad == txtBul.Text).ToList();
           
        }

        private void btnUrunIslemleri_Click(object sender, EventArgs e)
        {
            frmUrunler frm = new frmUrunler();
            frm.Show();
        }
    }
}

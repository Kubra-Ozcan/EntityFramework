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
    public partial class frmSatisler : Form
    {
        public frmSatisler()
        {
            InitializeComponent();
        }
        dbSirketEntities db = new dbSirketEntities();
        
        public void Listele()
        {

            dataGridView1.DataSource = db.SatisListesi2().ToList();

            var x = from item in db.tblMusteriler
                    select new { item.ID, adSoyad = item.ad + " " + item.soyad };

            cbMusteriler.DataSource = x.ToList();
            cbMusteriler.DisplayMember = "adSoyad";
            cbMusteriler.ValueMember = "ID";


            cbUrunler.DataSource = db.tblUrunler.ToList();
            cbUrunler.DisplayMember = "ad";
            cbUrunler.ValueMember = "ID";


        }
        private void frmSatisler_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void cbMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            var x = new tblSatisler();
            x.UrunID = int.Parse(cbUrunler.SelectedValue.ToString());
            x.musteriID = int.Parse(cbMusteriler.SelectedValue.ToString());
            x.tarih = DateTime.Now;

            db.tblSatisler.Add(x);
            db.SaveChanges();
            MessageBox.Show("Satış yapıldı!..");
            Listele();


        }
    }
}

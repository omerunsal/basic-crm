using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRM.Commonn;
using CRM.Dal;
using CRM.Entity;
namespace CRM.UI
{
    public partial class frmEkle : Form
    {
        public frmEkle()
        {
            InitializeComponent();
        }
        customerDAL cusDal = new customerDAL();
        
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Customer yeni = new Customer()
                {
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Adress = txtAdress.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Mail = txtMail.Text,
                    Phone = mtxtPhone.Text,
                    PhotoPath = txtResim.Text,
                    Gender = rbErkek.Checked
                };

                var result = cusDal.Save(yeni);
                MessageBox.Show(result.IsSucceeded == true ? "Başarıyla Eklendi" : "Hata");

                this.Hide();
                Form1 y = new Form1();
                y.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);;
            }

        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 y = new Form1();
            y.Show();

        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dosya = new OpenFileDialog();
                dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Tüm Dosyalar |*.*";
                dosya.Title = "resim";
                dosya.ShowDialog();
                string DosyaYolu = dosya.FileName;
                pictureBox1.Image = Image.FromFile(DosyaYolu);
                txtResim.Text = DosyaYolu;
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}

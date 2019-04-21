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
    public partial class frmGuncelle : Form
    {
        Customer customer;
        public frmGuncelle(Customer cust)
        {
            InitializeComponent();
            customer = cust;
        }
        
        customerDAL cusDal = new customerDAL();
        
        Customer secilen = new Customer();

        private void frmGuncelle_Load(object sender, EventArgs e)
        {
            txtName.Text = customer.Name;
            txtSurname.Text = customer.Surname;
            txtAdress.Text = customer.Adress;
            txtCity.Text = customer.City;
            txtCountry.Text = customer.Country;
            txtMail.Text = customer.Mail;
            txtResim.Text = customer.PhotoPath;
            mtxtPhone.Text = customer.Phone;
            if (customer.PhotoPath !=null)
            {
                pictureBox1.Image = Image.FromFile(customer.PhotoPath);
            }
            
        }
       
        private void btnResimSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Tüm Dosyalar |*.*";
            dosya.Title = "resim";
            dosya.ShowDialog();
            string DosyaYolu = dosya.FileName;
            pictureBox1.Image = Image.FromFile(DosyaYolu);
            txtResim.Text = DosyaYolu;
        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
            try
            {
                Customer yeni = new Customer()
                {
                    Id = customer.Id,
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
                var result =cusDal.Update(yeni);
                if (result.IsSucceeded)
                {
                    MessageBox.Show("Başarıyla güncellendi");
                }
               
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 y = new Form1();
            y.Show();
        }
    }
}

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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // CRm Project -> Customer Relationship Management (Müşteri İlişkileri Yönetim Sistemi...)

        // CRM.Entity içine BaseType.cs adında bir class açıyorum - oradayım...

        customerDAL cusDal = new customerDAL();

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }
        
        private void Listele()
        {
            var result = cusDal.ListOfCustomer();

            if (result.IsSucceeded == true) //işlem başarılıysa
            {
                dtgwCRM.DataSource = result.TransactionResult;
            }
        }

        #region Ekle / Güncelle / Sil Butonlarım
        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEkle frmEkle = new frmEkle();
            frmEkle.Show();
            this.Hide();
        }
        
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGuncelle frm = new frmGuncelle(dtgwCRM.CurrentRow.DataBoundItem as Customer);
            frm.Show();
            this.Hide();
        }
        int secilenID;
        string secilenIsim;
        private void dtgwCRM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenID = (int)dtgwCRM.CurrentRow.Cells[9].Value;
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (secilenID == 0)
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz Veriyi Seçiniz!");
                return;
            }
            var result = cusDal.Delete(secilenID);

            MessageBox.Show(result.IsSucceeded == true ? "Silme işleminiz başarılı" : "Silme İşleminiz Başarısız!");

            Listele();
        }
        #endregion
        
    }
}

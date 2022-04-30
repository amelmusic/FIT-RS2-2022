using eProdaja.Model;
using eProdaja.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdaja.WinUI
{
    public partial class frmKorisnici : Form
    {
        public APIService KorisinciService { get; set; } = new APIService("Korisnici");

        public frmKorisnici()
        {
            InitializeComponent();
            dgvKorisinici.AutoGenerateColumns = false;
        }

        private void frmKorisnici_Load(object sender, EventArgs e)
        {

        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            var searchObject = new KorisniciSearchObject();
            searchObject.KorisnickoIme = txtUsername.Text;
            searchObject.NameFTS = txtName.Text;
            searchObject.IncludeRoles = true;

            var list = await KorisinciService.Get<List<Korisnici>>(searchObject);

            dgvKorisinici.DataSource = list;
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }

        private void dgvKorisinici_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvKorisinici.SelectedRows[0].DataBoundItem as Korisnici;

            frmKorisniciDetails frm = new frmKorisniciDetails(item);
            frm.ShowDialog();
        }
    }
}

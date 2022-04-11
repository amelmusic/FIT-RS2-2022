using Flurl.Http;

namespace eProdaja.WinUI
{
    public partial class Form1 : Form
    {
        public APIService KorisniciService { get; set; } = new APIService("Korisnici");
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var list = await KorisniciService.Get<dynamic>();
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargoDelivery
{
    public partial class WelcomePage : Form
    {
        
        public WelcomePage()
        {
            InitializeComponent();
        }
    
        private async void buttonSignUp_Click(object sender, EventArgs e)
        {
            if (textBoxSignUpUsername.TextLength != 0 && textBoxSignUpEmail.TextLength != 0 && textBoxSignUpPassword.TextLength != 0)
            {
                var reg = await KullaniciIslemleri.kayitol(textBoxSignUpUsername.Text, textBoxSignUpEmail.Text, textBoxSignUpPassword.Text);
                Dictionary<string, string> sonuc = JsonConvert.DeserializeObject<Dictionary<string, string>>(reg);
                if (sonuc["status"] == "success")
                {
                    MessageBox.Show("Kayıt başarılı");

                }
                else
                {
                    MessageBox.Show("Sorun oluştu");
                }

            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayın");
            }
        }

        public void a()
        {
            TeslimatDurumEkranı one = new TeslimatDurumEkranı();
            Application.Run(one);
        }
        public void b()
        {
            GUI2 b = new GUI2();
            Application.Run(b);
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {

            if (textBoxLoginUsername.Text != null && textBoxLoginPassword.Text != null)
            {
                var deneme = await KullaniciIslemleri.girisyap(textBoxLoginUsername.Text, textBoxLoginPassword.Text);

                Dictionary<string, string> sonuc = JsonConvert.DeserializeObject<Dictionary<string, string>>(deneme);
                if(sonuc["status"]== "logged_in")
                {
                    this.Hide();
                  var t1=new Thread(a);
                    var t2 = new Thread(b);
                    t1.Start();
                    t2.Start();
                    

                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!!");
                }
              


            }
        }


        private async void buttonChangePassword_Click(object sender, EventArgs e)
        {
            if(textBoxChangePasswordUsername.TextLength!= 0 && textBoxChangePasswordOldPassword.TextLength != 0 && textBoxnewpass.TextLength != 0)
            {
                var sf = await KullaniciIslemleri.sifredegistir(textBoxnewpass.Text, textBoxChangePasswordOldPassword.Text, textBoxChangePasswordUsername.Text);
                Dictionary<string, string> sonuc = JsonConvert.DeserializeObject<Dictionary<string, string>>(sf);
                if (sonuc["status"] == "success")
                {
                    MessageBox.Show("Şifre Değiştirildi");

                }
                else
                {
                    MessageBox.Show("Girilen bilgiler hatalıdır");
                }
            }
            else
            {
                MessageBox.Show("Boş alan bırakmayın !");
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void girişYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeslimatAdresEkranı one = new TeslimatAdresEkranı();
            one.Show();
        }

        private void kullanıcıKonumuEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeslimatAdresEkranı one = new TeslimatAdresEkranı();
            one.Show();
        }

        private void teslimatDurumuEkranıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeslimatAdresEkranı one = new TeslimatAdresEkranı();
            one.Show();
        }

        private void haritaEkranıToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kayıtOlToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}

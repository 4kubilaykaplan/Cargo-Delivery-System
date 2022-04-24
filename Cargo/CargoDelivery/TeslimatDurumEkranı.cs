using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Microsoft.VisualBasic;

namespace CargoDelivery
{
    public partial class TeslimatDurumEkranı : Form
    {
        int selectedkargoindice= -1;
        public TeslimatDurumEkranı()
        {
            InitializeComponent();
            KargoListeOlustur();
        }


        private async void KargoListeOlustur()
        {
          
            listView1.Items.Clear();
            // Set the view to show details.
            listView1.View = View.Details;
            // Allow the user to edit item text.
            listView1.LabelEdit = false;
            // Allow the user to rearrange columns.
            listView1.AllowColumnReorder = false;
            // Display check boxes.
            listView1.CheckBoxes = false;
            // Select the item and subitems when selection is made.
            listView1.FullRowSelect = false;
            // Display grid lines.
            listView1.GridLines = true;
            listView1.MultiSelect = false;
            // Sort the items in the list in ascending order.
            listView1.Sorting = SortOrder.Ascending;
            var aa= await KargoIslemleri.kargolistele();
            List<Dictionary<string,string>> sonuc = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(aa);
            

            foreach (Dictionary<string, string> kv in sonuc)
            {
               
                ListViewItem item1 = new ListViewItem(kv["CargoID"], 0);
                // Place a check mark next to the item.
                item1.SubItems.Add(kv["DeliveryInformation"]);
           
                /*foreach(KeyValuePair<string, string> a in kv)
                {
                    MessageBox.Show(a.Key+"  :  "+a.Value);
                }*/
                listView1.Items.Add(item1);
            
            }


            ListViewItem item2 = new ListViewItem("item2", 1);
            item2.SubItems.Add("4");

            ListViewItem item3 = new ListViewItem("item3", 0);
            // Place a check mark next to the item.
            item3.SubItems.Add("7");

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
          



        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listView1.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                String text = listView1.Items[intselectedindex].Text;

                // MessageBox.Show(listView1.Items[intselectedindex].Text); 
                selectedkargoindice = intselectedindex;
            }
        }

        private async void teslimdurumudegistir_Click(object sender, EventArgs e)
        {
            if (selectedkargoindice == -1)
            {
                MessageBox.Show("Seçim Yapınız");
            }
            else
            {
               string content= Interaction.InputBox("Teslim Durumu Giriniz?", "Teslim Durumu Değiştir", "0");
                if(content=="1" || content == "0")
                {
                 
                    var result =await KargoIslemleri.teslimdurumudegistir(listView1.Items[selectedkargoindice].Text, content);
                    Dictionary<string, string> aa = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                    if (aa["status"] == "success")
                    {
                        MessageBox.Show("Değiştirildi");
                        KargoListeOlustur();
                        Program.add_update_req();
                    }
                    else
                    {
                        MessageBox.Show(aa["status"]);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Değişiklik Yapılamadı");
                }
            }
        }

        private async void sil_Click(object sender, EventArgs e)
        {

            if (selectedkargoindice == -1)
            {
                MessageBox.Show("Seçim Yapınız");
            }
            else
            {
             

                    var result = await KargoIslemleri.kargosil(listView1.Items[selectedkargoindice].Text);
                    Dictionary<string, string> aa = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                    if (aa["status"] == "success")
                    {
                        MessageBox.Show("Silindi");
                        KargoListeOlustur();
                    Program.add_update_req();
                }
                    else
                    {
                        MessageBox.Show("Hata Oluştu");
                    }

           
              
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeslimatAdresEkranı ta = new TeslimatAdresEkranı();
            ta.Show();
        }

        private void guncelle_Click(object sender, EventArgs e)
        {

            if (selectedkargoindice == -1)
            {
                MessageBox.Show("Seçim Yapınız");
            }
            else
            {



                this.Hide();
                GuncellemeEkranı g = new GuncellemeEkranı(listView1.Items[selectedkargoindice].Text);
                g.Show();


            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.add_update_req();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            KullaniciKonumuDegistir k = new KullaniciKonumuDegistir();
            k.Show();
            
        }
    }
}

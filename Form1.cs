using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMApp
{
    public partial class Form1 : Form
    {
        bool RSD = true;
        int iznos;
        int[] kolicina;
        Label l2 = new Label();
        Label l3 = new Label();
        PictureBox[] novac = new PictureBox[9];
        Label[] oznaka = new Label[9];
        PictureBox[] novacEUR = new PictureBox[6];
        Label[] oznakaEUR = new Label[6];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = new Bitmap("../../background/taki_company.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            button1.BackColor = Color.MediumVioletRed;
            button1.ForeColor = Color.White;
            button2.BackColor = Color.PaleVioletRed;
            button2.ForeColor = Color.White;
            button3.BackColor = Color.Orange;
            button3.ForeColor = Color.White;
            button4.BackColor = Color.OrangeRed;
            button4.ForeColor = Color.White;
            for (int i = 0; i < 9; i++)
            {
                novac[i] = new PictureBox();
                novac[i].Location = new Point(480, 195 + i * 30);
                novac[i].Size = new Size(65, 25);
                novac[i].BackColor = Color.Transparent;
                novac[i].BackgroundImageLayout = ImageLayout.Stretch;
                this.Controls.Add(novac[i]);

                oznaka[i] = new Label();
                oznaka[i].Location = new Point(550, 195 + i * 30);
                oznaka[i].Size = label1.Size;
                oznaka[i].Font = textBox1.Font;
                oznaka[i].BackColor = Color.Transparent;
                oznaka[i].ForeColor = Color.White;
                this.Controls.Add(oznaka[i]);
            }
            for (int i = 0; i < 6; i++)
            {
                novacEUR[i] = new PictureBox();
                novacEUR[i].Location = new Point(780, 195 + i * 30);
                novacEUR[i].Size = new Size(65, 25);
                novacEUR[i].BackColor = Color.Transparent;
                novacEUR[i].BackgroundImageLayout = ImageLayout.Stretch;
                this.Controls.Add(novacEUR[i]);

                oznakaEUR[i] = new Label();
                oznakaEUR[i].Location = new Point(850, 195 + i * 30);
                oznakaEUR[i].Size = label1.Size;
                oznakaEUR[i].Font = textBox1.Font;
                oznakaEUR[i].BackColor = Color.Transparent;
                oznakaEUR[i].ForeColor = Color.White;
                this.Controls.Add(oznakaEUR[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RSD = true;

            if (proveri_iznos(textBox1.Text))
            {
                int iznosEUR;
                decimal ostatak;

                iznosEUR = iznos / 120;
                ostatak = Decimal.Divide(iznos, 120) % 5;

                generisi_obavestenje("Cash withdrawal in RSD is completed successfully.");

                ucitaj_novac(iznos);
                RSD = false;
                ucitaj_novac(iznosEUR);
                RSD = true;

                string poruka = "* amount in EUR (at the rate of 120 RSD per EUR): " + (iznosEUR / 5) * 5 + " (~" + (iznosEUR / 5) * 5 * 120 + " RSD); amount in EUR which could not be converted:" + ostatak.ToString("0.00") + " (~" + (ostatak * 120).ToString("0.00") + " RSD)";

                generisi_fusnotu(poruka);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RSD = true;

            if (proveri_iznos(textBox1.Text))
            {
                int iznosEUR;
                decimal ostatak;

                iznosEUR = iznos / 120;
                ostatak = Decimal.Divide(iznos, 120) % 5;

                generisi_obavestenje("Cash withdrawal in RSD is completed successfully.");

                ucitaj_novac(iznos);
                RSD = false;
                ucitaj_novac(iznosEUR);
                RSD = true;

                string poruka = "* amount in EUR (at the rate of 120 RSD per EUR): " + (iznosEUR / 5) * 5 + " (~" + (iznosEUR / 5) * 5 * 120 + " RSD); amount in EUR which could not be converted:" + ostatak.ToString("0.00") + " (~" + (ostatak * 120).ToString("0.00") + " RSD)";

                generisi_fusnotu(poruka);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RSD = false;

            if (proveri_iznos(textBox1.Text))
            {
                int iznosRSD;
                int ostatak;

                iznosRSD = iznos * 119;
                ostatak = iznosRSD % 10;

                generisi_obavestenje("Cash deposit in EUR is completed successfully.");

                ucitaj_novac(iznos);
                RSD = true;
                ucitaj_novac(iznosRSD);
                RSD = false;

                string poruka = "* amount in RSD (at the rate of 119 RSD per EUR): " + (iznosRSD / 10) * 10 + " RSD (~" + Decimal.Divide((iznosRSD / 10) * 10, 119).ToString("0.00") + " EUR); amount in EUR which could not be converted:" + ostatak + " RSD (~" + Decimal.Divide(ostatak, 119).ToString("0.00") + " EUR)";

                generisi_fusnotu(poruka);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RSD = false;

            if (proveri_iznos(textBox1.Text))
            {
                int iznosRSD;
                int ostatak;

                iznosRSD = iznos * 119;
                ostatak = iznosRSD % 10;

                generisi_obavestenje("Cash deposit in EUR is completed successfully.");

                ucitaj_novac(iznos);
                RSD = true;
                ucitaj_novac(iznosRSD);
                RSD = false;

                string poruka = "* amount in RSD (at the rate of 119 RSD per EUR): " + (iznosRSD / 10) * 10 + " RSD (~" + Decimal.Divide((iznosRSD / 10) * 10, 119).ToString("0.00") + " EUR); amount in EUR which could not be converted:" + ostatak + " RSD (~" + Decimal.Divide(ostatak, 119).ToString("0.00") + " EUR)";

                generisi_fusnotu(poruka);
            }
        }

        private bool proveri_iznos(string text)
        {
            try
            {
                iznos = int.Parse(text);
                if (RSD && iznos % 10 > 0)
                {
                    throw new Exception("The smallest denomination is a 10 RSD banknote.");
                }
                else if (!RSD && iznos % 5 > 0)
                {
                    throw new Exception("The smallest denomination is a 5 EUR banknote.");
                }
                else
                {
                    return true;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Amount not entered correctly.");
                return false;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                return false;
            }
        }

        private void generisi_obavestenje(string poruka)
        {
            if (!this.Controls.Contains(l2))
            {
                l2 = new Label();
            }
            l2.Location = new Point(470, 155);
            l2.Text = poruka;
            l2.BackColor = Color.Transparent;
            l2.ForeColor = Color.White;
            Font myFont = new Font("Microsoft Sans Serif", 15);
            l2.Font = myFont;
            l2.Size = new Size(label1.Size.Width + 700, label1.Size.Height);
            if (!this.Controls.Contains(l2))
            {
                this.Controls.Add(l2);
            }
        }

        public void ucitaj_novac(int iznos)
        {
            int[] apoeni;
            if (RSD)
            {
                apoeni = new int[] { 5000, 2000, 1000, 500, 200, 100, 50, 20, 10 };
                kolicina = new int[apoeni.Length];
                for (int i = 0; i < kolicina.Length; i++)
                {
                    novac[i].BackgroundImage = null;
                    oznaka[i].Text = "";
                }
            }
            else
            {
                apoeni = new int[] { 200, 100, 50, 20, 10, 5 };
                kolicina = new int[apoeni.Length];
                for (int i = 0; i < kolicina.Length; i++)
                {
                    novacEUR[i].BackgroundImage = null;
                    oznakaEUR[i].Text = "";
                }
            }

            for (int i = 0; i < kolicina.Length; i++)
            {
                kolicina[i] = iznos / apoeni[i];
                iznos = iznos % apoeni[i];
            }

            int pozicija = 0;

            for (int i = 0; i < kolicina.Length; i++)
            {
                if (RSD && kolicina[i] > 0)
                {
                    novac[pozicija].BackgroundImage = new Bitmap("../../banknotes/" + apoeni[i] + ".jpg");
                    oznaka[pozicija].Text = "X " + kolicina[i];
                    pozicija++;
                }
                if (!RSD && kolicina[i] > 0)
                {
                    novacEUR[pozicija].BackgroundImage = new Bitmap("../../banknotes/EUR" + apoeni[i] + ".jpg");
                    oznakaEUR[pozicija].Text = "X " + kolicina[i];
                    pozicija++;
                }
            }
        }

        private void generisi_fusnotu(string poruka)
        {
            if (!this.Controls.Contains(l3))
            {
                l3 = new Label();
            }
            l3.Location = new Point(470, 470);
            l3.Text = poruka;
            l3.BackColor = Color.Transparent;
            l3.ForeColor = Color.White;
            l3.Font = this.Font;
            l3.Size = new Size(label1.Size.Width + 350, label1.Size.Height);
            if (!this.Controls.Contains(l3))
            {
                this.Controls.Add(l3);
            }
        }
    }
}
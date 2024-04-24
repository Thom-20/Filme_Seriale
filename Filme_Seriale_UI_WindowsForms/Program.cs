using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using StocareDate;
using StocareFisier;
using Filme;
using Seriale;
using System.Configuration;
using System.IO;

namespace Filme_Seriale_UI_WindowsForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Crearea și afișarea formularului pentru adăugarea de filme/seriale
            FormularMedia form1 = new FormularMedia();
            form1.Show();

            // Afișarea formularului pentru afișarea și gestionarea filmelor/serialelor
            Application.Run(new Form1());
            Application.Run(new Form2());

        }
    }

    public class FormularMedia : Form
    {
        public static int ok = 0;

        private Label lblnume;
        private TextBox txtnume;

        private Label lblregizor;
        private TextBox txtregizor;

        private Label lblgen;
        private TextBox txtgen;

        private Label lbldurata;
        private TextBox txtdurata;

        private Label lbllansare;
        private TextBox txtlansare;

        private Button btnAdauga;
        private Label lblFilm;

        /// <summary>
        /// pentru serial
        /// </summary>

        private Label lblnume1;
        private TextBox txtnume1;

        private Label lblregizor1;
        private TextBox txtregizor1;

        private Label lblgen1;
        private TextBox txtgen1;

        private Label lbldurata1;
        private TextBox txtdurata1;

        private Label lbllansare1;
        private TextBox txtlansare1;

        private Label lblepisoade1;
        private TextBox txtepisoade1;

        private Label lblsezoane1;
        private TextBox txtsezoane1;

        private Button btnAdauga1;
        private Label lblSerial;


        private const int LATIME_CONTROL = 150;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 170;
        private const int DIMENSIUNE_PAS_Z = 50;

        public FormularMedia()
        {
            // Configurarea aspectului formularului
            this.Size = new System.Drawing.Size(700, 700);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.DarkBlue;
            this.Text = "Formular de adăugare a unui Film sau Serial";


            // Adăugarea controlului de tip Label pentru 'Nume film'
            lblnume = new Label();
            lblnume.Width = LATIME_CONTROL;
            lblnume.Text = "Numele filmului:";
            lblnume.Top = DIMENSIUNE_PAS_Y;
            lblnume.BackColor = Color.White;
            this.Controls.Add(lblnume);

            // Adăugarea controlului de tip TextBox pentru 'Nume film'
            txtnume = new TextBox();
            txtnume.Width = LATIME_CONTROL;
            txtnume.Top = DIMENSIUNE_PAS_Y;
            txtnume.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtnume);


            // Adăugarea controlului de tip Label pentru 'Regizor film'
            lblregizor = new Label();
            lblregizor.Width = LATIME_CONTROL;
            lblregizor.Text = "Regizorul filmului:";
            lblregizor.Top = 2 * DIMENSIUNE_PAS_Y;
            lblregizor.BackColor = Color.White;
            this.Controls.Add(lblregizor);

            // Adăugarea controlului de tip TextBox pentru 'Regizor film'
            txtregizor = new TextBox();
            txtregizor.Width = LATIME_CONTROL;
            txtregizor.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 2 * DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtregizor);


            // Adăugarea controlului de tip Label pentru 'Gen film'
            lblgen = new Label();
            lblgen.Width = LATIME_CONTROL;
            lblgen.Text = "Genul filmului:";
            lblgen.Top = 3 * DIMENSIUNE_PAS_Y;
            lblgen.BackColor = Color.White;
            this.Controls.Add(lblgen);

            // Adăugarea controlului de tip TextBox pentru 'Gen film'
            txtgen = new TextBox();
            txtgen.Width = LATIME_CONTROL;
            txtgen.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 3 * DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtgen);


            // Adăugarea controlului de tip Label pentru 'Durata film'
            lbldurata = new Label();
            lbldurata.Width = LATIME_CONTROL;
            lbldurata.Text = "Durata filmului:";
            lbldurata.Top = 4 * DIMENSIUNE_PAS_Y;
            lbldurata.BackColor = Color.White;
            this.Controls.Add(lbldurata);

            // Adăugarea controlului de tip TextBox pentru 'Durata film'
            txtdurata = new TextBox();
            txtdurata.Width = LATIME_CONTROL;
            txtdurata.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 4 * DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtdurata);


            // Adăugarea controlului de tip Label pentru 'Lansare film'
            lbllansare = new Label();
            lbllansare.Width = LATIME_CONTROL;
            lbllansare.Text = "Anul lansarii filmului:";
            lbllansare.Top = 5 * DIMENSIUNE_PAS_Y;
            lbllansare.BackColor = Color.White;
            this.Controls.Add(lbllansare);

            // Adăugarea controlului de tip TextBox pentru 'Lansare film'
            txtlansare = new TextBox();
            txtlansare.Width = LATIME_CONTROL;
            txtlansare.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 5 * DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtlansare);


            // Adăugarea controlului de tip Button pentru adăugarea filmului
            btnAdauga = new Button();
            btnAdauga.Width = LATIME_CONTROL;
            btnAdauga.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 6 * DIMENSIUNE_PAS_Y);
            btnAdauga.Text = "Adaugă";
            btnAdauga.Click += OnButtonClicked;
            this.Controls.Add(btnAdauga);


            // Adăugarea unui label pentru afișarea informațiilor despre filmul adăugat
            lblFilm = new Label();
            lblFilm.Width = 215;
            lblFilm.Height = 100;
            lblFilm.Location = new System.Drawing.Point(DIMENSIUNE_PAS_Z, 8 * DIMENSIUNE_PAS_Y);
            lblFilm.BackColor = Color.LightBlue;
            lblFilm.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblFilm);



            // Adăugarea controlului de tip Label pentru 'Nume serial'
            lblnume1 = new Label();
            lblnume1.Width = LATIME_CONTROL;
            lblnume1.Text = "Numele serialului:";
            lblnume1.Top = DIMENSIUNE_PAS_Y;
            lblnume1.Left = 2 * DIMENSIUNE_PAS_X;
            lblnume1.BackColor = Color.White;
            this.Controls.Add(lblnume1);

            // Adăugarea controlului de tip TextBox pentru 'Nume serial'
            txtnume1 = new TextBox();
            txtnume1.Width = LATIME_CONTROL;
            txtnume1.Top = DIMENSIUNE_PAS_Y;
            txtnume1.Location = new System.Drawing.Point(3 * DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtnume1);


            // Adăugarea controlului de tip Label pentru 'Regizor serial'
            lblregizor1 = new Label();
            lblregizor1.Width = LATIME_CONTROL;
            lblregizor1.Text = "Regizorul serialului:";
            lblregizor1.Top = 2 * DIMENSIUNE_PAS_Y;
            lblregizor1.Left = 2 * DIMENSIUNE_PAS_X;
            lblregizor1.BackColor = Color.White;
            this.Controls.Add(lblregizor1);

            // Adăugarea controlului de tip TextBox pentru 'Regizor serial'
            txtregizor1 = new TextBox();
            txtregizor1.Width = LATIME_CONTROL;
            txtregizor1.Location = new System.Drawing.Point(3 * DIMENSIUNE_PAS_X, 2 * DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtregizor1);


            // Adăugarea controlului de tip Label pentru 'Gen serial'
            lblgen1 = new Label();
            lblgen1.Width = LATIME_CONTROL;
            lblgen1.Text = "Genul serialului:";
            lblgen1.Top = 3 * DIMENSIUNE_PAS_Y;
            lblgen1.Left = 2 * DIMENSIUNE_PAS_X;
            lblgen1.BackColor = Color.White;
            this.Controls.Add(lblgen1);

            // Adăugarea controlului de tip TextBox pentru 'Gen serial'
            txtgen1 = new TextBox();
            txtgen1.Width = LATIME_CONTROL;
            txtgen1.Location = new System.Drawing.Point(3 * DIMENSIUNE_PAS_X, 3 * DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtgen1);


            // Adăugarea controlului de tip Label pentru 'Durata serial'
            lbldurata1 = new Label();
            lbldurata1.Width = LATIME_CONTROL;
            lbldurata1.Text = "Durata unui episod:";
            lbldurata1.Top = 4 * DIMENSIUNE_PAS_Y;
            lbldurata1.Left = 2 * DIMENSIUNE_PAS_X;
            lbldurata1.BackColor = Color.White;
            this.Controls.Add(lbldurata1);

            // Adăugarea controlului de tip TextBox pentru 'Durata serial'
            txtdurata1 = new TextBox();
            txtdurata1.Width = LATIME_CONTROL;
            txtdurata1.Location = new System.Drawing.Point(3 * DIMENSIUNE_PAS_X, 4 * DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtdurata1);


            // Adăugarea controlului de tip Label pentru 'Lansare serial'
            lbllansare1 = new Label();
            lbllansare1.Width = LATIME_CONTROL;
            lbllansare1.Text = "Anul lansarii:";
            lbllansare1.Top = 5 * DIMENSIUNE_PAS_Y;
            lbllansare1.Left = 2 * DIMENSIUNE_PAS_X;
            lbllansare1.BackColor = Color.White;
            this.Controls.Add(lbllansare1);

            // Adăugarea controlului de tip TextBox pentru 'Lansare serial'
            txtlansare1 = new TextBox();
            txtlansare1.Width = LATIME_CONTROL;
            txtlansare1.Location = new System.Drawing.Point(3 * DIMENSIUNE_PAS_X, 5 * DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtlansare1);


            // Adăugarea controlului de tip Label pentru 'Episoade serial'
            lblepisoade1 = new Label();
            lblepisoade1.Width = LATIME_CONTROL;
            lblepisoade1.Text = "Nr. de episoade:";
            lblepisoade1.Top = 6 * DIMENSIUNE_PAS_Y;
            lblepisoade1.Left = 2 * DIMENSIUNE_PAS_X;
            lblepisoade1.BackColor = Color.White;
            this.Controls.Add(lblepisoade1);

            // Adăugarea controlului de tip TextBox pentru 'Episoade serial'
            txtepisoade1 = new TextBox();
            txtepisoade1.Width = LATIME_CONTROL;
            txtepisoade1.Location = new System.Drawing.Point(3 * DIMENSIUNE_PAS_X, 6 * DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtepisoade1);


            // Adăugarea controlului de tip Label pentru 'Sezoane serial'
            lblsezoane1 = new Label();
            lblsezoane1.Width = LATIME_CONTROL;
            lblsezoane1.Text = "Nr. de sezoane:";
            lblsezoane1.Top = 7 * DIMENSIUNE_PAS_Y;
            lblsezoane1.Left = 2 * DIMENSIUNE_PAS_X;
            lblsezoane1.BackColor = Color.White;
            this.Controls.Add(lblsezoane1);

            // Adăugarea controlului de tip TextBox pentru 'Sezoane serial'
            txtsezoane1 = new TextBox();
            txtsezoane1.Width = LATIME_CONTROL;
            txtsezoane1.Location = new System.Drawing.Point(3 * DIMENSIUNE_PAS_X, 7 * DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtsezoane1);



            // Adăugarea controlului de tip Button pentru adăugarea serialului
            btnAdauga1 = new Button();
            btnAdauga1.Width = LATIME_CONTROL;
            btnAdauga1.Location = new System.Drawing.Point(3 * DIMENSIUNE_PAS_X, 8 * DIMENSIUNE_PAS_Y);
            btnAdauga1.Text = "Adaugă";
            btnAdauga1.Click += OnButtonClicked;
            this.Controls.Add(btnAdauga1);

            // Adăugarea unui label pentru afișarea informațiilor despre serialul adăugat
            lblSerial = new Label();
            lblSerial.Width = 215;
            lblSerial.Height = 150;
            lblSerial.Location = new System.Drawing.Point(8 * DIMENSIUNE_PAS_Z, 10 * DIMENSIUNE_PAS_Y);
            lblSerial.BackColor = Color.LightBlue;
            lblSerial.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblSerial);


            // Închiderea aplicației când se închide formularul
            this.FormClosed += OnFormClosed;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            string numeFisier1 = ConfigurationManager.AppSettings["NumeFisier1"];
            string locatieFisierSolutie1 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier1 = locatieFisierSolutie1 + "\\" + numeFisier1;
            StocareFilmeFisier adminFilme = new StocareFilmeFisier(caleCompletaFisier1);

            string numeFisier2 = ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie2 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier2 = locatieFisierSolutie2 + "\\" + numeFisier2;
            StocareSerialeFisier adminSeriale = new StocareSerialeFisier(caleCompletaFisier2);

            if (sender == btnAdauga)
            {
                ok = 1;
                string nume = txtnume.Text;
                string regizor = txtregizor.Text;
                string gen = txtgen.Text;
                string durata1 = txtdurata.Text;
                float durata = Convert.ToInt32(durata1);
                string lansare1 = txtlansare.Text;
                int lansare = Convert.ToInt32(lansare1);
               /* 
                if(string.IsNullOrWhiteSpace(nume) && string.IsNullOrWhiteSpace(regizor) && string.IsNullOrWhiteSpace(gen) && !float.TryParse(txtdurata.Text, out durata) && !int.TryParse(txtlansare.Text, out lansare))
                {
                    MessageBox.Show("Câmpurile nu pot fi goale daca vrei sa adaugi un film!", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } 
               */
                if (string.IsNullOrWhiteSpace(nume))
                {
                    MessageBox.Show("Câmpul pentru numele filmului nu poate fi gol!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(regizor))
                {
                    MessageBox.Show("Câmpul pentru regizorul filmului nu poate fi gol!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(gen))
                {
                    MessageBox.Show("Câmpul pentru genul filmului nu poate fi gol!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!float.TryParse(txtdurata.Text, out durata))
                {
                    MessageBox.Show("Câmpul pentru durata filmului nu poate fi gol!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (durata < 0)
                {
                    MessageBox.Show("Durata unui film trebuie să fie mai mare ca zero.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(txtlansare.Text, out lansare))
                {
                    MessageBox.Show("Câmpul pentru anul lansarii filmului nu poate fi gol!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (lansare < 0)
                {
                    MessageBox.Show("Anul lansarii unui film trebuie să fie mai mare ca zero.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Film film = new Film(nume, regizor, gen, lansare, durata);
                adminFilme.AddFilm(film);

                // Afișarea informațiilor despre filmul adăugat
                lblFilm.Text = "Filmul adăugat: " + film.Info();

            }
            else if (sender == btnAdauga1)
            {
                ok = 2;
                string nume1 = txtnume1.Text;
                string regizor1 = txtregizor1.Text;
                string gen1 = txtgen1.Text;
                string durata1 = txtdurata1.Text;
                float durata = Convert.ToInt32(durata1);
                string lansare1 = txtlansare1.Text;
                int lansare = Convert.ToInt32(lansare1);
                string episoade1 = txtepisoade1.Text;
                int episoade = Convert.ToInt32(episoade1);
                string sezoane1 = txtsezoane1.Text;
                int sezoane = Convert.ToInt32(sezoane1);

                if (string.IsNullOrWhiteSpace(nume1))
                {
                    MessageBox.Show("Câmpul pentru numele serialului nu poate fi gol!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(regizor1))
                {
                    MessageBox.Show("Câmpul pentru regizorul serialului nu poate fi gol!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(gen1))
                {
                    MessageBox.Show("Câmpul pentru genul serialului nu poate fi gol!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!float.TryParse(txtdurata.Text, out durata))
                {
                    MessageBox.Show("Câmpul pentru durata unui episod din serial nu poate fi gol!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (durata < 0)
                {
                    MessageBox.Show("Durata unui episod din serial trebuie să fie mai mare ca zero.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(txtlansare.Text, out lansare))
                {
                    MessageBox.Show("Câmpul pentru anul lansarii serialului nu poate fi gol!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (lansare < 0)
                {
                    MessageBox.Show("Anul lansarii unui serial trebuie să fie mai mare ca zero.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(txtepisoade1.Text, out episoade))
                {
                    MessageBox.Show("Câmpul pentru numarul de episoade al serialului nu poate fi gol!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (episoade < 0)
                {
                    MessageBox.Show("Numarul de episoade al unui serial trebuie să fie mai mare ca zero.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(txtsezoane1.Text, out sezoane))
                {
                    MessageBox.Show("Câmpul pentru numarul de sezoane al serialului nu poate fi gol!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (sezoane < 0)
                {
                    MessageBox.Show("Numarul de sezoane al unui serial trebuie să fie mai mare sau egal ca unu.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Serial serial = new Serial(nume1, regizor1, gen1, lansare, durata, episoade, sezoane);
                adminSeriale.AddSerial(serial);

                // Afișarea informațiilor despre serialul adăugat
                lblSerial.Text = "Serialul adăugat: " + serial.Info();
            }
        }

        private void OnFormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
using System;
using Seriale;
using StocareFisier;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Filme_Seriale_UI_WindowsForms
{
    public partial class Form2 : Form
    {
        StocareSerialeFisier adminSeriale;

        private Label lblnume;
        private Label lblregizor;
        private Label lblgen;
        private Label lbldurata;
        private Label lbllansare;
        private Label lblepisoade;
        private Label lblsezoane;

        private Label[] lblsnume;
        private Label[] lblsregizor;
        private Label[] lblsgen;
        private Label[] lblsdurata;
        private Label[] lblslansare;
        private Label[] lblsepisoade;
        private Label[] lblssezoane;

        private Button btnRefresh;

        private const int LATIME_CONTROL = 120;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 120;

        public Form2()
        {
            InitializeComponent();
            string numeFisier2 = ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie2 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string caleCompletaFisier2 = locatieFisierSolutie2 + "\\" + numeFisier2;

            adminSeriale = new StocareSerialeFisier(caleCompletaFisier2);
            int nrSeriale = 0;

            Serial[] seriale = adminSeriale.GetSeriale(out nrSeriale);

            //setare proprietati
            this.Size = new Size(870, 300);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.DarkBlue;
            this.Text = "Informatii despre seriale";
            this.BackColor = Color.LightBlue;

            //adaugare control de tip Label pentru 'Nume';
            lblnume = new Label();
            lblnume.Width = LATIME_CONTROL;
            lblnume.Text = "Nume";
            lblnume.Left = DIMENSIUNE_PAS_X;
            lblnume.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblnume);

            //adaugare control de tip Label pentru 'Regizor';
            lblregizor = new Label();
            lblregizor.Width = LATIME_CONTROL;
            lblregizor.Text = "Regizor";
            lblregizor.Left = 2 * DIMENSIUNE_PAS_X;
            lblregizor.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblregizor);

            //adaugare control de tip Label pentru 'Gen';
            lblgen = new Label();
            lblgen.Width = LATIME_CONTROL;
            lblgen.Text = "Gen";
            lblgen.Left = 3 * DIMENSIUNE_PAS_X;
            lblgen.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblgen);

            //adaugare control de tip Label pentru 'Durata';
            lbldurata = new Label();
            lbldurata.Width = LATIME_CONTROL;
            lbldurata.Text = "Durata";
            lbldurata.Left = 4 * DIMENSIUNE_PAS_X;
            lbldurata.ForeColor = Color.DarkBlue;
            this.Controls.Add(lbldurata);

            //adaugare control de tip Label pentru 'Lansare';
            lbllansare = new Label();
            lbllansare.Width = LATIME_CONTROL;
            lbllansare.Text = "Lansare";
            lbllansare.Left = 5 * DIMENSIUNE_PAS_X;
            lbllansare.ForeColor = Color.DarkBlue;
            this.Controls.Add(lbllansare);

            //adaugare control de tip Label pentru 'Episoade';
            lblepisoade = new Label();
            lblepisoade.Width = LATIME_CONTROL;
            lblepisoade.Text = "Episoade";
            lblepisoade.Left = 6 * DIMENSIUNE_PAS_X;
            lblepisoade.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblepisoade);

            //adaugare control de tip Label pentru 'Sezoane';
            lblsezoane = new Label();
            lblsezoane.Width = LATIME_CONTROL;
            lblsezoane.Text = "Sezoane";
            lblsezoane.Left = 7 * DIMENSIUNE_PAS_X;
            lblsezoane.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblsezoane);

            //adaugare control de tip Refresh Button
            btnRefresh = new Button();
            btnRefresh.Width = LATIME_CONTROL;
            btnRefresh.ForeColor = Color.DarkBlue;
            btnRefresh.Location = new System.Drawing.Point((1 / 2) * DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y);
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += Form2_Load; ;
            this.Controls.Add(btnRefresh);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            AfiseazaSeriale();
        }

        private void AfiseazaSeriale()
        {
            Serial[] seriale = adminSeriale.GetSeriale(out int nrSeriale);

            lblsnume = new Label[nrSeriale];
            lblsregizor = new Label[nrSeriale];
            lblsgen = new Label[nrSeriale];
            lblsdurata = new Label[nrSeriale];
            lblslansare = new Label[nrSeriale];
            lblsepisoade = new Label[nrSeriale];
            lblssezoane = new Label[nrSeriale];

            int i = 0;
            foreach (Serial serial in seriale)
            {

                //adaugare control de tip Label pentru numele serialului
                lblsnume[i] = new Label();
                lblsnume[i].Width = LATIME_CONTROL;
                lblsnume[i].Text = serial.nume;
                lblsnume[i].ForeColor = Color.Blue;
                lblsnume[i].Left = DIMENSIUNE_PAS_X;
                lblsnume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsnume[i]);

                //adaugare control de tip Label pentru regizorul serialului
                lblsregizor[i] = new Label();
                lblsregizor[i].Width = LATIME_CONTROL;
                lblsregizor[i].Text = serial.regizor;
                lblsregizor[i].ForeColor = Color.Blue;
                lblsregizor[i].Left = 2 * DIMENSIUNE_PAS_X;
                lblsregizor[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsregizor[i]);

                //adaugare control de tip Label pentru genul serialului
                lblsgen[i] = new Label();
                lblsgen[i].Width = LATIME_CONTROL;
                lblsgen[i].Text = serial.genSerial;
                lblsgen[i].ForeColor = Color.Blue;
                lblsgen[i].Left = 3 * DIMENSIUNE_PAS_X;
                lblsgen[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsgen[i]);

                //adaugare control de tip Label pentru durata serialului
                lblsdurata[i] = new Label();
                lblsdurata[i].Width = LATIME_CONTROL;
                lblsdurata[i].Text = string.Join(" ", serial.durata);
                lblsdurata[i].ForeColor = Color.Blue;
                lblsdurata[i].Left = 4 * DIMENSIUNE_PAS_X;
                lblsdurata[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsdurata[i]);

                //adaugare control de tip Label pentru lansarea serialului
                lblslansare[i] = new Label();
                lblslansare[i].Width = LATIME_CONTROL;
                lblslansare[i].Text = string.Join(" ", serial.lansare);
                lblslansare[i].ForeColor = Color.Blue;
                lblslansare[i].Left = 5 * DIMENSIUNE_PAS_X;
                lblslansare[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblslansare[i]);

                //adaugare control de tip Label pentru episoadele serialului
                lblsepisoade[i] = new Label();
                lblsepisoade[i].Width = LATIME_CONTROL;
                lblsepisoade[i].Text = string.Join(" ", serial.episoade);
                lblsepisoade[i].ForeColor = Color.Blue;
                lblsepisoade[i].Left = 6 * DIMENSIUNE_PAS_X;
                lblsepisoade[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsepisoade[i]);

                //adaugare control de tip Label pentru sezoanele serialului
                lblssezoane[i] = new Label();
                lblssezoane[i].Width = LATIME_CONTROL;
                lblssezoane[i].Text = string.Join(" ", serial.sezoane);
                lblssezoane[i].ForeColor = Color.Blue;
                lblssezoane[i].Left = 7 * DIMENSIUNE_PAS_X;
                lblssezoane[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblssezoane[i]);
                i++;
            }



        }

    }
}
using System;
using Filme;
using StocareFisier;
using StocareDate;
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

    public partial class Form1 : Form
    {
        StocareFilmeFisier adminFilme;

        private Label lblnume;
        private Label lblregizor;
        private Label lblgen;
        private Label lbldurata;
        private Label lbllansare;

        private Label[] lblsnume;
        private Label[] lblsregizor;
        private Label[] lblsgen;
        private Label[] lblsdurata;
        private Label[] lblslansare;

        private Button btnRefresh;

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 120;

        public Form1()
        {
            InitializeComponent();
            string numeFisier1 = ConfigurationManager.AppSettings["NumeFisier1"];
            string locatieFisierSolutie1 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string caleCompletaFisier1 = locatieFisierSolutie1 + "\\" + numeFisier1;
            adminFilme = new StocareFilmeFisier(caleCompletaFisier1);
            int nrFilme = 0;

            Film[] filme = adminFilme.GetFilme(out nrFilme);

            //setare proprietati
            this.Size = new Size(620, 300);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.White;
            this.Text = "Informatii despre filme";
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

            //adaugare control de tip Refresh Button
            btnRefresh = new Button();
            btnRefresh.Width = LATIME_CONTROL;
            btnRefresh.ForeColor = Color.DarkBlue;
            btnRefresh.Location = new System.Drawing.Point((1/2)*DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y);
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += Form1_Load; ;
            this.Controls.Add(btnRefresh);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaFilme();
        }

        private void AfiseazaFilme()
        {
            Film[] filme = adminFilme.GetFilme(out int nrFilme);

            lblsnume = new Label[nrFilme];
            lblsregizor = new Label[nrFilme];
            lblsgen = new Label[nrFilme];
            lblsdurata = new Label[nrFilme];
            lblslansare = new Label[nrFilme];

            int i = 0;
            foreach (Film film in filme)
            {
                //adaugare control de tip Label pentru numele filmului
                lblsnume[i] = new Label();
                lblsnume[i].Width = LATIME_CONTROL;
                lblsnume[i].Text = film.nume;
                lblsnume[i].ForeColor = Color.Blue;
                lblsnume[i].Left = DIMENSIUNE_PAS_X;
                lblsnume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsnume[i]);

                //adaugare control de tip Label pentru regizorul filmului
                lblsregizor[i] = new Label();
                lblsregizor[i].Width = LATIME_CONTROL;
                lblsregizor[i].Text = film.regizor;
                lblsregizor[i].ForeColor = Color.Blue;
                lblsregizor[i].Left = 2 * DIMENSIUNE_PAS_X;
                lblsregizor[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsregizor[i]);

                //adaugare control de tip Label pentru genul filmului
                lblsgen[i] = new Label();
                lblsgen[i].Width = LATIME_CONTROL;
                lblsgen[i].Text = film.genFilm;
                lblsgen[i].ForeColor = Color.Blue;
                lblsgen[i].Left = 3 * DIMENSIUNE_PAS_X;
                lblsgen[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsgen[i]);

                //adaugare control de tip Label pentru durata filmului
                lblsdurata[i] = new Label();
                lblsdurata[i].Width = LATIME_CONTROL;
                lblsdurata[i].Text = string.Join(" ", film.durata);
                lblsdurata[i].ForeColor = Color.Blue;
                lblsdurata[i].Left = 4 * DIMENSIUNE_PAS_X;
                lblsdurata[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsdurata[i]);

                //adaugare control de tip Label pentru lansarea filmului
                lblslansare[i] = new Label();
                lblslansare[i].Width = LATIME_CONTROL;
                lblslansare[i].Text = string.Join(" ", film.lansare);
                lblslansare[i].ForeColor = Color.Blue;
                lblslansare[i].Left = 5 * DIMENSIUNE_PAS_X;
                lblslansare[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblslansare[i]);
                i++;

            }

        }
    }

}
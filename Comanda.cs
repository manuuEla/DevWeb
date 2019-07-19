using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace Delicious_
{
	public partial class Comanda : Form
	{
		OdbcConnection conexiune;
		OdbcDataReader cititor;
		DataSet dsDate;
		int nrTotalInreg;
		int cantitate1, cantitate2, cantitate3, cantitate4, cantitate5;
		int pret1, pret2, pret3, pret4, pret5;
		int total1, total2, total3, total4, total5;

		private void cboBauturi_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				int n = cboBauturi.SelectedIndex;
				txtPretBautura.Text = dsDate.Tables["Bauturi"].Rows[n].ItemArray[1].ToString();

			}
			catch (OdbcException eroare)
			{
				MessageBox.Show(" A aparut o problema :" + eroare.Message.ToString());

			}
		}

		private void cboSosuri_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				int n = cboSosuri.SelectedIndex;
				txtPretSos.Text = dsDate.Tables["Sosuri"].Rows[n].ItemArray[2].ToString();
			}
			catch (OdbcException eroare)
			{
				MessageBox.Show(" A aparut o problema :" + eroare.Message.ToString());

			}
		}

		private void btnComandaFinala_Click(object sender, EventArgs e)
		{
			try
			{
				OdbcCommand comanda = new OdbcCommand();
				comanda.CommandText = "INSERT INTO comanda (idComanda,idClient,numePrenumeClient,adresaLivrare,numeProdus,nume_salata,nume_bautura,nume_desert,nume_sos) VALUES (?,?,?,?,?,?,?,?,?)";
				comanda.Connection = conexiune;
				comanda.Parameters.Clear();
				comanda.Parameters.AddWithValue("idComanda", txtIdComanda.Text.ToString());
				comanda.Parameters.AddWithValue("idClient", txtIdClient.Text.ToString());
				comanda.Parameters.AddWithValue("numePrenumeClient", txtNumeClient.Text.ToString());
				comanda.Parameters.AddWithValue("adresaLivrare", txtAdresa.Text.ToString());
				comanda.Parameters.AddWithValue("numeProdus", cboMeniu.SelectedValue.ToString());
				comanda.Parameters.AddWithValue("nume_salata", cboSalate.SelectedValue.ToString());
				comanda.Parameters.AddWithValue("nume_bautura", cboBauturi.SelectedValue.ToString());
				comanda.Parameters.AddWithValue("nume_desert", cboDeserturi.SelectedValue.ToString());
				comanda.Parameters.AddWithValue("nume_sos", cboSosuri.SelectedValue.ToString());

				comanda.ExecuteNonQuery();
				MessageBox.Show("Comanda dumneavoastra: " + Environment.NewLine + textBox1.Text + Environment.NewLine + textBox2 + Environment.NewLine + textBox3 + Environment.NewLine + textBox4 + Environment.NewLine + textBox5 + Environment.NewLine + " TOTAL: " + txtPretFinal.Text + " RON");
				MessageBox.Show("Comanda a fost procesata!");
			}
			catch (OdbcException eroare)
			{
				MessageBox.Show("A aparut eroarea nr. " + eroare.ErrorCode.ToString() + " cu mesajul " +
				eroare.Message.ToString());
				if (conexiune.State == ConnectionState.Open)
					conexiune.Close();
			}
		}

		private void btnSalate_Click(object sender, EventArgs e)
		{
			if (txtportiiSalate.Text == "")
			{
				cantitate4 = 0;
			}
			else
			{
				cantitate4 = Int32.Parse(txtportiiSalate.Text);
			}
			pret4 = int.Parse(txtPretSalate.Text);
			total4 = cantitate4 * pret4;
			txtSalate.Text = total4.ToString();
			txtPretFinal.Text = (total1 + total2 + total3 + total4 + total5).ToString();
			textBox4.Text = "Ati selectat: " + Environment.NewLine + cboSalate.Text + " x " + txtportiiSalate.Text;

		}

		private void btnBauturi_Click(object sender, EventArgs e)
		{
			if (txtportiiBautura.Text == "")
			{
				cantitate2 = 0;
			}
			else
			{
				cantitate2 = Int32.Parse(txtportiiBautura.Text);
			}
			pret2 = int.Parse(txtPretBautura.Text);
			total2 = cantitate2 * pret2;
			txtBauturi.Text = total2.ToString();
			txtPretFinal.Text = (total1 + total2 + total3 + total4 + total5).ToString();
			textBox2.Text = "Ati selectat: " + Environment.NewLine + cboBauturi.Text + " x " + txtportiiBautura.Text;

		}

		private void btnDeserturi_Click(object sender, EventArgs e)
		{
			if (txtportiiDeserturi.Text == "")
			{
				cantitate3 = 0;
			}
			else
			{
				cantitate3 = Int32.Parse(txtportiiDeserturi.Text);
			}
			pret3 = int.Parse(txtPretDesert.Text);
			total3 = cantitate3 * pret3;
			txtDeserturi.Text = total3.ToString();
			txtPretFinal.Text = (total1 + total2 + total3 + total4 + total5).ToString();
			textBox3.Text = "Ati selectat: " + Environment.NewLine + cboDeserturi.Text + " x " + txtportiiDeserturi.Text;

		}

		private void btnSosuri_Click(object sender, EventArgs e)
		{
			if (txtportiiSosuri.Text == "")
			{
				cantitate5 = 0;
			}
			else
			{
				cantitate5 = Int32.Parse(txtportiiSosuri.Text);
			}
			pret5 = int.Parse(txtPretSos.Text);
			total5 = cantitate5 * pret5;
			txtSosuri.Text = total5.ToString();
			txtPretFinal.Text = (total1 + total2 + total3 + total4 + total5).ToString();
			textBox5.Text = "Ati selectat: " + Environment.NewLine + cboSosuri.Text + " x " + txtportiiSosuri.Text;

		}

		private void btnMeniu_Click(object sender, EventArgs e)
		{
			if (txtportiiMeniu.Text == "")
			{
				cantitate1 = 0;
			}
			else
			{
				cantitate1 = Int32.Parse(txtportiiMeniu.Text);
			}
			pret1 = int.Parse(txtPretMeniu.Text);
			total1 = cantitate1 * pret1;
			txtMeniu.Text = total1.ToString();
			txtPretFinal.Text = (total1 + total2 + total3 + total4 + total5).ToString();

			textBox1.Text = "Ati Selectat: " + Environment.NewLine + cboMeniu.Text + " cu " + cboLipii.Text + " x " + txtportiiMeniu.Text + " bucati ";
			txtPretFinal.Text = (total1 + total2 + total3 + total4).ToString();

		}

		private void cboSalate_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				int n = cboSalate.SelectedIndex;
				txtPretSalate.Text = dsDate.Tables["Salate"].Rows[n].ItemArray[1].ToString();

			}
			catch (OdbcException eroare)
			{
				MessageBox.Show(" A aparut o problema :" + eroare.Message.ToString());
			}
		}

		private void cboDeserturi_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtPretFinal.Text = (total1 + total2 + total3 + total4 + total5).ToString();
			try
			{
				int n = cboDeserturi.SelectedIndex;
				txtPretDesert.Text = dsDate.Tables["Desert"].Rows[n].ItemArray[1].ToString();

			}
			catch (OdbcException eroare)
			{
				MessageBox.Show(" A aparut o problema :" + eroare.Message.ToString());

			}
		}

		private void cboMeniu_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtPretFinal.Text = (total1 + total2 + total3 + total4 + total5).ToString();
			try
			{
				int n = cboMeniu.SelectedIndex;
				txtPretMeniu.Text = dsDate.Tables["MENIU"].Rows[n].ItemArray[1].ToString();

			}
			catch (OdbcException eroare)
			{
				MessageBox.Show(" A aparut o problema :" + eroare.Message.ToString());

			}
		}

		DateTime CurrTime = DateTime.Now;



		public Comanda()
		{
			InitializeComponent();
		}

		private void deschideConexiune()
		{
			try
			{
				conexiune = new OdbcConnection();
				conexiune.ConnectionString = "Driver={PostgreSQL ANSI};database=practica;server=localhost;port=5432;uid=postgres;pwd=petrea;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;lfconversion=1;updatablecursors=1;trueisminus1=0;bi=0;byteaaslongvarbinary=1;useserversideprepare=1;lowercaseidentifier=0;xaopt=1;";
				conexiune.Open();
				//MessageBox.Show("S-a deschis conexiunea!");
				OdbcCommand comanda;
				comanda = new OdbcCommand();
				comanda.Connection = conexiune;
				comanda.CommandText = "SELECT * FROM comanda";

				cititor = comanda.ExecuteReader();

				DataTable tblComanda;
				tblComanda = new DataTable("Comanda");
				tblComanda.Load(cititor);
				dsDate = new DataSet();
				dsDate.Tables.Add(tblComanda);
				nrTotalInreg = dsDate.Tables["Comanda"].Rows.Count;

			}
			catch (OdbcException eroare)
			{
				MessageBox.Show("A aparut eroarea nr. " + eroare.ErrorCode.ToString() + " cu mesajul " +
				eroare.Message.ToString());
				if (conexiune.State == ConnectionState.Open)
					conexiune.Close();
			}

		}

		private void populeazaMeniu()
		{
			OdbcCommand comanda;
			comanda = new OdbcCommand();
			comanda.Connection = conexiune;
			comanda.CommandText = "SELECT denumirepr, pret FROM meniu ORDER BY denumirepr ASC";
			OdbcDataReader cititor;
			cititor = comanda.ExecuteReader();
			DataTable tblComMeniu;
			tblComMeniu = new DataTable("MENIU");
			tblComMeniu.Load(cititor);
			dsDate.Tables.Add(tblComMeniu);
			cboMeniu.DataSource = dsDate.Tables["MENIU"];
			cboMeniu.DisplayMember = "denumirepr";
			cboMeniu.ValueMember = "denumirepr";
		}

		
		private void populeazaLipie()
		{
			OdbcCommand comanda;
			comanda = new OdbcCommand();
			comanda.Connection = conexiune;
			comanda.CommandText = "SELECT distinct tiplipie FROM lipie";
			OdbcDataReader cititor;
			cititor = comanda.ExecuteReader();
			DataTable tblLipie;
			tblLipie = new DataTable("Lipii");
			tblLipie.Load(cititor);
			dsDate.Tables.Add(tblLipie);
			cboLipii.DataSource = dsDate.Tables["Lipii"];
			cboLipii.DisplayMember = "tiplipie";
			cboLipii.ValueMember = "tiplipie";
		}

		private void populeazaBauturi()
		{
			OdbcCommand comanda;
			comanda = new OdbcCommand();
			comanda.Connection = conexiune;
			comanda.CommandText = "SELECT numeBautura, Pret FROM bauturi";
			OdbcDataReader cititor;
			cititor = comanda.ExecuteReader();
			DataTable tblBauturiAlcoolice;
			tblBauturiAlcoolice = new DataTable("Bauturi");
			tblBauturiAlcoolice.Load(cititor);
			dsDate.Tables.Add(tblBauturiAlcoolice);
			cboBauturi.DataSource = dsDate.Tables["Bauturi"];
			cboBauturi.DisplayMember = "NumeBautura";
			cboBauturi.ValueMember = "NumeBautura";
		}

		private void populeazaSosuri()
		{
			try
			{
				OdbcCommand comanda;
				comanda = new OdbcCommand();
				comanda.Connection = conexiune;
				comanda.CommandText = "SELECT * FROM sosuri";

				OdbcDataReader cititor;
				cititor = comanda.ExecuteReader();

				DataTable tblSosuri;
				tblSosuri = new DataTable("Sosuri");
				tblSosuri.Load(cititor);
				dsDate.Tables.Add(tblSosuri);

				cboSosuri.DataSource = dsDate.Tables["Sosuri"];
				cboSosuri.DisplayMember = "denumireSos";
				cboSosuri.ValueMember = "denumireSos";
			}
			catch (OdbcException eroare)
			{
				MessageBox.Show("A aparut o problema :" + eroare.Message.ToString());
				if (conexiune.State == ConnectionState.Open)
					conexiune.Close();

			}
		}

		private void dezactiveazaCasetaText()
		{
			txtPretMeniu.Enabled = false;
			txtPretSalate.Enabled = false;
			txtPretBautura.Enabled = false;
			txtPretDesert.Enabled = false;
			txtPretSos.Enabled = false;
			txtPretFinal.Enabled = false;
			txtBauturi.Enabled = false;
			txtDeserturi.Enabled = false;
			txtSalate.Enabled = false;
			txtMeniu.Enabled = false;
			txtSosuri.Enabled = false;
		}

		private void populeazaSalate()
		{
			OdbcCommand comanda;
			comanda = new OdbcCommand();
			comanda.Connection = conexiune;
			comanda.CommandText = "SELECT numeSalata, pret FROM salate";
			OdbcDataReader cititor;
			cititor = comanda.ExecuteReader();
			DataTable tblSalate;
			tblSalate = new DataTable("Salate");
			tblSalate.Load(cititor);
			dsDate.Tables.Add(tblSalate);
			cboSalate.DataSource = dsDate.Tables["Salate"];
			cboSalate.DisplayMember = "numeSalata";
			cboSalate.ValueMember = "numeSalata";
		}

		private void populeazaDeserturi()
		{
			OdbcCommand comanda;
			comanda = new OdbcCommand();
			comanda.Connection = conexiune;
			comanda.CommandText = "SELECT denumireDesert, pret FROM deserturi";
			OdbcDataReader cititor;
			cititor = comanda.ExecuteReader();
			DataTable tblDesert;
			tblDesert = new DataTable("Desert");
			tblDesert.Load(cititor);
			dsDate.Tables.Add(tblDesert);
			cboDeserturi.DataSource = dsDate.Tables["Desert"];
			cboDeserturi.DisplayMember = "denumireDesert";
			cboDeserturi.ValueMember = "denumireDesert";
		}
		private void Comanda_Load(object sender, EventArgs e)
		{
			this.deschideConexiune();
			this.populeazaMeniu();
			this.populeazaSalate();
			this.populeazaBauturi();
			this.populeazaDeserturi();
			this.dezactiveazaCasetaText();
			this.populeazaSosuri();
			this.populeazaLipie();
		}
	}
}

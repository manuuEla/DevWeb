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
	public partial class FormSalata : Form
	{
		public FormSalata()
		{
			InitializeComponent();
		}

		private void FormSalata_Load(object sender, EventArgs e)
		{

			OdbcConnection conexiune;
			conexiune = new OdbcConnection();
			conexiune.ConnectionString = "Driver={PostgreSQL ANSI};database=practica;server=localhost;port=5432;uid=postgres;pwd=petrea;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;lfconversion=1;updatablecursors=1;trueisminus1=0;bi=0;byteaaslongvarbinary=1;useserversideprepare=1;lowercaseidentifier=0;xaopt=1;";
			conexiune.Open();

			OdbcCommand comanda;
			comanda = new OdbcCommand();
			comanda.CommandText = "SELECT * FROM salate";
			comanda.Connection = conexiune;

			OdbcDataReader cititor;
			cititor = comanda.ExecuteReader();

			DataSet dsDate;
			dsDate = new DataSet();

			DataTable tblSalate;
			tblSalate = new DataTable("ComandaSalate");
			tblSalate.Load(cititor);
			dsDate.Tables.Add(tblSalate);

			this.cboSalate.DataSource = dsDate.Tables["ComandaSalate"];
			this.cboSalate.DisplayMember = "numesalata";
			this.cboSalate.ValueMember = "numesalata";
			conexiune.Close();
		}

		private void cboSalate_SelectedIndexChanged(object sender, EventArgs e)
		{
			OdbcConnection conexiune;
			OdbcCommand comanda;
			DataSet dsDate;
			OdbcDataReader cititor;
			DataTable tblSalate;

			conexiune = new OdbcConnection();
			conexiune.ConnectionString = "Driver={PostgreSQL ANSI};database=practica;server=localhost;port=5432;uid=postgres;pwd=petrea;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;lfconversion=1;updatablecursors=1;trueisminus1=0;bi=0;byteaaslongvarbinary=1;useserversideprepare=1;lowercaseidentifier=0;xaopt=1;";
			conexiune.Open();

			comanda = new OdbcCommand();
			comanda.CommandText = "SELECT * FROM salate WHERE numesalata=?";
			comanda.Connection = conexiune;

			comanda.Parameters.Clear();
			comanda.Parameters.AddWithValue("@idsalata", cboSalate.SelectedValue.ToString());

			cititor = comanda.ExecuteReader();

			tblSalate = new DataTable("ComenziSalate");
			tblSalate.Load(cititor);
			lblTotal.Visible = true;
			dsDate = new DataSet();
			dsDate.Tables.Add(tblSalate);


			grdSalate.DataSource = dsDate;
			grdSalate.DataMember = "ComenziSalate";
			grdSalate.Refresh();
		}

		private void grdSalate_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			OdbcConnection conexiune;
			OdbcCommand comanda;
			DataSet dsDate;
			OdbcDataReader cititor;
			DataTable tblClienti;

			conexiune = new OdbcConnection();
			conexiune.ConnectionString = "Driver={PostgreSQL ANSI};database=practica;server=localhost;port=5432;uid=postgres;pwd=petrea;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;lfconversion=1;updatablecursors=1;trueisminus1=0;bi=0;byteaaslongvarbinary=1;useserversideprepare=1;lowercaseidentifier=0;xaopt=1;";
			conexiune.Open();
			comanda = new OdbcCommand();
			comanda.CommandText = "SELECT * FROM comanda WHERE idSalata=?";
			comanda.Connection = conexiune;

			int pidSalata;
			pidSalata = Int32.Parse(grdSalate.CurrentRow.Cells[0].FormattedValue.ToString());
			comanda.Parameters.Clear();
			comanda.Parameters.AddWithValue("@idsalate", pidSalata);
			cititor = comanda.ExecuteReader();
			tblClienti = new DataTable("SalateComandate");
			tblClienti.Load(cititor);
			dsDate = new DataSet();
			dsDate.Tables.Add(tblClienti);

			grdComandaClienti.DataSource = dsDate;
			grdComandaClienti.DataMember = "SalateComandate";
			grdComandaClienti.Refresh();
			lblTotal.Text = "Total persoane ce au comandat salate = " + dsDate.Tables["SalateComandate"].Rows.Count.ToString();
			conexiune.Close();
		}
	}
}

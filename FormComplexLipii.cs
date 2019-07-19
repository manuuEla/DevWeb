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
	public partial class FormComplexLipii : Form
	{
		public FormComplexLipii()
		{
			InitializeComponent();
		}

		private void FormComplexLipii_Load(object sender, EventArgs e)
		{
			OdbcConnection conexiune;
			conexiune = new OdbcConnection();
			conexiune.ConnectionString = "Driver={PostgreSQL ANSI};database=practica;server=localhost;port=5432;uid=postgres;pwd=petrea;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;lfconversion=1;updatablecursors=1;trueisminus1=0;bi=0;byteaaslongvarbinary=1;useserversideprepare=1;lowercaseidentifier=0;xaopt=1;";
			conexiune.Open();

			OdbcCommand comanda;
			comanda = new OdbcCommand();
			comanda.CommandText = "SELECT * FROM lipie";
			comanda.Connection = conexiune;

			OdbcDataReader cititor;
			cititor = comanda.ExecuteReader();

			DataSet dsDate;
			dsDate = new DataSet();

			DataTable tblLipie;
			tblLipie = new DataTable("ComandaLipie");
			tblLipie.Load(cititor);
			dsDate.Tables.Add(tblLipie);

			this.cboLipie.DataSource = dsDate.Tables["ComandaLipie"];
			this.cboLipie.DisplayMember = "tiplipie";
			this.cboLipie.ValueMember = "tiplipie";
			conexiune.Close();

		}

		private void cboLipii_SelectedIndexChanged(object sender, EventArgs e)
		{
			OdbcConnection conexiune;
			OdbcCommand comanda;
			DataSet dsDate;
			OdbcDataReader cititor;
			DataTable tblLipie;

			conexiune = new OdbcConnection();
			conexiune.ConnectionString = "Driver={PostgreSQL ANSI};database=practica;server=localhost;port=5432;uid=postgres;pwd=petrea;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;lfconversion=1;updatablecursors=1;trueisminus1=0;bi=0;byteaaslongvarbinary=1;useserversideprepare=1;lowercaseidentifier=0;xaopt=1;";
			conexiune.Open();

			comanda = new OdbcCommand();
			comanda.CommandText = "SELECT * FROM Lipie WHERE tiplipie=?";
			comanda.Connection = conexiune;

			comanda.Parameters.Clear();
			comanda.Parameters.AddWithValue("@idlipie", cboLipie.SelectedValue.ToString());

			cititor = comanda.ExecuteReader();

			tblLipie = new DataTable("ComenziLipie");
			tblLipie.Load(cititor);
			lblTotal.Visible = true;
			dsDate = new DataSet();
			dsDate.Tables.Add(tblLipie);


			grdLipie.DataSource = dsDate;
			grdLipie.DataMember = "Comenzilipie";
			grdLipie.Refresh();
		}

	

		private void grdLipii_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			OdbcConnection conexiune;
			OdbcCommand comanda;
			DataSet dsDate;
			OdbcDataReader cititor;
			DataTable tblPersoane;

			conexiune = new OdbcConnection();
			conexiune.ConnectionString = "Driver={PostgreSQL ANSI};database=practica;server=localhost;port=5432;uid=postgres;pwd=petrea;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;lfconversion=1;updatablecursors=1;trueisminus1=0;bi=0;byteaaslongvarbinary=1;useserversideprepare=1;lowercaseidentifier=0;xaopt=1;";
			conexiune.Open();
			comanda = new OdbcCommand();
			comanda.CommandText = "SELECT * FROM comanda WHERE idlipie=?";
			comanda.Connection = conexiune;

			int cidLipie;
			cidLipie = Int32.Parse(grdLipie.CurrentRow.Cells[0].FormattedValue.ToString());
			comanda.Parameters.Clear();
			comanda.Parameters.AddWithValue("@idlipie", cidLipie);
			cititor = comanda.ExecuteReader();
			tblPersoane = new DataTable("LipiiComandate");
			tblPersoane.Load(cititor);
			dsDate = new DataSet();
			dsDate.Tables.Add(tblPersoane);

			grdComandaPersoane.DataSource = dsDate;
			grdComandaPersoane.DataMember = "LipiiComandate";
			grdComandaPersoane.Refresh();
			lblTotal.Text = "Total persoane ce au comandat lipie " + dsDate.Tables["LipiiComandate"].Rows.Count.ToString();
			conexiune.Close();
		}

		private void lblTotal_Click(object sender, EventArgs e)
		{

		}
	}
}

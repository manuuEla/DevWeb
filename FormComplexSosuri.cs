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
	public partial class FormComplexSosuri : Form
	{
		public FormComplexSosuri()
		{
			InitializeComponent();
		}

		private void FormComplexSosuri_Load(object sender, EventArgs e)
		{
			OdbcConnection conexiune;
			conexiune = new OdbcConnection();
			conexiune.ConnectionString = "Driver={PostgreSQL ANSI};database=practica;server=localhost;port=5432;uid=postgres;pwd=petrea;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;lfconversion=1;updatablecursors=1;trueisminus1=0;bi=0;byteaaslongvarbinary=1;useserversideprepare=1;lowercaseidentifier=0;xaopt=1;";
			conexiune.Open();

			OdbcCommand comanda;
			comanda = new OdbcCommand();
			comanda.CommandText = "SELECT * FROM sosuri";
			comanda.Connection = conexiune;

			OdbcDataReader cititor;
			cititor = comanda.ExecuteReader();

			DataSet dsDate;
			dsDate = new DataSet();

			DataTable tblSos;
			tblSos = new DataTable("ComandaSos");
			tblSos.Load(cititor);
			dsDate.Tables.Add(tblSos);

			this.cboSos.DataSource = dsDate.Tables["ComandaSos"];
			this.cboSos.DisplayMember = "denumiresos";
			this.cboSos.ValueMember = "denumiresos";
			conexiune.Close();
		}

		private void cboSos_SelectedIndexChanged(object sender, EventArgs e)
		{
			OdbcConnection conexiune;
			OdbcCommand comanda;
			DataSet dsDate;
			OdbcDataReader cititor;
			DataTable tblSos;

			conexiune = new OdbcConnection();
			conexiune.ConnectionString = "Driver={PostgreSQL ANSI};database=practica;server=localhost;port=5432;uid=postgres;pwd=petrea;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;lfconversion=1;updatablecursors=1;trueisminus1=0;bi=0;byteaaslongvarbinary=1;useserversideprepare=1;lowercaseidentifier=0;xaopt=1;";
			conexiune.Open();

			comanda = new OdbcCommand();
			comanda.CommandText = "SELECT * FROM sosuri WHERE denumiresos=?";
			comanda.Connection = conexiune;

			comanda.Parameters.Clear();
			comanda.Parameters.AddWithValue("@idsos", cboSos.SelectedValue.ToString());

			cititor = comanda.ExecuteReader();

			tblSos = new DataTable("ComenziSos");
			tblSos.Load(cititor);
			lblTotal.Visible = true;
			dsDate = new DataSet();
			dsDate.Tables.Add(tblSos);


			grdSos.DataSource = dsDate;
			grdSos.DataMember = "ComenziSos";
			grdSos.Refresh();
		}

		private void grdSos_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
			comanda.CommandText = "SELECT * FROM comanda WHERE idsos=?";
			comanda.Connection = conexiune;

			int cidSos;
			cidSos = Int32.Parse(grdSos.CurrentRow.Cells[0].FormattedValue.ToString());
			comanda.Parameters.Clear();
			comanda.Parameters.AddWithValue("@idsos", cidSos);
			cititor = comanda.ExecuteReader();
			tblPersoane = new DataTable("SosuriComandate");
			tblPersoane.Load(cititor);
			dsDate = new DataSet();
			dsDate.Tables.Add(tblPersoane);

			grdComandaPersoane.DataSource = dsDate;
			grdComandaPersoane.DataMember = "SosuriComandate";
			grdComandaPersoane.Refresh();
			lblTotal.Text = "Total persoane ce au comandat sos = " + dsDate.Tables["SosuriComandate"].Rows.Count.ToString();
			conexiune.Close();
		}
	}
}

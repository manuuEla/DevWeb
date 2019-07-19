using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.Odbc;

namespace Delicious
{
    public partial class FormComplexClienti : Form
    {
        OdbcCommand comanda;
        OdbcConnection conexiune;
        DataSet dsDateMeniu, dsDateClienti, dsDateComanda;
        public FormComplexClienti()
        {
            InitializeComponent();
        }

        private void FormComplexClienti_Load(object sender, EventArgs e)
        {
            populeazaMeniu();
        }


        private void populeazaMeniu()
        {
            conexiune = new OdbcConnection();
            conexiune.ConnectionString = "Driver={PostgreSQL ANSI};database=restaurant;server=localhost;port=5432;uid=postgres;pwd=651*sql;sslmode=disable;readonly=0;protocol=7.4;fakeoidindex=0;showoidcolumn=0;rowversioning=0;showsystemtables=0;fetch=100;unknownsizes=0;maxvarcharsize=255;maxlongvarcharsize=8190;debug=0;commlog=0;usedeclarefetch=0;textaslongvarchar=1;unknownsaslongvarchar=0;boolsaschar=1;parse=0;lfconversion=1;updatablecursors=1;trueisminus1=0;bi=0;byteaaslongvarbinary=1;useserversideprepare=1;lowercaseidentifier=0;xaopt=1;";
            conexiune.Open();
            OdbcDataReader cititor;
            cititor = comanda.ExecuteReader();
            DataTable tblMeniu;
            tblMeniu = new DataTable("Meniu");
            tblMeniu.Load(cititor);
            dsDateMeniu = new DataSet();
            dsDateMeniu.Tables.Add(tblMeniu);
            cboMeniu.DataSource = dsDateMeniu.Tables["Meniu"];
            cboMeniu.DisplayMember = "denumirePr";
            cboMeniu.ValueMember = "idProdus";
            cboMeniu.Refresh();
        }

        private void grdComanda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboMeniu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idProdusSelectat;
            idProdusSelectat = cboMeniu.SelectedValue.ToString();
            comanda = new OdbcCommand();
            comanda.CommandText = "SELECT * FROM comanda WHERE idProdus=? ORDER BY numeprenumeClient";
            comanda.Connection = conexiune;

            comanda.Parameters.AddWithValue("idProdus", idProdusSelectat);
            OdbcDataReader cititor;
            cititor = comanda.ExecuteReader();

            DataTable tblComanda;
            tblComanda = new DataTable("Comanda");
            tblComanda.Load(cititor);

            dsDateComanda = new DataSet();
            dsDateComanda.Tables.Add(tblComanda);

            grdClienti.DataMember = null;
            grdClienti.Refresh();

            grdComanda.DataSource = dsDateComanda;
            grdComanda.DataMember = "Comanda";

            grdComanda.Refresh();

            lblComanda.Text = "Nr comenzi = " + dsDateComanda.Tables["Comanda"].Rows.Count.ToString();
        }

        private void grdComanda_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //curat gridul cu facturi 
            grdClienti.DataMember = null;
            grdClienti.Refresh();
            //MessageBox.Show("Te-ai deplasat in grid");
            //obtin valoarea codului client (de pe prima celula) de pe linia curent selectata 
            //din grid          
            int idClientCurent;
            idClientCurent = Int32.Parse(grdClienti.CurrentRow.Cells[0].FormattedValue.ToString());
            // MessageBox.Show("Codul clientului selectat este " + codClientCurent);    
            // MessageBox.Show(grdClienti.RowCount.ToString());                     
            comanda = new OdbcCommand();
            comanda.CommandText = "SELECT * FROM clienti WHERE idClient=?";
            comanda.Connection = conexiune;

            comanda.Parameters.AddWithValue("idClient", idClientCurent);

            //definesc cititor (reader) 
            OdbcDataReader cititor;
            cititor = comanda.ExecuteReader();

            //definim o tabela "locala"   
            DataTable tblClienti;
            tblClienti = new DataTable("Clienti");
            tblClienti.Load(cititor);

            dsDateClienti = new DataSet();
            dsDateClienti.Tables.Add(tblClienti);

            //stabilesc sursa de date pentru gridul cu clienti  
            grdClienti.DataSource = dsDateClienti;
            grdClienti.DataMember = "Clienti";
            grdClienti.Refresh();

            //actualizare eticheta cu suma totala a facturilor emise clientului curent selectat   

            comanda.CommandText = "SELECT SUM(portiimeniu*pret) AS total FROM comanda c INNER JOIN meniu m ON c.idProdus=m.idProdus INNER JOIN clienti cl ON c.idClient=cl.idClient WHERE cl.idClient=?";
            comanda.Parameters.Clear();
            comanda.Parameters.AddWithValue("idClient", idClientCurent);
            cititor = comanda.ExecuteReader();

            //definim o tabela "locala"      
            DataTable tblTotalClienti;
            tblTotalClienti = new DataTable("TOTALCLIENTI");
            tblTotalClienti.Load(cititor);

            dsDateClienti = new DataSet();
            dsDateClienti.Tables.Add(tblTotalClienti);

            lblClienti.Text = "Total clienti = " + dsDateClienti.Tables["TOTALCLIENTI"].Rows[0].ItemArray[0].ToString();
        }

    }
}
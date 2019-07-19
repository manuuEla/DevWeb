namespace Delicious
{
    partial class FormComplexClienti
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMeniu = new System.Windows.Forms.Label();
            this.cboMeniu = new System.Windows.Forms.ComboBox();
            this.grdClienti = new System.Windows.Forms.DataGridView();
            this.grdComanda = new System.Windows.Forms.DataGridView();
            this.lblClienti = new System.Windows.Forms.Label();
            this.lblComanda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdClienti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdComanda)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMeniu
            // 
            this.lblMeniu.AutoSize = true;
            this.lblMeniu.Location = new System.Drawing.Point(175, 30);
            this.lblMeniu.Name = "lblMeniu";
            this.lblMeniu.Size = new System.Drawing.Size(36, 13);
            this.lblMeniu.TabIndex = 0;
            this.lblMeniu.Text = "Meniu";
            // 
            // cboMeniu
            // 
            this.cboMeniu.FormattingEnabled = true;
            this.cboMeniu.Location = new System.Drawing.Point(216, 22);
            this.cboMeniu.Name = "cboMeniu";
            this.cboMeniu.Size = new System.Drawing.Size(121, 21);
            this.cboMeniu.TabIndex = 1;
            this.cboMeniu.SelectedIndexChanged += new System.EventHandler(this.cboMeniu_SelectedIndexChanged);
            // 
            // grdClienti
            // 
            this.grdClienti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdClienti.Location = new System.Drawing.Point(34, 207);
            this.grdClienti.Name = "grdClienti";
            this.grdClienti.Size = new System.Drawing.Size(594, 93);
            this.grdClienti.TabIndex = 2;
            // 
            // grdComanda
            // 
            this.grdComanda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdComanda.Location = new System.Drawing.Point(34, 64);
            this.grdComanda.Name = "grdComanda";
            this.grdComanda.Size = new System.Drawing.Size(594, 115);
            this.grdComanda.TabIndex = 3;
            this.grdComanda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdComanda_CellContentClick);
            // 
            // lblClienti
            // 
            this.lblClienti.AutoSize = true;
            this.lblClienti.Location = new System.Drawing.Point(31, 191);
            this.lblClienti.Name = "lblClienti";
            this.lblClienti.Size = new System.Drawing.Size(35, 13);
            this.lblClienti.TabIndex = 4;
            this.lblClienti.Text = "Clienti";
            // 
            // lblComanda
            // 
            this.lblComanda.AutoSize = true;
            this.lblComanda.Location = new System.Drawing.Point(41, 48);
            this.lblComanda.Name = "lblComanda";
            this.lblComanda.Size = new System.Drawing.Size(52, 13);
            this.lblComanda.TabIndex = 5;
            this.lblComanda.Text = "Comanda";
            // 
            // FormComplexClienti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 331);
            this.Controls.Add(this.lblComanda);
            this.Controls.Add(this.lblClienti);
            this.Controls.Add(this.grdComanda);
            this.Controls.Add(this.grdClienti);
            this.Controls.Add(this.cboMeniu);
            this.Controls.Add(this.lblMeniu);
            this.Name = "FormComplexClienti";
            this.Text = "FormComplexClienti";
            this.Load += new System.EventHandler(this.FormComplexClienti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdClienti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdComanda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMeniu;
        private System.Windows.Forms.ComboBox cboMeniu;
        private System.Windows.Forms.DataGridView grdClienti;
        private System.Windows.Forms.DataGridView grdComanda;
        private System.Windows.Forms.Label lblClienti;
        private System.Windows.Forms.Label lblComanda;
    }
}
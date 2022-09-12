namespace Projet_Delta_V1._1.Users_Controls
{
    partial class UC_PointVenteActive
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_PointVenteActive));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSupprimerEtablissement = new System.Windows.Forms.Button();
            this.textBoxSearchEtab = new System.Windows.Forms.TextBox();
            this.comboBoxSearchEtab = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNouvelEtablissement = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelNumberPointVenteActive = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.IDCodeLabelAd = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelEtablissementAd = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewListEtablissement = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListEtablissement)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.btnSupprimerEtablissement);
            this.panel1.Controls.Add(this.textBoxSearchEtab);
            this.panel1.Controls.Add(this.comboBoxSearchEtab);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnNouvelEtablissement);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1033, 56);
            this.panel1.TabIndex = 0;
            // 
            // btnSupprimerEtablissement
            // 
            this.btnSupprimerEtablissement.FlatAppearance.BorderSize = 0;
            this.btnSupprimerEtablissement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimerEtablissement.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimerEtablissement.ForeColor = System.Drawing.Color.White;
            this.btnSupprimerEtablissement.Image = ((System.Drawing.Image)(resources.GetObject("btnSupprimerEtablissement.Image")));
            this.btnSupprimerEtablissement.Location = new System.Drawing.Point(241, 2);
            this.btnSupprimerEtablissement.Name = "btnSupprimerEtablissement";
            this.btnSupprimerEtablissement.Size = new System.Drawing.Size(246, 52);
            this.btnSupprimerEtablissement.TabIndex = 8;
            this.btnSupprimerEtablissement.Text = "    Supprimer Etablissement";
            this.btnSupprimerEtablissement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSupprimerEtablissement.UseVisualStyleBackColor = true;
            this.btnSupprimerEtablissement.Click += new System.EventHandler(this.btnSupprimerEtablissement_Click);
            // 
            // textBoxSearchEtab
            // 
            this.textBoxSearchEtab.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBoxSearchEtab.Location = new System.Drawing.Point(826, 15);
            this.textBoxSearchEtab.Name = "textBoxSearchEtab";
            this.textBoxSearchEtab.Size = new System.Drawing.Size(202, 27);
            this.textBoxSearchEtab.TabIndex = 7;
            this.textBoxSearchEtab.TextChanged += new System.EventHandler(this.textBoxSearchEtab_TextChanged);
            // 
            // comboBoxSearchEtab
            // 
            this.comboBoxSearchEtab.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBoxSearchEtab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchEtab.FormattingEnabled = true;
            this.comboBoxSearchEtab.Items.AddRange(new object[] {
            "CODE",
            "ETABLISSEMENT",
            "VILLE"});
            this.comboBoxSearchEtab.Location = new System.Drawing.Point(640, 15);
            this.comboBoxSearchEtab.Name = "comboBoxSearchEtab";
            this.comboBoxSearchEtab.Size = new System.Drawing.Size(183, 29);
            this.comboBoxSearchEtab.TabIndex = 6;
            this.comboBoxSearchEtab.SelectedValueChanged += new System.EventHandler(this.comboBoxSearchEtab_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(521, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Chercher par :";
            // 
            // btnNouvelEtablissement
            // 
            this.btnNouvelEtablissement.FlatAppearance.BorderSize = 0;
            this.btnNouvelEtablissement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNouvelEtablissement.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNouvelEtablissement.ForeColor = System.Drawing.Color.White;
            this.btnNouvelEtablissement.Image = ((System.Drawing.Image)(resources.GetObject("btnNouvelEtablissement.Image")));
            this.btnNouvelEtablissement.Location = new System.Drawing.Point(2, 1);
            this.btnNouvelEtablissement.Name = "btnNouvelEtablissement";
            this.btnNouvelEtablissement.Size = new System.Drawing.Size(225, 52);
            this.btnNouvelEtablissement.TabIndex = 0;
            this.btnNouvelEtablissement.Text = "    Nouvel Etablissement";
            this.btnNouvelEtablissement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNouvelEtablissement.UseVisualStyleBackColor = true;
            this.btnNouvelEtablissement.Click += new System.EventHandler(this.btnNouvelEtablissement_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelNumberPointVenteActive);
            this.panel2.Controls.Add(this.label44);
            this.panel2.Controls.Add(this.IDCodeLabelAd);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.labelEtablissementAd);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 653);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1033, 31);
            this.panel2.TabIndex = 1;
            // 
            // labelNumberPointVenteActive
            // 
            this.labelNumberPointVenteActive.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelNumberPointVenteActive.AutoSize = true;
            this.labelNumberPointVenteActive.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberPointVenteActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(94)))));
            this.labelNumberPointVenteActive.Location = new System.Drawing.Point(723, 8);
            this.labelNumberPointVenteActive.Name = "labelNumberPointVenteActive";
            this.labelNumberPointVenteActive.Size = new System.Drawing.Size(22, 16);
            this.labelNumberPointVenteActive.TabIndex = 46;
            this.labelNumberPointVenteActive.Text = "00";
            // 
            // label44
            // 
            this.label44.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.Color.Black;
            this.label44.Location = new System.Drawing.Point(521, 8);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(132, 16);
            this.label44.TabIndex = 38;
            this.label44.Text = "Code Etablissement:";
            this.label44.Visible = false;
            // 
            // IDCodeLabelAd
            // 
            this.IDCodeLabelAd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IDCodeLabelAd.AutoSize = true;
            this.IDCodeLabelAd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IDCodeLabelAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDCodeLabelAd.ForeColor = System.Drawing.Color.Black;
            this.IDCodeLabelAd.Location = new System.Drawing.Point(653, 8);
            this.IDCodeLabelAd.Name = "IDCodeLabelAd";
            this.IDCodeLabelAd.Size = new System.Drawing.Size(64, 16);
            this.IDCodeLabelAd.TabIndex = 37;
            this.IDCodeLabelAd.Text = "IDCode:";
            this.IDCodeLabelAd.Visible = false;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(309, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 16);
            this.label11.TabIndex = 36;
            this.label11.Text = "Code:";
            this.label11.Visible = false;
            // 
            // labelEtablissementAd
            // 
            this.labelEtablissementAd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEtablissementAd.AutoSize = true;
            this.labelEtablissementAd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEtablissementAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEtablissementAd.ForeColor = System.Drawing.Color.Black;
            this.labelEtablissementAd.Location = new System.Drawing.Point(352, 7);
            this.labelEtablissementAd.Name = "labelEtablissementAd";
            this.labelEtablissementAd.Size = new System.Drawing.Size(164, 18);
            this.labelEtablissementAd.TabIndex = 35;
            this.labelEtablissementAd.Text = "Code Etablissement ";
            this.labelEtablissementAd.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "© 2021 Tous droits réservés à Bnd Mobetisoft";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewListEtablissement);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(5, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1033, 592);
            this.panel3.TabIndex = 2;
            // 
            // dataGridViewListEtablissement
            // 
            this.dataGridViewListEtablissement.AllowUserToAddRows = false;
            this.dataGridViewListEtablissement.AllowUserToDeleteRows = false;
            this.dataGridViewListEtablissement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewListEtablissement.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridViewListEtablissement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListEtablissement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewListEtablissement.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewListEtablissement.MultiSelect = false;
            this.dataGridViewListEtablissement.Name = "dataGridViewListEtablissement";
            this.dataGridViewListEtablissement.ReadOnly = true;
            this.dataGridViewListEtablissement.RowTemplate.Height = 30;
            this.dataGridViewListEtablissement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewListEtablissement.Size = new System.Drawing.Size(1033, 592);
            this.dataGridViewListEtablissement.TabIndex = 0;
            this.dataGridViewListEtablissement.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListEtablissement_CellClick);
            this.dataGridViewListEtablissement.DoubleClick += new System.EventHandler(this.dataGridViewListEtablissement_DoubleClick);
            this.dataGridViewListEtablissement.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewListEtablissement_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.LavenderBlush;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modiToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(247, 50);
            // 
            // modiToolStripMenuItem
            // 
            this.modiToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.modiToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modiToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.modiToolStripMenuItem.Name = "modiToolStripMenuItem";
            this.modiToolStripMenuItem.Size = new System.Drawing.Size(246, 24);
            this.modiToolStripMenuItem.Text = "Modifier Etablissement";
            this.modiToolStripMenuItem.Click += new System.EventHandler(this.modiToolStripMenuItem_Click);
            // 
            // UC_PointVenteActive
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UC_PointVenteActive";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1043, 689);
            this.Load += new System.EventHandler(this.UC_PointVenteActive_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListEtablissement)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnNouvelEtablissement;
        private System.Windows.Forms.TextBox textBoxSearchEtab;
        private System.Windows.Forms.ComboBox comboBoxSearchEtab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewListEtablissement;
        private System.Windows.Forms.Button btnSupprimerEtablissement;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelEtablissementAd;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label IDCodeLabelAd;
        private System.Windows.Forms.Label labelNumberPointVenteActive;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modiToolStripMenuItem;
    }
}

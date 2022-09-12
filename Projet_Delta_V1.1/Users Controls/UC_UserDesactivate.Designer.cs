namespace Projet_Delta_V1._1.Users_Controls
{
    partial class UC_UserDesactivate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_UserDesactivate));
            this.dataGridViewListUserDesactive = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.labelNumberUserActive = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.IDCodeLabelAd = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelEtablissementAd = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSupprimerUtilisateurDefinitivement = new System.Windows.Forms.Button();
            this.btnRestaurerUtilisateur = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.comboBoxSearch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListUserDesactive)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewListUserDesactive
            // 
            this.dataGridViewListUserDesactive.AllowUserToAddRows = false;
            this.dataGridViewListUserDesactive.AllowUserToDeleteRows = false;
            this.dataGridViewListUserDesactive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewListUserDesactive.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewListUserDesactive.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridViewListUserDesactive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListUserDesactive.Location = new System.Drawing.Point(0, 56);
            this.dataGridViewListUserDesactive.MultiSelect = false;
            this.dataGridViewListUserDesactive.Name = "dataGridViewListUserDesactive";
            this.dataGridViewListUserDesactive.ReadOnly = true;
            this.dataGridViewListUserDesactive.RowTemplate.Height = 30;
            this.dataGridViewListUserDesactive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewListUserDesactive.Size = new System.Drawing.Size(1033, 592);
            this.dataGridViewListUserDesactive.TabIndex = 0;
            this.dataGridViewListUserDesactive.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListUserDesactive_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBox);
            this.panel2.Controls.Add(this.labelNumberUserActive);
            this.panel2.Controls.Add(this.label44);
            this.panel2.Controls.Add(this.IDCodeLabelAd);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.labelEtablissementAd);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 653);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1033, 31);
            this.panel2.TabIndex = 7;
            // 
            // checkBox
            // 
            this.checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox.AutoSize = true;
            this.checkBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox.ForeColor = System.Drawing.Color.Black;
            this.checkBox.Location = new System.Drawing.Point(419, 6);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(145, 21);
            this.checkBox.TabIndex = 97;
            this.checkBox.Text = "Mode synthétique ";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // labelNumberUserActive
            // 
            this.labelNumberUserActive.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelNumberUserActive.AutoSize = true;
            this.labelNumberUserActive.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberUserActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(94)))));
            this.labelNumberUserActive.Location = new System.Drawing.Point(790, 7);
            this.labelNumberUserActive.Name = "labelNumberUserActive";
            this.labelNumberUserActive.Size = new System.Drawing.Size(22, 16);
            this.labelNumberUserActive.TabIndex = 96;
            this.labelNumberUserActive.Text = "00";
            // 
            // label44
            // 
            this.label44.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.Color.Black;
            this.label44.Location = new System.Drawing.Point(529, 7);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(132, 16);
            this.label44.TabIndex = 95;
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
            this.IDCodeLabelAd.Location = new System.Drawing.Point(661, 7);
            this.IDCodeLabelAd.Name = "IDCodeLabelAd";
            this.IDCodeLabelAd.Size = new System.Drawing.Size(64, 16);
            this.IDCodeLabelAd.TabIndex = 94;
            this.IDCodeLabelAd.Text = "IDCode:";
            this.IDCodeLabelAd.Visible = false;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(317, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 16);
            this.label11.TabIndex = 93;
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
            this.labelEtablissementAd.Location = new System.Drawing.Point(360, 6);
            this.labelEtablissementAd.Name = "labelEtablissementAd";
            this.labelEtablissementAd.Size = new System.Drawing.Size(164, 18);
            this.labelEtablissementAd.TabIndex = 92;
            this.labelEtablissementAd.Text = "Code Etablissement ";
            this.labelEtablissementAd.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "© 2021 Tous droits réservés à Bnd Mobetisoft";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.btnSupprimerUtilisateurDefinitivement);
            this.panel1.Controls.Add(this.btnRestaurerUtilisateur);
            this.panel1.Controls.Add(this.textBoxSearch);
            this.panel1.Controls.Add(this.comboBoxSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1033, 56);
            this.panel1.TabIndex = 6;
            // 
            // btnSupprimerUtilisateurDefinitivement
            // 
            this.btnSupprimerUtilisateurDefinitivement.FlatAppearance.BorderSize = 0;
            this.btnSupprimerUtilisateurDefinitivement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimerUtilisateurDefinitivement.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimerUtilisateurDefinitivement.ForeColor = System.Drawing.Color.White;
            this.btnSupprimerUtilisateurDefinitivement.Image = ((System.Drawing.Image)(resources.GetObject("btnSupprimerUtilisateurDefinitivement.Image")));
            this.btnSupprimerUtilisateurDefinitivement.Location = new System.Drawing.Point(233, 2);
            this.btnSupprimerUtilisateurDefinitivement.Name = "btnSupprimerUtilisateurDefinitivement";
            this.btnSupprimerUtilisateurDefinitivement.Size = new System.Drawing.Size(220, 52);
            this.btnSupprimerUtilisateurDefinitivement.TabIndex = 9;
            this.btnSupprimerUtilisateurDefinitivement.Text = "    Supprimer Utilisateur";
            this.btnSupprimerUtilisateurDefinitivement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSupprimerUtilisateurDefinitivement.UseVisualStyleBackColor = true;
            this.btnSupprimerUtilisateurDefinitivement.Click += new System.EventHandler(this.btnSupprimerUtilisateurDefinitivement_Click);
            // 
            // btnRestaurerUtilisateur
            // 
            this.btnRestaurerUtilisateur.FlatAppearance.BorderSize = 0;
            this.btnRestaurerUtilisateur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurerUtilisateur.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurerUtilisateur.ForeColor = System.Drawing.Color.White;
            this.btnRestaurerUtilisateur.Image = ((System.Drawing.Image)(resources.GetObject("btnRestaurerUtilisateur.Image")));
            this.btnRestaurerUtilisateur.Location = new System.Drawing.Point(3, 2);
            this.btnRestaurerUtilisateur.Name = "btnRestaurerUtilisateur";
            this.btnRestaurerUtilisateur.Size = new System.Drawing.Size(217, 52);
            this.btnRestaurerUtilisateur.TabIndex = 8;
            this.btnRestaurerUtilisateur.Text = "    Restaurer Utilisateur";
            this.btnRestaurerUtilisateur.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRestaurerUtilisateur.UseVisualStyleBackColor = true;
            this.btnRestaurerUtilisateur.Click += new System.EventHandler(this.btnRestaurerUtilisateur_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBoxSearch.Location = new System.Drawing.Point(820, 15);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(200, 27);
            this.textBoxSearch.TabIndex = 7;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // comboBoxSearch
            // 
            this.comboBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBoxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearch.FormattingEnabled = true;
            this.comboBoxSearch.Items.AddRange(new object[] {
            "ID",
            "PRENOM",
            "NOM",
            "LOGIN",
            "ETABLISSEMENT"});
            this.comboBoxSearch.Location = new System.Drawing.Point(623, 15);
            this.comboBoxSearch.Name = "comboBoxSearch";
            this.comboBoxSearch.Size = new System.Drawing.Size(193, 29);
            this.comboBoxSearch.TabIndex = 6;
            this.comboBoxSearch.SelectedValueChanged += new System.EventHandler(this.comboBoxSearch_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(506, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Chercher par :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewListUserDesactive);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1033, 679);
            this.panel3.TabIndex = 8;
            // 
            // UC_UserDesactivate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UC_UserDesactivate";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1043, 689);
            this.Load += new System.EventHandler(this.UC_UserDesactivate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListUserDesactive)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewListUserDesactive;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ComboBox comboBoxSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRestaurerUtilisateur;
        private System.Windows.Forms.Button btnSupprimerUtilisateurDefinitivement;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Label labelNumberUserActive;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label IDCodeLabelAd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelEtablissementAd;
    }
}

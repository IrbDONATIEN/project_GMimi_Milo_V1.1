﻿namespace Projet_Delta_V1._1.Users_Controls
{
    partial class UC_UserEnCours
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
            this.dataGridViewListUsereEnCours = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.labelNumberUserActive = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.IDCodeLabelAd = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelEtablissementAd = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.comboBoxSearch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListUsereEnCours)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewListUsereEnCours
            // 
            this.dataGridViewListUsereEnCours.AllowUserToAddRows = false;
            this.dataGridViewListUsereEnCours.AllowUserToDeleteRows = false;
            this.dataGridViewListUsereEnCours.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewListUsereEnCours.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewListUsereEnCours.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridViewListUsereEnCours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListUsereEnCours.Location = new System.Drawing.Point(0, 56);
            this.dataGridViewListUsereEnCours.MultiSelect = false;
            this.dataGridViewListUsereEnCours.Name = "dataGridViewListUsereEnCours";
            this.dataGridViewListUsereEnCours.ReadOnly = true;
            this.dataGridViewListUsereEnCours.RowTemplate.Height = 30;
            this.dataGridViewListUsereEnCours.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewListUsereEnCours.Size = new System.Drawing.Size(1033, 590);
            this.dataGridViewListUsereEnCours.TabIndex = 0;
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
            this.panel2.TabIndex = 10;
            // 
            // checkBox
            // 
            this.checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox.AutoSize = true;
            this.checkBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox.ForeColor = System.Drawing.Color.Black;
            this.checkBox.Location = new System.Drawing.Point(417, 7);
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
            this.labelNumberUserActive.Location = new System.Drawing.Point(788, 8);
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
            this.label44.Location = new System.Drawing.Point(527, 8);
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
            this.IDCodeLabelAd.Location = new System.Drawing.Point(659, 8);
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
            this.label11.Location = new System.Drawing.Point(315, 8);
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
            this.labelEtablissementAd.Location = new System.Drawing.Point(358, 7);
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
            this.panel1.Controls.Add(this.textBoxSearch);
            this.panel1.Controls.Add(this.comboBoxSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1033, 56);
            this.panel1.TabIndex = 9;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxSearch.Location = new System.Drawing.Point(346, 15);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(268, 27);
            this.textBoxSearch.TabIndex = 7;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // comboBoxSearch
            // 
            this.comboBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearch.FormattingEnabled = true;
            this.comboBoxSearch.Items.AddRange(new object[] {
            "ID",
            "PRENOM",
            "NOM",
            "LOGIN",
            "ETABLISSEMENT"});
            this.comboBoxSearch.Location = new System.Drawing.Point(131, 15);
            this.comboBoxSearch.Name = "comboBoxSearch";
            this.comboBoxSearch.Size = new System.Drawing.Size(209, 29);
            this.comboBoxSearch.TabIndex = 6;
            this.comboBoxSearch.SelectedValueChanged += new System.EventHandler(this.comboBoxSearch_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Chercher par :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewListUsereEnCours);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1033, 679);
            this.panel3.TabIndex = 11;
            // 
            // UC_UserEnCours
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UC_UserEnCours";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1043, 689);
            this.Load += new System.EventHandler(this.UC_UserEnCours_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListUsereEnCours)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewListUsereEnCours;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ComboBox comboBoxSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Label labelNumberUserActive;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label IDCodeLabelAd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelEtablissementAd;
    }
}

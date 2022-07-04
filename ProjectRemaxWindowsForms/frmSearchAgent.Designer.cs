
namespace ProjectRemaxWindowsForms
{
    partial class frmSearchAgent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchAgent));
            this.gridSearch = new System.Windows.Forms.DataGridView();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.cboEmail = new System.Windows.Forms.ComboBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.cboID = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rbnID = new System.Windows.Forms.RadioButton();
            this.rbnEmail = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridSearch)).BeginInit();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridSearch
            // 
            this.gridSearch.AllowUserToAddRows = false;
            this.gridSearch.AllowUserToDeleteRows = false;
            this.gridSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSearch.Location = new System.Drawing.Point(11, 161);
            this.gridSearch.Name = "gridSearch";
            this.gridSearch.Size = new System.Drawing.Size(511, 205);
            this.gridSearch.TabIndex = 32;
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.rbnEmail);
            this.gbSearch.Controls.Add(this.rbnID);
            this.gbSearch.Controls.Add(this.cboEmail);
            this.gbSearch.Controls.Add(this.btnFind);
            this.gbSearch.Controls.Add(this.cboID);
            this.gbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbSearch.Location = new System.Drawing.Point(11, 59);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(511, 96);
            this.gbSearch.TabIndex = 31;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search Agent";
            // 
            // cboEmail
            // 
            this.cboEmail.FormattingEnabled = true;
            this.cboEmail.Location = new System.Drawing.Point(130, 55);
            this.cboEmail.Name = "cboEmail";
            this.cboEmail.Size = new System.Drawing.Size(262, 24);
            this.cboEmail.TabIndex = 37;
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFind.Location = new System.Drawing.Point(411, 35);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(82, 31);
            this.btnFind.TabIndex = 35;
            this.btnFind.Text = "FIND";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // cboID
            // 
            this.cboID.FormattingEnabled = true;
            this.cboID.Location = new System.Drawing.Point(130, 25);
            this.cboID.Name = "cboID";
            this.cboID.Size = new System.Drawing.Size(262, 24);
            this.cboID.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(99, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(329, 31);
            this.lblTitle.TabIndex = 30;
            this.lblTitle.Text = "SEARCH FOR AGENTS";
            // 
            // rbnID
            // 
            this.rbnID.AutoSize = true;
            this.rbnID.Location = new System.Drawing.Point(18, 26);
            this.rbnID.Name = "rbnID";
            this.rbnID.Size = new System.Drawing.Size(63, 20);
            this.rbnID.TabIndex = 38;
            this.rbnID.TabStop = true;
            this.rbnID.Text = "By ID";
            this.rbnID.UseVisualStyleBackColor = true;
            // 
            // rbnEmail
            // 
            this.rbnEmail.AutoSize = true;
            this.rbnEmail.Location = new System.Drawing.Point(18, 56);
            this.rbnEmail.Name = "rbnEmail";
            this.rbnEmail.Size = new System.Drawing.Size(87, 20);
            this.rbnEmail.TabIndex = 39;
            this.rbnEmail.TabStop = true;
            this.rbnEmail.Text = "By Email";
            this.rbnEmail.UseVisualStyleBackColor = true;
            // 
            // frmSearchAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(541, 378);
            this.Controls.Add(this.gridSearch);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSearchAgent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remax - Search Agent";
            this.Load += new System.EventHandler(this.frmSearchAgent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSearch)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridSearch;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cboEmail;
        private System.Windows.Forms.ComboBox cboID;
        private System.Windows.Forms.RadioButton rbnEmail;
        private System.Windows.Forms.RadioButton rbnID;
    }
}

namespace ProjectRemaxWindowsForms
{
    partial class frmSearchHouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchHouse));
            this.gridSearch = new System.Windows.Forms.DataGridView();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.cboLoc = new System.Windows.Forms.ComboBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.cboAgent = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rbnAgent = new System.Windows.Forms.RadioButton();
            this.rbnLoc = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridSearch)).BeginInit();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridSearch
            // 
            this.gridSearch.AllowUserToAddRows = false;
            this.gridSearch.AllowUserToDeleteRows = false;
            this.gridSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSearch.Location = new System.Drawing.Point(20, 157);
            this.gridSearch.Name = "gridSearch";
            this.gridSearch.Size = new System.Drawing.Size(511, 205);
            this.gridSearch.TabIndex = 35;
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.rbnLoc);
            this.gbSearch.Controls.Add(this.rbnAgent);
            this.gbSearch.Controls.Add(this.cboLoc);
            this.gbSearch.Controls.Add(this.btnFind);
            this.gbSearch.Controls.Add(this.cboAgent);
            this.gbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbSearch.Location = new System.Drawing.Point(20, 55);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(511, 96);
            this.gbSearch.TabIndex = 34;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search House";
            // 
            // cboLoc
            // 
            this.cboLoc.FormattingEnabled = true;
            this.cboLoc.Location = new System.Drawing.Point(130, 55);
            this.cboLoc.Name = "cboLoc";
            this.cboLoc.Size = new System.Drawing.Size(262, 24);
            this.cboLoc.TabIndex = 37;
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
            // cboAgent
            // 
            this.cboAgent.FormattingEnabled = true;
            this.cboAgent.Location = new System.Drawing.Point(130, 25);
            this.cboAgent.Name = "cboAgent";
            this.cboAgent.Size = new System.Drawing.Size(262, 24);
            this.cboAgent.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(94, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(332, 31);
            this.lblTitle.TabIndex = 33;
            this.lblTitle.Text = "SEARCH FOR HOUSES";
            // 
            // rbnAgent
            // 
            this.rbnAgent.AutoSize = true;
            this.rbnAgent.Location = new System.Drawing.Point(18, 26);
            this.rbnAgent.Name = "rbnAgent";
            this.rbnAgent.Size = new System.Drawing.Size(88, 20);
            this.rbnAgent.TabIndex = 38;
            this.rbnAgent.TabStop = true;
            this.rbnAgent.Text = "By Agent";
            this.rbnAgent.UseVisualStyleBackColor = true;
            // 
            // rbnLoc
            // 
            this.rbnLoc.AutoSize = true;
            this.rbnLoc.Location = new System.Drawing.Point(17, 56);
            this.rbnLoc.Name = "rbnLoc";
            this.rbnLoc.Size = new System.Drawing.Size(107, 20);
            this.rbnLoc.TabIndex = 39;
            this.rbnLoc.TabStop = true;
            this.rbnLoc.Text = "By Location";
            this.rbnLoc.UseVisualStyleBackColor = true;
            // 
            // frmSearchHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(551, 376);
            this.Controls.Add(this.gridSearch);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSearchHouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remax - Search House";
            this.Load += new System.EventHandler(this.frmSearchHouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSearch)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridSearch;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.ComboBox cboLoc;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ComboBox cboAgent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rbnLoc;
        private System.Windows.Forms.RadioButton rbnAgent;
    }
}
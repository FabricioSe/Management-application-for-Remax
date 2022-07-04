using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ProjectRemaxWindowsForms
{
    public partial class frmHouses : Form
    {
        public frmHouses()
        {
            InitializeComponent();
        }

        //Global variables
        DataSet myset;
        DataTable tabSellers, tabHouses;
        OleDbConnection mycon;
        OleDbDataAdapter myadp, myadpHouse;
        int currentPosition;
        string mode;

        private void btnClose_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to quit the House management form?";
            string title = "Management closing";
            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmHouses_Load(object sender, EventArgs e)
        {
            lbltitle.BackColor = lblAddress.BackColor = lblPostal.BackColor = lblLocation.BackColor = System.Drawing.Color.Transparent;
            lblType.BackColor = lblPrice.BackColor = lblStatus.BackColor = lblSeller.BackColor = System.Drawing.Color.Transparent;

            myset = new DataSet();

            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\fojed\Desktop\INFO\LaSalle\Courses\S3\Multi_Tier_Applications\Project_1\ProjectRemaxWindowsForms\ProjectRemaxWindowsForms\Database\Remax_DB.mdb");
            mycon.Open();

            OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Sellers", mycon);
            myadp = new OleDbDataAdapter(mycmd);
            myadp.Fill(myset, "Sellers");

            tabSellers = myset.Tables["Sellers"];

            mycmd = new OleDbCommand("SELECT * FROM Houses", mycon);
            myadpHouse = new OleDbDataAdapter(mycmd);
            myadpHouse.Fill(myset, "Houses");

            tabHouses = myset.Tables["Houses"];

            currentPosition = 0;
            Display();
            ActivateBTN(true, false, true);
        }

        private void Display()
        {
            txtAddress.Text = tabHouses.Rows[currentPosition]["Address"].ToString();
            txtPostal.Text = tabHouses.Rows[currentPosition]["Postal Code"].ToString();
            txtLocation.Text = tabHouses.Rows[currentPosition]["Location"].ToString();
            txtType.Text = tabHouses.Rows[currentPosition]["Type"].ToString();
            txtPrice.Text = tabHouses.Rows[currentPosition]["Price"].ToString();
            txtStatus.Text = tabHouses.Rows[currentPosition]["Status"].ToString();

            int referSeller = Convert.ToInt32(tabHouses.Rows[currentPosition]["ReferSeller"]);
            cboSeller.SelectedValue = referSeller;
            // Databinding 
            cboSeller.DataSource = tabSellers;
            cboSeller.DisplayMember = "FullName";
            cboSeller.ValueMember = "RefSeller";

            lblInfoHouse.Text = "House " + (currentPosition + 1) + " on a total of " + tabHouses.Rows.Count;
        }

        private void ActivateBTN(bool AdEdiDel, bool SaveCanc, bool Navig)
        {
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = AdEdiDel;
            btnSave.Enabled = btnCancel.Enabled = SaveCanc;
            btnFirst.Enabled = btnLast.Enabled = btnNext.Enabled = btnPrevious.Enabled = Navig;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmSellers seller = new frmSellers();
            seller.ShowDialog();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPosition = 0;
            Display();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPosition > 0)
            {
                currentPosition -= 1;
                Display();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPosition < (tabHouses.Rows.Count - 1))
            {
                currentPosition += 1;
                Display();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPosition = tabHouses.Rows.Count - 1;
            Display();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "Add";
            txtAddress.Text = txtPostal.Text = txtLocation.Text = txtType.Text = "";
            txtPrice.Text = txtStatus.Text = "";
            txtAddress.Focus();
            cboSeller.Text = "Select a Seller";
            lblInfoHouse.Text = "--- Adding Mode ---";
            ActivateBTN(false, true, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "Edit";
            txtAddress.Focus();
            lblInfoHouse.Text = "--- Editing Mode ---";
            ActivateBTN(false, true, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to delete this House?";
            string title = "Warning : House Deletion";

            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Delete row in dataset
                tabHouses.Rows[currentPosition].Delete();
                // Synchronize (update) new contents of dataset in the database
                OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myadpHouse);
                myadpHouse.Update(myset, "Houses");
                // Update the contest of the database into the dataset
                myset.Tables.Remove("Houses");
                // Load table Courses again
                OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Houses", mycon);
                myadpHouse = new OleDbDataAdapter(mycmd);
                myadpHouse.Fill(myset, "Houses");
                tabSellers = myset.Tables["Houses"];

                currentPosition = 0;
                Display();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string addrss = txtAddress.Text.Trim();
            string postal = txtPostal.Text.Trim();
            string loc = txtLocation.Text.Trim();
            string type = txtType.Text;
            decimal price = Convert.ToDecimal(txtPrice.Text);
            string status = txtStatus.Text.Trim();
            Int32 ReferSeller = Convert.ToInt32(cboSeller.SelectedValue);
            DataRow myrow;

            if (mode == "Add")
            {
                myrow = tabHouses.NewRow();
                myrow["Address"] = addrss;
                myrow["Postal Code"] = postal;
                myrow["Location"] = loc;
                myrow["Type"] = type;
                myrow["Price"] = price;
                myrow["ReferSeller"] = ReferSeller;
                tabHouses.Rows.Add(myrow);
                currentPosition = tabHouses.Rows.Count - 1;
            }
            else if (mode == "Edit")
            {
                myrow = tabHouses.Rows[currentPosition];
                myrow["Address"] = addrss;
                myrow["Postal Code"] = postal;
                myrow["Location"] = loc;
                myrow["Type"] = type;
                myrow["Price"] = price;
                myrow["ReferSeller"] = ReferSeller;
            }
            //new record saved only in the table of the dataset
            //Now we need to update (or synchronize) the contents of the dataset -> the database
            OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myadpHouse);
            myadpHouse.Update(myset, "Houses");

            //Update the contents of the database -> dataset
            myset.Tables.Remove("Houses");
            OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Houses", mycon);
            myadpHouse = new OleDbDataAdapter(mycmd);
            myadpHouse.Fill(myset, "Houses");
            tabHouses = myset.Tables["Houses"];

            Display();
            mode = "";
            ActivateBTN(true, false, true);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //new record saved only in the table of the dataset
            //Now we need to update (or synchronize) the contents of the dataset -> the database
            OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myadp);
            myadp.Update(myset, "Sellers");

            //Update the contents of the database -> dataset
            myset.Tables.Remove("Sellers");
            OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Sellers", mycon);
            myadp = new OleDbDataAdapter(mycmd);
            myadp.Fill(myset, "Sellers");
            tabSellers = myset.Tables["Sellers"];

            Display();
            ActivateBTN(true, false, true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Display();
            ActivateBTN(true, false, true);
        }
    }
}

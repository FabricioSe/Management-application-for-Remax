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
    public partial class frmSellers : Form
    {
        public frmSellers()
        {
            InitializeComponent();
        }

        //Global variables
        DataSet myset;
        DataTable tabAgents, tabSellers;
        OleDbConnection mycon;
        OleDbDataAdapter myadpSeller;
        int currentPosition;
        string mode;

        private void btnClose_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to quit the Seller management form?";
            string title = "Management closing";
            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmSellers_Load(object sender, EventArgs e)
        {
            lbltitle.BackColor = lblname.BackColor = lblemail.BackColor = lblpass.BackColor = System.Drawing.Color.Transparent;
            lblPhone.BackColor = lblAgent.BackColor = System.Drawing.Color.Transparent;

            myset = new DataSet();

            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\fojed\Desktop\INFO\LaSalle\Courses\S3\Multi_Tier_Applications\Project_1\ProjectRemaxWindowsForms\ProjectRemaxWindowsForms\Database\Remax_DB.mdb");
            mycon.Open();

            OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Agents", mycon);
            OleDbDataAdapter myadp = new OleDbDataAdapter(mycmd);
            myadp.Fill(myset, "Agents");

            tabAgents = myset.Tables["Agents"];

            mycmd = new OleDbCommand("SELECT * FROM Sellers", mycon);
            myadpSeller = new OleDbDataAdapter(mycmd);
            myadpSeller.Fill(myset, "Sellers");

            tabSellers = myset.Tables["Sellers"];

            currentPosition = 0;
            Display();
            ActivateBTN(true, false, true);
        }

        private void Display()
        {
            txtFullName.Text = tabSellers.Rows[currentPosition]["FullName"].ToString();
            txtEmail.Text = tabSellers.Rows[currentPosition]["Email"].ToString();
            txtPass.Text = tabSellers.Rows[currentPosition]["Pin"].ToString();
            txtPhone.Text = tabSellers.Rows[currentPosition]["Phone"].ToString();

            int referAgent = Convert.ToInt32(tabSellers.Rows[currentPosition]["ReferAgent"]);
            cboAgent.SelectedValue = referAgent;
            // Databinding 
            cboAgent.DataSource = tabAgents;
            cboAgent.DisplayMember = "FullName";
            cboAgent.ValueMember = "RefAgent";

            lblInfoSeller.Text = "Seller " + (currentPosition + 1) + " on a total of " + tabSellers.Rows.Count;
        }

        private void ActivateBTN(bool AdEdiDel, bool SaveCanc, bool Navig)
        {
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = AdEdiDel;
            btnSave.Enabled = btnCancel.Enabled = SaveCanc;
            btnFirst.Enabled = btnLast.Enabled = btnNext.Enabled = btnPrevious.Enabled = Navig;
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
            if (currentPosition < (tabSellers.Rows.Count - 1))
            {
                currentPosition += 1;
                Display();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPosition = tabSellers.Rows.Count - 1;
            Display();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "Add";
            txtFullName.Text = txtEmail.Text = txtPass.Text = txtPhone.Text  = "";
            txtFullName.Focus();
            cboAgent.Text = "Select an Agent";
            lblInfoSeller.Text = "--- Adding Mode ---";
            ActivateBTN(false, true, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "Edit";
            txtFullName.Focus();
            lblInfoSeller.Text = "--- Editing Mode ---";
            ActivateBTN(false, true, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to delete this Seller?";
            string title = "Warning : Seller Deletion";

            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Delete row in dataset
                tabSellers.Rows[currentPosition].Delete();
                // Synchronize (update) new contents of dataset in the database
                OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myadpSeller);
                myadpSeller.Update(myset, "Sellers");
                // Update the contest of the database into the dataset
                myset.Tables.Remove("Sellers");
                // Load table Courses again
                OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Sellers", mycon);
                myadpSeller = new OleDbDataAdapter(mycmd);
                myadpSeller.Fill(myset, "Sellers");
                tabSellers = myset.Tables["Sellers"];

                currentPosition = 0;
                Display();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string pin = txtPass.Text.Trim();
            string phone = txtPhone.Text;
            Int32 ReferAgent = Convert.ToInt32(cboAgent.SelectedValue);
            DataRow myrow;

            if (mode == "Add")
            {
                myrow = tabSellers.NewRow();
                myrow["FullName"] = name;
                myrow["Email"] = email;
                myrow["Pin"] = pin;
                myrow["Phone"] = phone;
                myrow["ReferAgent"] = ReferAgent;
                tabSellers.Rows.Add(myrow);
                currentPosition = tabSellers.Rows.Count - 1;
            }
            else if (mode == "Edit")
            {
                myrow = tabSellers.Rows[currentPosition];
                myrow["FullName"] = name;
                myrow["Email"] = email;
                myrow["Pin"] = pin;
                myrow["Phone"] = phone;
                myrow["ReferAgent"] = ReferAgent;
            }
            //new record saved only in the table of the dataset
            //Now we need to update (or synchronize) the contents of the dataset -> the database
            OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myadpSeller);
            myadpSeller.Update(myset, "Sellers");

            //Update the contents of the database -> dataset
            myset.Tables.Remove("Sellers");
            OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Sellers", mycon);
            myadpSeller = new OleDbDataAdapter(mycmd);
            myadpSeller.Fill(myset, "Sellers");
            tabSellers = myset.Tables["Sellers"];

            Display();
            mode = "";
            ActivateBTN(true, false, true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Display();
            ActivateBTN(true, false, true);
        }
    }
}

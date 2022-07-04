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
    public partial class frmBuyers : Form
    {
        public frmBuyers()
        {
            InitializeComponent();
        }

        //Global variables
        DataSet myset;
        DataTable tabAgents, tabBuyers;
        OleDbConnection mycon;
        OleDbDataAdapter myadpBuyer;
        int currentPosition;
        string mode;
        private void btnClose_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to quit the Buyer management form?";
            string title = "Management closing";
            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmBuyers_Load(object sender, EventArgs e)
        {
            lbltitle.BackColor = lblname.BackColor = lblemail.BackColor = lblpass.BackColor = System.Drawing.Color.Transparent;
            lblPhone.BackColor = lblBudget.BackColor = lblAgent.BackColor = System.Drawing.Color.Transparent;

            myset = new DataSet();

            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\fojed\Desktop\INFO\LaSalle\Courses\S3\Multi_Tier_Applications\Project_1\ProjectRemaxWindowsForms\ProjectRemaxWindowsForms\Database\Remax_DB.mdb");
            mycon.Open();

            OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Agents", mycon);
            OleDbDataAdapter myadp = new OleDbDataAdapter(mycmd);
            myadp.Fill(myset, "Agents");

            tabAgents = myset.Tables["Agents"];

            mycmd = new OleDbCommand("SELECT * FROM Buyers", mycon);
            myadpBuyer = new OleDbDataAdapter(mycmd);
            myadpBuyer.Fill(myset, "Buyers");

            tabBuyers = myset.Tables["Buyers"];

            currentPosition = 0;
            Display();
            ActivateBTN(true, false, true);
        }

        private void Display()
        {
            txtFullName.Text = tabBuyers.Rows[currentPosition]["FullName"].ToString();
            txtEmail.Text = tabBuyers.Rows[currentPosition]["Email"].ToString();
            txtPass.Text = tabBuyers.Rows[currentPosition]["Pin"].ToString();
            txtPhone.Text = tabBuyers.Rows[currentPosition]["Phone"].ToString();
            txtBudget.Text = tabBuyers.Rows[currentPosition]["Budget"].ToString();

            int referAgent = Convert.ToInt32(tabBuyers.Rows[currentPosition]["ReferAgent"]);
            cboAgent.SelectedValue = referAgent;
            // Databinding 
            cboAgent.DataSource = tabAgents;
            cboAgent.DisplayMember = "FullName";
            cboAgent.ValueMember = "RefAgent";

            lblInfoBuyer.Text = "Buyer " + (currentPosition + 1) + " on a total of " + tabBuyers.Rows.Count;
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
            if (currentPosition < (tabBuyers.Rows.Count - 1))
            {
                currentPosition += 1;
                Display();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPosition = tabBuyers.Rows.Count - 1;
            Display();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "Add";
            txtFullName.Text = txtEmail.Text = txtPass.Text = txtPhone.Text = txtBudget.Text = "";
            txtFullName.Focus();
            cboAgent.Text = "Select an Agent";
            lblInfoBuyer.Text = "--- Adding Mode ---";
            ActivateBTN(false, true, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "Edit";
            txtFullName.Focus();
            lblInfoBuyer.Text = "--- Editing Mode ---";
            ActivateBTN(false, true, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to delete this Buyer?";
            string title = "Warning : Buyer Deletion";

            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Delete row in dataset
                tabBuyers.Rows[currentPosition].Delete();
                // Synchronize (update) new contents of dataset in the database
                OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myadpBuyer);
                myadpBuyer.Update(myset, "Buyers");
                // Update the contest of the database into the dataset
                myset.Tables.Remove("Buyers");
                // Load table Courses again
                OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Buyers", mycon);
                myadpBuyer = new OleDbDataAdapter(mycmd);
                myadpBuyer.Fill(myset, "Buyers");
                tabBuyers = myset.Tables["Buyers"];

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
            decimal budget = Convert.ToDecimal(txtBudget.Text);
            Int32 ReferAgent = Convert.ToInt32(cboAgent.SelectedValue);
            DataRow myrow;

            if (mode == "Add")
            {
                myrow = tabBuyers.NewRow();
                myrow["FullName"] = name;
                myrow["Email"] = email;
                myrow["Pin"] = pin;
                myrow["Phone"] = phone;
                myrow["Budget"] = budget;
                myrow["ReferAgent"] = ReferAgent;
                tabBuyers.Rows.Add(myrow);
                currentPosition = tabBuyers.Rows.Count - 1;
            }
            else if (mode == "Edit")
            {
                myrow = tabBuyers.Rows[currentPosition];
                myrow["FullName"] = name;
                myrow["Email"] = email;
                myrow["Pin"] = pin;
                myrow["Phone"] = phone;
                myrow["Budget"] = budget;
                myrow["ReferAgent"] = ReferAgent;
            }
            //new record saved only in the table of the dataset
            //Now we need to update (or synchronize) the contents of the dataset -> the database
            OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myadpBuyer);
            myadpBuyer.Update(myset, "Buyers");

            //Update the contents of the database -> dataset
            myset.Tables.Remove("Buyers");
            OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Buyers", mycon);
            myadpBuyer = new OleDbDataAdapter(mycmd);
            myadpBuyer.Fill(myset, "Buyers");
            tabBuyers = myset.Tables["Buyers"];

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

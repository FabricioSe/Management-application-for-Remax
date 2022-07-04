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
    public partial class frmAgents : Form
    {
        public frmAgents()
        {
            InitializeComponent();
        }

        //Global variables
        DataSet myset;
        DataTable tabAgents, tabAdministrators;
        OleDbConnection mycon;
        OleDbDataAdapter myadp, myadpAgent;
        int currentPosition;
        string mode;

        private void btnClose_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to quit the Agent management form?";
            string title = "Management closing";
            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmAgents_Load(object sender, EventArgs e)
        {
            lbltitle.BackColor = lblname.BackColor = lblemail.BackColor = lblpass.BackColor = lblAdmin.BackColor = System.Drawing.Color.Transparent;

            myset = new DataSet();

            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\fojed\Desktop\INFO\LaSalle\Courses\S3\Multi_Tier_Applications\Project_1\ProjectRemaxWindowsForms\ProjectRemaxWindowsForms\Database\Remax_DB.mdb");
            mycon.Open();

            OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Agents", mycon);
            myadpAgent = new OleDbDataAdapter(mycmd);
            myadpAgent.Fill(myset, "Agents"); 

            tabAgents = myset.Tables["Agents"];

            mycmd = new OleDbCommand("SELECT * FROM Administrators", mycon);
            myadp = new OleDbDataAdapter(mycmd);
            myadp.Fill(myset, "Administrators");

            tabAdministrators = myset.Tables["Administrators"];

            currentPosition = 0;
            Display();
            ActivateBTN(true, false, true);
        }

        private void Display()
        {
            txtFullName.Text = tabAgents.Rows[currentPosition]["FullName"].ToString();
            txtEmail.Text = tabAgents.Rows[currentPosition]["Email"].ToString();
            txtPass.Text = tabAgents.Rows[currentPosition]["Pin"].ToString();

            int referAdministrator = Convert.ToInt32(tabAgents.Rows[currentPosition]["ReferAdmin"]);
            cboAdmin.SelectedValue = referAdministrator;
            // Databinding 
            cboAdmin.DataSource = tabAdministrators;
            cboAdmin.DisplayMember = "FullName";
            cboAdmin.ValueMember = "RefAdmin";

            lblInfoAdmin.Text = "Agent " + (currentPosition + 1) + " on a total of " + tabAgents.Rows.Count;
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
            if (currentPosition < (tabAgents.Rows.Count - 1))
            {
                currentPosition += 1;
                Display();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPosition = tabAgents.Rows.Count - 1;
            Display();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "Add";
            txtFullName.Text = txtEmail.Text = txtPass.Text = "";
            txtFullName.Focus();
            cboAdmin.Text = "Select an Administrator";
            lblInfoAdmin.Text = "--- Adding Mode ---";
            ActivateBTN(false, true, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "Edit";
            txtFullName.Focus();
            lblInfoAdmin.Text = "--- Editing Mode ---";
            ActivateBTN(false, true, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to delete this Agent?";
            string title = "Warning : Agent Deletion";

            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Delete row in dataset
                tabAgents.Rows[currentPosition].Delete();
                // Synchronize (update) new contents of dataset in the database
                OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myadpAgent);
                myadpAgent.Update(myset, "Agents");
                // Update the contest of the database into the dataset
                myset.Tables.Remove("Agents");
                // Load table Courses again
                OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Agents", mycon);
                myadpAgent = new OleDbDataAdapter(mycmd);
                myadpAgent.Fill(myset, "Agents");
                tabAgents = myset.Tables["Agents"];

                currentPosition = 0;
                Display();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string pin = txtPass.Text.Trim();
            Int32 RefAdministrator = Convert.ToInt32(cboAdmin.SelectedValue);
            DataRow myrow;

            if (mode == "Add")
            {
                myrow = tabAgents.NewRow();
                myrow["FullName"] = name;
                myrow["Email"] = email;
                myrow["Pin"] = pin;
                myrow["ReferAdmin"] = RefAdministrator;
                tabAgents.Rows.Add(myrow);
                currentPosition = tabAgents.Rows.Count - 1;
            }
            else if (mode == "Edit")
            {
                myrow = tabAdministrators.Rows[currentPosition];
                myrow["FullName"] = name;
                myrow["Email"] = email;
                myrow["Pin"] = pin;
                myrow["ReferAdmin"] = RefAdministrator;
            }
            //new record saved only in the table of the dataset
            //Now we need to update (or synchronize) the contents of the dataset -> the database
            OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myadpAgent);
            myadpAgent.Update(myset, "Agents");

            //Update the contents of the database -> dataset
            myset.Tables.Remove("Agents");
            OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Agents", mycon);
            myadpAgent = new OleDbDataAdapter(mycmd);
            myadpAgent.Fill(myset, "Agents");
            tabAgents = myset.Tables["Agents"];

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

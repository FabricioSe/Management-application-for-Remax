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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        //Global variables
        DataSet myset;
        DataTable tabAdministrators;
        OleDbConnection mycon;
        OleDbDataAdapter myadpAdmin;
        int currentPosition;
        string mode;

        private void btnClose_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to quit the Administrator management form?";
            string title = "Management closing";
            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            lbltitle.BackColor = lblname.BackColor = lblemail.BackColor = lblpass.BackColor = System.Drawing.Color.Transparent;

            myset = new DataSet(); 
            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\fojed\Desktop\INFO\LaSalle\Courses\S3\Multi_Tier_Applications\Project_1\ProjectRemaxWindowsForms\ProjectRemaxWindowsForms\Database\Remax_DB.mdb");
            mycon.Open();
            OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Administrators", mycon);
            myadpAdmin = new OleDbDataAdapter(mycmd);
            myadpAdmin.Fill(myset, "Administrators"); 

            tabAdministrators = myset.Tables["Administrators"];

            currentPosition = 0;
            Display();
            ActivateBTN(true, false, true);
        }

        private void Display()
        {
            txtFullName.Text = tabAdministrators.Rows[currentPosition]["FullName"].ToString();
            txtEmail.Text = tabAdministrators.Rows[currentPosition]["Email"].ToString();
            txtPass.Text = tabAdministrators.Rows[currentPosition]["Pin"].ToString();
            lblInfoAdmin.Text = "Administrator " + (currentPosition + 1) + " on a total of " + tabAdministrators.Rows.Count;
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
            if (currentPosition < (tabAdministrators.Rows.Count - 1))
            {
                currentPosition += 1;
                Display();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPosition = tabAdministrators.Rows.Count - 1;
            Display();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "Add";
            txtFullName.Text = txtEmail.Text = txtPass.Text = "";
            txtFullName.Focus();
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
            string msg = "Are you sure you want to delete this Administrator?";
            string title = "Warning : Administrator Deletion";

            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Delete row in dataset
                tabAdministrators.Rows[currentPosition].Delete();
                // Synchronize (update) new contents of dataset in the database
                OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myadpAdmin);
                myadpAdmin.Update(myset, "Administrators");
                // Update the contest of the database into the dataset
                myset.Tables.Remove("Administrators");
                // Load table Courses again
                OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Administrators", mycon);
                myadpAdmin = new OleDbDataAdapter(mycmd);
                myadpAdmin.Fill(myset, "Administrators");
                tabAdministrators = myset.Tables["Administrators"];

                currentPosition = 0;
                Display();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string pin = txtPass.Text.Trim();
            DataRow myrow;

            if (mode == "Add")
            {
                myrow = tabAdministrators.NewRow();
                myrow["FullName"] = name;
                myrow["Email"] = email;
                myrow["Pin"] = pin;
                tabAdministrators.Rows.Add(myrow);
                currentPosition = tabAdministrators.Rows.Count - 1;
            }
            else if (mode == "Edit")
            {
                myrow = tabAdministrators.Rows[currentPosition];
                myrow["FullName"] = name;
                myrow["Email"] = email;
                myrow["Pin"] = pin;
            }
            //new record saved only in the table of the dataset
            //Now we need to update (or synchronize) the contents of the dataset -> the database
            OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myadpAdmin);
            myadpAdmin.Update(myset, "Administrators");

            //Update the contents of the database -> dataset
            myset.Tables.Remove("Administrators");
            OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Administrators", mycon);
            myadpAdmin = new OleDbDataAdapter(mycmd);
            myadpAdmin.Fill(myset, "Administrators");
            tabAdministrators = myset.Tables["Administrators"];

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

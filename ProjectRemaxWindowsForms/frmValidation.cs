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
    public partial class frmValidation : Form
    {
        public frmValidation()
        {
            InitializeComponent();
        }

        // Global variables
        OleDbConnection mycon;
        OleDbCommand mycmd;
        OleDbDataReader myrder;
        public static string mode = "";

        private void btnExit_Click(object sender, EventArgs e)
        {
            string info = "Are you sure you want to the Remax Application";
            string title = "Close Remax Application";

            if (MessageBox.Show(info, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string pwd = txtPasswd.Text.Trim();
            string sql;

            mycon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Remax_DB.accdb");
            mycon.Open();

            if (rbAdmin.Checked == true)
            {
                sql = "SELECT Email, Pin FROM Administrators WHERE Email = '" + email + "' AND Pin = '" + pwd + "'";
                mycmd = new OleDbCommand(sql, mycon);
                myrder = mycmd.ExecuteReader();
                
                if (myrder.HasRows == true)
                {  
                    mycon.Close();
                    this.Close();
                    mode = "Admin";
                }
                else
                {
                    mycon.Close();
                    txtEmail.Focus();
                    txtPasswd.Clear();
                    lblInfo.Text = "Email or Password not found, try again!";
                }
            }
            else if (rbAgents.Checked == true)
            {
                sql = "SELECT Email, Pin FROM Agents WHERE Email = '" + email + "' AND Pin = '" + pwd + "'";
                mycmd = new OleDbCommand(sql, mycon);
                myrder = mycmd.ExecuteReader();

                if (myrder.HasRows == true)
                {
                    mycon.Close();
                    this.Close();
                    mode = "Agent";
                }
                else
                {
                    mycon.Close();
                    txtEmail.Focus();
                    txtPasswd.Clear();
                    lblInfo.Text = "Email or Password not found, try again!";
                }
            }
            else if (rbSellers.Checked == true)
            {
                sql = "SELECT Email, Pin FROM Sellers WHERE Email = '" + email + "' AND Pin = '" + pwd + "'";
                mycmd = new OleDbCommand(sql, mycon);
                myrder = mycmd.ExecuteReader();

                if (myrder.HasRows == true)
                {
                    mycon.Close();
                    this.Close();
                    mode = "Seller";
                }
                else
                {
                    mycon.Close();
                    txtEmail.Focus();
                    txtPasswd.Clear();
                    lblInfo.Text = "Email or Password not found, try again!";
                }
            }
            else if (rbBuyers.Checked == true)
            {
                sql = "SELECT Email, Pin FROM Buyers WHERE Email = '" + email + "' AND Pin = '" + pwd + "'";
                mycmd = new OleDbCommand(sql, mycon);
                myrder = mycmd.ExecuteReader();

                if (myrder.HasRows == true)
                {
                    mycon.Close();
                    this.Close();
                    mode = "Buyer";
                }
                else
                {
                    mycon.Close();
                    txtEmail.Focus();
                    txtPasswd.Clear();
                    lblInfo.Text = "Email or Password not found, try again!";
                }
            }
            else
            {
                lblInfo.Text = "Please, select one valid option";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmail.Text = txtPasswd.Text = "";
            txtEmail.Focus();
        }
    }
}

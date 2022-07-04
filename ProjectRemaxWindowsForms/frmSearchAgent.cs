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
    public partial class frmSearchAgent : Form
    {
        public frmSearchAgent()
        {
            InitializeComponent();
        }

        // Global variables
        DataSet myset;
        OleDbConnection mycon;
        OleDbDataAdapter myadp;
        DataTable tabAgents;
        int RefAgent;
        string email;

        private void frmSearchAgent_Load(object sender, EventArgs e)
        {
            lblTitle.BackColor = gbSearch.BackColor = System.Drawing.Color.Transparent;

            // Display IDs in checkbox
            myset = new DataSet();
            mycon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Remax_DB.accdb");
            OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Agents", mycon);
            myadp = new OleDbDataAdapter(mycmd);
            myadp.Fill(myset, "Agents");

            tabAgents = myset.Tables["Agents"];

            //LinQ
            var allIDs = from DataRow agn in tabAgents.Rows
                         select new
                         {
                             ID = agn.Field<int>("RefAgent")
                         };
            cboID.DisplayMember = "ID";
            cboID.DataSource = allIDs.Distinct().ToList();
            ///////////////

            //Display Emails in checkbox
            //LinQ
            var allEmails = from DataRow mail in tabAgents.Rows
                            select new { Emails = mail.Field<string>("Email") };
            cboEmail.DisplayMember = "Emails";
            cboEmail.DataSource = allEmails.Distinct().ToList();

            FillGridWithAgents();
        }

        private void FillGridWithAgents()
        {
            // LinQ
            var AgentFound = from DataRow agnt in tabAgents.Rows
                             select new
                             {
                                 Names = agnt.Field<string>("FullName"),
                                 Email = agnt.Field<string>("Email")
                             };

            if (AgentFound.Count() != 0)
            {
                // Display using databinding
                gridSearch.DataSource = AgentFound.ToList();
            }
            else
            {
                gridSearch.DataSource = null;
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (rbnID.Checked == true)
            {
                RefAgent = Convert.ToInt32(cboID.Text);

                // LinQ
                var AgentFound = from DataRow agent in tabAgents.Rows
                                 where agent.Field<int>("RefAgent") == RefAgent
                                 select new
                                 {
                                     Names = agent.Field<string>("FullName"),
                                     Emails = agent.Field<string>("Email")
                                 };

                if (AgentFound.Count() != 0)
                {
                    gridSearch.DataSource = AgentFound.ToList();
                }
                else
                {
                    gridSearch.DataSource = null;
                }
            }
            else if (rbnEmail.Checked == true)
            {
                email = cboEmail.Text;

                // LinQ
                var AgentFound = from DataRow agent in tabAgents.Rows
                                 where agent.Field<string>("Email") == email.ToString()
                                 select new
                                 {
                                     Names = agent.Field<string>("FullName"),
                                     Emails = agent.Field<string>("Email")
                                 };

                if (AgentFound.Count() != 0)
                {
                    gridSearch.DataSource = AgentFound.ToList();
                }
                else
                {
                    gridSearch.DataSource = null;
                }
            }
        }
    }
}

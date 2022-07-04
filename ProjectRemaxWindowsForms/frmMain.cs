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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmValidation validation = new frmValidation();
            validation.ShowDialog();

            if (frmValidation.mode == "Admin")
            {
                mnuManage.Enabled = mnuEmp.Enabled = mnuClients.Enabled = mnuHouses.Enabled = true;
                MessageBox.Show("Welcome Administrator");
            }
            else if (frmValidation.mode == "Agent")
            {
                mnuEmp.Enabled = mnuClients.Enabled = mnuHouses.Enabled = true;
                MessageBox.Show("Welcome Agent");
            }
            else if (frmValidation.mode == "Buyer" || frmValidation.mode == "Seller")
            {
                MessageBox.Show("Welcome Client");
            }
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmValidation validation = new frmValidation();
            validation.ShowDialog();       
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string info = "Are you sure you want to close the Remax application";
            string title = "Close Remax Application";

            if (MessageBox.Show(info, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void administratorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmin admin = new frmAdmin();
            admin.ShowDialog();
        }

        private void agentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgents agent = new frmAgents();
            agent.ShowDialog();
        }

        private void buyersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuyers buyer = new frmBuyers();
            buyer.ShowDialog();
        }

        private void sellersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSellers seller = new frmSellers();
            seller.ShowDialog();
        }

        private void mnuHouses_Click(object sender, EventArgs e)
        {
            frmHouses house = new frmHouses();
            house.ShowDialog();            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSearchAgent agent = new frmSearchAgent();
            agent.ShowDialog();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchHouse house = new frmSearchHouse();
            house.ShowDialog();
        }
    }
}

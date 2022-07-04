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
    public partial class frmSearchHouse : Form
    {
        public frmSearchHouse()
        {
            InitializeComponent();
        }

        // Global variables
        DataSet myset;
        OleDbConnection mycon;
        OleDbDataAdapter myadpHouse;
        DataTable tabAgents, tabHouses, tabSellers;
        string name;
        string loc;
        string ReferAgent;
        string ReferSeller;

        private void frmSearchHouse_Load(object sender, EventArgs e)
        {
            lblTitle.BackColor = gbSearch.BackColor = System.Drawing.Color.Transparent;

            // Display Agents in checkbox
            myset = new DataSet();
            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\fojed\Desktop\INFO\LaSalle\Courses\S3\Multi_Tier_Applications\Project_1\ProjectRemaxWindowsForms\ProjectRemaxWindowsForms\Database\Remax_DB.mdb");
            OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Agents", mycon);
            OleDbDataAdapter myadp = new OleDbDataAdapter(mycmd);
            myadp.Fill(myset, "Agents");

            tabAgents = myset.Tables["Agents"];

            //LinQ
            var allAgents = from DataRow agn in tabAgents.Rows
                         select new
                         {
                             Names = agn.Field<string>("FullName")
                         };
            cboAgent.DisplayMember = "Names";
            cboAgent.DataSource = allAgents.Distinct().ToList();
            ///////////////

            //Display Location in checkbox
            mycmd = new OleDbCommand("SELECT * FROM Houses", mycon);
            myadpHouse = new OleDbDataAdapter(mycmd);
            myadpHouse.Fill(myset, "Houses");

            tabHouses = myset.Tables["Houses"];

            //LinQ
            var allLocations = from DataRow loc in tabHouses.Rows
                            select new { locations = loc.Field<string>("Location") };
            cboLoc.DisplayMember = "Locations";
            cboLoc.DataSource = allLocations.Distinct().ToList();

            // Get information from sellers
            mycmd = new OleDbCommand("SELECT * FROM Sellers", mycon);
            myadp = new OleDbDataAdapter(mycmd);
            myadp.Fill(myset, "Sellers");

            tabSellers = myset.Tables["Sellers"];

            FillGridWithHouses();
        }

        private void FillGridWithHouses()
        {
            // LinQ
            var HouseFound = from DataRow house in tabHouses.Rows
                             select new
                             {
                                 Addresss = house.Field<string>("Address"),
                                 Postals = house.Field<string>("Postal Code"),
                                 Locations = house.Field<string>("Location"),
                                 Types = house.Field<string>("Type"),
                                 Prices = house.Field<decimal>("Price"),
                                 Statuss = house.Field<string>("Status")
                             };

            if (HouseFound.Count() != 0)
            {
                // Display using databinding
                gridSearch.DataSource = HouseFound.ToList();
            }
            else
            {
                gridSearch.DataSource = null;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (rbnAgent.Checked == true)
            {
                name = cboAgent.Text.ToString();
                ReferAgent = "";

                foreach (DataRow myrow in tabAgents.Rows)
                {
                    if (myrow["FullName"].ToString() == name)
                    {
                        ReferAgent = myrow["RefAgent"].ToString();
                        break;
                    }
                }

                ReferSeller = "";

                foreach (DataRow myrow in tabSellers.Rows)
                {
                    if (myrow["ReferAgent"].ToString() == ReferAgent)
                    {
                        ReferSeller = myrow["RefSeller"].ToString();
                        break;
                    }
                }

                // LinQ
                var HouseFound = from DataRow house in tabHouses.Rows
                                 where house.Field<int>("ReferSeller") == Convert.ToInt32(ReferSeller)
                                 select new
                                 {
                                     Addresss = house.Field<string>("Address"),
                                     Postals = house.Field<string>("Postal Code"),
                                     Locations = house.Field<string>("Location"),
                                     Types = house.Field<string>("Type"),
                                     Prices = house.Field<decimal>("Price"),
                                     Statuss = house.Field<string>("Status")
                                 };

                if (HouseFound.Count() != 0)
                {
                    gridSearch.DataSource = HouseFound.ToList();
                }
                else
                {
                    gridSearch.DataSource = null;
                }
            }
            else if (rbnLoc.Checked == true)
            {
                loc = cboLoc.Text.ToString();

                // LinQ
                var HouseFound = from DataRow house in tabHouses.Rows
                                 where house.Field<string>("Location") == loc
                                 select new
                                 {
                                     Addresss = house.Field<string>("Address"),
                                     Postals = house.Field<string>("Postal Code"),
                                     Locations = house.Field<string>("Location"),
                                     Types = house.Field<string>("Type"),
                                     Prices = house.Field<decimal>("Price"),
                                     Statuss = house.Field<string>("Status")
                                 };

                if (HouseFound.Count() != 0)
                {
                    gridSearch.DataSource = HouseFound.ToList();
                }
                else
                {
                    gridSearch.DataSource = null;
                }
            }
        }
    }
}

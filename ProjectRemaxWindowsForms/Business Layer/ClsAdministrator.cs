using System;
using System.Collections.Generic;
using System.Text;

namespace Remax_Business_Layer
{
    public class ClsAdministrator
    {
        private string vAdminName;
        private string vEmployeeID;
        private string vAdminEmail;
        private string vAdminPhone;
        private string vAdminPin;
        private ClsListBuyers vBuyers;
        private ClsListAgents vAgents;
        private ClsListSellers vSellers;
        private ClsListHouses vHouses;

        public ClsAdministrator()
        {
            vAdminName = vEmployeeID = vAdminEmail = vAdminPhone = vAdminPin = "Not Defined";
            vBuyers = new ClsListBuyers();
            vAgents = new ClsListAgents();
            vSellers = new ClsListSellers();
            vHouses = new ClsListHouses();
        }

        public ClsAdministrator(string adminName, string employeeID, string adminEmail, string adminPhone, string adminPin, ClsListBuyers buyers, ClsListAgents agents, ClsListSellers sellers, ClsListHouses houses)
        {
            vAdminName = adminName;
            vEmployeeID = employeeID;
            vAdminEmail = adminEmail;
            vAdminPhone = adminPhone;
            vAdminPin = adminPin;
            vBuyers = buyers;
            vAgents = agents;
            vSellers = sellers;
            vHouses = houses;
        }

        public string AdminName { get => vAdminName; set => vAdminName = value; }
        public string EmployeeID { get => vEmployeeID; set => vEmployeeID = value; }
        public string AdminEmail { get => vAdminEmail; set => vAdminEmail = value; }
        public string AdminPhone { get => vAdminPhone; set => vAdminPhone = value; }
        public string AdminPin { get => vAdminPin; set => vAdminPin = value; }
        public ClsListBuyers Buyers { get => vBuyers; set => vBuyers = value; }
        public ClsListAgents Agents { get => vAgents; set => vAgents = value; }
        public ClsListSellers Sellers { get => vSellers; set => vSellers = value; }
        public ClsListHouses Houses { get => vHouses; set => vHouses = value; }
    }
}
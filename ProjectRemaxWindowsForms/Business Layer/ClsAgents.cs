using System;
using System.Collections.Generic;
using System.Text;

namespace Remax_Business_Layer
{
    public class ClsAgents
    {
        private string vAgentEmail;
        private string vAgentName;
        private string vEmployeeID;
        private string vAgentPhone;
        private string vAgentPin;
        private ClsListBuyers vBuyers;
        private ClsListHouses vHouses;
        private ClsListSellers vSellers;

        public ClsAgents()
        {
            vAgentEmail = vAgentName = vEmployeeID = vAgentPhone = vAgentPin = "Not Defined";
            vBuyers = new ClsListBuyers();
            vHouses = new ClsListHouses();
            vSellers = new ClsListSellers();
        }

        public ClsAgents(string agentEmail, string agentName, string employeeID, string agentPhone, string agentPin, ClsListBuyers buyers, ClsListHouses houses, ClsListSellers sellers)
        {
            AgentEmail = agentEmail;
            AgentName = agentName;
            EmployeeID = employeeID;
            AgentPhone = agentPhone;
            AgentPin = agentPin;
            Buyers = buyers;
            Houses = houses;
            Sellers = sellers;
        }

        public string AgentEmail { get => vAgentEmail; set => vAgentEmail = value; }
        public string AgentName { get => vAgentName; set => vAgentName = value; }
        public string EmployeeID { get => vEmployeeID; set => vEmployeeID = value; }
        public string AgentPhone { get => vAgentPhone; set => vAgentPhone = value; }
        public string AgentPin { get => vAgentPin; set => vAgentPin = value; }
        public ClsListBuyers Buyers { get => vBuyers; set => vBuyers = value; }
        public ClsListHouses Houses { get => vHouses; set => vHouses = value; }
        public ClsListSellers Sellers { get => vSellers; set => vSellers = value; }
    }
}
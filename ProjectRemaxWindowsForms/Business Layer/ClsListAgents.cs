using System;
using System.Collections.Generic;
using System.Text;

namespace Remax_Business_Layer
{
    public class ClsListAgents
    {
        private List<ClsAgents> myListAgents;

        public ClsListAgents()
        {
            myListAgents = new List<ClsAgents>();
        }

        public int NumberOf
        {
            get
            {
                return myListAgents.Count;
            }
        }

        public bool Add(ClsAgents Agen)
        {
            if (Exist(Agen.EmployeeID) == false)
            {
                myListAgents.Add(Agen);
                return true;
            }
            else
            {
                return false;
            }    
        }

        public bool Delete(string EmployeeID)
        {
            ClsAgents agenFound = Find(EmployeeID);
            if (agenFound == null)
            {
                return false;
            }
            else
            {
                return myListAgents.Remove(agenFound); // Returns true
            }    
        }

        public bool Exist(string EmployeeID)
        {
            bool result = false;
            foreach (ClsAgents agen in myListAgents)
            {
                if (agen.EmployeeID == EmployeeID)
                {
                    result = true;
                    return result;
                }
            }
            return result;
        }

        public ClsAgents Find(string EmployeeID)
        {
           foreach (ClsAgents agen in myListAgents)
            {
                if (agen.EmployeeID == EmployeeID)
                {
                    return agen;
                }
            }
            return null;
        }
    }
}
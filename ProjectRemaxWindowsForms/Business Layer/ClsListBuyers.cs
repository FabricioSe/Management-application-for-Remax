using System;
using System.Collections.Generic;
using System.Text;

namespace Remax_Business_Layer
{
    public class ClsListBuyers
    {
        private List<ClsBuyers> myListBuyers;

        public ClsListBuyers()
        {
            myListBuyers = new List<ClsBuyers>();
        }
        public int NumberOf
        {
            get
            {
                return myListBuyers.Count;
            }
        }

        public bool Add(ClsBuyers Buyer)
        {
            if (Exist(Buyer.ClientID) == false)
            {
                myListBuyers.Add(Buyer);
                return true;
            }
            else
            {
                return false;
            }            
        }

        public bool Delete(string ClientID)
        {
            ClsBuyers buyerFound = Find(ClientID);
            if (buyerFound == null)
            {
                return false;
            }
            else
            {
                return myListBuyers.Remove(buyerFound); // Returns True
            }
        }

        public bool Exist(string ClientID)
        {
            bool result = false;
            foreach (ClsBuyers buyer in myListBuyers)
            {
                if (buyer.ClientID == ClientID)
                {
                    result = true;
                    return result;
                }
            }
            return result;
        }

        public ClsBuyers Find(string ClientID)
        {
            foreach (ClsBuyers Buyer in myListBuyers)
            {
                if (Buyer.ClientID == ClientID)
                {
                    return Buyer;
                }
            }
            return null;
        }
    }
}
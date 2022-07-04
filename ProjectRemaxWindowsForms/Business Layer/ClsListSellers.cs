using System;
using System.Collections.Generic;
using System.Text;

namespace Remax_Business_Layer
{
    public class ClsListSellers
    {
        public List<ClsSellers> myListSellers;

        public ClsListSellers()
        {
            myListSellers = new List<ClsSellers>();
        }
        public int NumberOf
        {
            get
            {
                return myListSellers.Count;
            }
        }

        public bool Add(ClsSellers seller)
        {
            if (Exist(seller.SellerID) == false)
            {
                myListSellers.Add(seller);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete()
        {
            throw new System.NotImplementedException();
        }

        public bool Exist(string SellerID)
        {
            bool result = false;
            foreach (ClsSellers seller in myListSellers)
            {
                if (seller.SellerID == SellerID)
                {
                    result = true;
                    return result;
                }
            }
            return result;
        }

        public ClsSellers Find(string SellerID)
        {
            foreach (ClsSellers seller in myListSellers)
            {
                if (seller.SellerID == SellerID)
                {
                    return seller;
                }
            }
            return null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Remax_Business_Layer
{
    public class ClsSellers
    {
        private string vSellerEmail;
        private string vSellerID;
        private string vSellerName;
        private string vSellerNumber;
        private ClsListHouses vHouses;

        public ClsSellers()
        {
            vSellerEmail = vSellerName = vSellerNumber = vSellerID = "Not Defined";
            vHouses = new ClsListHouses();
        }

        public ClsSellers(string sellerEmail, string sellerID, string sellerName, string sellerNumber, ClsListHouses houses)
        {
            SellerEmail = sellerEmail;
            SellerID = sellerID;
            SellerName = sellerName;
            SellerNumber = sellerNumber;
            Houses = houses;
        }

        public string SellerEmail
        {
            get => default;
            set
            {
            }
        }

        public string SellerID { get => vSellerID; set => vSellerID = value; }

        public string SellerName
        {
            get => default;
            set
            {
            }
        }

        public string SellerNumber
        {
            get => default;
            set
            {
            }
        }

        public ClsListHouses Houses
        {
            get => default;
            set
            {
            }
        }

        public void Register(string sellerEmail, string sellerName, string sellerNumber)
        {
            SellerEmail = sellerEmail;
            SellerName = sellerName;
            SellerNumber = sellerNumber;
        }
    }
}
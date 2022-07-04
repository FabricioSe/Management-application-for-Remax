using System;
using System.Collections.Generic;
using System.Text;

namespace Remax_Business_Layer
{
    public class ClsBuyers
    {
        private string vBuyerEmail;
        private string vBuyerName;
        private string vClientID;
        private string vBuyerPhone;
        private ClsListHouses vHouses;

        public ClsBuyers()
        {
            vBuyerEmail = vBuyerName = vClientID = vBuyerPhone = "Not Defined";
            vHouses = new ClsListHouses();
        }

        public ClsBuyers(string buyerEmail, string buyerName, string clientID, string buyerPhone, ClsListHouses houses)
        {
            BuyerEmail = buyerEmail;
            BuyerName = buyerName;
            ClientID = clientID;
            BuyerPhone = buyerPhone;
            Houses = houses;
        }

        public string BuyerEmail
        {
            get => default;
            set
            {
            }
        }

        public string BuyerName
        {
            get => default;
            set
            {
            }
        }

        public string ClientID
        {
            get => default;
            set
            {
            }
        }

        public string BuyerPhone { get => vBuyerPhone; set => vBuyerPhone = value; }
        public ClsListHouses Houses
        {
            get => default;
            set
            {
            }
        }

        public void Register(string buyerEmail, string buyerName, string clientID, string buyerPhone)
        {
            BuyerEmail = buyerEmail;
            BuyerName = buyerName;
            ClientID = clientID;
            BuyerPhone = buyerPhone;
        }
    }
}
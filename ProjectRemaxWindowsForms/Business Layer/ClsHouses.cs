using System;
using System.Collections.Generic;
using System.Text;

namespace Remax_Business_Layer
{
    public class ClsHouses
    {
        private string vHouseLocation;
        private string vHouseID;
        private decimal vHousePrice;
        private string vHouseType;
        private bool vHouseStatus;
        private ClsListSellers vSellers;

        public ClsHouses()
        {
            vHouseLocation = vHouseType = vHouseID = "Not Defined";
            vHousePrice = -1;
            vHouseStatus = true;
            vSellers = new ClsListSellers();
        }
        public ClsHouses(string houseLocation, string houseID, decimal housePrice, string houseType, bool houseStatus, ClsListSellers sellers)
        {
            HouseLocation = houseLocation;
            HouseID = houseID;
            HousePrice = housePrice;
            HouseType = houseType;
            HouseStatus = houseStatus;
            Sellers = sellers;
        }

        public string HouseLocation
        {
            get => default;
            set
            {
            }
        }

        public string HouseID { get => vHouseID; set => vHouseID = value; }

        public decimal HousePrice
        {
            get => default;
            set
            {
            }
        }

        public bool HouseStatus
        {
            get => default;
            set
            {
            }
        }

        public string HouseType
        {
            get => default;
            set
            {
            }
        }

        public ClsListSellers Sellers
        {
            get => default;
            set
            {
            }
        }
    }
}
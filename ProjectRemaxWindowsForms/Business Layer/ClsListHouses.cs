using System;
using System.Collections.Generic;
using System.Text;

namespace Remax_Business_Layer
{
    public class ClsListHouses
    {
        private List<ClsHouses> myListHouses;

        public ClsListHouses()
        {
            myListHouses = new List<ClsHouses>();
        }

        public int NumberOf
        {
            get 
            {
                return myListHouses.Count;
            }
        }

        public bool Add(ClsHouses House)
        {
            if (Exist(House.HouseID) == false)
            {
                myListHouses.Add(House);
                return true;
            }
            return false;
        }

        public bool Delete(string HouseID)
        {
            ClsHouses houseFound = Find(HouseID);
            if (houseFound == null)
            {
                return false;
            } 
            else
            {
                return myListHouses.Remove(houseFound); // Returns true
            }
        }

        public bool Exist(string HouseID)
        {
            bool result = false;
            foreach (ClsHouses house in myListHouses)
            {
                if (house.HouseID == HouseID)
                {
                    result = true;
                    return result;
                }
            }
            return result;
        }

        public ClsHouses Find(string HouseID)
        {
            foreach (ClsHouses house in myListHouses)
            {
                if (house.HouseID == HouseID)
                {
                    return house;
                }
            }
            return null;
        }
    }
}
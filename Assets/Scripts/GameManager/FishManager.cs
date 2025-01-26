using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public static class FishManager
    {

        public const string BLOBFISH = "Blobfish";
        public const string CRAB = "Crab";
        public const string FALSE_BOAT_FISH = "False Boat Fish";
        public const string OARFISH = "Oarfish";
        public const string SALMON = "Salmon";
        public const string SNAIL = "Snail";
        public const string SQUID = "Squid";
        public const string URCHIN = "Urchin";
        public const string ANGLER = "Angler";
        public const string 
        
        private static Dictionary<string, bool> FishFound = new Dictionary<string, bool>()
        {
            {BLOBFISH, false},
            {CRAB, false},
            {FALSE_BOAT_FISH, false},
            {OARFISH, false},
            {SALMON, false},
            {SNAIL, false},
            {SQUID, false},
            {URCHIN, false},
            {ANGLER, false}
        };

        public static void CollectFish(string fishName)
        {
            if (FishFound.ContainsKey(fishName))
            {
                FishFound[fishName] = true;
                Debug.Log(fishName + " Found!");
            }
            else
            {
                Debug.Log("Fish is not in Dictionary");
            }

            if (FishFound[BLOBFISH])
            {
                Victory();
            }
            
        }

        private static void Victory()
        {
            Time.timeScale = 0;
            DisplayLeaderboard();
        }

        private static void DisplayLeaderboard()
        {
            
        }
        
    }
}

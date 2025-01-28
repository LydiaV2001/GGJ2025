using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManager
{
    public static class FishManager
    {

        public const string BLOBFISH = "Blobfish";
        public const string CRAB = "Crab";
        public const string FALSE_BOAR_FISH = "FalseBoarFish";
        public const string OARFISH = "Oarfish";
        public const string SALMON = "Salmon";
        public const string SNAIL = "Snail";
        public const string SQUID = "Squid";
        public const string URCHIN = "Urchin";
        public const string ANGLER = "Angler";
        public const string DOLPHIN = "Dolphin";
        public const string PUFFER_FISH = "Pufferfish";
        public const string SWORD_FISH = "Swordfish";



        public const string ROCK = "Rock";

        
        private static Dictionary<string, bool> FishFound = new Dictionary<string, bool>()
        {
            {BLOBFISH, false},
            {CRAB, false},
            {FALSE_BOAR_FISH, false},
            {OARFISH, false},
            {SALMON, false},
            {SNAIL, false},
            {SQUID, false},
            {URCHIN, false},
            {ANGLER, false},
            {DOLPHIN, false},
            {PUFFER_FISH, false},
            {SWORD_FISH, false},
        };

        public static void CollectFish(string fishName)
        {
            Debug.Log(fishName);
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

            if(fishName == "Rock"){
                SceneManager.LoadScene("MainMenu");
            }
            
        }

        private static void Victory()
        {
            SceneManager.LoadScene("End");
        }

    }
}

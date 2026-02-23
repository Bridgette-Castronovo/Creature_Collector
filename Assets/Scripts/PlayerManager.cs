using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public int playerMoney = 20000;
    public Dictionary<string, int> inventory = new Dictionary<string, int>();

    


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        inventory["feed"] = 5;
        inventory["water"] = 5;
        inventory["chew toy"] = 1;
    }

    
}

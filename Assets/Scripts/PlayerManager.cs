using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public int playerMoney = 20000;
    public int day = 1;
    public Dictionary<string, int> foodInventory = new Dictionary<string, int>();

    


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


        foodInventory["Fruit"] = 5;
        foodInventory["Grains"] = 5;
        foodInventory["Meat"] = 5;
        foodInventory["Crystal"] = 0;
    }

    public int getMoney()
    {
        return playerMoney;
    }

    public void addMoney(int amount)
    {
        playerMoney += amount;
    }

    public void subtractMoney(int amount)
    {
        playerMoney -= amount;
    }

    public void progressDay()
    {
        day += 1;
        playerMoney += 1000;
    }

    
}

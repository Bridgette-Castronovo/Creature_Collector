using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    private int playerMoney = 20000;
    private int day = 1;
    public Dictionary<string, int> foodInventory = new Dictionary<string, int>();
    public Dictionary<string, int> medInventory = new Dictionary<string, int>();
    public Dictionary<int, Creature> creatureInventory = new Dictionary<int, Creature>();

    


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);


        foodInventory["Fruit"] = 5;
        foodInventory["Grains"] = 5;
        foodInventory["Meat"] = 5;
        foodInventory["Crystal Dust"] = 0;

        medInventory["Cast"] = 1;
        medInventory["Antiparasitic"] = 1;
        medInventory["Antibiotic"] = 1;
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

    public int getDay()
    {
        return day;
    }

    
}

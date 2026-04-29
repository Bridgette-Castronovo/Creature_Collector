using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEditor;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    private int playerMoney = 20000;
    public int earnedToday = 0;
    public int spentToday = 0;
    private int day = 1;
    private int animalIdCounter = 1;
    public Dictionary<string, int> foodInventory = new Dictionary<string, int>();
    public Dictionary<string, int> medInventory = new Dictionary<string, int>();
    


    

    public Dictionary<int, Animal> creatureInventory = new Dictionary<int, Animal>();
    public Queue<Animal> unassignedAnimals = new Queue<Animal>();
    public List<Habitat> habitats = new List<Habitat>();



    //quest variables
    public bool quest2Triggered = false;
    public bool quest3Triggered = false;
    public bool quest4Triggered = false;
    public bool quest5Triggered = false;
    public bool quest6Triggered = false;



    


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);


        if (habitats.Count == 0)
        {
            InitializePlayerData();
        }

    }

    private void InitializePlayerData()
    {
        // Create initial habitats and animals for the player
        Habitat habitat1 = CreateHabitat();
        habitat1.animal1 = null;
        Habitat habitat2 = CreateHabitat();

        foodInventory["Fruit"] = 5;
        foodInventory["Grains"] = 5;
        foodInventory["Meat"] = 10;
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
        earnedToday += amount;
        playerMoney += amount;
    }

    public void subtractMoney(int amount)
    {
        spentToday += amount;
        playerMoney -= amount;
    }

    public void progressDay()
    {
        day += 1;
    }

    public int getDay()
    {
        return day;
    }


    public Animal GenerateRandAnimal(Creature creature)
    {
        Debug.Log("New Animal Generated");
        Animal newAnimal = new Animal();
        newAnimal.id = animalIdCounter;
        animalIdCounter += 1;
        newAnimal.creature = creature;
        newAnimal.health = 100;
        newAnimal.habitatHappiness = 100;
        newAnimal.hunger = 100.0f;
        newAnimal.illnesses = new int[3] { 0, 0, 0 };

        creatureInventory[newAnimal.id] = newAnimal;
        unassignedAnimals.Enqueue(newAnimal);
        return newAnimal;
    }

    public Animal GenerateSickAnimal(Creature creature, int ill1, int ill2, int ill3)
    {
        Animal newAnimal = new Animal();
        newAnimal.id = animalIdCounter;
        animalIdCounter += 1;
        newAnimal.creature = creature;
        newAnimal.health = 100;
        newAnimal.habitatHappiness = 100;
        newAnimal.hunger = 100.0f;

        newAnimal.illnesses = new int[3] { ill1, ill2, ill3 };
        creatureInventory[newAnimal.id] = newAnimal;
        unassignedAnimals.Enqueue(newAnimal);
        return newAnimal;
    }

    public Habitat CreateHabitat()
    {
        Habitat newHabitat = new Habitat();
        newHabitat.animal1 = null;
        newHabitat.animal2 = null;
        newHabitat.animal3 = null;
        newHabitat.animal4 = null;
        newHabitat.temperature = 50;
        newHabitat.waterLevel = 50;
        habitats.Add(newHabitat);
        return newHabitat;
    }

    public void calculateHabitatHappiness()
    {
        foreach (var animal in creatureInventory.Values)
        {
            if (animal.waterCurr < animal.creature.waterIdeal-10 || animal.waterCurr > animal.creature.waterIdeal+10)
            {
                animal.habitatHappiness -= 10;
            }
            else
            {
                animal.habitatHappiness += 5;
            }

            if (animal.tempCurr < animal.creature.tempIdeal-10 || animal.tempCurr > animal.creature.tempIdeal+10)
            {
                animal.habitatHappiness -= 10;
            }
            else
            {
                animal.habitatHappiness += 5;
            }

            animal.habitatHappiness = Math.Clamp(animal.habitatHappiness, 0, 100);
        }
        
    }

    public void calculateHealth()
    {
        foreach (var animal in creatureInventory.Values)
        {
            if (animal.hunger < 50)
            {
                animal.health -= 30;
            }
            if (animal.hunger > 80)
            {
                animal.health += 5;
            }
            if (animal.habitatHappiness < 50)
            {
                animal.health -= 10;
            }
            if (animal.habitatHappiness > 80)
            {
                animal.health += 5;
            }
            if (animal.illnesses[0] == 1)
            {
                animal.health -= 10;
            }
            if (animal.illnesses[1] == 1)
            {
                animal.health -= 10;
            }
            if (animal.illnesses[2] == 1)
            {
                animal.health -= 20;
            }
            if (animal.dayFruit < animal.creature.fruitIdeal)
            {
                animal.health -= 10;
            }
            if (animal.dayMeat < animal.creature.meatIdeal)
            {
                animal.health -= 10;
            }
            if (animal.dayGrains < animal.creature.grainsIdeal)
            {
                animal.health -= 10;
            }
            if (animal.dayCrystal < animal.creature.crystalIdeal)
            {
                animal.health -= 10;
            }

            animal.health = Math.Clamp(animal.health, 0, 100);
            
        }
        
    }

    public void setHunger()
    {
        foreach (var animal in creatureInventory.Values)
        {
            animal.hunger = 100;
        }
    }

    public int getProfits()
    {
        int totalProfits = 0;
        foreach (var val in creatureInventory.Values)
        {
            totalProfits += Mathf.RoundToInt(val.creature.value * (val.health / 100f));
            Debug.Log("Total Profits: " + totalProfits);
        }

        return totalProfits;
            
    }

    public string getIllnesses(Animal animal)
    {
        string illnessString = "";
        if (animal.illnesses[0] == 1)
        {
            illnessString += "Broken Bone\n";
        }
        if (animal.illnesses[1] == 1)
        {
            illnessString += "Parasites\n";
        }
        if (animal.illnesses[2] == 1)
        {
            illnessString += "Disease";
        }

        if (illnessString == "")
        {
            illnessString = "None";
        }

        return illnessString;
    }

    public void advanceDay()
    {
        earnedToday = 0;
        spentToday = 0;
        calculateHabitatHappiness();
        calculateHealth();
        setHunger();
        progressDay();
    }

    
}

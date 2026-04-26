using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    private int playerMoney = 20000;
    private int earnedToday = 0;
    private int spentToday = 0;
    private int day = 1;
    private int animalIdCounter = 1;
    public Dictionary<string, int> foodInventory = new Dictionary<string, int>();
    public Dictionary<string, int> medInventory = new Dictionary<string, int>();
    


    

    public Dictionary<int, Animal> creatureInventory = new Dictionary<int, Animal>();
    public Queue<Animal> unassignedAnimals = new Queue<Animal>();
    public List<Habitat> habitats = new List<Habitat>();


    


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
        playerMoney += 1000;
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
        newAnimal.hunger = 100;

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
        newAnimal.hunger = 100;

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

    public void calculateHealth()
    {
        foreach (var animal in creatureInventory.Values)
        {
            
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
            totalProfits += (val.creature.value * (val.health / 100));
        }

        return totalProfits;
            
    }

    
}

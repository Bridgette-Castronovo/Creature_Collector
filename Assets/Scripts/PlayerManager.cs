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


        foodInventory["Fruit"] = 5;
        foodInventory["Grains"] = 5;
        foodInventory["Meat"] = 5;
        foodInventory["Crystal Dust"] = 0;

        medInventory["Cast"] = 1;
        medInventory["Antiparasitic"] = 1;
        medInventory["Antibiotic"] = 1;

        Habitat firstHabitat = CreateHabitat();
        habitats.Add(firstHabitat);

        Habitat secondHabitat = CreateHabitat();
        habitats.Add(secondHabitat);
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
        Animal newAnimal = new Animal();
        newAnimal.id = animalIdCounter;
        animalIdCounter += 1;
        newAnimal.creature = creature;
        newAnimal.health = 100;
        newAnimal.habitatHappiness = 100;
        newAnimal.hunger = 0;

        creatureInventory[newAnimal.id] = newAnimal;
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
        newAnimal.hunger = 0;

        newAnimal.illnesses = new int[3] { ill1, ill2, ill3 };
        creatureInventory[newAnimal.id] = newAnimal;
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

    
}

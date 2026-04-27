using UnityEngine;
using TMPro;
// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using System;
using UnityEngine.Timeline;
using System.Collections.Generic;
using UnityEditor;
using static PlayerManager;

public class HabitatManager : MonoBehaviour
{
    //habitat buttons
    [SerializeField] private Button FeedButton;
    [SerializeField] private Button MedButton;
    [SerializeField] private Button HabitatButton;

    //canvases
    [SerializeField] private Canvas FeedCanvas;
    [SerializeField] private Canvas MedCanvas;
    [SerializeField] private Canvas HabitatCanvas;
    [SerializeField] private Canvas SelectCanvas;
    [SerializeField] private Canvas HealthCanvas;
    [SerializeField] private Canvas DailyReportCanvas;

    //animal canvases
    [SerializeField] private Canvas Creature1Canvas;
    [SerializeField] private Canvas Creature2Canvas;
    [SerializeField] private Canvas Creature3Canvas;
    [SerializeField] private Canvas Creature4Canvas;


    //food inventory text
    [SerializeField] private TextMeshProUGUI fruitAmt;
    [SerializeField] private TextMeshProUGUI meatAmt;
    [SerializeField] private TextMeshProUGUI grainAmt;
    [SerializeField] private TextMeshProUGUI crystalAmt;

    //mix weight
    [SerializeField] private TextMeshProUGUI weightText;

    //food fill bars
    [SerializeField] private Image fruitFill;
    [SerializeField] private Image meatFill;
    [SerializeField] private Image grainsFill;
    [SerializeField] private Image crystalFill;


    //med inventory text
    [SerializeField] private TextMeshProUGUI castAmt;
    [SerializeField] private TextMeshProUGUI bacAmt;
    [SerializeField] private TextMeshProUGUI parAmt;

    //med menu text
    [SerializeField] private TextMeshProUGUI currIllnesses;
    [SerializeField] private TextMeshProUGUI currMedText;

    //habitat menu text
    [SerializeField] private TextMeshProUGUI tempText;
    [SerializeField] private TextMeshProUGUI waterText;


    //food type scriptable objects
    [SerializeField] private FoodType fruitData;
    [SerializeField] private FoodType grainData;
    [SerializeField] private FoodType meatData;
    [SerializeField] private FoodType crystalData;

    //med type scriptable objects
    [SerializeField] private MedType castData;
    [SerializeField] private MedType antiparasiticData;
    [SerializeField] private MedType antibioticData;

    //creature type scriptable objects
    [SerializeField] private Creature dragonData;


    //health menu text
    [SerializeField] private TextMeshProUGUI hungerText;
    [SerializeField] private TextMeshProUGUI habitatText;
    [SerializeField] private TextMeshProUGUI illnessText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI creatureID;

    //header and next day text
    [SerializeField] private TextMeshProUGUI animalCount;
    [SerializeField] private TextMeshProUGUI earnedText;
    [SerializeField] private TextMeshProUGUI spentText;


    private Dictionary<String, int> foodMixInv = new Dictionary<String, int>();
    private MedType currMed;
    private int habitatIndex;
    private Habitat currHabitat;

    private int currWeight = 0;
    private float maxWeight = 1;
    private int numAnimals = 0;

    private int menuState = 0;

    
    private Animal currAnimal;

    private Animal habAnimal1;
    private Animal habAnimal2;
    private Animal habAnimal3;
    private Animal habAnimal4;

    private bool research = false;

    


    void Awake()
    {
        Creature1Canvas.gameObject.SetActive(false);
        Creature2Canvas.gameObject.SetActive(false);
        Creature3Canvas.gameObject.SetActive(false);
        Creature4Canvas.gameObject.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foodMixInv["Fruit"] = 0;
        foodMixInv["Grains"] = 0;
        foodMixInv["Meat"] = 0;
        foodMixInv["Crystal Dust"] = 0;

        
        currAnimal = null;
        currMed = null;

        habitatIndex = 0;
        currHabitat = PlayerManager.Instance.habitats[habitatIndex];

        fruitFill.fillAmount = 0;
        meatFill.fillAmount = 0;
        grainsFill.fillAmount = 0;
        crystalFill.fillAmount = 0;
        
        
        updateAnimalSlots();


        

        
    }

    // Update is called once per frame
    void Update()
    {
        // if (currAnimal != null)
        // {
        //     Debug.Log("Current animal: " + currAnimal.id);

        // }

        animalCount.text = PlayerManager.Instance.creatureInventory.Count.ToString() + "/" + PlayerManager.Instance.habitats.Count * 4;
        
        if (menuState == 0)
        {
            FeedCanvas.gameObject.SetActive(false);
            MedCanvas.gameObject.SetActive(false);
            HabitatCanvas.gameObject.SetActive(false);
            SelectCanvas.gameObject.SetActive(false);
            HealthCanvas.gameObject.SetActive(false);
            DailyReportCanvas.gameObject.SetActive(false);
        }

        if (menuState == 1)
        {
            FeedCanvas.gameObject.SetActive(true);
            MedCanvas.gameObject.SetActive(false);
            HabitatCanvas.gameObject.SetActive(false);
            SelectCanvas.gameObject.SetActive(false);
            HealthCanvas.gameObject.SetActive(false);
            DailyReportCanvas.gameObject.SetActive(false);

            fruitAmt.text = "x" + PlayerManager.Instance.foodInventory["Fruit"].ToString();
            meatAmt.text = "x" + PlayerManager.Instance.foodInventory["Meat"].ToString();
            grainAmt.text = "x" + PlayerManager.Instance.foodInventory["Grains"].ToString();
            crystalAmt.text = "x" + PlayerManager.Instance.foodInventory["Crystal Dust"].ToString();

            

            weightText.text = currWeight.ToString() + " lbs";
        }

        if (menuState == 2)
        {
            FeedCanvas.gameObject.SetActive(false);
            MedCanvas.gameObject.SetActive(true);
            HabitatCanvas.gameObject.SetActive(false);
            SelectCanvas.gameObject.SetActive(true);
            HealthCanvas.gameObject.SetActive(false);
            DailyReportCanvas.gameObject.SetActive(false);

            // if (currAnimal != null)
            // {
            //     currIllnesses.text = String.Join("\n", currAnimal.illnesses);
            // }
            // if (currMed != null)
            // {
            //     currMedText.text = currMed.getName();
            // }
                
            // castAmt.text = "x" + PlayerManager.Instance.medInventory["Cast"].ToString();
            // bacAmt.text = "x" + PlayerManager.Instance.medInventory["Antibiotic"].ToString();
            // parAmt.text = "x" + PlayerManager.Instance.medInventory["Antiparasitic"].ToString();
            
        }

        if (menuState == 3)
        {
            FeedCanvas.gameObject.SetActive(false);
            MedCanvas.gameObject.SetActive(false);
            HabitatCanvas.gameObject.SetActive(true);
            SelectCanvas.gameObject.SetActive(false);
            HealthCanvas.gameObject.SetActive(false);
            DailyReportCanvas.gameObject.SetActive(false);

            waterText.text = currHabitat.waterLevel.ToString() + "%";
            tempText.text = currHabitat.temperature.ToString() + "%";
        }

        if (menuState == 4)
        {
            FeedCanvas.gameObject.SetActive(false);
            MedCanvas.gameObject.SetActive(false);
            HabitatCanvas.gameObject.SetActive(false);
            SelectCanvas.gameObject.SetActive(true);
            HealthCanvas.gameObject.SetActive(true);
            DailyReportCanvas.gameObject.SetActive(false);

            if (currAnimal != null)
            {
                hungerText.text = currAnimal.hunger.ToString() + "%";
                habitatText.text = currAnimal.habitatHappiness.ToString() + "%";
                illnessText.text = PlayerManager.Instance.getIllnesses(currAnimal);
                healthText.text = currAnimal.health.ToString() + "%";
                creatureID.text = "ID: " + currAnimal.id.ToString();
            } else
            {
                hungerText.text = "---";
                habitatText.text = "---";
                illnessText.text = "---";
                healthText.text = "---";
                creatureID.text = "No Creature Selected";
            }
        }

        if (menuState == 5)
        {
            FeedCanvas.gameObject.SetActive(false);
            MedCanvas.gameObject.SetActive(false);
            HabitatCanvas.gameObject.SetActive(false);
            SelectCanvas.gameObject.SetActive(false);
            HealthCanvas.gameObject.SetActive(false);
            DailyReportCanvas.gameObject.SetActive(true);
        }
        
    }

    public void FruitAddOnClick()
    {
        if (PlayerManager.Instance.foodInventory["Fruit"] >= 1 && (currWeight + fruitData.getWeight() <= maxWeight))
        {
            PlayerManager.Instance.foodInventory["Fruit"] -= 1;

            foodMixInv["Fruit"] += 1;

            currWeight += fruitData.getWeight();
            updateFoodFill();
            
        } 
    }

    public void FruitRemoveOnClick()
    {
        if (foodMixInv["Fruit"] >= 1)
        {
            PlayerManager.Instance.foodInventory["Fruit"] += 1;

            foodMixInv["Fruit"] -= 1;

            currWeight -= fruitData.getWeight();
            updateFoodFill();
            
        } 
    }

    public void MeatAddOnClick()
    {
        if (PlayerManager.Instance.foodInventory["Meat"] >= 1 && (currWeight + meatData.getWeight() <= maxWeight))
        {
            PlayerManager.Instance.foodInventory["Meat"] -= 1;

            foodMixInv["Meat"] += 1;

            currWeight += meatData.getWeight();
            updateFoodFill();
            
        } 
    }

    public void MeatRemoveOnClick()
    {
        if (foodMixInv["Meat"] >= 1)
        {
            PlayerManager.Instance.foodInventory["Meat"] += 1;

            foodMixInv["Meat"] -= 1;

            currWeight -= meatData.getWeight();
            updateFoodFill();
            
        } 
    }

    public void GrainAddOnClick()
    {
        if (PlayerManager.Instance.foodInventory["Grains"] >= 1 && (currWeight + grainData.getWeight() <= maxWeight))
        {
            PlayerManager.Instance.foodInventory["Grains"] -= 1;

            foodMixInv["Grains"] += 1;

            currWeight += grainData.getWeight();
            updateFoodFill();
            
        } 
    }

    public void GrainRemoveOnClick()
    {
        if (foodMixInv["Grains"] >= 1)
        {
            PlayerManager.Instance.foodInventory["Grains"] += 1;

            foodMixInv["Grains"] -= 1;

            currWeight -= grainData.getWeight();
            updateFoodFill();
            
        } 
    }

    public void CrystalAddOnClick()
    {
        if (PlayerManager.Instance.foodInventory["Crystal Dust"] >= 1 && (currWeight + crystalData.getWeight() <= maxWeight))
        {
            PlayerManager.Instance.foodInventory["Crystal Dust"] -= 1;

            foodMixInv["Crystal Dust"] += 1;

            currWeight += crystalData.getWeight();
            updateFoodFill();
            
        } 
    }

    public void CrystalRemoveOnClick()
    {
        if (foodMixInv["Crystal Dust"] >= 1)
        {
            PlayerManager.Instance.foodInventory["Crystal Dust"] += 1;

            foodMixInv["Crystal Dust"] -= 1;

            currWeight -= crystalData.getWeight();
            updateFoodFill();
            
        } 
    }

    public void FeedAnimals()
    {
        int eating = countAnimals();
        if (habAnimal1 != null && habAnimal1.id != 0)
        {
            habAnimal1.hunger -= (((float)currWeight / eating) / maxWeight) * 100f;
            habAnimal1.hunger = System.Math.Clamp(habAnimal1.hunger, 0f, 100f);
            habAnimal1.dayFruit += foodMixInv["Fruit"];
            habAnimal1.dayMeat += foodMixInv["Meat"];
            habAnimal1.dayGrains += foodMixInv["Grains"];
            habAnimal1.dayCrystal += foodMixInv["Crystal Dust"];
            Debug.Log("Weight " + currWeight);
            Debug.Log("Per creature " + currWeight / eating);
            Debug.Log("Reduced by " + maxWeight / (currWeight / eating));
        }
        if (habAnimal2 != null && habAnimal2.id != 0)
        {
            habAnimal2.hunger -= (((float)currWeight / eating) / maxWeight) * 100f;
            habAnimal2.hunger = System.Math.Clamp(habAnimal2.hunger, 0f, 100f);
            habAnimal2.dayFruit += foodMixInv["Fruit"];
            habAnimal2.dayMeat += foodMixInv["Meat"];
            habAnimal2.dayGrains += foodMixInv["Grains"];
            habAnimal2.dayCrystal += foodMixInv["Crystal Dust"];
        }
        if (habAnimal3 != null && habAnimal3.id != 0)
        {
            habAnimal3.hunger -= (((float)currWeight / eating) / maxWeight) * 100f;
            habAnimal3.hunger = System.Math.Clamp(habAnimal3.hunger, 0f, 100f);
            habAnimal3.dayFruit += foodMixInv["Fruit"];
            habAnimal3.dayMeat += foodMixInv["Meat"];
            habAnimal3.dayGrains += foodMixInv["Grains"];
            habAnimal3.dayCrystal += foodMixInv["Crystal Dust"];
        }
        if (habAnimal4 != null && habAnimal4.id != 0)
        {
            habAnimal4.hunger -= (((float)currWeight / eating) / maxWeight) * 100f;
            habAnimal4.hunger = System.Math.Clamp(habAnimal4.hunger, 0f, 100f);
            habAnimal4.dayFruit += foodMixInv["Fruit"];
            habAnimal4.dayMeat += foodMixInv["Meat"];
            habAnimal4.dayGrains += foodMixInv["Grains"];
            habAnimal4.dayCrystal += foodMixInv["Crystal Dust"];
        }

        Debug.Log(habAnimal1.dayFruit);

        if (eating > 0)
        {
            foodMixInv["Fruit"] = 0;
            foodMixInv["Meat"] = 0;
            foodMixInv["Grains"] = 0;
            foodMixInv["Crystal Dust"] = 0;
            maxWeight -= currWeight;
            currWeight = 0;
            updateFoodFill();
            menuState = 0;
        }


        if (PlayerManager.Instance.quest3Triggered == false)
        {
            PlayerManager.Instance.quest3Triggered = true;
        }
    }

    private int countAnimals()
    {
        int count = 0;
        if (habAnimal1 != null && habAnimal1.id != 0)
        {
            count += 1;
        }
        if (habAnimal2 != null && habAnimal2.id != 0)
        {
            count += 1;
        }
        if (habAnimal3 != null && habAnimal3.id != 0)
        {
            count += 1;
        }
        if (habAnimal4 != null && habAnimal4.id != 0)
        {
            count += 1;
        }

        return count;
    }

    public void CureAnimal()
    {
        if (PlayerManager.Instance.quest4Triggered == false)
        {
            PlayerManager.Instance.quest4Triggered = true;
        }
    }

    public void NextDay()
    {
        menuState = 5;
        int profits = PlayerManager.Instance.getProfits();
        PlayerManager.Instance.addMoney(profits);
        earnedText.text = PlayerManager.Instance.earnedToday.ToString();
        spentText.text = PlayerManager.Instance.spentToday.ToString();

        PlayerManager.Instance.advanceDay();
        updateAnimalSlots();


        if (PlayerManager.Instance.quest6Triggered == false)
        {
            PlayerManager.Instance.quest6Triggered = true;
        }
    }

    private void updateFoodFill()
    {
        fruitFill.fillAmount = (float)(foodMixInv["Fruit"] * fruitData.getWeight()) / (float)currWeight;
        meatFill.fillAmount = (float)(foodMixInv["Meat"] * meatData.getWeight()) / (float)currWeight;
        grainsFill.fillAmount = (float)(foodMixInv["Grains"] * grainData.getWeight()) / (float)currWeight;
        crystalFill.fillAmount = (float)(foodMixInv["Crystal Dust"] * crystalData.getWeight()) / (float)currWeight;

        ColorUtility.TryParseHtmlString("#411683", out Color myPurple);
        ColorUtility.TryParseHtmlString("#7F9B85", out Color myGreen);
        ColorUtility.TryParseHtmlString("#A65555", out Color myRed);

        if (research == false)
        {
            fruitFill.color = myPurple;
            meatFill.color = myPurple;
            grainsFill.color = myPurple;
            crystalFill.color = myPurple;
        }
        if (research == true)
        {
            fruitFill.color = myRed;
            meatFill.color = myRed;
            grainsFill.color = myRed;
            crystalFill.color = myRed;
            if (foodMixInv["Fruit"] / numAnimals >= dragonData.fruitIdeal)
            {
                fruitFill.color = myGreen;
            }
            if (foodMixInv["Meat"] / numAnimals >= dragonData.meatIdeal)
            {
                meatFill.color = myGreen;
            }
            if (foodMixInv["Grains"] / numAnimals >= dragonData.grainsIdeal)
            {
                grainsFill.color = myGreen;
            }
            if (foodMixInv["Crystal Dust"] / numAnimals >= dragonData.crystalIdeal)
            {
                crystalFill.color = myGreen;
            }
        }

    }

    private void updateAnimalSlots()
    {
        // habAnimal1 = PlayerManager.Instance.creatureInventory[currHabitat.animal1.id];
        // habAnimal2 = PlayerManager.Instance.creatureInventory[currHabitat.animal2.id];
        // habAnimal3 = PlayerManager.Instance.creatureInventory[currHabitat.animal3.id];
        // habAnimal4 = PlayerManager.Instance.creatureInventory[currHabitat.animal4.id];

        habAnimal1 = currHabitat.animal1;
        habAnimal2 = currHabitat.animal2;
        habAnimal3 = currHabitat.animal3;
        habAnimal4 = currHabitat.animal4;

        Creature1Canvas.gameObject.SetActive(habAnimal1 != null && habAnimal1.id != 0);
        Creature2Canvas.gameObject.SetActive(habAnimal2 != null && habAnimal2.id != 0);
        Creature3Canvas.gameObject.SetActive(habAnimal3 != null && habAnimal3.id != 0);
        Creature4Canvas.gameObject.SetActive(habAnimal4 != null && habAnimal4.id != 0);

        maxWeight = 0;
        numAnimals = 0;
        if (habAnimal1 != null && habAnimal1.id != 0)
        {
            Debug.Log(habAnimal1.creature.weightMax);
            Debug.Log(habAnimal1.hunger);
            maxWeight += (habAnimal1.creature.weightMax * (habAnimal1.hunger / 100));
            Debug.Log(maxWeight);
            numAnimals += 1;
        }
        if (habAnimal2 != null && habAnimal2.id != 0)
        {
            maxWeight += (habAnimal2.creature.weightMax * (habAnimal2.hunger / 100));
            numAnimals += 1;
        }
        if (habAnimal3 != null && habAnimal3.id != 0)
        {
            maxWeight += (habAnimal3.creature.weightMax * (habAnimal3.hunger / 100));
            numAnimals += 1;
        }
        if (habAnimal4 != null && habAnimal4.id != 0)
        {
            maxWeight += (habAnimal4.creature.weightMax * (habAnimal4.hunger / 100));
            numAnimals += 1;
        }

        Debug.Log("Max Weight: " + maxWeight);
    }


    public void Select1()
    {
        if (habAnimal1 != null && habAnimal1.id != 0)
        {
            currAnimal = habAnimal1;
        }
        
    }
    public void Select2()
    {
        if (habAnimal2 != null && habAnimal2.id != 0)
        {
            currAnimal = habAnimal2;
        }
    }
    public void Select3()
    {
        if (habAnimal3 != null && habAnimal3.id != 0)
        {
            currAnimal = habAnimal3;
        }
    }
    public void Select4()
    {
        if (habAnimal4 != null && habAnimal4.id != 0)
        {
            currAnimal = habAnimal4;
        }
    }

    public void HabitatNext()
    {
        menuState = 0;
        habitatIndex = (habitatIndex + 1  + PlayerManager.Instance.habitats.Count) % PlayerManager.Instance.habitats.Count;
        currHabitat = PlayerManager.Instance.habitats[habitatIndex];
        updateAnimalSlots();

        Debug.Log("Current habitat index: " + habitatIndex);
    }
    public void HabitatPrev()
    {
        menuState = 0;
        habitatIndex = (habitatIndex - 1  + PlayerManager.Instance.habitats.Count) % PlayerManager.Instance.habitats.Count;
        currHabitat = PlayerManager.Instance.habitats[habitatIndex];
        updateAnimalSlots();

        Debug.Log("Current habitat index: " + habitatIndex);
    }

    public void CreateCreatureTest()
    {
        PlayerManager.Instance.GenerateRandAnimal(dragonData);
        Debug.Log("Creature Created");
    }

    public void CreateHabitatTest()
    {
        PlayerManager.Instance.CreateHabitat();
    }


    public void AddSlot1()
    {
        Debug.Log("Add1 called");
        Animal toAssign = PlayerManager.Instance.unassignedAnimals.Dequeue();
        currHabitat.animal1 = toAssign;
        updateAnimalSlots();

        if (PlayerManager.Instance.quest2Triggered == false)
        {
            PlayerManager.Instance.quest2Triggered = true;
        }
    }

    public void AddSlot2()
    {
        Animal toAssign = PlayerManager.Instance.unassignedAnimals.Dequeue();
        currHabitat.animal2 = toAssign;
        updateAnimalSlots();

        if (PlayerManager.Instance.quest2Triggered == false)
        {
            PlayerManager.Instance.quest2Triggered = true;
        }
    }

    public void AddSlot3()
    {
        Animal toAssign = PlayerManager.Instance.unassignedAnimals.Dequeue();
        currHabitat.animal3 = toAssign;
        updateAnimalSlots();

        if (PlayerManager.Instance.quest2Triggered == false)
        {
            PlayerManager.Instance.quest2Triggered = true;
        }
    }

    public void AddSlot4()
    {
        Animal toAssign = PlayerManager.Instance.unassignedAnimals.Dequeue();
        currHabitat.animal4 = toAssign;
        updateAnimalSlots();

        if (PlayerManager.Instance.quest2Triggered == false)
        {
            PlayerManager.Instance.quest2Triggered = true;
        }
    }


    public void increaseWater()
    {
        currHabitat.waterLevel += 5;
        currHabitat.waterLevel = System.Math.Clamp(currHabitat.waterLevel, 0, 100);
        updateHabitatConditions();
    }
    public void decreaseWater()
    {
        currHabitat.waterLevel -= 5;
        currHabitat.waterLevel = System.Math.Clamp(currHabitat.waterLevel, 0, 100);
        updateHabitatConditions();
    }

    public void increaseTemp()
    {
        currHabitat.temperature += 5;
        currHabitat.temperature = System.Math.Clamp(currHabitat.temperature, 0, 100);
        updateHabitatConditions();
    }
    public void decreaseTemp()
    {
        currHabitat.temperature -= 5;
        currHabitat.temperature = System.Math.Clamp(currHabitat.temperature, 0, 100);
        updateHabitatConditions();
    }

    private void updateHabitatConditions()
    {
        if (habAnimal1 != null && habAnimal1.id != 0)
        {
            habAnimal1.waterCurr = currHabitat.waterLevel;
            habAnimal1.tempCurr = currHabitat.temperature;
        }
        if (habAnimal2 != null && habAnimal2.id != 0)
        {
            habAnimal2.waterCurr = currHabitat.waterLevel;
            habAnimal2.tempCurr = currHabitat.temperature;
        }
        if (habAnimal3 != null && habAnimal3.id != 0)
        {
            habAnimal3.waterCurr = currHabitat.waterLevel;
            habAnimal3.tempCurr = currHabitat.temperature;
        }
        if (habAnimal4 != null && habAnimal4.id != 0)
        {
            habAnimal4.waterCurr = currHabitat.waterLevel;
            habAnimal4.tempCurr = currHabitat.temperature;
        }

    }


    public void CloseMenu()
    {
        menuState = 0;
    }

    public void FeedMenu()
    {
        updateFoodFill();
        menuState = 1;
    }

    public void MedMenu()
    {
        menuState = 2;
    }

    public void HabitatMenu()
    {
        menuState = 3;
    }

    public void HealthMenu()
    {
        menuState = 4;
    }

    public void ResearchOn()
    {
        Debug.Log("Research on");
        updateFoodFill();
        research = true;
    }

    


}

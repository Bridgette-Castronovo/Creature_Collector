using UnityEngine;
using TMPro;
// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using System;
using UnityEngine.Timeline;
using System.Collections.Generic;

public class CareButtons : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private TextMeshProUGUI animalNeeds;
    [SerializeField] private Button FeedButton;

    [SerializeField] public Canvas foodInvCanvas;
    
    [SerializeField] public Canvas canvas;

    //food inventory text
    [SerializeField] private TextMeshProUGUI fruitAmt;
    [SerializeField] private TextMeshProUGUI meatAmt;
    [SerializeField] private TextMeshProUGUI grainAmt;
    [SerializeField] private TextMeshProUGUI crystalAmt;

    [SerializeField] public Canvas foodMixCanvas;

    //food mix text
    [SerializeField] private TextMeshProUGUI fruitMixAmt;
    [SerializeField] private TextMeshProUGUI meatMixAmt;
    [SerializeField] private TextMeshProUGUI grainMixAmt;
    [SerializeField] private TextMeshProUGUI crystalMixAmt;

    //food type scriptable objects
    [SerializeField] private FoodType fruitData;
    [SerializeField] private FoodType grainData;
    [SerializeField] private FoodType meatData;
    [SerializeField] private FoodType crystalData;

    [SerializeField] private TextMeshProUGUI weightText;

    [SerializeField] private Image fruitFill;
    [SerializeField] private Image meatFill;
    [SerializeField] private Image grainsFill;
    [SerializeField] private Image crystalFill;
    [SerializeField] private Image weightFill;

    private int health = 50;
    // private int thirst = 50;
    // private int entertainment = 50;
    // private String illness = "";
    private bool fed = false;

    // private int day = 1;
    // private int money = 2000;

    // private Creature[] habitatCreatures = new Creature[6];
    [SerializeField] private Creature habitatCreature;


    private int maxFeed;
    private int currFeed = 0;

    private int inMenu = 0;

    private Dictionary<String, int> foodMixInv = new Dictionary<String, int>();



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // PlayerManager player = PlayerManager.getPlayer();

        dayText.text = $"Day {PlayerManager.Instance.getDay()}, ${PlayerManager.Instance.getMoney()}";
        animalNeeds.text = $"Health: {health}%";

        foodMixInv["Fruit"] = 0;
        foodMixInv["Grains"] = 0;
        foodMixInv["Meat"] = 0;
        foodMixInv["Crystal Dust"] = 0;

        maxFeed = habitatCreature.hunger;
        // maxFeed = 150;
    }

    public void DayButtonOnClick()
    {
        PlayerManager.Instance.progressDay();



        
        currFeed = 0;
        fed = false;
    }

    public void FeedButtonOnClick()
    {
        inMenu = 1;
    }

    public void WaterButtonOnClick()
    {
        
    }

    public void EntertainmentButtonOnClick()
    {
        
    }

    

    public void FruitAddOnClick()
    {
        if (PlayerManager.Instance.foodInventory["Fruit"] >= 1)
        {
            PlayerManager.Instance.foodInventory["Fruit"] -= 1;
            fruitAmt.text = PlayerManager.Instance.foodInventory["Fruit"].ToString();

            foodMixInv["Fruit"] += 1;
            fruitMixAmt.text = foodMixInv["Fruit"].ToString();

            currFeed += fruitData.getWeight();

        }
        
    }

    public void MeatAddOnClick()
    {
        if (PlayerManager.Instance.foodInventory["Meat"] >= 1)
        {
            PlayerManager.Instance.foodInventory["Meat"] -= 1;
            meatAmt.text = PlayerManager.Instance.foodInventory["Meat"].ToString();

            foodMixInv["Meat"] += 1;
            meatMixAmt.text = foodMixInv["Meat"].ToString();

            currFeed += meatData.getWeight();
        }
        
    }

    public void GrainsAddOnClick()
    {
        if (PlayerManager.Instance.foodInventory["Grains"] >= 1)
        {
            PlayerManager.Instance.foodInventory["Grains"] -= 1;
            grainAmt.text = PlayerManager.Instance.foodInventory["Grains"].ToString();

            foodMixInv["Grains"] += 1;
            grainMixAmt.text = foodMixInv["Grains"].ToString();

            currFeed += grainData.getWeight();
        }
        
    }

    public void CrystalAddOnClick()
    {
        if (PlayerManager.Instance.foodInventory["Crystal Dust"] >= 1)
        {
            PlayerManager.Instance.foodInventory["Crystal Dust"] -= 1;
            crystalAmt.text = PlayerManager.Instance.foodInventory["Crystal Dust"].ToString();

            foodMixInv["Crystal Dust"] += 1;
            crystalMixAmt.text = foodMixInv["Crystal Dust"].ToString();

            currFeed += crystalData.getWeight();
        }
        
    }


    public void FruitRemoveOnClick()
    {
        if (foodMixInv["Fruit"] >= 1)
        {
            PlayerManager.Instance.foodInventory["Fruit"] += 1;
            fruitAmt.text = PlayerManager.Instance.foodInventory["Fruit"].ToString();

            foodMixInv["Fruit"] -= 1;
            fruitMixAmt.text = foodMixInv["Fruit"].ToString();

            currFeed -= fruitData.getWeight();
        }
    }

    public void MeatRemoveOnClick()
    {
        if (foodMixInv["Meat"] >= 1)
        {
            PlayerManager.Instance.foodInventory["Meat"] += 1;
            meatAmt.text = PlayerManager.Instance.foodInventory["Meat"].ToString();

            foodMixInv["Meat"] -= 1;
            meatMixAmt.text = foodMixInv["Meat"].ToString();

            currFeed -= meatData.getWeight();
        }
    }

    public void GrainsRemoveOnClick()
    {
        if (foodMixInv["Grains"] >= 1)
        {
            PlayerManager.Instance.foodInventory["Grains"] += 1;
            grainAmt.text = PlayerManager.Instance.foodInventory["Grains"].ToString();

            foodMixInv["Grains"] -= 1;
            grainMixAmt.text = foodMixInv["Grains"].ToString();
            
            currFeed -= grainData.getWeight();
        }
    }

    public void CrystalRemoveOnClick()
    {
        if (foodMixInv["Crystal Dust"] >= 1)
        {
            PlayerManager.Instance.foodInventory["Crystal Dust"] += 1;
            crystalAmt.text = PlayerManager.Instance.foodInventory["Crystal Dust"].ToString();

            foodMixInv["Crystal Dust"] -= 1;
            crystalMixAmt.text = foodMixInv["Crystal Dust"].ToString();

            currFeed -= crystalData.getWeight();
        }
    }

    public void FeedMixOnClick()
    {
        inMenu = 0;

        if (foodMixInv["Fruit"]*fruitData.getWeight() >= 50 || foodMixInv["Meat"]*meatData.getWeight() >= 90)
        {
            health += 10;
        }
        else
        {
            health -= 20;
        }

        foodMixInv["Fruit"] = 0;
        foodMixInv["Grains"] = 0;
        foodMixInv["Meat"] = 0;
        foodMixInv["Crystal Dust"] = 0;

        fruitMixAmt.text = foodMixInv["Fruit"].ToString();
        meatMixAmt.text = foodMixInv["Meat"].ToString();
        grainMixAmt.text = foodMixInv["Grains"].ToString();
        crystalMixAmt.text = foodMixInv["Crystal Dust"].ToString();

        

        fed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (inMenu == 0)
        {
            if (fed == false)
            {
                FeedButton.gameObject.SetActive(true);
            }
            
            // WaterButton.gameObject.SetActive(true);
            // EntertainmentButton.gameObject.SetActive(true);

            
            foodInvCanvas.gameObject.SetActive(false);

            foodMixCanvas.gameObject.SetActive(false);
        }

        if (inMenu == 1)
        {
            FeedButton.gameObject.SetActive(false);
            // WaterButton.gameObject.SetActive(false);
            // EntertainmentButton.gameObject.SetActive(false);

            foodInvCanvas.gameObject.SetActive(true);

            fruitAmt.text = PlayerManager.Instance.foodInventory["Fruit"].ToString();
            meatAmt.text = PlayerManager.Instance.foodInventory["Meat"].ToString();
            grainAmt.text = PlayerManager.Instance.foodInventory["Grains"].ToString();
            crystalAmt.text = PlayerManager.Instance.foodInventory["Crystal Dust"].ToString();

            if (foodMixInv["Fruit"]*fruitData.getWeight() >= habitatCreature.fruitMin)
            {
                fruitFill.color = Color.green;
            } else
            {
                fruitFill.color = Color.red;
            }
            if (foodMixInv["Meat"]*meatData.getWeight() >= habitatCreature.meatMin)
            {
                meatFill.color = Color.green;
            } else
            {
                meatFill.color = Color.red;
            }
            if (foodMixInv["Grains"]*grainData.getWeight() >= habitatCreature.grainsMin)
            {
                grainsFill.color = Color.green;
            } else
            {
                grainsFill.color = Color.red;
            }
            if (foodMixInv["Crystal Dust"]*crystalData.getWeight() >= habitatCreature.crystalMin)
            {
                crystalFill.color = Color.green;
            } else
            {
                crystalFill.color = Color.red;
            }


            foodMixCanvas.gameObject.SetActive(true);

            weightText.text = "Weight: " + currFeed.ToString();
            weightFill.fillAmount = (float)currFeed / maxFeed;
            // print(maxFeed.ToString());
            
            fruitFill.fillAmount = (float)(foodMixInv["Fruit"] * fruitData.getWeight()) / maxFeed;
            meatFill.fillAmount = (float)(foodMixInv["Meat"] * meatData.getWeight()) / maxFeed;
            grainsFill.fillAmount = (float)(foodMixInv["Grains"] * grainData.getWeight()) / maxFeed;
            crystalFill.fillAmount = (float)(foodMixInv["Crystal Dust"] * crystalData.getWeight()) / maxFeed;
            
        }



        health = System.Math.Clamp(health, 0, 100);

        
        dayText.text = $"Day {PlayerManager.Instance.getDay()}, ${PlayerManager.Instance.getMoney()}";
        animalNeeds.text = $"Health: {health}%";

        
        
    }
}

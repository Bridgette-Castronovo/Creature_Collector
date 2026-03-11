using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using System;
using UnityEngine.Timeline;
using System.Collections.Generic;

public class CareButtons : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private TextMeshProUGUI animalNeeds;
    [SerializeField] private Button FeedButton;
    // [SerializeField] private Button WaterButton;
    // [SerializeField] private Button EntertainmentButton;

    [SerializeField] public Canvas foodInvCanvas;
    
    // //add from inventory
    // [SerializeField] private Button FruitButton;
    // [SerializeField] private Button MeatButton;
    // [SerializeField] private Button GrainsButton;
    // [SerializeField] private Button CrystalButton;
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

    // //remove from mix
    // [SerializeField] private Button FruitMixButton;
    // [SerializeField] private Button MeatMixButton;
    // [SerializeField] private Button GrainsMixButton;
    // [SerializeField] private Button CrystalMixButton;

    // //feed to animals
    // [SerializeField] private Button FeedMixButton;

    //food type scriptable objects
    [SerializeField] private FoodType fruitData;
    [SerializeField] private FoodType grainData;
    [SerializeField] private FoodType meatData;
    [SerializeField] private FoodType crystalData;

    private int hunger = 50;
    private int thirst = 50;
    private int entertainment = 50;
    private String illness = "";
    private bool fed = false;

    // private int day = 1;
    // private int money = 2000;


    private int maxFeed = 20;
    private int currFeed = 0;

    private int inMenu = 0;

    private Dictionary<String, int> foodMixInv = new Dictionary<String, int>();



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // PlayerManager player = PlayerManager.getPlayer();

        dayText.text = $"Day {PlayerManager.Instance.getDay()}, ${PlayerManager.Instance.getMoney()}";
        animalNeeds.text = $"Hunger: {hunger}%\nThirst: {thirst}%\nEntertainment: {entertainment}%\nIllness: {illness}";

        foodMixInv["Fruit"] = 0;
        foodMixInv["Grains"] = 0;
        foodMixInv["Meat"] = 0;
        foodMixInv["Crystal Dust"] = 0;
    }

    public void DayButtonOnClick()
    {
        PlayerManager.Instance.progressDay();

        hunger -= 30;
        thirst -= 30;
        entertainment -= 30;
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

            // hunger += 30;
            // currFeed += fruitData.getWeight();

            // if (currFeed >= maxFeed)
            // {
            //     fed = true;
            // }

            // inMenu = 0;
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
            // hunger += 5;
            // currFeed += meatData.getWeight();

            // if (currFeed >= maxFeed)
            // {
            //     fed = true;
            // }

            // inMenu = 0;
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

            // hunger += 5;
            // currFeed += grainData.getWeight();

            // if (currFeed >= maxFeed)
            // {
            //     fed = true;
            // }

            // inMenu = 0;
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

            // hunger += 50;
            // currFeed += crystalData.getWeight();

            // if (currFeed >= maxFeed)
            // {
            //     fed = true;
            // }
            
            // inMenu = 0;
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
        }
    }

    public void FeedMixOnClick()
    {
        inMenu = 0;

        foodMixInv["Fruit"] = 0;
        foodMixInv["Grains"] = 0;
        foodMixInv["Meat"] = 0;
        foodMixInv["Crystal Dust"] = 0;

        fruitMixAmt.text = foodMixInv["Fruit"].ToString();
        meatMixAmt.text = foodMixInv["Meat"].ToString();
        grainMixAmt.text = foodMixInv["Grains"].ToString();
        crystalMixAmt.text = foodMixInv["Crystal Dust"].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (inMenu == 0)
        {
            if (fed == false && hunger < 100)
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

            foodMixCanvas.gameObject.SetActive(true);
            
        }



        hunger = System.Math.Clamp(hunger, 0, 100);
        thirst = System.Math.Clamp(thirst, 0, 100);
        entertainment = System.Math.Clamp(entertainment, 0, 100);
        if (hunger < 10)
        {
            illness = "Starving";
        } else
        {
            illness = "";
        }
        dayText.text = $"Day {PlayerManager.Instance.getDay()}, ${PlayerManager.Instance.getMoney()}";
        animalNeeds.text = $"Hunger: {hunger}%\nThirst: {thirst}%\nEntertainment: {entertainment}%\nIllness: {illness}";

        
        
    }
}

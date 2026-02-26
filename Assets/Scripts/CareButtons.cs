using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using System;
using UnityEngine.Timeline;

public class CareButtons : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private TextMeshProUGUI animalNeeds;
    [SerializeField] private Button FeedButton;
    [SerializeField] private Button WaterButton;
    [SerializeField] private Button EntertainmentButton;
    
    [SerializeField] private Button FruitButton;
    [SerializeField] private Button MeatButton;
    [SerializeField] private Button GrainsButton;
    [SerializeField] private Button CrystalButton;
    [SerializeField] public Canvas canvas;

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
    private int hayWeight = 10;
    private int fruitWeight = 20;
    private int liveFoodWeight = 20;

    private int inMenu = 0;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // PlayerManager player = PlayerManager.getPlayer();

        dayText.text = $"Day {PlayerManager.Instance.getDay()}, ${PlayerManager.Instance.getMoney()}";
        animalNeeds.text = $"Hunger: {hunger}%\nThirst: {thirst}%\nEntertainment: {entertainment}%\nIllness: {illness}";
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

    

    public void FruitOnClick()
    {
        PlayerManager.Instance.foodInventory["Fruit"] -= 1;
        hunger += 30;
        currFeed += fruitData.getWeight();

        if (currFeed >= maxFeed)
        {
            fed = true;
        }

        inMenu = 0;
    }

    public void MeatOnClick()
    {
        PlayerManager.Instance.foodInventory["Meat"] -= 1;
        hunger += 5;
        currFeed += meatData.getWeight();

        if (currFeed >= maxFeed)
        {
            fed = true;
        }

        inMenu = 0;
    }

    public void GrainsOnClick()
    {
        PlayerManager.Instance.foodInventory["Grains"] -= 1;
        hunger += 5;
        currFeed += grainData.getWeight();

        if (currFeed >= maxFeed)
        {
            fed = true;
        }

        inMenu = 0;
    }

    public void CrystalOnClick()
    {
        PlayerManager.Instance.foodInventory["Crystal Dust"] -= 1;
        hunger += 50;
        currFeed += crystalData.getWeight();

        if (currFeed >= maxFeed)
        {
            fed = true;
        }
        
        inMenu = 0;
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
            
            WaterButton.gameObject.SetActive(true);
            EntertainmentButton.gameObject.SetActive(true);

            
            FruitButton.gameObject.SetActive(false);
            MeatButton.gameObject.SetActive(false);
            GrainsButton.gameObject.SetActive(false);
            CrystalButton.gameObject.SetActive(false);
        }

        if (inMenu == 1)
        {
            FeedButton.gameObject.SetActive(false);
            WaterButton.gameObject.SetActive(false);
            EntertainmentButton.gameObject.SetActive(false);

            FruitButton.gameObject.SetActive(true);
            MeatButton.gameObject.SetActive(true);
            GrainsButton.gameObject.SetActive(true);
            CrystalButton.gameObject.SetActive(true);
            
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

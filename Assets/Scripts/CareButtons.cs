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
    [SerializeField] private Button HayButton;
    [SerializeField] private Button FruitButton;
    [SerializeField] private Button LiveFoodButton;
    [SerializeField] public Canvas canvas;

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
        dayText.text = $"Day {PlayerManager.Instance.day}, ${PlayerManager.Instance.playerMoney}";
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

    public void HayButtonOnClick()
    {
        PlayerManager.Instance.playerMoney -= 50;
        hunger += 5;
        currFeed += hayWeight;

        if (currFeed >= maxFeed)
        {
            fed = true;
        }

        inMenu = 0;
    }

    public void FruitButtonOnClick()
    {
        PlayerManager.Instance.playerMoney -= 50;
        hunger += 30;
        currFeed += fruitWeight;

        if (currFeed >= maxFeed)
        {
            fed = true;
        }

        inMenu = 0;
    }

    public void LiveFoodButtonOnClick()
    {
        PlayerManager.Instance.playerMoney -= 50;
        hunger += 50;
        currFeed += liveFoodWeight;

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

            HayButton.gameObject.SetActive(false);
            FruitButton.gameObject.SetActive(false);
            LiveFoodButton.gameObject.SetActive(false);
        }

        if (inMenu == 1)
        {
            FeedButton.gameObject.SetActive(false);
            WaterButton.gameObject.SetActive(false);
            EntertainmentButton.gameObject.SetActive(false);

            HayButton.gameObject.SetActive(true);
            FruitButton.gameObject.SetActive(true);
            LiveFoodButton.gameObject.SetActive(true);
            
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
        dayText.text = $"Day {PlayerManager.Instance.day}, ${PlayerManager.Instance.playerMoney}";
        animalNeeds.text = $"Hunger: {hunger}%\nThirst: {thirst}%\nEntertainment: {entertainment}%\nIllness: {illness}";

        
        
    }
}

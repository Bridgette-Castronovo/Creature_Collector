using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using System;

public class HabitatText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private TextMeshProUGUI animalNeeds;
    [SerializeField] public Canvas canvas;

    private int hunger = 50;
    private int thirst = 50;
    private int entertainment = 50;
    private String illness = "None";

    private int day = 1;
    private int money = 2000;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dayText.text = $"Day {day}, ${money}";
        animalNeeds.text = $"Hunger: {hunger}%\nThirst: {thirst}%\nEntertainment: {entertainment}%\nIllness: {illness}";
    }

    public void DayButtonOnClick()
    {
        day += 1;
        money += 100;

        hunger -= 30;
        thirst -= 30;
        entertainment -= 30;
    }

    public void FeedButtonOnClick()
    {
        GameObject hayFoodButtonObject = new GameObject("HayFoodButton");

        UnityEngine.UI.Image hayButtonImage = hayFoodButtonObject.AddComponent<UnityEngine.UI.Image>();
        Button hayButton = hayFoodButtonObject.AddComponent<Button>();

        hayFoodButtonObject.transform.SetParent(canvas.transform, false);

        RectTransform rectTransform = hayFoodButtonObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(160, 60);
        rectTransform.anchoredPosition = new Vector3(0, 0, 0);
    }

    public void WaterButtonOnClick()
    {
        
    }

    public void EntertainmentButtonOnClick()
    {
        
    }

    public void HayButtonOnClick()
    {
        money -= 50;
        hunger += 5;
    }

    public void FruitButtonOnClick()
    {
        money -= 50;
        hunger += 30;
    }

    public void LiveFoodButtonOnClick()
    {
        money -= 50;
        hunger += 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (hunger < 10)
        {
            illness = "Starving";
        }
        dayText.text = $"Day {day}, ${money}";
        animalNeeds.text = $"Hunger: {hunger}%\nThirst: {thirst}%\nEntertainment: {entertainment}%\nIllness: {illness}";

        
        
    }
}

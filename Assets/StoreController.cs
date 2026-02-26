using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class StoreController : MonoBehaviour
{


    //inventory
    [SerializeField] private TextMeshProUGUI inventoryText;

    //canvases that will be deactivated/disabled
    [SerializeField] private Canvas storeCanvas;
    [SerializeField] private Canvas purchaseCanvas;

    //food store buttons
    [SerializeField] private Button buyFruit;
    [SerializeField] private Button buyMeat;
    [SerializeField] private Button buyGrains;
    [SerializeField] private Button buyCrystal;

    //purchase text
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemAmount;
    [SerializeField] private TextMeshProUGUI itemCost;

    //purchase buttons
    [SerializeField] private Button exitPurchase;
    [SerializeField] private Button addItem;
    [SerializeField] private Button subtractItem;
    [SerializeField] private Button purchase;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    void loadInventory()
    {
        inventoryText.text = $"Fruit: ${PlayerManager.Instance.foodInventory["Fruit"]}\n" +
                             $"Meat: ${PlayerManager.Instance.foodInventory["Meat"]}\n" +
                             $"Grains: ${PlayerManager.Instance.foodInventory["Grains"]}\n" +
                             $"Crystal Dust: ${PlayerManager.Instance.foodInventory["Crystal"]}";
        
    }
}

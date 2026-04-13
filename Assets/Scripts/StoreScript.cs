using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using NUnit.Framework.Constraints;

public class StoreScript : MonoBehaviour
{


    //inventory
    // [SerializeField] private TextMeshProUGUI inventoryText;
    [SerializeField] private TextMeshProUGUI fruitAmount;
    [SerializeField] private TextMeshProUGUI meatAmount;
    [SerializeField] private TextMeshProUGUI grainAmount;
    [SerializeField] private TextMeshProUGUI crystalAmount;
    [SerializeField] private TextMeshProUGUI moneyAmount;

    //canvases that will be deactivated/disabled
    [SerializeField] private Canvas storeCanvas;
    [SerializeField] private Canvas purchaseCanvas;

    //food store buttons
    // [SerializeField] private Button buyFruit;
    // [SerializeField] private Button buyMeat;
    // [SerializeField] private Button buyGrains;
    // [SerializeField] private Button buyCrystal;

    //purchase text
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemAmount;
    [SerializeField] private TextMeshProUGUI itemCost;

    //purchase buttons
    // [SerializeField] private Button exitPurchase;
    // [SerializeField] private Button addItem;
    // [SerializeField] private Button subtractItem;
    // [SerializeField] private Button purchase;

    //food type scriptable objects
    [SerializeField] private FoodType fruitData;
    [SerializeField] private FoodType grainData;
    [SerializeField] private FoodType meatData;
    [SerializeField] private FoodType crystalData;


    private bool purchaseOpen = false;
    private int purchaseAmount = 0;
    private FoodType purchaseType = null;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        purchaseCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        loadInventory();

        if (purchaseOpen)
        {
            purchaseCanvas.gameObject.SetActive(true);

            itemName.text = purchaseType.getFoodName();
            itemAmount.text = purchaseAmount.ToString();

            int totalCost = purchaseType.getBuyCost() * purchaseAmount;
            itemCost.text = totalCost.ToString();


            // if (purchaseType == null)
            // {
            //     print("This is the problem");
            // } else
            // {
            //     print(purchaseType.getFoodName());
            // }
            

        
        } else
        {
            purchaseCanvas.gameObject.SetActive(false);
            
        }

    }

    public void addItem()
    {
        purchaseAmount += 1;
    }

    public void subtractItem()
    {
        purchaseAmount -= 1;
    }

    public void purchaseComplete()
    {
        int totalCost = purchaseType.getBuyCost() * purchaseAmount;
        if (PlayerManager.Instance.getMoney() >= totalCost)
        {
            PlayerManager.Instance.subtractMoney(totalCost);
            PlayerManager.Instance.foodInventory[purchaseType.getFoodName()] += purchaseAmount;

            purchaseOpen = false;
            purchaseAmount = 0;
            purchaseType = null;
        }
        
    }

    public void exitPurchase()
    {
        purchaseOpen = false;
        purchaseAmount = 0;
        purchaseType = null;
    }




    public void purchaseFruit()
    {
        print(fruitData.getFoodName());
        purchaseOpen = true;
        purchaseType = fruitData;
    }

    public void purchaseMeat()
    {
        purchaseOpen = true;
        purchaseType = meatData;
    }

    public void purchaseGrains()
    {
        purchaseOpen = true;
        purchaseType = grainData;
    }

    public void purchaseCrystal()
    {
        purchaseOpen = true;
        purchaseType = crystalData;
    }

    private void loadInventory()
    {
        fruitAmount.text = "x" + PlayerManager.Instance.foodInventory["Fruit"].ToString();
        meatAmount.text = "x" + PlayerManager.Instance.foodInventory["Meat"].ToString();
        grainAmount.text = "x" + PlayerManager.Instance.foodInventory["Grains"].ToString();
        crystalAmount.text = "x" + PlayerManager.Instance.foodInventory["Crystal Dust"].ToString();
        
        moneyAmount.text = PlayerManager.Instance.getMoney().ToString();
    }
}

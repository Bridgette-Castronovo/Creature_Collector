using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;

public class StoreScript : MonoBehaviour
{


    //inventory
    // [SerializeField] private TextMeshProUGUI inventoryText;
    [Header("Inventory Amounts")]
    [SerializeField] private TextMeshProUGUI fruitAmount;
    [SerializeField] private TextMeshProUGUI meatAmount;
    [SerializeField] private TextMeshProUGUI grainAmount;
    [SerializeField] private TextMeshProUGUI crystalAmount;
    [SerializeField] private TextMeshProUGUI castAmount;
    [SerializeField] private TextMeshProUGUI antiparasiticAmount;
    [SerializeField] private TextMeshProUGUI antibioticAmount;
    [SerializeField] private TextMeshProUGUI moneyAmount;

    //canvases that will be deactivated/disabled
    [Header("Canvases")]
    [SerializeField] private Canvas foodStoreCanvas;
    [SerializeField] private Canvas medStoreCanvas;
    [SerializeField] private Canvas habitatStoreCanvas;
    [SerializeField] private Canvas overlayCanvas;
    [SerializeField] private Canvas purchaseCanvas;

    [Header("Menu Buttons")]
    [SerializeField] private Button foodMenuButton;
    [SerializeField] private Button medMenuButton;
    [SerializeField] private Button habitatMenuButton;


    //purchase text
    [Header("Purchase Info")]
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemAmount;
    [SerializeField] private TextMeshProUGUI itemCost;

    [Header("Buyable Types")]
    //food type scriptable objects
    [SerializeField] private FoodType fruitData;
    [SerializeField] private FoodType grainData;
    [SerializeField] private FoodType meatData;
    [SerializeField] private FoodType crystalData;

    //med type scriptable objects
    [SerializeField] private MedType castData;
    [SerializeField] private MedType antiparasiticData;
    [SerializeField] private MedType antibioticData;

    //habitat scriptable object
    [SerializeField] private HabitatSlot habitatData;

    [Header("Purchase Images")]
    [SerializeField] private Image fruitImage;
    [SerializeField] private Image grainImage;
    [SerializeField] private Image meatImage;
    [SerializeField] private Image crystalImage;
    [SerializeField] private Image habitatImage;


    private bool purchaseOpen = false;
    private int storeType = 0;

    private int purchaseAmount = 0;
    private int purchaseCat = 0;
    private int totalCost = 0;
    private Buyable purchaseType = null;
    private Image purchaseImage;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        overlayCanvas.gameObject.SetActive(false);
        purchaseCanvas.gameObject.SetActive(false);
        purchaseImage = fruitImage;
    }

    // Update is called once per frame
    void Update()
    {
        loadInventory();

        if (storeType == 0)
        {
            foodStoreCanvas.gameObject.SetActive(true);
            medStoreCanvas.gameObject.SetActive(false);
            habitatStoreCanvas.gameObject.SetActive(false);

            foodMenuButton.gameObject.SetActive(false);
            medMenuButton.gameObject.SetActive(true);
            habitatMenuButton.gameObject.SetActive(true);
        } 
        if (storeType == 1)
        {
            foodStoreCanvas.gameObject.SetActive(false);
            medStoreCanvas.gameObject.SetActive(true);
            habitatStoreCanvas.gameObject.SetActive(false);

            foodMenuButton.gameObject.SetActive(true);
            medMenuButton.gameObject.SetActive(false);
            habitatMenuButton.gameObject.SetActive(true);
        }
        if (storeType == 2)
        {
            foodStoreCanvas.gameObject.SetActive(false);
            medStoreCanvas.gameObject.SetActive(false);
            habitatStoreCanvas.gameObject.SetActive(true);

            foodMenuButton.gameObject.SetActive(true);
            medMenuButton.gameObject.SetActive(true);
            habitatMenuButton.gameObject.SetActive(false);
        }

        if (purchaseOpen)
        {
            overlayCanvas.gameObject.SetActive(true);
            purchaseCanvas.gameObject.SetActive(true);

            itemName.text = purchaseType.getName();
            // print(purchaseType.getName());
            itemAmount.text = purchaseAmount.ToString();

            totalCost = purchaseType.getCost() * purchaseAmount;
            itemCost.text = totalCost.ToString();
            purchaseImage.gameObject.SetActive(true);
        } else
        {
            overlayCanvas.gameObject.SetActive(false);
            purchaseCanvas.gameObject.SetActive(false); 
            purchaseImage.gameObject.SetActive(false);
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
        
        if (PlayerManager.Instance.getMoney() >= totalCost)
        {
            PlayerManager.Instance.subtractMoney(totalCost);
            if (purchaseCat == 0) {
                PlayerManager.Instance.foodInventory[purchaseType.getName()] += purchaseAmount;
            }
            if (purchaseCat == 1) {
                PlayerManager.Instance.medInventory[purchaseType.getName()] += purchaseAmount;
            }

            if (purchaseType == habitatData)
            {
                while (purchaseAmount > 0)
                {
                    PlayerManager.Instance.CreateHabitat();
                    purchaseAmount -= 1;
                }

                if (PlayerManager.Instance.quest5Triggered == false)
                {
                    PlayerManager.Instance.quest5Triggered = true;
                }
                
            }
            

            purchaseOpen = false;
            purchaseAmount = 0;
            purchaseType = null;

            Debug.Log(PlayerManager.Instance.habitats.Count);
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
        purchaseOpen = true;
        purchaseType = fruitData;
        purchaseCat = 0;
        purchaseImage = fruitImage;
    }

    public void purchaseMeat()
    {
        purchaseOpen = true;
        purchaseType = meatData;
        purchaseCat = 0;
        purchaseImage = meatImage;
    }

    public void purchaseGrains()
    {
        purchaseOpen = true;
        purchaseType = grainData;
        purchaseCat = 0;
        purchaseImage = grainImage;
    }

    public void purchaseCrystal()
    {
        purchaseOpen = true;
        purchaseType = crystalData;
        purchaseCat = 0;
        purchaseImage = crystalImage;
    }

    public void purchaseCast()
    {
        purchaseOpen = true;
        purchaseType = castData;
        purchaseCat = 1;
        purchaseImage = crystalImage;
    }

    public void purchaseAntiparasitic()
    {
        purchaseOpen = true;
        purchaseType = antiparasiticData;
        purchaseCat = 1;
        purchaseImage = crystalImage;
    }

    public void purchaseAntibiotic()
    {
        purchaseOpen = true;
        purchaseType = antibioticData;
        purchaseCat = 1;
        purchaseImage = crystalImage;
    }

    public void purchaseHabitatUpgrade()
    {
        purchaseOpen = true;
        purchaseType = habitatData;
        purchaseCat = 2;
        purchaseImage = habitatImage;
    }

    public void foodTab()
    {
        storeType = 0;
    }

    public void medTab()
    {
        storeType = 1;
    }

    public void habitatTab()
    {
        storeType = 2;
    }

    private void loadInventory()
    {
        fruitAmount.text = "x" + PlayerManager.Instance.foodInventory["Fruit"].ToString();
        meatAmount.text = "x" + PlayerManager.Instance.foodInventory["Meat"].ToString();
        grainAmount.text = "x" + PlayerManager.Instance.foodInventory["Grains"].ToString();
        crystalAmount.text = "x" + PlayerManager.Instance.foodInventory["Crystal Dust"].ToString();

        castAmount.text = "x" + PlayerManager.Instance.medInventory["Cast"].ToString();
        antiparasiticAmount.text = "x" + PlayerManager.Instance.medInventory["Antiparasitic"].ToString();
        antibioticAmount.text = "x" + PlayerManager.Instance.medInventory["Antibiotic"].ToString();
        
        moneyAmount.text = PlayerManager.Instance.getMoney().ToString();
    }
}

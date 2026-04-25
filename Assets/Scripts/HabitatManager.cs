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


    //med inventory text
    [SerializeField] private TextMeshProUGUI castAmt;
    [SerializeField] private TextMeshProUGUI bacAmt;
    [SerializeField] private TextMeshProUGUI parAmt;

    //med menu text
    [SerializeField] private TextMeshProUGUI currIllnesses;
    [SerializeField] private TextMeshProUGUI currMedText;


    //food type scriptable objects
    [SerializeField] private FoodType fruitData;
    [SerializeField] private FoodType grainData;
    [SerializeField] private FoodType meatData;
    [SerializeField] private FoodType crystalData;


    private Dictionary<String, int> foodMixInv = new Dictionary<String, int>();
    private MedType currMed;
    private int habitatIndex = 0;
    private Habitat currHabitat;

    private int currWeight = 0;

    private int menuState = 0;

    
    private Animal currAnimal;

    private Animal habAnimal1;
    private Animal habAnimal2;
    private Animal habAnimal3;
    private Animal habAnimal4;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foodMixInv["Fruit"] = 0;
        foodMixInv["Grains"] = 0;
        foodMixInv["Meat"] = 0;
        foodMixInv["Crystal Dust"] = 0;

        
        currAnimal = null;
        currMed = null;

        currHabitat = PlayerManager.Instance.habitats[habitatIndex];
        updateAnimalSlots();
        
    }

    // Update is called once per frame
    void Update()
    {
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

            if (currAnimal != null)
            {
                currIllnesses.text = String.Join("\n", currAnimal.illnesses);
            }
            if (currMed != null)
            {
                currMedText.text = currMed.getName();
            }
                
            castAmt.text = "x" + PlayerManager.Instance.medInventory["Cast"].ToString();
            bacAmt.text = "x" + PlayerManager.Instance.medInventory["Antibiotic"].ToString();
            parAmt.text = "x" + PlayerManager.Instance.medInventory["Antiparasitic"].ToString();
            
        }

        if (menuState == 3)
        {
            FeedCanvas.gameObject.SetActive(false);
            MedCanvas.gameObject.SetActive(false);
            HabitatCanvas.gameObject.SetActive(true);
            SelectCanvas.gameObject.SetActive(false);
            HealthCanvas.gameObject.SetActive(false);
            DailyReportCanvas.gameObject.SetActive(false);
        }

        if (menuState == 4)
        {
            FeedCanvas.gameObject.SetActive(false);
            MedCanvas.gameObject.SetActive(false);
            HabitatCanvas.gameObject.SetActive(false);
            SelectCanvas.gameObject.SetActive(true);
            HealthCanvas.gameObject.SetActive(true);
            DailyReportCanvas.gameObject.SetActive(false);
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

    private void updateAnimalSlots()
    {
        habAnimal1 = currHabitat.animal1;
        habAnimal2 = currHabitat.animal2;
        habAnimal3 = currHabitat.animal3;
        habAnimal4 = currHabitat.animal4;

        Creature1Canvas.gameObject.SetActive(habAnimal1 != null);
        Creature2Canvas.gameObject.SetActive(habAnimal2 != null);
        Creature3Canvas.gameObject.SetActive(habAnimal3 != null);
        Creature4Canvas.gameObject.SetActive(habAnimal4 != null);
    }


    public void Select1()
    {
        if (currHabitat.animal1 != null)
        {
            currAnimal = currHabitat.animal1;
        }
        
    }
    public void Select2()
    {
        if (currHabitat.animal2 != null)
        {
            currAnimal = currHabitat.animal2;
        }
    }
    public void Select3()
    {
        if (currHabitat.animal3 != null)
        {
            currAnimal = currHabitat.animal3;
        }
    }
    public void Select4()
    {
        if (currHabitat.animal4 != null)
        {
            currAnimal = currHabitat.animal4;
        }
    }

    public void HabitatNext()
    {
        habitatIndex = (habitatIndex - 1) % PlayerManager.Instance.habitats.Count;
        currHabitat = PlayerManager.Instance.habitats[habitatIndex];
        updateAnimalSlots();
    }
    public void HabitatPrev()
    {
        habitatIndex = (habitatIndex + 1) % PlayerManager.Instance.habitats.Count;
        currHabitat = PlayerManager.Instance.habitats[habitatIndex];
        updateAnimalSlots();
    }


}

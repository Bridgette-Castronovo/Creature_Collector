using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PageDisplay : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public Image image;
    public TMP_Text weightText;
    public TMP_Text valueText;
    public TMP_Text waterText;
    public TMP_Text tempText;

    public void SetData(Creature data)
    {
        if (data == null) return;
        Debug.Log("Setting page: " + data.speciesName);
        titleText.text = data.speciesName;
        weightText.text = "Weight: " + c.weightMax;
        valueText.text = "Value: " + c.value;
        waterText.text = "Water: " + c.waterIdeal;
        tempText.text = "Temp: " + c.tempIdeal;
        descriptionText.text = data.speciesDesc;
        image.sprite = data.image;
    }
}
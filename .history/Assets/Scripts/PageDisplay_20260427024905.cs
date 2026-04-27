using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PageDisplay : MonoBehaviour
{
    public TMP_Text infoText;
    public TMP_Text descriptionText;
    public Image image;
   

    public void SetData(Creature data)
    {
        if (data == null) return;
        Debug.Log("Setting page: " + data.speciesName);
        infoText.text =
            "Name: " + c.speciesName + "\n" +
            "Weight: " + c.weightMax + "\n" +
            "Value: " + c.value + "\n" +
            "Water: " + c.waterIdeal + "\n" +
            "Temp: " + c.tempIdeal;
        descriptionText.text = data.speciesDesc;
        image.sprite = data.image;
    }
}
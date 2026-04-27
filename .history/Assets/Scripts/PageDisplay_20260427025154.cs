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
            "Name: " + data.speciesName + "\n" +
            "Weight: " + data.weightMax + "\n" +
            "Value: " + data.value + "\n" +
            "Water: " + data.waterIdeal + "\n" +
            "Temp: " + data.tempIdeal;

        descriptionText.text = data.speciesDesc;
        image.sprite = data.image;
    }
}
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PageDisplay : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public Image image;

    public void SetData(Creature data)
    {
        if (data == null) return;

        titleText.text = data.speciesName;
        descriptionText.text = data.speciesDesc;
        image.sprite = data.image;
    }
}
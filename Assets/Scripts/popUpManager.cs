using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupManager : MonoBehaviour
{
    public GameObject popup;
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public Image image;

    public void Show(Creature data)
    {
        popup.SetActive(true);
        titleText.text = data.speciesName;
        descriptionText.text = data.speciesDesc;
        image.sprite = data.image;
    }

    public void Hide()
    {
        popup.SetActive(false);
    }
}
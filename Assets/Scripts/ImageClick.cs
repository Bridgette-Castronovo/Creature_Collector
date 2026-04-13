using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageClick : MonoBehaviour
{
    [Header("Data")]
    public Creature creatureData;

    [Header("Popup")]
    public GameObject popup;
    public TMP_Text titleElem;
    public TMP_Text descriptionElem;
    public Image photoElem;

    public void OpenPopup()
    {
        popup.SetActive(true);

        titleElem.text = creatureData.speciesName;
        descriptionElem.text = creatureData.speciesDesc;
        photoElem.sprite = creatureData.image;
    }

    public void ClosePopup()
    {
        popup.SetActive(false);
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmailBodyDisplay : MonoBehaviour
{
    public TMP_Text bodyText;
    public Button attachmentButton;  // drag in from the scene
    public Image attachmentImage;    // the image on that button

    public void ShowEmail(QuestEmail email)
    {
        bodyText.text = email.body;

        bool hasAttachment = email.attachmentSprite != null;
        attachmentButton.gameObject.SetActive(hasAttachment);
        if (hasAttachment)
            attachmentImage.sprite = email.attachmentSprite;
    }
}
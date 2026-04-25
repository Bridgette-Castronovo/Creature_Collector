using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmailBodyDisplay : MonoBehaviour
{
    public TMP_Text bodyText;
    public Button attachmentButton;
    public Image attachmentImage;

    private QuestEmail _currentEmail;

    public void ShowEmail(QuestEmail email)
    {
        _currentEmail = email;
        bodyText.text = email.body;

        // Re-enable button every time a new email is opened
        attachmentButton.interactable = true;

        bool hasAttachment = email.attachmentSprite != null;
        attachmentButton.gameObject.SetActive(hasAttachment);
        if (hasAttachment)
        {
            attachmentImage.sprite = email.attachmentSprite;
            attachmentButton.onClick.RemoveAllListeners();
            attachmentButton.onClick.AddListener(OnAttachmentClicked);
        }
    }

    void OnAttachmentClicked()
    {
        QuestManager.Instance.ClaimReward(_currentEmail);
        attachmentButton.interactable = false;
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmailPrefabUI : MonoBehaviour
{
    public TMP_Text senderText;
    public TMP_Text subjectText;
    public TMP_Text previewText;

    private QuestEmail emailData;
    private EmailBodyDisplay bodyDisplay;

    public void Populate(QuestEmail email, EmailBodyDisplay display)
    {
        emailData = email;
        bodyDisplay = display;

        senderText.text = email.sender;
        subjectText.text = email.subject;
        previewText.text = email.preview;

        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        bodyDisplay.ShowEmail(emailData);
        if (bodyDisplay == null)
        {
            Debug.LogError("bodyDisplay is NULL");
            return;
        }

        Debug.Log("Email clicked");
    }
}
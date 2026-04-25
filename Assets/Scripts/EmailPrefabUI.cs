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

        Button btn = GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (bodyDisplay == null)
        {
            Debug.LogError("bodyDisplay is NULL — check EmailUIManager has Body Display assigned in Inspector");
            return;
        }
        Debug.Log("Email clicked: " + emailData.subject);
        bodyDisplay.ShowEmail(emailData);
    }
}
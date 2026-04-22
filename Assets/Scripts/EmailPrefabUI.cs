using TMPro;
using UnityEngine;

public class EmailPrefabUI : MonoBehaviour
{
    public TMP_Text senderText;
    public TMP_Text subjectText;
    public TMP_Text previewText;
    public TMP_Text bodyText;       // shown when expanded (optional)

    public void Populate(QuestEmail email)
    {
        senderText.text = email.sender;
        subjectText.text = email.subject;
        previewText.text = email.preview;
        if (bodyText) bodyText.text = email.body;
    }
}
using UnityEngine;
using TMPro;

public class DetailPaneUI : MonoBehaviour
{
    public TextMeshProUGUI subjectText;
    public TextMeshProUGUI senderText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI bodyText;
    public GameObject emptyState; // "Select an email" placeholder
    public GameObject contentState; // the actual email content

    void Start()
    {
        emptyState.SetActive(true);
        contentState.SetActive(false);
    }

    public void Display(EmailData email)
    {
        emptyState.SetActive(false);
        contentState.SetActive(true);

        subjectText.text = email.subject;
        senderText.text = "From: " + email.sender;
        timeText.text = email.time;
        bodyText.text = email.body;
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmailRowUI : MonoBehaviour
{
    [Header("References")]
    public Image background;
    public GameObject unreadDot;
    public TextMeshProUGUI senderText;
    public TextMeshProUGUI subjectText;
    public TextMeshProUGUI previewText;
    public TextMeshProUGUI timeText;
    public Button button;

    [Header("Colors")]
    public Color normalColor = Color.white;
    public Color selectedColor = new Color(0.9f, 0.95f, 1f);

    private static EmailRowUI currentlySelected;
    private EmailData data;
    private InboxManager inbox;

    public void Setup(EmailData emailData, InboxManager manager)
    {
        data = emailData;
        inbox = manager;

        senderText.text = data.sender;
        subjectText.text = data.subject;
        previewText.text = data.body;
        timeText.text = data.time;

        senderText.fontStyle = data.isUnread ? FontStyles.Bold : FontStyles.Normal;
        subjectText.fontStyle = data.isUnread ? FontStyles.Bold : FontStyles.Normal;
        unreadDot.SetActive(data.isUnread);

        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        // Deselect previous
        if (currentlySelected != null && currentlySelected != this)
            currentlySelected.Deselect();

        // Select this row
        currentlySelected = this;
        background.color = selectedColor;

        // Mark as read
        data.isUnread = false;
        unreadDot.SetActive(false);
        senderText.fontStyle = FontStyles.Normal;
        subjectText.fontStyle = FontStyles.Normal;

        // Tell the inbox to show this email
        inbox.ShowEmail(data);
    }

    public void Deselect()
    {
        background.color = normalColor;
    }
}
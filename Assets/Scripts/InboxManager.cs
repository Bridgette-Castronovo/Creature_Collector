using UnityEngine;
using System.Collections.Generic;

public class InboxManager : MonoBehaviour
{
    [Header("Scroll List")]
    public Transform emailListContainer; // the Content object inside your ScrollRect
    public GameObject emailRowPrefab;

    [Header("Detail Pane")]
    public DetailPaneUI detailPane;

    [Header("Email Data")]
    public List<EmailData> emails = new List<EmailData>();

    void Start()
    {
        PopulateInbox();
    }

    void PopulateInbox()
    {
        foreach (EmailData email in emails)
        {
            GameObject row = Instantiate(emailRowPrefab, emailListContainer);
            row.GetComponent<EmailRowUI>().Setup(email, this);
        }
    }

    public void ShowEmail(EmailData email)
    {
        detailPane.Display(email);
    }
}
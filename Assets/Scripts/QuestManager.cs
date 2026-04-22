using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }

    //Assign all your emails in the Inspector
    public List<QuestEmail> allEmails = new();

    //Other systems subscribe to this
    public event Action<QuestEmail> OnEmailReceived;

    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
    }

    /// <summary>Call this from anywhere to send a specific email.</summary>
    public void TriggerEmail(string emailId)
    {
        QuestEmail email = allEmails.Find(e => e.id == emailId);
        if (email == null)
        {
            Debug.LogWarning($"QuestManager: no email with id '{emailId}'");
            return;
        }
        OnEmailReceived?.Invoke(email);
    }
}
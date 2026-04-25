using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }

    public List<QuestEmail> allEmails = new();
    public event Action<QuestEmail> OnEmailReceived;

    public bool firstCreatureCollected = false;

    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(SendStartingEmails());
    }

    IEnumerator SendStartingEmails()
    {
        yield return null;
        TriggerEmail("corporate_start");
        TriggerEmail("conservation_m1");
    }

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

    public void CollectFirstCreature()
    {
        firstCreatureCollected = true;
        Debug.Log("First creature collected: " + firstCreatureCollected);
    }
}
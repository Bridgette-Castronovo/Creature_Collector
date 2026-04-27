using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerManager;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }

    public List<QuestEmail> allEmails = new();
    public event Action<QuestEmail> OnEmailReceived;

    public bool firstCreatureCollected = false;
    public int playerMoney = 0;
    public Creature dragonData;


    
    

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
        if (PlayerManager.Instance.quest2Triggered == true)
        {
            TriggerEmail("conservation_m1");
        }
        if (PlayerManager.Instance.quest3Triggered == true)
        {
            TriggerEmail("conservation_m2");
        }
        if (PlayerManager.Instance.quest4Triggered == true)
        {
            TriggerEmail("conservation_m3");
        }
        if (PlayerManager.Instance.quest5Triggered == true)
        {
            TriggerEmail("conservation_m4");
        }
        if (PlayerManager.Instance.quest6Triggered == true)
        {
            TriggerEmail("tutorial_complete");
        }
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

    public void ClaimReward(QuestEmail email)
    {
        switch (email.rewardType)
        {
            case RewardType.FirstCreature:
                PlayerManager.Instance.GenerateSickAnimal(dragonData, 1, 0, 0);
                firstCreatureCollected = true;
                Debug.Log("First creature collected: " + firstCreatureCollected);
                break;

            case RewardType.Money:
                playerMoney += email.rewardAmount;
                PlayerManager.Instance.addMoney(email.rewardAmount);
                Debug.Log("Money received: " + email.rewardAmount + " | Total: " + playerMoney);
                Debug.Log("Player money total: " + PlayerManager.Instance.getMoney());
                break;

            case RewardType.None:
                Debug.Log("No reward for this email.");
                break;
        }
    }
}
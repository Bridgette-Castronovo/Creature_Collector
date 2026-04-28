using UnityEngine;

[System.Serializable]
public class QuestEmail
{
    public string id;
    public string sender;
    public string subject;
    public string preview;
    [TextArea(4, 10)]
    public string body;
    public Sprite attachmentSprite;

    // Reward
    public RewardType rewardType;
    public int rewardAmount; // used for money rewards
}

public enum RewardType
{
    None,
    FirstCreature,
    Money
}
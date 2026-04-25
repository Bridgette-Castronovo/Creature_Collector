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
    public Sprite attachmentSprite; // assign in Inspector, leave null if no attachment
}
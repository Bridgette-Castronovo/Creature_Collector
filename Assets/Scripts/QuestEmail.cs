using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestEmail
{
    public string id;           //"corporate_start", "conservation_m1"
    public string sender;
    public string subject;
    public string preview;      //short blurb shown in list
    [TextArea(4, 10)]
    public string body;
}
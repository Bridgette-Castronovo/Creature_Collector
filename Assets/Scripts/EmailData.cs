[System.Serializable]
public class EmailData
{
    public string sender;
    public string subject;
    public string body;
    public string time;
    public bool isUnread;
    public string tag;
    public bool isRead = false;
}
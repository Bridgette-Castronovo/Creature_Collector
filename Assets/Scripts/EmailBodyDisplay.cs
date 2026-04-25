using TMPro;
using UnityEngine;

public class EmailBodyDisplay : MonoBehaviour
{
    public TMP_Text bodyText;

    public void ShowEmail(QuestEmail email)
    {
        bodyText.text = email.body;
    }
}
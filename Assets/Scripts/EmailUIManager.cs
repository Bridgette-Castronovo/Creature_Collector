using UnityEngine;

public class EmailUIManager : MonoBehaviour
{
    [Header("References")]
    public Transform contentArea;       // ScrollRect ? Viewport ? Content
    public EmailPrefabUI emailPrefab;   // your Email Prefab

    void OnEnable() => QuestManager.Instance.OnEmailReceived += SpawnEmail;
    void OnDisable() => QuestManager.Instance.OnEmailReceived -= SpawnEmail;

    void SpawnEmail(QuestEmail email)
    {
        EmailPrefabUI instance = Instantiate(emailPrefab, contentArea);
        instance.Populate(email);
        // Place above all existing emails
        instance.transform.SetAsFirstSibling();
    }
}
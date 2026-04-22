using UnityEngine;
public class EmailUIManager : MonoBehaviour
{
    [Header("References")]
    public Transform contentArea;
    public GameObject emailPrefab;
    public EmailBodyDisplay bodyDisplay; 

    void Start()
    {
        QuestManager.Instance.OnEmailReceived += SpawnEmail;
    }

    void OnDisable()
    {
        if (QuestManager.Instance != null)
            QuestManager.Instance.OnEmailReceived -= SpawnEmail;
    }

    void SpawnEmail(QuestEmail email)
    {
        GameObject instance = Instantiate(emailPrefab, contentArea);

        EmailPrefabUI ui = instance.GetComponent<EmailPrefabUI>();
        if (ui == null)
        {
            Debug.LogWarning("EmailUIManager: spawned prefab has no EmailPrefabUI component.");
            return;
        }

        ui.Populate(email, bodyDisplay);

        instance.transform.SetAsFirstSibling();
    }
}
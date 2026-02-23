using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    public string Description;
    public int RequiredAmount;
    public int CurrentAmount;
    public bool Completed {  get; private set; }
    public UnityEvent OnGoalCompleted;

    public void UpdateProgress(int amount)
    {
        if (Completed) return;
        CurrentAmount += amount;
        if (CurrentAmount >= RequiredAmount)
        {
            Complete();
        }
    }

    private void Complete()
    {
        Completed = true;
        OnGoalCompleted.Invoke();
        Debug.Log("You have completed: " + Description);
    }
}

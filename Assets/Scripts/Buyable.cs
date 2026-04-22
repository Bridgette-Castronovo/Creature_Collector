using UnityEngine;

[CreateAssetMenu(fileName = "Buyable", menuName = "Scriptable Objects/Buyable")]
public class Buyable : ScriptableObject
{
    public string itemName;
    public int cost;



    public virtual string getName()
    {
        return itemName;
    }

    public virtual int getCost()
    {
        return cost;
    }

}

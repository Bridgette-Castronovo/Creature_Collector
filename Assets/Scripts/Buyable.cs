using UnityEngine;

[CreateAssetMenu(fileName = "Buyable", menuName = "Scriptable Objects/Buyable")]
public class Buyable : ScriptableObject
{
    public string name;
    public int cost;
    public int weight;



    public string getName()
    {
        return name;
    }

    public int getCost()
    {
        return cost;
    }

    public int getWeight()
    {
        return weight;
    }
}

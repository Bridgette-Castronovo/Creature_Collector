using UnityEngine;

[CreateAssetMenu(fileName = "FoodType", menuName = "Scriptable Objects/FoodType")]
public class FoodType : Buyable
{

    public int weight;
    public override string getName()
    {
        return itemName;
    }

    public override int getCost()
    {
        return cost;
    }

    public int getWeight()
    {
        return weight;
    }
}

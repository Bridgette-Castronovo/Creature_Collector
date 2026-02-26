using UnityEngine;

[CreateAssetMenu(fileName = "FoodType", menuName = "Scriptable Objects/FoodType")]
public class FoodType : ScriptableObject
{
    public string foodName = "Food Type";
    public int buyCost = 200;
    public int weight = 20;



    public string getFoodName()
    {
        return foodName;
    }

    public int getBuyCost()
    {
        return buyCost;
    }

    public int getWeight()
    {
        return weight;
    }
}

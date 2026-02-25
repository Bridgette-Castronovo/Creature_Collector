using UnityEngine;

[CreateAssetMenu(fileName = "MeatFood", menuName = "Scriptable Objects/MeatFood")]
public class MeatFood : ScriptableObject
{
    private string foodName = "Meat";

    private int buyCost = 200;
    private int weight = 200;
}

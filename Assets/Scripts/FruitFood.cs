using UnityEngine;

[CreateAssetMenu(fileName = "FruitFood", menuName = "Scriptable Objects/FruitFood")]
public class FruitFood : ScriptableObject
{
    private string foodName = "Fruit";

    private int buyCost = 200;
    private int weight = 200;
}

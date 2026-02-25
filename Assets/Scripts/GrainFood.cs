using UnityEngine;

[CreateAssetMenu(fileName = "GrainFood", menuName = "Scriptable Objects/GrainFood")]
public class GrainFood : ScriptableObject
{
    private string foodName = "Grains";

    private int buyCost = 100;
    private int weight = 500;
}

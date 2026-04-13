using UnityEngine;

[CreateAssetMenu(fileName = "Creature", menuName = "Scriptable Objects/Creature")]
public class Creature : ScriptableObject
{
    public string speciesName = "New Species";
    public string speciesDesc = "Add a description for this species.";
    public Sprite image;

    public int weightMin = 100;
    public int weightMax = 200;

    public int hunger = 150;

    public int fruitMin = 50;
    public int fruitMax = 100;

    public int meatMin = 50;
    public int meatMax = 100;

    public int grainsMin = 50;
    public int grainsMax = 100;

    public int crystalMin = 50;
    public int crystalMax = 100;

    public bool research = false;
}

using UnityEngine;

[CreateAssetMenu(fileName = "Creature", menuName = "Scriptable Objects/Creature")]
public class Creature : ScriptableObject
{
    public string speciesName = "New Species";
    public string speciesDesc = "Add a description for this species.";
    public Sprite image;

    public int weightMax;


    public int fruitIdeal;

    public int meatIdeal;

    public int grainsIdeal;

    public int crystalIdeal;

    public int waterIdeal;
    public int tempIdeal;

    public bool research = false;
}

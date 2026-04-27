using UnityEngine;

[System.Serializable]
public class Animal
{
    public int id;
    public Creature creature;

    public int health;
    public int habitatHappiness;
    public float hunger;
    public int[] illnesses;

    public int dayFruit = 0;
    public int dayMeat = 0;
    public int dayGrains = 0;
    public int dayCrystal = 0;
    public int waterCurr = 0;
    public int tempCurr = 0;


}

using UnityEngine;

public class FoodMix : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int fruit = 0;
    public int meat = 0;
    public int grains = 0;
    public int crystal = 0;
    public int totalFood = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalFood = fruit + meat + grains + crystal;
    }
}

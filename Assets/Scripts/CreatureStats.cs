using UnityEngine;

public class CreatureStats : MonoBehaviour
{

    [SerializeField] public string creatureName = "New Creature";
    [SerializeField] public Creature species;
    public int currWeight;
    public int currHunger;
    public int health = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // currWeight = Random.Range(species.weightMin, species.weightMax);
        // currHunger = species.hunger;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

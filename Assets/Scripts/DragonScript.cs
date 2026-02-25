using UnityEngine;

[CreateAssetMenu(fileName = "DragonScript", menuName = "Scriptable Objects/DragonScript")]
public class DragonScript : ScriptableObject
{
    private string speciesName = "Ryufuku";
    private string speciesDesc = "Ryufuku is found in the seas of Japan. The Ryufuku " +
                                "is a sea serpent shaped dragon that floats through the" +
                                " environment. Ryufuku also may be holding a mystical jewel," +
                                " in ancient times they used this to control the tides. " +
                                "Now, the jewel is used as a mystical object that the dragon" +
                                " likes to play with or perhaps used in granting luck to others. " +
                                "Wishing and meditating to this dragon may bring you luck in the near future.";

    private int weightMin = 2000;
    private int weightMax = 2500;

    private int hunger = 200;

    private int fruitMin = 50;
    private int fruitMax = 75;

    private int meatMin = 90;
    private int meatMax = 125;

    private int grainsMin = 0;
    private int grainsMax = 0;

    private int crystalMin = 0;
    private int crystalMax = 0;

    private bool research = false;
    
}

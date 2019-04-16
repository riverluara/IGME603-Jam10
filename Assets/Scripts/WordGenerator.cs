using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList = {"Start" ,"I am Kimura", "from the outside village",
"I am a junior Ninja", "with the power of fire",
"I want to see castellan",
"There is a weird thing happened",
"Some villagers died",
"Next",
"Begin",
"Trust me",
"I have seen the corpse",
"They looked very weird",
"There is no scar", "on their body",
"It looks like they died", "when they were sleeping",
"I think the devils", "invade their dreams",
"End", "End"

 };

    static int randomIndex = 0;

   

    public static string GetRandomWord()
    {
        //int randomIndex = Random.Range(0, wordList.Length);
        
        string randomWord = wordList[PlayerPrefs.GetInt("number")];
        PlayerPrefs.SetInt("number", PlayerPrefs.GetInt("number") + 1);
        return randomWord;
    }
}

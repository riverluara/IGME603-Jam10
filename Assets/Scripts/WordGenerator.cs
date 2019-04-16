using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList = {"I am Kimura", "I live outside the village",
"I am a junior fire Ninja",
"I am on my way",
"to see Castellan",
"Something strange happened",
"The villagers have fallen asleep",
"and they will not wake up",
"Begin",
"Begin",
"Trust me",
"I saw the villagers",
"They will not wake up",
"They are not hurt", "I think it is the Dream Devils",
"They come from the mountains", "Sometimes they come",
"and invade our dreams", "but this time",
"they will not leave", "Why are they here?",
"End","End"

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

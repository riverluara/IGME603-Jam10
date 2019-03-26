using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList = { "ancient", "tacky", "chilly", "possessive",
        "spiteful", "skinny", "bubble", "fragile", "dual", "pathfinder", "planet",
        "pod", "computer", "artifical", "tech", "cyber", "control", "zoned" };
    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];

        return randomWord;
    }
}

using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList = { "ancient","937", "tacky", "chilly", "158","possessive",
        "spiteful", "47693","593674","skinny", "bubble", "fragile","4537", "dual","45370", "pathfinder", "planet",
        "pod", "computer","45613", "artifical", "tech", "cyber", "control", "zoned" };
    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];

        return randomWord;
    }
}

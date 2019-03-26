using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator2 : MonoBehaviour
{
    int randomIndex;
    string randomWord;
    private string[] wordList = { "45678941", "7894152", "7894531", "489756151", "4568712", "78653124", "45612378" };
    private  string[] wordList2 = { "126", "2897", "9656", "1732", "09246", "4834", "3997" };
    private string[] wordList3 = { "12", "28", "96", "17", "09", "48", "37" };
    public  string GetRandomWord(int levelIndex)
    {
        if (levelIndex == 0)
        {
            randomIndex = Random.Range(0, wordList.Length);
            randomWord = wordList[randomIndex];

        }
        if (levelIndex == 1)
        {
            randomIndex = Random.Range(0, wordList2.Length);
            randomWord = wordList2[randomIndex];

        }
        if (levelIndex == 2)
        {
            randomIndex = Random.Range(0, wordList3.Length);
            randomWord = wordList3[randomIndex];

        }

        return randomWord;
    }
}

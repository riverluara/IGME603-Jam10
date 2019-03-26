using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    //int levelIndex = 0;
    int randomIndex;
    string randomWord;
    private  string[] wordList = { "ancient","tacky","chilly","possessive","spiteful","skinny","bubble"};
    private  string[] wordList2 = { "aby", "shy", "kiss", "pear", "sun", "feel", "kite" };
    private  string[] wordList3 = { "ab", "y", "g", "yu", "k", "la", "ix" };
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

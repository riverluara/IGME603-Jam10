using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public WordDisplay SpawnWord()
    {

        GameObject wordObj = Instantiate(wordPrefab);//Add Random Position later
        WordDisplay wordDisplay = wordObj.GetComponentInChildren<WordDisplay>();

        return wordDisplay;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    
    private float RandomZ;
    public GameObject wordPrefab;
    void Start()
    {
        RandomZ = Random.Range(48.21f, 61.41f);
    }
    public WordDisplay SpawnWord()
    {
        RandomZ = Random.Range(48.21f, 61.41f);
        GameObject wordObj = Instantiate(wordPrefab, new Vector3(6.4f, -16.98f, RandomZ),Quaternion.identity);//Add Random Position later
        WordDisplay wordDisplay = wordObj.GetComponentInChildren<WordDisplay>();

        return wordDisplay;
    }
}

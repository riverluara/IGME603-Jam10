using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner2 : MonoBehaviour
{
    private float RandomZ;
    public GameObject wordPrefab;
    void Start()
    {
        RandomZ = Random.Range(48.21f, 61.41f);
    }
    public WordDisplay2 SpawnWord()
    {
        RandomZ = Random.Range(48.21f, 61.41f);
        GameObject wordObj = Instantiate(wordPrefab, new Vector3(6.4f, -16.98f, RandomZ), Quaternion.identity);//Add Random Position later
        WordDisplay2 wordDisplay = wordObj.GetComponentInChildren<WordDisplay2>();

        return wordDisplay;
    }
}

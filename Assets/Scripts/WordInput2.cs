using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput2 : MonoBehaviour
{
    public WordControl2 wordControl;

    // Update is called once per frame
    void Update()
    {
        foreach (char letter in Input.inputString)
        {
            wordControl.TypeLetter(letter);
        }

    }
}

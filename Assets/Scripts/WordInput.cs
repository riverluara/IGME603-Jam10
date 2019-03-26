using UnityEngine;

public class WordInput : MonoBehaviour
{
    public WordControl wordControl;

    // Update is called once per frame
    void Update()
    {
        foreach (char letter in Input.inputString)
        {
            wordControl.TypeLetter(letter);
        }
    }
}

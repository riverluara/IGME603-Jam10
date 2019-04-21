using System.Collections.Generic;
using UnityEngine;

public class WordControl : MonoBehaviour
{
    public List<Word> words;
    public WordSpawner wordSpawner;
    public CombatManager combatManager;

    private bool hasActiveWord;
    private Word activeWord;

    void Start()
    {

    }

    public void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
        Debug.Log(word.word);
        words.Add(word);
    }

    public void TypeLetter(char letter)
    {
        if (hasActiveWord)
        {
            // Check next
            // Remove it from word
            if (activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
        }
        else
        {
            foreach (Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }

        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }

    public void DesoryWord()
    {
        hasActiveWord = false;
        words.Remove(activeWord);
    }
}

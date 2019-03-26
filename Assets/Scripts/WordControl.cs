using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordControl : MonoBehaviour
{
    public int levelIndex = 0;
    public List<Word> words;
    public WordSpawner wordSpawner;
    public CombatManager combatManager;
    public WordGenerator wordGenerator;
    private bool hasActiveWord;
    private Word activeWord;
    void Start()
    {
        
    }

    public void AddWord()
    {
        
        Word word = new Word(wordGenerator.GetRandomWord(levelIndex), wordSpawner.SpawnWord());
        Debug.Log(word.word);
        words.Add(word);
    }
    public void TypeLetter(char letter)
    {
        if (hasActiveWord)
        {
            //Check next
            //remove it from word
            if(activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
        }
        else
        {
            foreach(Word word in words)
            {
                if(word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }

        if(hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }
}

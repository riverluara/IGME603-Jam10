using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordControl2 : MonoBehaviour
{
    public int levelIndex = 0;
    public List<Word2> words;
    public WordSpawner2 wordSpawner;
    public CombatManager combatManager;
    public WordGenerator2 wordGenerator2;
    private bool hasActiveWord;
    private Word2 activeWord;
    void Start()
    {

    }

    public void AddWord()
    {

        Word2 word = new Word2(wordGenerator2.GetRandomWord(levelIndex), wordSpawner.SpawnWord());
        Debug.Log(word.word);
        words.Add(word);
    }
    public void TypeLetter(char letter)
    {
        if (hasActiveWord)
        {
            //Check next
            //remove it from word
            if (activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
        }
        else
        {
            foreach (Word2 word in words)
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
}

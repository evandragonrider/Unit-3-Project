using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public EnemySpawner wordSpawner;
    public List<Word> words;
    private bool hasActiveWord;
    private Word activeWord;

    private void Start()
    {
        AddWord();
        AddWord();
        AddWord();
    }

    public WordDisplay AddWord()
    {
        string newWord = WordGenerator.GetRandomWord();

        //wordDisplay is tempermental
        WordDisplay wordDisplay = wordSpawner.SpawnWordEnemy();
        wordDisplay.SetWord(newWord);

        Word word = new Word(newWord, wordDisplay);
        words.Add(word);

        return wordDisplay;
    }

    public void TypeLetter(char letter)
    {
        if (hasActiveWord)
        {
            //check if letter was next and remove from word
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
}





	
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class WordManager : MonoBehaviour
{
    public List<Word> words;

    public wordSpawner wordSpawner;
    public wordScore wordScore;
    
    private bool hasActiveWord;
    private Word activeWord;

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
            if (activeWord.getNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
        }
        else
        {
            foreach (Word word in words)
            {
                if (word.getNextLetter() == letter)
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
            wordScore.addScore();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList = {"word 1", "word 2","example sentence","howdy" };

    public static string GetRandomWord(){
        int randomIndex = Random.Range(0,wordList.Length);
        string randomWord = wordList[randomIndex];

        return randomWord;
    }
    
}
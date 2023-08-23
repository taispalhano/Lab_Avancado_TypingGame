using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Typer : MonoBehaviour
{
    public TextMeshProUGUI wordLabel = null;

    [SerializeField] private string remainingWord;
    [SerializeField] private string currentWord;

    [SerializeField] private WordPackage wordPackage;

    private void Start()
    {
        SetCurrentWord();
    }
    private void SetCurrentWord()
    {
        currentWord = wordPackage.GetRandomWord();
        SetRemainingWord(currentWord);
    }
    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordLabel.text = remainingWord;  
    }
    private void Update()
    {
        CheckInput();
    }
    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;
            if (keysPressed.Length == 1) EnterLetter(keysPressed);
        }
    }
    private void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            RemoveLetter();
            GameManager.instance.RegisterLetter();

            if (IsWordComplete()) SetCurrentWord();
        }
    }
    private bool IsCorrectLetter(string letter) => remainingWord.IndexOf(letter) == 0;
    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }
    private bool IsWordComplete() => remainingWord.Length == 0;
}
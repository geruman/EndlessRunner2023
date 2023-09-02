using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using System.Collections;

public class HighScoreMono : MonoBehaviour
{    
    [SerializeField] Text newScoreMessage;    
    public event Action<string> onNameSet;
    private int lettersSet = 0;
    [SerializeField] Text[] userNameText;
    private char[] letters = Enumerable.Range(1, 5).Select(x=> '_').ToArray();

    private static IEnumerable<KeyCode> LetterKeyCodes => 
        (Enum.GetValues(typeof(KeyCode)) as KeyCode[])
            .Where(x => KeyCodeIsALetter(x.ToString()));

    private void Awake()
    {
        RefreshLetters();
        StartCoroutine("BlinkFirstUnderLine");
    }

    private IEnumerator BlinkFirstUnderLine()
    {
        while(letters.Any(BlinkableCharacter))
        {
            letters[lettersSet] = InvertBlinkable(letters.First(BlinkableCharacter));
            RefreshLetters();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private char InvertBlinkable(char c) => c == '_'? ' ' : '_';

    private bool BlinkableCharacter(char c) => c == '_' || c == ' ';

    public void SetHighScore()
    {
        HandleUserInput();
        if (NameIsSet())
        {
            onNameSet.Invoke(string.Join(string.Empty, letters));
        }
    }

    private void HandleUserInput()
    {
        if (LetterKeyCodes.Any(Input.GetKeyDown))
        {
            letters[lettersSet++] = LetterKeyCodes.First(Input.GetKeyDown).ToString()[0];
            RefreshLetters();
        }
        else if (Input.GetKeyDown(KeyCode.Backspace) && lettersSet > 0)
        {
            for (int i = lettersSet; i < letters.Length; i++)
            {
                letters[i] = '_';
            }            
            lettersSet--;
            RefreshLetters();
            StopCoroutine("BlinkFirstUnderLine");
            StartCoroutine("BlinkFirstUnderLine");
        }
    }

    private bool NameIsSet() => !(lettersSet < letters.Length);

    private void RefreshLetters()
    {
        for (int i = 0; i < letters.Length; i++)
        {
            userNameText[i].text = letters[i].ToString();
        }        
    }

    private static bool KeyCodeIsALetter(string keyCode)
        => keyCode.Length == 1 && char.IsLetter(keyCode[0]);
}

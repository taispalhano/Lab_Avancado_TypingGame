using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private float typingSpeed;

    [SerializeField] private TextMeshProUGUI typingSpeedText;

    private float lastTime;
    private float elapsedTime;

    private int lettersTyped;

    private void Update()
    {
        if (elapsedTime >= 0.5f)
        {
            typingSpeed = lettersTyped;
            typingSpeedText.text = $"{typingSpeed} / Second";
            lettersTyped = 0;
            elapsedTime = 0f;
        }
        else elapsedTime += Time.deltaTime;
    }
    public void RegisterLetter()
    {
         lettersTyped++;
    }
}
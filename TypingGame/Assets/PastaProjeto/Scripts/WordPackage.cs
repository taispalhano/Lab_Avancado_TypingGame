using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Banco de Palavras", menuName ="Typing Game/Banco de Palavras/Novo Banco de Palavras")]
public class WordPackage : ScriptableObject
{
    [SerializeField] private List<string> phrases = new List<string>();

    public string GetRandomWord() => phrases[Random.Range(0, phrases.Count)];
}
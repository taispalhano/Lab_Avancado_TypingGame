using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Banco de Palavras", menuName ="Typing Game/Banco de Palavras/Novo Banco de Palavras")]
public class WordPackage : ScriptableObject
{
    public List<string> frases = new List<string>();
    public float tempoParaCumprir = 60f;
    public bool faseTemTempo = true;


    public string PegarPalavraAleatoria()
    {
        return frases[Random.Range(0, frases.Count)];
    }
}
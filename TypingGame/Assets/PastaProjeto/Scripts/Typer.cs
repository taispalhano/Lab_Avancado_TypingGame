using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Typer : MonoBehaviour
{
    public TextMeshProUGUI palavraPosicao = null;

    private string fraseRestante;
    private string fraseAtual;
    [SerializeField] private int tamanhoUltimaFrase;

    public WordPackage pacoteDeFrases;

    public AudioClip errou;
    public AudioClip fraseCorreta;

    public List<string> frasesCopia;

    public void OnStart()
    {
        frasesCopia.Clear();
        frasesCopia.AddRange(pacoteDeFrases.frases);
    }
    public void AtribuirFrase()
    {
        if (frasesCopia.Count <= 0) return;

        fraseAtual = frasesCopia[0];
        tamanhoUltimaFrase = fraseAtual.Length;
        AtribuirFraseRestante(fraseAtual);
    }
    private void AtribuirFraseRestante(string novaString)
    {
        fraseRestante = novaString;
        palavraPosicao.text = fraseRestante;  
    }
    private void Update()
    {
        ChecarInput();
    }
    private void ChecarInput()
    {
        if (Input.anyKeyDown)
        {
            string teclaAperdada = Input.inputString;
            if (teclaAperdada.Length == 1) TentarLetra(teclaAperdada);
        }
    }
    private void TentarLetra(string letraEscrita)
    {
        if (LetraEstaCorreta(letraEscrita))
        {
            RemoverLetra();
            GameManager.instance.RegistrarLetra();

            if (PalavraEstaCompleta())
            {
                GameManager.instance._pontos += tamanhoUltimaFrase * 2;
                GameManager.instance.TocarSom(fraseCorreta);

                tamanhoUltimaFrase = 0;

                frasesCopia.Remove(frasesCopia[0]);

                AtribuirFrase();
            }
        }
        else GameManager.instance.TocarSom(errou);
    }
    private bool LetraEstaCorreta(string letra)
    {
        return fraseRestante.IndexOf(letra) == 0;
    }
    private void RemoverLetra()
    {
        string novaString = fraseRestante.Remove(0, 1);
        AtribuirFraseRestante(novaString);
    }
    private bool PalavraEstaCompleta()
    {
        return fraseRestante.Length == 0;
    }
}
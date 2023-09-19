using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    private AudioSource fonteSom;

    [SerializeField] private float velocidadeDeEscrita;

    [SerializeField] private TextMeshProUGUI velocidadeDeEscritaTexto;
    [SerializeField] private TextMeshProUGUI pontosTexto;

    public int _pontos;

    private float tempoPassado;

    private int letrasEscritas;

    private void Start()
    {
        fonteSom = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (tempoPassado >= 0.5f)
        {
            velocidadeDeEscrita = letrasEscritas;
            velocidadeDeEscritaTexto.text = $"{velocidadeDeEscrita} / Segundo";
            letrasEscritas = 0;
            tempoPassado = 0f;
        }
        else tempoPassado += Time.deltaTime;
        pontosTexto.text = $"Pontuação: {_pontos}";

        if (Input.GetKeyDown(KeyCode.F1)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RegistrarLetra()
    {
         letrasEscritas++;
    }
    public void TocarSom(AudioClip clip)
    {
        fonteSom.PlayOneShot(clip);
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    private Typer escrevedor;

    [SerializeField] private float velocidadeDeEscrita;

    [SerializeField] private TextMeshProUGUI velocidadeDeEscritaTexto;
    [SerializeField] private TextMeshProUGUI pontosTexto;

    public int _pontos;

    private float tempoPassado;

    private int letrasEscritas;

    [SerializeField] private TextMeshProUGUI timerTexto;
    float timerValor = 0;

    int seconds = 0;
    int minutes = 0;

    public GameObject telaFimDeJogo;
    public bool jogoAcabou = false;

    public WordPackage pacoteDeFrases;

    public TextMeshProUGUI pontuacaoFinal;

    private void Start()
    {
        fonteSom = GetComponent<AudioSource>();
        
        escrevedor = GetComponent<Typer>();
        escrevedor.pacoteDeFrases = pacoteDeFrases;
        escrevedor.OnStart();
        escrevedor.AtribuirFrase();

        timerValor = pacoteDeFrases.tempoParaCumprir;

        timerTexto.gameObject.SetActive(pacoteDeFrases.faseTemTempo);
    }

    private void Update()
    {
        if (pacoteDeFrases.faseTemTempo)
        {
            if (timerValor <= 0 && !jogoAcabou) FimDeJogo();
            else timerValor -= Time.deltaTime;

            minutes = Mathf.FloorToInt(timerValor / 60);
            seconds = Mathf.FloorToInt(timerValor % 60);

            timerTexto.text = $"{minutes}:{ seconds}";
        }
        else timerTexto.gameObject.SetActive(false);

        if (escrevedor.frasesCopia.Count <= 0) FimDeJogo();

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
    public void FimDeJogo()
    {
        jogoAcabou = true;
        pontuacaoFinal.text = $"Pontuação: {_pontos}";
        telaFimDeJogo.SetActive(true);
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
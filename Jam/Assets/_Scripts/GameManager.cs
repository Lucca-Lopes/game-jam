using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Todas as peças de roupas disponíveis no jogo")]
    [SerializeField] public List<PecaDeRoupa> todasCabecas;
    [SerializeField] public List<PecaDeRoupa> todasTorsos;
    [SerializeField] public List<PecaDeRoupa> todasPernas;
    [SerializeField] public List<PecaDeRoupa> todasPes;
    [SerializeField] public List<PecaDeRoupa> todasMaos;

    [Header("Nomes possíveis para os oponentes")]
    [SerializeField] List<string> nomesOponentes;

    [Header("Configurações de dificuldade do oponente")]
    [SerializeField] int precisaoOponente;
    [SerializeField] int ganhoDePrecisaoOponente;
    [SerializeField] double minAtributoFocado;
    [SerializeField] double redPecaNaoFocada;

    [HideInInspector] public int numVitorias;

    [Header("Managers")]
    [SerializeField] JuradosManager jm;
    [SerializeField] OponenteManager om;
    [SerializeField] QuickTimeManager qtm;

    [Header("GameObjects")]
    public GameObject[] GameObjectLojas;
    public GameObject StatsWindow;
    public GameObject pontuacaoPlayer;
    public GameObject pontuacaoOponente;
    public GameObject botaoVitoria;
    public GameObject botaoDerrota;
    public GameObject MenuObject;
    public GameObject BatalhaObject;
    public GameObject TextVitorias;

    bool podeCalcularPontos = false;

    private void Update()
    {
        pontuacaoPlayer.GetComponent<TextMesh>().text = PlayerManager.Instance.pontuacaoTotal.ToString();
        pontuacaoOponente.GetComponent<TextMesh>().text = om.pontuacaoTotal.ToString();

        if(qtm.QTEpermitido && qtm.numeroAtualQTE == qtm.numeroTotalQTE && podeCalcularPontos)
        {
            jm.AtribuirPontuacao();
            om.CalcularPontuacaoFinal();
            podeCalcularPontos = false;

            if (PlayerManager.Instance.pontuacaoTotal >= om.pontuacaoTotal)
                botaoVitoria.SetActive(true);
            else
                botaoDerrota.SetActive(true);
        }
    }

    public void VencerPartida()
    {
        PlayerManager.Instance.dinheiro += 100;
        MenuObject.SetActive(true);
        BatalhaObject.SetActive(false);
        botaoVitoria.SetActive(false);
        numVitorias++;
        TextVitorias.GetComponent<TextMesh>().text = numVitorias.ToString();
    }

    public void PerderPartida()
    {
        MenuObject.SetActive(true);
        BatalhaObject.SetActive(false);
        botaoDerrota.SetActive(false);
        numVitorias = 0;
        TextVitorias.GetComponent<TextMesh>().text = numVitorias.ToString();
    }

    public void DefinirOponente()
    {
        podeCalcularPontos = true;

        //Definindo um nome para o oponente
        var indexNome = Random.Range(0, nomesOponentes.Count);
        om.nome = this.nomesOponentes[indexNome];
        nomesOponentes.RemoveAt(indexNome);

        //Definindo uma roupa perfeita para um jurado
        var indexJuradoFocado = Random.Range(0, jm.juradosAtuais.Count);
        EscolherUmaPecaPerfeita(indexJuradoFocado);

        //Definindo outras roupas
        if (om.pecaCabeca == null)
            EscolherUmaPeca(this.todasCabecas, om.pecaCabeca);
        if (om.pecaTorso == null)
            EscolherUmaPeca(this.todasTorsos, om.pecaTorso);
        if (om.pecaPernas == null)
            EscolherUmaPeca(this.todasPernas, om.pecaPernas);
        if (om.pecaPes == null)
            EscolherUmaPeca(this.todasPes, om.pecaPes);
        if (om.pecaMao == null)
            EscolherUmaPeca(this.todasMaos, om.pecaMao);

    }

    void EscolherUmaPeca(List<PecaDeRoupa> pecas, PecaDeRoupa? peca)
    {
        var dado = Random.Range(1, 11);
        if(dado <= precisaoOponente)
            EscolherUmaPecaBoa(pecas, peca);
        else
            EscolherUmaPecaAleatoria(pecas, peca);
        
    }

    void EscolherUmaPecaAleatoria(List<PecaDeRoupa> pecas, PecaDeRoupa? peca)
    {
        var indexPeca = Random.Range(0, pecas.Count);
        peca = pecas[indexPeca];
    }

    void EscolherUmaPecaBoa(List<PecaDeRoupa> pecas, PecaDeRoupa peca)
    {
        var indexJurado = Random.Range(0, jm.juradosAtuais.Count);
        switch (jm.juradosAtuais[indexJurado].atributoFavorito)
        {
            case Jurado.Atributos.Ataque:
                foreach (PecaDeRoupa roupa in pecas)
                {
                    if (roupa.ataque >= (minAtributoFocado - redPecaNaoFocada))
                    {
                        peca = roupa;
                        return;
                    }
                }
                break;
            case Jurado.Atributos.Defesa:
                foreach (PecaDeRoupa roupa in pecas)
                {
                    if (roupa.defesa >= (minAtributoFocado - redPecaNaoFocada))
                    {
                        peca = roupa;
                        return;
                    }
                }
                break;
            case Jurado.Atributos.Conforto:
                foreach (PecaDeRoupa roupa in pecas)
                {
                    if (roupa.conforto >= (minAtributoFocado - redPecaNaoFocada))
                    {
                        peca = roupa;
                        return;
                    }
                }
                break;
            case Jurado.Atributos.Beleza:
                foreach (PecaDeRoupa roupa in pecas)
                {
                    if (roupa.beleza >= (minAtributoFocado - redPecaNaoFocada))
                    {
                        peca = roupa;
                        return;
                    }
                }
                break;
        }
    }

    void EscolherUmaPecaPerfeita(int indexJurado)
    {
        var peca = todasMaos[0];
        var escolha = Random.Range(1, 6);
        switch (escolha)
        {
            case 1:
                peca = AcharPecaPerfeita(indexJurado, todasCabecas);
                om.pecaCabeca = peca;
                break;
            case 2:
                peca = AcharPecaPerfeita(indexJurado, todasTorsos);
                om.pecaTorso = peca;
                break;
            case 3:
                peca = AcharPecaPerfeita(indexJurado, todasPernas);
                om.pecaPernas = peca;
                break;
            case 4:
                peca = AcharPecaPerfeita(indexJurado, todasPes);
                om.pecaPes = peca;
                break;
            default:
                peca = AcharPecaPerfeita(indexJurado, todasMaos);
                om.pecaMao = peca;
                break;
        }
    }

    PecaDeRoupa AcharPecaPerfeita(int indexJurado, List<PecaDeRoupa> pecas)
    {
        switch (jm.juradosAtuais[indexJurado].atributoFavorito)
        {
            case Jurado.Atributos.Ataque:
                foreach (PecaDeRoupa roupa in pecas)
                {
                    if (roupa.ataque >= minAtributoFocado)
                    {
                        return roupa;
                    }
                }
                break;
            case Jurado.Atributos.Defesa:
                foreach (PecaDeRoupa roupa in pecas)
                {
                    if (roupa.defesa >= minAtributoFocado)
                    {
                        return roupa;
                    }
                }
                break;
            case Jurado.Atributos.Conforto:
                foreach (PecaDeRoupa roupa in pecas)
                {
                    if (roupa.conforto >= minAtributoFocado)
                    {
                        return roupa;
                    }
                }
                break;
            case Jurado.Atributos.Beleza:
                foreach (PecaDeRoupa roupa in pecas)
                {
                    if (roupa.beleza >= minAtributoFocado)
                    {
                        return roupa;
                    }
                }
                break;
        }
        return pecas[0];
    }

    public void CloseStatsWindow(){
        StatsWindow.SetActive(false);
    }
}

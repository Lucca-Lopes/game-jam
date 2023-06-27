using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponenteManager : MonoBehaviour
{
    [HideInInspector] public string nome;
    [HideInInspector] public double ataque;
    [HideInInspector] public double defesa;
    [HideInInspector] public double conforto;
    [HideInInspector] public double beleza;
    [HideInInspector] public double pontuacaoTotal;

    [HideInInspector] public PecaDeRoupa? pecaCabeca;
    [HideInInspector] public PecaDeRoupa? pecaTorso;
    [HideInInspector] public PecaDeRoupa? pecaPernas;
    [HideInInspector] public PecaDeRoupa? pecaPes;
    [HideInInspector] public PecaDeRoupa? pecaMao;

    public void DefinirStatus(string nome, PecaDeRoupa pecaCabeca, PecaDeRoupa pecaTorso, PecaDeRoupa pecaPernas, PecaDeRoupa pecaPes, PecaDeRoupa pecaMao)
    {
        this.nome = nome;
        this.pecaCabeca = pecaCabeca;
        this.pecaTorso = pecaTorso;
        this.pecaPernas = pecaPernas;
        this.pecaPes = pecaPes;
        this.pecaMao = pecaMao;
        DefinirAtributos();
    }

    void DefinirAtributos()
    {
        this.ataque += pecaCabeca.ataque + pecaTorso.ataque + pecaPernas.ataque + pecaPes.ataque + pecaMao.ataque;
        this.defesa += pecaCabeca.defesa + pecaTorso.defesa + pecaPernas.defesa + pecaPes.defesa + pecaMao.defesa;
        this.conforto += pecaCabeca.conforto + pecaTorso.conforto + pecaPernas.conforto + pecaPes.conforto + pecaMao.conforto;
        this.beleza += pecaCabeca.beleza + pecaTorso.beleza + pecaPernas.beleza + pecaPes.beleza + pecaMao.beleza;
    }
}

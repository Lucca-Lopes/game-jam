using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OponenteManager : MonoBehaviour
{
    [HideInInspector] public string nome;
    [HideInInspector] public double ataque;
    [HideInInspector] public double defesa;
    [HideInInspector] public double conforto;
    [HideInInspector] public double beleza;
    [HideInInspector] public double pontuacaoTotal;

    [HideInInspector] public PecaDeRoupa? pecaCabeca { get => pecaCabeca; set => SomarAtributos(value); }
    [HideInInspector] public PecaDeRoupa? pecaTorso { get => pecaTorso; set => SomarAtributos(value); }
    [HideInInspector] public PecaDeRoupa? pecaPernas { get => pecaPernas; set => SomarAtributos(value); }
    [HideInInspector] public PecaDeRoupa? pecaPes { get => pecaPes; set => SomarAtributos(value); }
    [HideInInspector] public PecaDeRoupa? pecaMao { get => pecaMao; set => SomarAtributos(value); }

    public Image cabeca;
    public Image pernaT;
    public Image pes;
    public Image pernaF;
    public Image torso;
    public Image mao;

    void SomarAtributos(PecaDeRoupa pecaAdicionada)
    {
        this.ataque += pecaAdicionada.ataque;
        this.defesa += pecaAdicionada.defesa;
        this.conforto += pecaAdicionada.conforto;
        this.beleza += pecaAdicionada.beleza;
    }

    public void CalcularPontuacaoFinal()
    {
        pontuacaoTotal = 0;
        pontuacaoTotal += ataque + defesa + conforto + beleza;
        pontuacaoTotal *= 1.25;
    }

   

    private void Update()
    {
        if (PlayerManager.Instance.pecaCabeca != null)
            cabeca.sprite = pecaCabeca.sprite;

        if (PlayerManager.Instance.pecaPernas != null)
            pernaF.sprite = pecaPernas.sprite;

        if (PlayerManager.Instance.pecaPes != null)
            pes.sprite = pecaPes.sprite;

        if (PlayerManager.Instance.pecaTorso != null)
            torso.sprite = pecaTorso.sprite;

        if (PlayerManager.Instance.pecaMao != null)
            mao.sprite = pecaMao.sprite;
    }
}

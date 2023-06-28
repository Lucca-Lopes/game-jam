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

    [HideInInspector] public PecaDeRoupa? pecaCabeca { get => pecaCabeca; set => SomarAtributos(value); }
    [HideInInspector] public PecaDeRoupa? pecaTorso { get => pecaTorso; set => SomarAtributos(value); }
    [HideInInspector] public PecaDeRoupa? pecaPernas { get => pecaPernas; set => SomarAtributos(value); }
    [HideInInspector] public PecaDeRoupa? pecaPes { get => pecaPes; set => SomarAtributos(value); }
    [HideInInspector] public PecaDeRoupa? pecaMao { get => pecaMao; set => SomarAtributos(value); }

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
}

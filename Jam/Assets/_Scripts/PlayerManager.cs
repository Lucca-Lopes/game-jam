using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance = new PlayerManager();

    public int dinheiro = 100;
    public PecaDeRoupa? pecaCabeca = null;
    public PecaDeRoupa? pecaTorso = null;
    public PecaDeRoupa? pecaPernas = null;
    public PecaDeRoupa? pecaPes = null;
    public PecaDeRoupa? pecaMao = null;
    public PecaDeRoupa? pernaT = null;

    public double ataque = 0;
    public double defesa = 0;
    public double conforto = 0;
    public double beleza = 0;

    public double pontuacaoTotal = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void CalcularPontuacaoFinal()
    {
        pontuacaoTotal = ataque + defesa + conforto + beleza;
    }

    public void TrocarRoupa(PecaDeRoupa roupa)
    {
        switch (roupa.tipo)
        {
            case PecaDeRoupa.Tipo.Cabeca:
                TrocarAtributos(roupa, pecaCabeca);
                pecaCabeca = roupa;
                break;
            case PecaDeRoupa.Tipo.Torso:
                TrocarAtributos(roupa, pecaTorso);
                pecaTorso = roupa;
                break;
            case PecaDeRoupa.Tipo.Pernas:
                TrocarAtributos(roupa, pecaPernas);
                pecaPernas = roupa;
                break;
            case PecaDeRoupa.Tipo.Pes:
                TrocarAtributos(roupa, pecaPes);
                pecaPes = roupa;
                break;
            case PecaDeRoupa.Tipo.Mao:
                TrocarAtributos(roupa, pecaMao);
                pecaMao = roupa;
                break;
        }
    }

    void TrocarAtributos(PecaDeRoupa roupaAdd, PecaDeRoupa? roupaRemovida)
    {
        if(roupaRemovida == null)
        {
            ataque += roupaAdd.ataque;
            defesa += roupaAdd.defesa;
            conforto += roupaAdd.conforto;
            beleza += roupaAdd.beleza;
        }
        else
        {
            ataque += roupaAdd.ataque - roupaRemovida.ataque;
            defesa += roupaAdd.defesa - roupaRemovida.defesa;
            conforto += roupaAdd.conforto - roupaRemovida.conforto;
            beleza += roupaAdd.beleza - roupaRemovida.beleza;
        }
    }
}

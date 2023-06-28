using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public int dinheiro = 100;
    PecaDeRoupa? pecaCabeca = null;
    PecaDeRoupa? pecaTorso = null;
    PecaDeRoupa? pecaPernas = null;
    PecaDeRoupa? pecaPes = null;
    PecaDeRoupa? pecaMao = null;

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

    public void TrocarRoupa(GameObject roupa)
    {
        var roupaItem = roupa.GetComponent<RoupaBehavior>().roupaItem;
        var rtRoupa = roupa.GetComponent<RectTransform>();

        switch (roupaItem.tipo)
        {
            case PecaDeRoupa.Tipo.Cabeca:
                TrocarAtributos(roupaItem, pecaCabeca);
                pecaCabeca = roupaItem;
                break;
            case PecaDeRoupa.Tipo.Torso:
                TrocarAtributos(roupaItem, pecaTorso);
                pecaTorso = roupaItem;
                break;
            case PecaDeRoupa.Tipo.Pernas:
                TrocarAtributos(roupaItem, pecaPernas);
                pecaPernas = roupaItem;
                break;
            case PecaDeRoupa.Tipo.Pes:
                TrocarAtributos(roupaItem, pecaPes);
                pecaPes = roupaItem;
                break;
            case PecaDeRoupa.Tipo.Mao:
                TrocarAtributos(roupaItem, pecaMao);
                pecaMao = roupaItem;
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

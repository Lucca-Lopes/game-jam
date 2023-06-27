using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    int dinheiro = 100;
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

    public void AddRoupa(GameObject roupa)
    {
        var roupaItem = roupa.GetComponent<RoupaBehavior>().roupaItem;
        var rtRoupa = roupa.GetComponent<RectTransform>();

        switch (roupaItem.tipo)
        {
            case PecaDeRoupa.Tipo.Cabeca:
                pecaCabeca = roupaItem;
                rtRoupa.localPosition = new(0, 370, 0);
                break;
            case PecaDeRoupa.Tipo.Torso:
                pecaTorso = roupaItem;
                rtRoupa.localPosition = new(0, 70, 0);
                break;
            case PecaDeRoupa.Tipo.Pernas:
                pecaPernas = roupaItem;
                rtRoupa.localPosition = new(0, -120, 0);
                break;
            case PecaDeRoupa.Tipo.Pes:
                pecaPes = roupaItem;
                rtRoupa.localPosition = new(0, -300, 0);
                break;
            case PecaDeRoupa.Tipo.Mao:
                pecaMao = roupaItem;
                rtRoupa.localPosition = new(-160, -50, 0);
                break;
        }

        ataque =+ roupaItem.ataque;
        defesa =+ roupaItem.defesa;
        conforto =+ roupaItem.conforto;
        beleza =+ roupaItem.beleza;

        roupa.GetComponent<Button>().enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    double dinheiro = 0.0;
    PecaDeRoupa? pecaCabeca = null;
    PecaDeRoupa? pecaCorpo = null;
    PecaDeRoupa? pecaMao = null;

    public void AddRoupa(GameObject roupa)
    {
        var roupaItem = roupa.GetComponent<RoupaBehavior>().roupaItem;

        switch (roupaItem.tipo)
        {
            case PecaDeRoupa.Tipo.Cabeca:
                pecaCabeca = roupaItem;
                roupa.transform.position = new(0, 4, 0);
                break;
            case PecaDeRoupa.Tipo.Corpo:
                pecaCorpo = roupaItem;
                roupa.transform.position = new(0, 2, 0);
                break;
            case PecaDeRoupa.Tipo.Mao:
                pecaMao = roupaItem;
                roupa.transform.position = new(-2, -1, 0);
                break;
        }
        roupa.GetComponent<Button>().enabled = false;
    }
}

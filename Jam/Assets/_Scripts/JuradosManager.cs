using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuradosManager : MonoBehaviour
{
    public List<Jurado> juradosDisponiveis;
    [HideInInspector] public List<Jurado> juradosAtuais;

    [SerializeField] double modFavorito;
    [SerializeField] double modOdiado;
    [SerializeField] double modBonus;

    // Start is called before the first frame update
    void Start()
    {
        DefinirJurados();
    }

    public void DefinirJurados()
    {
        if (juradosDisponiveis.Count > 3)
        {
            var jurado1 = Random.Range(0, juradosDisponiveis.Count - 1);

            var jurado2 = jurado1;
            while(jurado2 == jurado1)
            {
                jurado2 = Random.Range(0, juradosDisponiveis.Count - 1);
            }

            var jurado3 = jurado1;
            while(jurado3 == jurado1 || jurado3 == jurado2)
            {
                jurado3 = Random.Range(0, juradosDisponiveis.Count - 1);
            }

            juradosAtuais.Add(juradosDisponiveis[jurado1]);
            juradosAtuais.Add(juradosDisponiveis[jurado2]);
            juradosAtuais.Add(juradosDisponiveis[jurado3]);
        }
        else
        {
            juradosAtuais = juradosDisponiveis;
        }
    }

    public void AtribuirPontuacao()
    {
        foreach(Jurado jurado in juradosAtuais)
        {
            if(VerificarMultiplicador(jurado.atributoFavorito))
                AplicarModificador(jurado.atributoFavorito, modFavorito + modBonus);
            else
                AplicarModificador(jurado.atributoFavorito, modFavorito);

            if (VerificarMultiplicador(jurado.atributoOdiado))
                AplicarModificador(jurado.atributoOdiado, modOdiado - modBonus);
            else
                AplicarModificador(jurado.atributoOdiado, modOdiado);
        }
        PlayerManager.Instance.CalcularPontuacaoFinal();
    }

    bool VerificarMultiplicador(Jurado.Atributos atributo)
    {
        var countAtaque = 0;
        var countDefesa = 0;
        var countConforto = 0;
        var countBeleza = 0;

        foreach (Jurado jurado in juradosAtuais)
        {
            switch (atributo)
            {
                case Jurado.Atributos.Ataque:
                    countAtaque++;
                    break;
                case Jurado.Atributos.Defesa:
                    countDefesa++;
                    break;
                case Jurado.Atributos.Conforto:
                    countConforto++;
                    break;
                case Jurado.Atributos.Beleza:
                    countBeleza++;
                    break;
            }
        }
        if (countAtaque > 2 || countDefesa > 2 || countConforto > 2 || countBeleza > 2)
            return true;
        else
            return false;
    }

    void AplicarModificador(Jurado.Atributos atributo, double modificador)
    {
        switch (atributo)
        {
            case Jurado.Atributos.Ataque:
                PlayerManager.Instance.ataque *= modificador;
                break;
            case Jurado.Atributos.Defesa:
                PlayerManager.Instance.defesa *= modificador;
                break;
            case Jurado.Atributos.Conforto:
                PlayerManager.Instance.conforto *= modificador;
                break;
            case Jurado.Atributos.Beleza:
                PlayerManager.Instance.beleza *= modificador;
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova peça de roupa", menuName = "Peça de roupa")]
public class PecaDeRoupa : ScriptableObject
{
    public enum Tipo
    {
        Cabeca,
        Corpo,
        Mao
    }

    public Tipo tipo;
    public Sprite sprite;
    public double custo;
    public int ataque;
    public int defesa;
    public int conforto;
    public int beleza;
    
}

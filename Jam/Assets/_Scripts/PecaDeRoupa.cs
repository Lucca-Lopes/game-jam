using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova peça de roupa", menuName = "Peça de roupa")]
public class PecaDeRoupa : ScriptableObject
{
    public enum Tipo
    {
        Cabeca,
        Torso,
        Pernas,
        Pes,
        Mao
    }

    public Tipo tipo;
    public Sprite sprite;
    public int custo;
    public int ataque;
    public int defesa;
    public int conforto;
    public int beleza;
    
}

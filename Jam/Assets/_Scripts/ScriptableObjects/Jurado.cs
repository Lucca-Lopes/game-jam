using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo jurado", menuName = "Jurado")]
public class Jurado : ScriptableObject
{
    public enum Atributos
    {
        Ataque,
        Defesa,
        Conforto,
        Beleza
    }

    public string nome;
    public Sprite sprite;
    public Sprite icon;
    public Atributos atributoFavorito;
    public Atributos atributoOdiado;
    public int pontosMinVitoria;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Todas as peças de roupas disponíveis no jogo")]
    [SerializeField] List<PecaDeRoupa> todasCabecas;
    [SerializeField] List<PecaDeRoupa> todasTorsos;
    [SerializeField] List<PecaDeRoupa> todasPernas;
    [SerializeField] List<PecaDeRoupa> todasPes;
    [SerializeField] List<PecaDeRoupa> todasMaos;

    [Header("Nomes possíveis para os oponentes")]
    [SerializeField] List<string> nomesOponentes;


    [Header("Managers")]
    [SerializeField] JuradosManager jm;
    [SerializeField] OponenteManager om;

    [Header("Lojas")]
    public GameObject[] GameObjectLojas;

    public void DefinirOponente()
    {
        //Definindo um nome para o oponente
        var indexNome = Random.Range(0, nomesOponentes.Count-1);
        var nomeOponente = this.nomesOponentes[indexNome];
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loja : MonoBehaviour
{
    [SerializeField]
    private PecaDeRoupa[] pecaDeRoupas;
    public GameObject Item;
    public Transform Grid;

    [Header("Item Selecionado")]
    public Sprite imgSelecionado;
    public Sprite imgSemSelecao;

    private void Start() {
        GerarItems();
    }

    public void Comprar(){
        //Item comprado
    }

    public void SelecionarItem(){
        //Mudar de item selecionado
    }

    public void GerarItems(){
        foreach(PecaDeRoupa pecaDeRoupa in pecaDeRoupas){
            Instantiate(Item, Grid);
            Item.GetComponent<Items>().AtualizarItem(pecaDeRoupa);
        }
    }
}

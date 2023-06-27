using UnityEngine;

public class Loja : MonoBehaviour
{
    [SerializeField]
    private PecaDeRoupa[] pecaDeRoupas;
    public GameObject[] Items;

    [Header("Instantiate Prefab")]
    public GameObject itemPrefab;
    public Transform Grid;

    [Header("Item Selecionado")]
    public Sprite imgSelecionado;
    private int itemSelecionado;

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
        for(int i = 0; i < pecaDeRoupas.Length; i++){
            Items[i] = Instantiate(itemPrefab, Grid);
            Items[i].GetComponent<Items>().AtualizarItem(pecaDeRoupas[i]);
        }
    }
}

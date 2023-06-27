using UnityEngine;

[System.Serializable]
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

    //Receber Index dos items selecionados
    public void SelecionarItem(int i){
        
        itemSelecionado = i;

        foreach(GameObject item in Items){
            if(item.GetComponent<Items>().Index != itemSelecionado){
                //Desativar outline
            }
        }
    }

    public void GerarItems(){
        for(int i = 0; i < pecaDeRoupas.Length; i++){
            Items[i] = Instantiate(itemPrefab, Grid);
            Items[i].GetComponent<Items>().AtualizarItem(pecaDeRoupas[i]);
            //Indexar cada Item na loja 
            Items[i].GetComponent<Items>().Index = i;
        }
    }
}

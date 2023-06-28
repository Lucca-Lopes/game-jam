using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Loja : MonoBehaviour
{
    [SerializeField]
    private PecaDeRoupa[] pecaDeRoupas;
    public GameObject[] _Items;
    public MenuAudioSystem audioSystem;
    public int LojaIndex;

    [Header("Instantiate Prefab")]
    public GameObject itemPrefab;
    public Transform Grid;

    [Header("Item Selecionado")]
    public int itemSelecionado = -1;

    [Header("Botao Comprar/Equipar")]
    public GameObject Comprar_GM;
    public GameObject Equipar_GM;
    public Button button;
    
 

    private void Start() {
        GerarItems();
    }

    

    //Receber Index dos items selecionados
    public void SelecionarItem(int i){
        
        itemSelecionado = i;

        foreach(GameObject item in _Items){
            if(item.GetComponent<Items>().Index != itemSelecionado){
                item.GetComponent<Items>().selecionado.sprite = item.GetComponent<Items>().normal;
            }
        }

    }

    public void BuyButtonUpdate(){
        if(ItemDescription.lojaAtual.itemSelecionado >= 0){
            if( ItemDescription.lojaAtual._Items[ItemDescription.lojaAtual.itemSelecionado].GetComponent<Items>().comprado){
                ItemDescription.lojaAtual.Comprar_GM.SetActive(false);
                ItemDescription.lojaAtual.Equipar_GM.SetActive(true);
                //Equipar
            }else{
                ItemDescription.lojaAtual.Comprar_GM.SetActive(true);
                ItemDescription.lojaAtual.Equipar_GM.SetActive(false);
                //Comprar
            }
        }
    }

    public void GerarItems(){
        for(int i = 0; i < pecaDeRoupas.Length; i++){
            _Items[i] = Instantiate(itemPrefab, Grid);
            _Items[i].GetComponent<Items>().AtualizarItem(pecaDeRoupas[i]);
            //Indexar cada Item na loja
            _Items[i].GetComponent<Items>().Index = i;
            _Items[i].GetComponent<Items>().lojaIndex = LojaIndex;

            _Items[i].GetComponent<Items>().button.onClick.AddListener(audioSystem.ButtonAudio2);
            _Items[i].GetComponent<Items>().button.onClick.AddListener(BuyButtonUpdate);
        }
    }
}

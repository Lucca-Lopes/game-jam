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
    public static int itemSelecionado = -1;

    [Header("Botao Comprar/Equipar")]
    public GameObject Comprar_GM;
    public GameObject Equipar_GM;
    public Button button;
 

    private void Start() {
        GerarItems();
    }

    public void BuyButton(){
        if( _Items[itemSelecionado].GetComponent<Items>().comprado){
            PlayerManager.Instance.TrocarRoupa(_Items[itemSelecionado].GetComponent<Items>().pecaDeRoupa);
        }else{
            if(PlayerManager.Instance.dinheiro >=  _Items[itemSelecionado].GetComponent<Items>().pecaDeRoupa.custo){
                audioSystem.Buy(true);
                _Items[itemSelecionado].GetComponent<Items>().comprado = true;
                BuyButtonUpdate();
            }else{
                audioSystem.Buy(false);
            }
        }
    }

    public void BuyButtonUpdate(){
        button.onClick.AddListener(BuyButton);
        if( _Items[itemSelecionado].GetComponent<Items>().comprado){
            Comprar_GM.SetActive(false);
            Equipar_GM.SetActive(true);
            //Equipar
        }else{
            Comprar_GM.SetActive(true);
            Equipar_GM.SetActive(false);
            //Comprar
        }
    }

    //Receber Index dos items selecionados
    public void SelecionarItem(int i){
        
        itemSelecionado = i;

        foreach(GameObject item in _Items){
            if(item.GetComponent<Items>().Index != itemSelecionado){
                item.GetComponent<Items>().selecionado.gameObject.SetActive(false);
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

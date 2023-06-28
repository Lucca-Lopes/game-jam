using UnityEngine;

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

 

    private void Start() {
        GerarItems();
    }

    public void Comprar(){
        if(PlayerManager.Instance.dinheiro > _Items[itemSelecionado].GetComponent<Items>().pecaDeRoupa.custo);
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
        }
    }
}

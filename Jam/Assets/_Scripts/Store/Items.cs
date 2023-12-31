using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Items : MonoBehaviour {
    public PecaDeRoupa pecaDeRoupa;
    public GameObject manager;
    public int Index;
    public int lojaIndex;
    
    [Header("Selecao")]
    public Sprite emSelecao;
    public Sprite normal;

    [Header("GameObjects")]
    public Image image;
    public Button button;
    public TMP_Text precoText;
    public Image selecionado;

    [Header("Purchase State")]
    
    public bool comprado = false;


    private void Awake() => manager = GameObject.Find("GameManager");

    public void AtualizarItem(PecaDeRoupa roupa){
        pecaDeRoupa = roupa;
        image.sprite = roupa.icon;
        precoText.text = roupa.custo.ToString();
    }

    //Devolver index para loja
    //Apenas Ler no botão
    public void ItemSelecionado(){
        //Pegar lista de lojas no game manager, depois pegar script loja e selecionar o item

        if(Index == 
        manager.GetComponent<GameManager>().GameObjectLojas[lojaIndex].GetComponent<Loja>().itemSelecionado){
            Debug.Log("Fechar");
            manager.GetComponent<GameManager>().GameObjectLojas[lojaIndex].GetComponent<Loja>().SelecionarItem(-1);
            manager.GetComponent<GameManager>().StatsWindow.SetActive(false);
            selecionado.sprite = normal;
            
        }else{
            Debug.Log("Abrir");
            manager.GetComponent<GameManager>().GameObjectLojas[lojaIndex].GetComponent<Loja>().SelecionarItem(Index);
            manager.GetComponent<GameManager>().StatsWindow.SetActive(true);
            selecionado.sprite = emSelecao;
        }
        

    }

}


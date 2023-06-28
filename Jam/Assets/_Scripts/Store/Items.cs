using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Items : MonoBehaviour {
    private PecaDeRoupa pecaDeRoupa;
    public GameObject manager;
    public int Index;
    public int lojaIndex;

    [Header("GameObjects")]
    public Image image;
    public TMP_Text precoText;
    public Image selecionado;

    private void Awake() => manager = GameObject.Find("GameManager");

    public void AtualizarItem(PecaDeRoupa roupa){
        image.sprite = roupa.sprite;
        precoText.text = roupa.custo.ToString();
    }

    //Devolver index para loja
    //Apenas Ler no botão
    public void ItemSelecionado(){
        //Pegar lista de lojas no game manager, depois pegar script loja e selecionar o item
        Debug.Log("teste");
        manager.GetComponent<GameManager>().GameObjectLojas[lojaIndex].GetComponent<Loja>().SelecionarItem(Index);
        selecionado.gameObject.SetActive(true);
    }

}

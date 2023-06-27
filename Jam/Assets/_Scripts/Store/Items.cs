using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Items : MonoBehaviour {
    private PecaDeRoupa pecaDeRoupa;
    public GameObject loja;
    public int Index;

    [Header("GameObjects")]
    public Image image;
    public TMP_Text precoText;
    public Image selecionado;

    private void Awake() => loja = GameObject.Find("Loja");

    public void AtualizarItem(PecaDeRoupa roupa){
        image.sprite = roupa.sprite;
        precoText.text = roupa.custo.ToString();
    }

    //Devolver index para loja
    //Apenas Ler no botão
    public void ItemSelecionado(){
        loja.GetComponent<Loja>().SelecionarItem(Index);
        selecionado.gameObject.SetActive(true);
    }

}

using TMPro;
using UnityEngine;

public class ItemDescription : MonoBehaviour {
    public TMP_Text nome;
    public TMP_Text meuAtaque;
    public TMP_Text ItemAtaque;
    public TMP_Text meudefesa;
    public TMP_Text itemDefesa;
    public TMP_Text meuConforto;
    public TMP_Text itemConforto;
    public TMP_Text meuBeleza;
    public TMP_Text itemBeleza;
    public TMP_Text BuyButtonText;
    public static Loja lojaAtual = new();

    public GameObject[] Lojas;

    public void Update(){
        meuAtaque.text = PlayerManager.Instance.ataque.ToString();
        meudefesa.text = PlayerManager.Instance.defesa.ToString();
        meuBeleza.text = PlayerManager.Instance.beleza.ToString();
        meuConforto.text = PlayerManager.Instance.conforto.ToString();

        foreach(GameObject loja in Lojas){
            if(loja.activeSelf){
                var lojaSC = loja.GetComponent<Loja>();
                lojaAtual = lojaSC;
                if(lojaSC.itemSelecionado >= 0){
                    PecaDeRoupa roupa = lojaSC._Items[lojaSC.itemSelecionado].GetComponent<Items>().pecaDeRoupa;

                    itemBeleza.text = "+" + lojaSC._Items[lojaSC.itemSelecionado].GetComponent<Items>().pecaDeRoupa.beleza.ToString();
                    itemConforto.text = "+" + lojaSC._Items[lojaSC.itemSelecionado].GetComponent<Items>().pecaDeRoupa.conforto.ToString();
                    itemDefesa.text = "+" + lojaSC._Items[lojaSC.itemSelecionado].GetComponent<Items>().pecaDeRoupa.defesa.ToString();
                    ItemAtaque.text = "+" + lojaSC._Items[lojaSC.itemSelecionado].GetComponent<Items>().pecaDeRoupa.ataque.ToString();
                    nome.text = roupa.nome;
                    BuyButtonText.text = roupa.custo.ToString();
                }
                
            }
        }
    }
}

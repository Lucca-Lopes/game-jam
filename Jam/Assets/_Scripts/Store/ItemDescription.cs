using TMPro;
using UnityEngine;

public class ItemDescription : MonoBehaviour {
    public TMP_Text nome;
    public TMP_Text ataque;
    public TMP_Text defesa;
    public TMP_Text conforto;
    public TMP_Text beleza;
    public TMP_Text BuyButtonText;
    public static Loja lojaAtual = new();

    public GameObject[] Lojas;

    public void Update(){
        foreach(GameObject loja in Lojas){
            if(loja.activeSelf){
                var lojaSC = loja.GetComponent<Loja>();
                lojaAtual = lojaSC;
                if(lojaSC.itemSelecionado >= 0){
                    PecaDeRoupa roupa = lojaSC._Items[lojaSC.itemSelecionado].GetComponent<Items>().pecaDeRoupa;
                    nome.text = roupa.nome;
                    BuyButtonText.text = roupa.custo.ToString();
                }
                
            }
        }
    }
}

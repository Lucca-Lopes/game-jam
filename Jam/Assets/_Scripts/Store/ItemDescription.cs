using TMPro;
using UnityEngine;

public class ItemDescription : MonoBehaviour {
    public TMP_Text nome;
    public TMP_Text ataque;
    public TMP_Text defesa;
    public TMP_Text conforto;
    public TMP_Text beleza;
    public GameManager gameManager;

    public GameObject[] Lojas;

    public void Update(){
        foreach(GameObject loja in Lojas){
            if(loja.activeSelf){
                PecaDeRoupa roupa = loja.GetComponent<Loja>()._Items[loja.GetComponent<Loja>().itemSelecionado].GetComponent<Items>().pecaDeRoupa;

                nome.text = roupa.nome;
            }
        }
    }
}

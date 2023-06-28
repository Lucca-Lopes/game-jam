using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LojaManager : MonoBehaviour {
    public LojaWindow[] lojas;
    public int lojaAtual = 0;
    public Button botao;
    public Button botaoSucessor;
    public TMP_Text nome;

    private void Start() {
        CheckWindow();
    }

    private void Update() {
    }

    private void CheckWindow() {
        botao.interactable = (lojaAtual > 0);
        botaoSucessor.interactable = (lojaAtual < lojas.Length - 1);
        nome.text = lojas[lojaAtual].nome;
    }

    public void MudarLoja(int i){
        lojas[lojaAtual].lojaGameobject.SetActive(false);
        lojaAtual += i;
        lojas[lojaAtual].lojaGameobject.SetActive(true);
        CheckWindow();
    }

    
    public void BuyButton(){
        if(ItemDescription.lojaAtual.itemSelecionado >= 0){
            if(ItemDescription.lojaAtual._Items[ItemDescription.lojaAtual.itemSelecionado].GetComponent<Items>().comprado){
                PlayerManager.Instance.TrocarRoupa(ItemDescription.lojaAtual._Items[ItemDescription.lojaAtual.itemSelecionado].GetComponent<Items>().pecaDeRoupa);
            }else{
                if(PlayerManager.Instance.dinheiro >=  ItemDescription.lojaAtual._Items[ItemDescription.lojaAtual.itemSelecionado].GetComponent<Items>().pecaDeRoupa.custo){
                    ItemDescription.lojaAtual.audioSystem.Buy(true);
                    ItemDescription.lojaAtual._Items[ItemDescription.lojaAtual.itemSelecionado].GetComponent<Items>().comprado = true;
                    PlayerManager.Instance.dinheiro -= ItemDescription.lojaAtual._Items[ItemDescription.lojaAtual.itemSelecionado].GetComponent<Items>().pecaDeRoupa.custo;
                    ItemDescription.lojaAtual.BuyButtonUpdate();
                }else{
                    ItemDescription.lojaAtual.audioSystem.Buy(false);
                }
            }
        }
    }

}

[System.Serializable]
public struct LojaWindow {
    public string nome;
    public GameObject lojaGameobject;
}

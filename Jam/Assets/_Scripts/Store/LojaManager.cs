using UnityEngine.UI;
using UnityEngine;

public class LojaManager : MonoBehaviour {
    public LojaWindow[] lojas;
    public int lojaAtual = 0;
    public Button botao;
    public Button botaoSucessor;


    private void Start() {
        CheckWindow();
    }

    private void CheckWindow() {
        botao.interactable = (lojaAtual > 0);
        botaoSucessor.interactable = (lojaAtual < lojas.Length - 1);
    }

    public void MudarLoja(int i){
        lojas[lojaAtual].lojaGameobject.SetActive(false);
        lojaAtual += i;
        lojas[lojaAtual].lojaGameobject.SetActive(true);
        CheckWindow();
    }

}

[System.Serializable]
public struct LojaWindow {
    public string nome;
    public int ordem;
    public GameObject lojaGameobject;
}

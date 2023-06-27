using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LojaManager : MonoBehaviour {
    public GameObject lojaAtual;
    public GameObject botaoAntecessor;
    public GameObject botaoSucessor;
    public GameObject[] lojas;

    public void Sucessor(GameObject loja){
        lojaAtual.SetActive(false);
        loja.SetActive(true);
        lojaAtual = loja;
    }

    public void Antecessor(GameObject loja){
        
    }
}

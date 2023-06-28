using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public GameObject MainMenu;
    public GameObject Store;
    [SerializeField] private GameObject JanelaAtual;
    public void OpenWindow(GameObject gameObject){
        JanelaAtual.SetActive(false);
        gameObject.SetActive(true);

        JanelaAtual = gameObject;
    }
}

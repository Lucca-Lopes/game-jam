using TMPro;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    public TMP_Text moedaText;
    private void Update() {
        AtualizarMoeda();
    }
    public void AtualizarMoeda(){
        moedaText.text = PlayerManager.Instance.dinheiro.ToString();
    }
}

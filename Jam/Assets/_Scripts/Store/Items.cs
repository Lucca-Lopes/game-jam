using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Items : MonoBehaviour {
    private PecaDeRoupa pecaDeRoupa;

    [Header("GameObjects")]
    public Image image;
    public TMP_Text precoText;

    public void AtualizarItem(PecaDeRoupa roupa){
        image.sprite = roupa.sprite;
        precoText.text = roupa.custo.ToString();
    }
}

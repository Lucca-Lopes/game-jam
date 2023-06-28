using UnityEngine.UI;
using UnityEngine;

public class JuradosUI : MonoBehaviour {
    public Image[] iconejurados;
    public JuradosManager juradosManager;


    public void Update(){
        for(int i = 0; i < iconejurados.Length; i++){
            Debug.Log(juradosManager.juradosAtuais[i].icon);
            iconejurados[i].sprite = juradosManager.juradosAtuais[i].icon;
        }
    }
}

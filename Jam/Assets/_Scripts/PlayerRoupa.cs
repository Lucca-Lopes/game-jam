using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRoupa : MonoBehaviour {
    public Image cabeca;
    public Image pernaT;
    public Image pes;
    public Image pernaF;
    public Image torso;
    public Image mao;

    private void Update() {
        if(PlayerManager.Instance.pecaCabeca != null)
            cabeca.sprite = PlayerManager.Instance.pecaCabeca.sprite;

        if(PlayerManager.Instance.pecaPernas != null)
            pernaF.sprite = PlayerManager.Instance.pecaPernas.sprite;

        if(PlayerManager.Instance.pecaPes != null)
            pes.sprite = PlayerManager.Instance.pecaPes.sprite;
            
        if(PlayerManager.Instance.pecaTorso != null)
            torso.sprite = PlayerManager.Instance.pecaTorso.sprite;

        if(PlayerManager.Instance.pecaMao != null)
            mao.sprite = PlayerManager.Instance.pecaMao.sprite;
    }
}

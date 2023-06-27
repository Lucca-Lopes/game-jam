using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoupaBehavior : MonoBehaviour
{
    public PecaDeRoupa roupaItem;

    private void Start()
    {
        var imageComponent = gameObject.GetComponent<Image>();
        imageComponent.sprite = roupaItem.sprite;
    }
}

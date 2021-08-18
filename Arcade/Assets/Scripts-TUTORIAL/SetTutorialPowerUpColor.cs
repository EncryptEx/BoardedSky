using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTutorialPowerUpColor : MonoBehaviour
{
    public Color c;
    void Start()
    {
        var prenderer = this.GetComponent<Renderer>();
        prenderer.material.SetColor("_Color",
            c);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Petal : MonoBehaviour
{
    public Colors color;

    public void SetColor(Colors color)
    {
        this.color = color;
        this.GetComponent<Renderer>().material.SetColor("_Color", new Color(ColorSound.colorRGB[color].x, ColorSound.colorRGB[color].y, ColorSound.colorRGB[color].z));
    }
}

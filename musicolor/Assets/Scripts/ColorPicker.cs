using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    // Color of the color picker
    public Colors color;
    // Start is called before the first frame update
    void Start()
    {
        // Get renderer of the color picker
        Renderer renderer = GetComponent<Renderer>();
        // Create the color from the colorRGB dictionary
        Color color = new Color(ColorSound.colorRGB[this.color].x, ColorSound.colorRGB[this.color].y, ColorSound.colorRGB[this.color].z);
        // Assign the color to the renderer
        renderer.material.SetColor("_Color", color);
    }

    public Colors GetColor()
    {
        return color;
    }
}

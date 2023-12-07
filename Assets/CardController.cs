using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private Color color;
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        color = renderer.color;
    }

    void OnMouseDown(){
        GameObject cubo = GameObject.Find("Cube");
        cubo.GetComponent<Renderer>().material.color=blendColor(cubo.GetComponent<Renderer>().material.color);
        GameObject cubo2 = GameObject.Find("Cube 2");
        cubo2.GetComponent<Renderer>().material.color=blendColor2(cubo.GetComponent<Renderer>().material.color);
    }

    private Color blendColor(Color cubeColor){
        Color ret = new Color(cubeColor.r*color.r, cubeColor.g*color.g, cubeColor.b*color.b); 
        Debug.Log(ret.ToString());
        return ret;
    }

    private Color blendColor2(Color cubeColor){
        Color ret = new Color((cubeColor.r+color.r)/2, (cubeColor.g+color.g)/2, (cubeColor.b+color.b)/2); 
        Debug.Log(ret.ToString());
        return ret;
    }
}

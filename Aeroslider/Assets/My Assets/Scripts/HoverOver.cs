using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOver : MonoBehaviour    {

    public Material HighlightMaterial;
    private Material savedMaterial;
    private GameObject curObj;
    

    // Start is called before the first frame update
    void Start()
    {
       // renderer.material.color = Color.white;
    }

    void OnMouseEnter()
    {
        //GetComponent<Renderer>().material.color = Color.blue;
        //savedMaterial = curObj.GetComponent<Renderer>().material;
        //curObj.GetComponent<Renderer>().material = HighlightMaterial;
    }

    void OnMouseExit()
    {
        //GetComponent<Renderer>().material.color = Color.white; 
       // curObj.GetComponent<Renderer>().material = savedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

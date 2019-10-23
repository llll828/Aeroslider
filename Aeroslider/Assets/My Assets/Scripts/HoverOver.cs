using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoverOver : MonoBehaviour    {

    public Material HighlightMaterial;
    private Material savedMaterial;
    private GameObject curObj;
    public bool isStart;
    public bool isExit;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.green;
        //savedMaterial = curObj.GetComponent<Renderer>().material;
        //curObj.GetComponent<Renderer>().material = HighlightMaterial;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white; 
        //curObj.GetComponent<Renderer>().material = savedMaterial;
    }
    void OnMouseUp()
    {
        if (isStart)
        {
            SceneManager.LoadScene("Scene_0");
        }
        if (isExit)
        {
            Application.Quit();
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}

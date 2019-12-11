using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuffinCOnter : MonoBehaviour
{
    public Text guffin;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        guffin.text = ("Guffins: " + PlayerInventory.guffinCount);
    }
}

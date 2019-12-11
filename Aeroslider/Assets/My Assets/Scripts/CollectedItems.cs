using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedItems : MonoBehaviour
{
    public Text coins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = ("Coins: " + PlayerInventory.coinCount);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public AudioSource soundPlayer;

    public AudioClip coinGet;
    public AudioClip guffinGet;

    [Range(0f, 1f)]
    public float coinVolume;

    [Range(0f, 1f)]
    public float guffinVolume;
    private void OnTriggerEnter(Collider objectCollided)
    {
        if (objectCollided.gameObject.tag == "Coin")
        {
            PlayerInventory.coinCount++;
            soundPlayer.PlayOneShot(coinGet, coinVolume);
            print("I have " + PlayerInventory.coinCount + " Coins!");
            Destroy(objectCollided.gameObject);
        }
        if (objectCollided.gameObject.tag == "Macguffin")
        {
            PlayerInventory.guffinCount++;
            soundPlayer.PlayOneShot(guffinGet, guffinVolume);
            print("I have " + PlayerInventory.guffinCount + " Macguffins!");
            Destroy(objectCollided.gameObject);
        }
    }
}
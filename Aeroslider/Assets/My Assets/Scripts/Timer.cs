using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public int time;
    public Text timeText;

    // Start is called before the first frame update
    private void Start()
    {
        UpdateTimeUI();
    }


    void UpdateTimeUI()
    {
        timeText.text = "Time Left: " + time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            SceneManager.LoadScene("TempEndScreen");
        }
    }
}

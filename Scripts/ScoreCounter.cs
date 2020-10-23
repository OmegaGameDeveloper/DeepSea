using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text teksnya;
    public float skor;
    public string stri;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        skor += (Time.deltaTime *Time.timeScale) * 10;
        stri = skor.ToString();
        teksnya.text = stri;
    }
}

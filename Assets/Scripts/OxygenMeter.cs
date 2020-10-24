using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenMeter : MonoBehaviour
{
    public Slider oxygenBar;
    public Oxygen playerOxygen;
    public GameObject player;

    private void Start()
    {
        playerOxygen = player.GetComponent<Oxygen>();
        oxygenBar = GetComponent<Slider>();
        oxygenBar.maxValue = playerOxygen.maxOxy;
        oxygenBar.value = playerOxygen.maxOxy;
    }

    public void SetOxygen(float o2)
    {
        oxygenBar.value = o2;
    }
}

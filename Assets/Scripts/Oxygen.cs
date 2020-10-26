using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour
{
    public float curOxy = 0;
    public float maxOxy = 100;

    public OxygenMeter oxyBar;

    int oxystage;

    // Start is called before the first frame update
    void Start()
    {
        oxystage = PlayerPrefs.GetInt("OxygenStage");
        if (oxystage == 0)
        {
            curOxy = 100f;
            maxOxy = 100f;
        }else if (oxystage == 1)
        {
            curOxy = 200f;
            maxOxy = 200f;
        }
        else if (oxystage == 2)
        {
            curOxy = 300f;
            maxOxy = 300f;
        }
        else if (oxystage == 3)
        {
            curOxy = 400f;
            maxOxy = 400f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        curOxy -= 1f * Time.unscaledDeltaTime;

        oxyBar.SetOxygen(curOxy);
    }
}

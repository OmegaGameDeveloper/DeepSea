using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waktu : MonoBehaviour
{

    public bool stop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StopKau()
    {
        stop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTerrain : MonoBehaviour
{
   
    public GameObject[] terrain;
    public float theTime;

    public bool spawn;




    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "SpawnKeun")
        {
            spawn = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        theTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Waktu = 26.9321;
        theTime += Time.deltaTime * Time.timeScale;
        if (theTime >= 25.89) {
            spawn = true;
        }
        if (spawn == true)
        {
            spawn = false;
            int maxterrain = terrain.Length;
            int saatini = UnityEngine.Random.Range(0, maxterrain);
            Instantiate(terrain[saatini], transform.position + (new Vector3(-85,-gameObject.transform.position.y,56.3f)), transform.rotation);
            theTime = 0;
        }
    }
}

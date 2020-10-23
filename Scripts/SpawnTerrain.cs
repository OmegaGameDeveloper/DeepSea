using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTerrain : MonoBehaviour
{
   
    public GameObject[] terrain;
   
  
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn == true)
        {
            spawn = false;
            int maxterrain = terrain.Length;
            int saatini = UnityEngine.Random.Range(0, maxterrain);
            Instantiate(terrain[saatini], transform.position + (new Vector3(-85,0,56.3f)), transform.rotation);
        }
    }
}

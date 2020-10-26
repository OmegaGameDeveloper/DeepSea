using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTerrain : MonoBehaviour
{
   
    public GameObject[] terrain;
    public float theTime;

    public bool spawnning;

    public Sepawner spawn;


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "SpawnKeun")
        {
            spawnning = true;
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
            spawnning = true;
        }
        if (spawnning == true)
        {
            if(spawn.zonab1 == true)
            {
                spawnning = false;
                int saatini = UnityEngine.Random.Range(0, 2);
                Instantiate(terrain[saatini], transform.position + (new Vector3(-85, -gameObject.transform.position.y, 56.3f)), transform.rotation);
                theTime = 0;
            }
            if (spawn.zonab2 == true)
            {
                spawnning = false;
                int saatini = UnityEngine.Random.Range(3, 4);
                Instantiate(terrain[saatini], transform.position + (new Vector3(-85, -gameObject.transform.position.y, 56.3f)), transform.rotation);
                theTime = 0;
            }
        }
    }
}

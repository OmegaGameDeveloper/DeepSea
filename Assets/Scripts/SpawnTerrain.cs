using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTerrain : MonoBehaviour
{
   
    public GameObject[] terrain;
    public float theTime;

    public bool spawnning;

    public  Sepawner spawn;
    public GameObject goSpawn;
    // Start is called before the first frame update
    void Start()
    {
        theTime = 0;
        goSpawn = GameObject.FindGameObjectWithTag("GameManager");
        spawn = goSpawn.GetComponent<Sepawner>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "SpawnKeun")
        {
            spawnning = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Waktu = 26.9321;
        //theTime += Time.deltaTime * Time.timeScale;
        //if (theTime >= 25.89) {
            //spawnning = true;
        //}
        if (spawnning == true)
        {
            if(spawn.zonab1 == true)
            {
                spawnning = false;
                int saatini = UnityEngine.Random.Range(0, 1);
                Quaternion rotation = Quaternion.Euler(0, 0, 0);
                Instantiate(terrain[saatini], transform.position + (new Vector3(0, -gameObject.transform.position.y, 56.3f)), rotation);
                theTime = 0;
            }
            if (spawn.zonab2 == true)
            {
                spawnning = false;
                int saatini = UnityEngine.Random.Range(2, 3);
                Quaternion rotation = Quaternion.Euler(0, 0, 0);
                Instantiate(terrain[saatini], transform.position + (new Vector3(0, -gameObject.transform.position.y, 56.3f)), rotation);
                theTime = 0;
            }
        }
    }
}

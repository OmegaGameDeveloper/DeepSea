
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sepawner : MonoBehaviour
{

    public GameObject[] enemy1,enemy2,enemy3,powerup,spawnAble;
    
    public Transform[] lokasi;
    
    public string zoneName;

    public int maxsizeenemy1, maxsizeenemy2, maxsizeenemy3;

    public int iEnemy,iLocation,iPowerup,iSpawnning,maxsizepowerup,maxsizeloc;

    public float batchsize, waitTime, lastspawntime, resettime, timenow;
    public bool doneStatus,pausedState,awalstate,delayState,takePhoto;

    public bool zonab1, zonab2, zonab3;

    public List<GameObject> myList;

    public List<GameObject> zona1, zona2, zona3;

    public Oxygen oxygenState;
    public OxygenMeter oxygenMeter;
    public float oxygenSekarang;
    // Start is called before the first frame update
    void Start()
    {
        awalstate = true;
        maxsizepowerup = powerup.Length;
        maxsizeenemy1 = enemy1.Length;
        maxsizeloc = lokasi.Length;
        batchsize = Random.Range(10, 40);
        batchsize = (batchsize * 10) / 100;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (oxygenState.curOxy / oxygenState.maxOxy <= 0.1f && (!pausedState || takePhoto) && !delayState)
        {
            StartCoroutine(SpawnOxygen());
        }

        if (zonab1)
        {
            zoneName = "Epipelagic";
            if (!delayState && (!pausedState || takePhoto))
            {
                StartCoroutine(Spawnning1());
            }

            if (pausedState || takePhoto)
            {
                StopCoroutine(Spawnning1());
            }
            StopCoroutine(Spawnning2());
            StopCoroutine(Spawnning3());
        }
        else if (zonab2)
        {
            zoneName = "Mesopelagic";
            if (!delayState && (!pausedState || takePhoto))
            {
                StartCoroutine(Spawnning2());
            }

            if (pausedState || takePhoto)
            {
                StopCoroutine(Spawnning2());
            }
            StopCoroutine(Spawnning1());
            StopCoroutine(Spawnning3());
        }
        else if (zonab3)
        {
            zoneName = "Bathypelagic";
            if (!delayState && (!pausedState || takePhoto))
            {
                StartCoroutine(Spawnning3());
            }

            if (pausedState || takePhoto)
            {
                StopCoroutine(Spawnning3());
            }
            StopCoroutine(Spawnning1());
            StopCoroutine(Spawnning2());
        }
        else
        {
            StopCoroutine(Spawnning1());
            StopCoroutine(Spawnning2());
            StopCoroutine(Spawnning3());
        }
    }

    public IEnumerator Spawnning1() 
    {
        delayState = true;
        iSpawnning = Random.Range(0, maxsizeenemy1 + 1);

        iPowerup = Random.Range(0, maxsizepowerup);
        iEnemy = Random.Range(0, maxsizeenemy1);
        iLocation = Random.Range(0, maxsizeloc);


        Vector3 posx = lokasi[iLocation].transform.position;
        Quaternion rotation = lokasi[iLocation].transform.rotation;

        zona1 = enemy1.ToList();
        zona1.Add(powerup[iPowerup]);
        spawnAble = zona1.ToArray();

        Instantiate(spawnAble[iSpawnning], posx, rotation);

        yield return new WaitForSeconds(batchsize);
        batchsize = Random.Range(10, 40);
        batchsize = (batchsize * 10) / 100;

        zona1.Clear();

        delayState = false;
    }

    public IEnumerator Spawnning2()
    {
        delayState = true;
        iSpawnning = Random.Range(0, maxsizeenemy2 + 1);

        iPowerup = Random.Range(0, maxsizepowerup);
        iEnemy = Random.Range(0, maxsizeenemy2);
        iLocation = Random.Range(0, maxsizeloc);


        Vector3 posx = lokasi[iLocation].transform.position;
        Quaternion rotation = lokasi[iLocation].transform.rotation;

        zona2 = enemy2.ToList();
        zona2.Add(powerup[iPowerup]);
        spawnAble = zona2.ToArray();

        Instantiate(spawnAble[iSpawnning], posx, rotation);

        yield return new WaitForSeconds(batchsize);
        batchsize = Random.Range(10, 40);
        batchsize = (batchsize * 10) / 100;

        zona2.Clear();

        delayState = false;
    }
    public IEnumerator Spawnning3()
    {
        delayState = true;
        iSpawnning = Random.Range(0, maxsizeenemy3 + 1);

        iPowerup = Random.Range(0, maxsizepowerup);
        iEnemy = Random.Range(0, maxsizeenemy3);
        iLocation = Random.Range(0, maxsizeloc);


        Vector3 posx = lokasi[iLocation].transform.position;
        Quaternion rotation = lokasi[iLocation].transform.rotation;

        zona3 = enemy3.ToList();
        zona3.Add(powerup[iPowerup]);
        spawnAble = zona3.ToArray();

        Instantiate(spawnAble[iSpawnning], posx, rotation);

        yield return new WaitForSeconds(batchsize);
        batchsize = Random.Range(10, 40);
        batchsize = (batchsize * 10) / 100;

        zona3.Clear();

        delayState = false;
    }
    IEnumerator SpawnOxygen()
    {
        delayState = true;
        iLocation = Random.Range(0, maxsizeloc);
        Vector3 posx = lokasi[iLocation].transform.position;
        Quaternion rotation = lokasi[iLocation].transform.rotation;
        Instantiate(powerup[2], posx, rotation);
        Debug.Log("Oxygen!");
        yield return new WaitForSeconds(batchsize);
        batchsize = Random.Range(10, 40);
        batchsize = (batchsize * 10) / 100;
        delayState = false;
    }
}


using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sepawner : MonoBehaviour
{

    public GameObject[] enemy,powerup,spawnAble;
    public Transform[] lokasi;

    public int iEnemy,iLocation,iPowerup,iSpawnning,maxsizeenemy,maxsizepowerup,maxsizeloc;

    public float batchsize, waitTime, lastspawntime, resettime, timenow;
    public bool doneStatus,pausedState,awalstate,delayState;

    public List<GameObject> myList;



    // Start is called before the first frame update
    void Start()
    {
        awalstate = true;
        maxsizepowerup = powerup.Length;
        maxsizeenemy = enemy.Length;
        maxsizeloc = lokasi.Length;
        batchsize = Random.Range(10, 40);
        batchsize = (batchsize * 10) / 100;


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!delayState)
        {
            StartCoroutine(Spawnning());
        }

        if (!pausedState){
            
        }else{
            //StopCoroutine(Spawnning());            
        }
        if (doneStatus)
        {
        }    
    }

    void Check()
    {
        

    }

    public IEnumerator Spawnning() 
    {
        delayState = true;
        iSpawnning = Random.Range(0, maxsizeenemy + 1);

        iPowerup = Random.Range(0, maxsizepowerup);
        iEnemy = Random.Range(0, maxsizeenemy);
        iLocation = Random.Range(0, maxsizeloc);


        Vector3 posx = lokasi[iLocation].transform.position;
        Quaternion rotation = lokasi[iLocation].transform.rotation;

        myList = enemy.ToList();
        myList.Add(powerup[iPowerup]);
        spawnAble = myList.ToArray();

        Instantiate(spawnAble[iSpawnning], posx, rotation);

        yield return new WaitForSeconds(batchsize);
        batchsize = Random.Range(10, 40);
        batchsize = (batchsize * 10) / 100;

        myList.Clear();

        delayState = false;
    }
}

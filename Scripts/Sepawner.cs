using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sepawner : MonoBehaviour
{

    public GameObject[] go;
    public Transform[] lokasi;

    public int i,x,maxsizego,maxsizeloc;

    public float batchsize, waitTime, lastspawntime, resettime, timenow;
    public bool doneStatus,pausedState,awalstate,delayState;

    // Start is called before the first frame update
    void Start()
    {
        awalstate = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (awalstate)
        {
            StartCoroutine(LaunchObstacle());
        }
        else
        {
            StopCoroutine(LaunchObstacle());
        }

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

    IEnumerator Spawnning() 
    {
        delayState = true;
        maxsizego = go.Length;
        maxsizeloc = lokasi.Length;
        i = Random.Range(0, maxsizego);
        x = Random.Range(0, maxsizeloc);
        Vector3 posx = lokasi[x].transform.position;
        Quaternion rotation = lokasi[x].transform.rotation;
        Instantiate(go[i], posx, rotation);
        yield return new WaitForSeconds(batchsize);
        batchsize = Random.Range(10, 40);
        batchsize = (batchsize * 10) / 100;
        delayState = false;
    }

    IEnumerator LaunchObstacle()
    {
        maxsizego = go.Length;
        maxsizeloc = lokasi.Length;
        i = Random.Range(0, maxsizego);
        x = Random.Range(0, maxsizeloc);
        Vector3 posx = lokasi[x].transform.position;
        Quaternion rotation = lokasi[x].transform.rotation;
        Instantiate(go[i], posx,rotation);
        batchsize = Random.Range(10, 40);
        batchsize = (batchsize * 10) / 100;
        awalstate = false;
        yield break;
    }
}

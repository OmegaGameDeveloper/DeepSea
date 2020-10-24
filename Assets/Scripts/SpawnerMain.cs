using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMain : MonoBehaviour
{
    public GameObject go;
    public Transform[] lokasi;
    public Transform lokasiLari;

    public int x, maxsizeloc;

    public float batchsize, waitTime, lastspawntime, resettime, timenow;
    public bool doneStatus, pausedState, awalstate, delayState;

    public Animator anims;

    // Start is called before the first frame update
    void Start()
    {
        awalstate = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!delayState)
        {
            StartCoroutine(Spawnning());
            StopCoroutine(Waiting());
            StopCoroutine(AttacK());
        }
        else
        {
            StartCoroutine(Waiting());
            StopCoroutine(Spawnning());
            StopCoroutine(AttacK());
        }

        if (!pausedState)
        {

        }
        else
        {
            //StopCoroutine(Spawnning());            
        }
        if (doneStatus)
        {
            StartCoroutine(AttacK());
            StopCoroutine(Waiting());
            StopCoroutine(Spawnning());

        }
        else
        {
            StartCoroutine(Spawnning());
            StopCoroutine(Waiting());
            StopCoroutine(AttacK());
        }
    }

    IEnumerator AttacK()
    {
        doneStatus = false;
        Instantiate(go, lokasiLari);
        yield break;
    }

    IEnumerator Waiting()
    {
        delayState = true;
        waitTime = Random.Range(1, 3);
        yield return new WaitForSeconds(waitTime);
        delayState = false;
    }


    IEnumerator Spawnning()
    {
        delayState = true;
        maxsizeloc = lokasi.Length;
        x = Random.Range(0, maxsizeloc);
        Vector3 posx = lokasi[x].transform.position;
        Quaternion rotation = lokasi[x].transform.rotation;
        Instantiate(go, posx, rotation);
        yield return new WaitForSeconds(batchsize);
        batchsize = Random.Range(10, 30);
        batchsize = (batchsize * 10) / 100;
        doneStatus = true;
    }
}

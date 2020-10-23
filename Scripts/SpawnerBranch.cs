using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBranch : MonoBehaviour
{

    public bool tersedia,spawnb;
    RaycastHit hit;
    public float Reach;
    public GameObject gelo;
    Sepawner sepawn;
    // Start is called before the first frame update
    void Start()
    {
        sepawn = gelo.GetComponent<Sepawner>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.localPosition, fwd * Reach, Color.red);

        if (Physics.Raycast(transform.position, fwd, out hit, Reach))
        {
            if (hit.collider.tag == "Ground")
            {
                tersedia = false;
            }
        }
        else
        {
            tersedia = true;
        }

        if (spawnb)
        {
            Debug.Log("Spawn!"+sepawn.i);
        }
        else
        {
            Debug.Log("Stop!");
        }

        if (tersedia)
        {
            Debug.Log("Tersedia");
        }
        else
        {
            Debug.Log("Tidak Tersedia");
        }
        }

    }

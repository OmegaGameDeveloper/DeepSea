using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AktivasiPenghancur : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "SpawnKeun")
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}

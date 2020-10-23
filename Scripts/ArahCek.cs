using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArahCek : MonoBehaviour
{
    public GameObject go;
    //Raycast Reach
    public float Reach;

    RaycastHit hit;

    AutoPilot ap;

    // Start is called before the first frame update
    void Start()
    {
        ap = go.GetComponent<AutoPilot>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        //Debug Raycast As Shown On The Scene Screen
        Debug.DrawRay(transform.localPosition, fwd * Reach, Color.red);

        if (Physics.Raycast(transform.position, fwd, out hit, Reach))
        {
            if (hit.collider.tag == "Enemy")
            {
                if (gameObject.name == "Atas")
                {
                    ap.availatas = false;
                    ap.availtengah = true;
                    ap.availbawah = true;
                }
                if (gameObject.name == "Bawah")
                {
                    ap.availbawah = false;
                    ap.availatas = true;
                    ap.availtengah = true;
                }
                if (gameObject.name == "Tengah")
                {
                    ap.availtengah = false;
                    ap.availbawah = true;
                    ap.availatas = true;
                }
            }
        }
    }
}

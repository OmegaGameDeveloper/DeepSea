using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPilot : MonoBehaviour
{
    public float speed,Reach,jarakk,step,waktunya;
    public bool nabrakkiri, nabrakkanan, nabrakatas, nabrakbawah,kosong,simple;
    //public Transform tengah;
    public bool musuhlewat;
    //koordinatpergerakan
    public Transform  bawah, atas, tengah;


    //status arah pergerakan
    public bool bawahb, atasb,tengahb;
    //status ketersediaan arah
    public bool availatas, availbawah, availtengah;

    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime*Time.timeScale;
        //jikaditengah,baca arah yang available

        if (atasb)
        {
            transform.position = Vector3.MoveTowards(transform.position, atas.position, step);
        }
        if (bawahb)
        {
            transform.position = Vector3.MoveTowards(transform.position, bawah.position, step);
        }
       
        if (tengahb)
        {
            transform.position = Vector3.MoveTowards(transform.position, tengah.position, step);
        }

        if (!availatas)
        {
            bawahb = true;
        }
        else
        {
            bawahb = false;
        }
        
        if (!availbawah)
        {
            atasb = true;
        }
        else
        {
            atasb = false;
        }
        
        if(!availatas&& !availbawah)
        {
            tengahb = true;
        }
        else
        {
            tengahb = false;
        }
        
        if (!availtengah)
        {
            if (!availatas)
            {
                bawahb = true;
            }
            else if (!availbawah)
            {
                atasb = true;
            }
        }
        else
        {
            if (availatas)
            {
                bawahb = false;
            }
            else if (availbawah)
            {
                atasb = false;
            }

        }
    }
}

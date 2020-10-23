using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swaipus : MonoBehaviour
{
    //versi 9 kordinat


    public Vector2 vecawal,vecakhir;
    public float startTime, endTime,swipeTime;
    public Vector2 swipeDistance;
    public float speed;

    //koordinatpergerakan
    public Transform kanan, kiri, bawah, atas,tengah,ataskanan,ataskiri,bawahkanan,bawahkiri;
    

    //status arah pergerakan
    public bool kananb, kirib, bawahb, atasb,ataskananb,ataskirib,bawahkirib,bawahkananb,tengahb,awal;
    //status tag arah
    public bool atasn, bawahn, kirin, kanann, ataskanann, ataskirin, bawahkanann, bawahkirin,tengahn;
    //status arah yang available
    public bool kananbb, kiribb, bawahbb, atasbb, ataskananbb, ataskiribb, bawahkiribb, bawahkananbb, tengahbb;

    public bool autonya;
    public AutoPilot autopilotnya;

    // Start is called before the first frame update
    void Start()
    {
        autonya = false;
        autopilotnya = GetComponent<AutoPilot>();
    
    }

    public void Auto()
    {
        autonya = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Kanan")
        {
            kanann = true;
            kirin = false;
            bawahn = false;
            atasn = false;
            ataskirin = false;
            ataskanann = false;
            bawahkanann = false;
            bawahkirin = false;
            
            tengahn = false;
            
        }
        if (other.tag == "Kiri")
        {
            kanann = false;
            kirin = true;
            bawahn = false;
            atasn = false;
            ataskirin = false;
            ataskanann = false;
            bawahkanann = false;
            bawahkirin = false;
            tengahn = false;
           
            
        }
        if (other.tag == "Atas")
        {
            kanann = false;
            kirin = false;
            bawahn = false;
            atasn = true;
            ataskirin = false;
            ataskanann = false;
            bawahkanann = false;
            bawahkirin = false;
            tengahn = false;
            
          
        }
        if (other.tag == "Bawah")
        {
            kanann = false;
            kirin = false;
            bawahn = true;
            atasn = false;
            ataskirin = false;
            ataskanann = false;
            bawahkanann = false;
            bawahkirin = false;
            tengahn = false;
            
           
        }
        if (other.tag == "Atas Kanan")
        {
            kanann = false;
            kirin = false;
            bawahn = false;
            atasn = false;
            ataskirin = false;
            ataskanann = true;
            bawahkanann = false;
            bawahkirin = false;
            tengahn = false;
            
          
        }
        if (other.tag == "Atas Kiri")
        {
            kanann = false;
            kirin = false;
            bawahn = false;
            atasn = false;
            ataskirin = true;
            ataskanann = false;
            bawahkanann = false;
            bawahkirin = false;
            tengahn = false;
            
            
        }
        if (other.tag == "Bawah Kanan")
        {
            kanann = false;
            kirin = false;
            bawahn = false;
            atasn = false;
            ataskirin = false;
            ataskanann = false;
            bawahkanann = true;
            bawahkirin = false;
            tengahn = false;
            
           
        }
        if (other.tag == "Bawah Kiri")
        {
            kanann = false;
            kirin = false;
            bawahn = false;
            atasn = false;
            ataskirin = false;
            ataskanann = false;
            bawahkanann = false;
            bawahkirin = true;
            tengahn = false;
           
           
        }
        if (other.tag == "Tengah")
        {
            kanann = false;
            kirin = false;
            bawahn = false;
            atasn = false;
            ataskirin = false;
            ataskanann = false;
            bawahkanann = false;
            bawahkirin = false;
            tengahn = true;
            autopilotnya.musuhlewat = false;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (autonya)
        {
            autopilotnya.enabled = true;
        }
        else
        {
            autopilotnya.enabled = false;
        }

        float step = speed * Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            vecawal = Input.mousePosition;
            startTime = Time.time;   // Storing start time
        }
        if (Input.GetMouseButtonUp(0)) {
           
            endTime = Time.time;
            vecakhir = Input.mousePosition;

            
            swipeTime = endTime - startTime;

            if (swipeTime < 3f)
            {
                Swipes();
            }
        }
        if (kananb) {
            transform.position = Vector3.MoveTowards(transform.position, kanan.position, step);
        }
        if (kirib) {
            transform.position = Vector3.MoveTowards(transform.position, kiri.position, step);
        }

        if (atasb)
        {
            transform.position = Vector3.MoveTowards(transform.position, atas.position, step);
        }
        if (bawahb)
        {
            transform.position = Vector3.MoveTowards(transform.position, bawah.position, step);
        }
        if (ataskananb)
        {
            transform.position = Vector3.MoveTowards(transform.position, ataskanan.position, step);
        }
        if (bawahkananb)
        {
            transform.position = Vector3.MoveTowards(transform.position, bawahkanan.position, step);
        }
        if (ataskirib)
        {
            transform.position = Vector3.MoveTowards(transform.position, ataskiri.position, step);
        }
        if (bawahkirib)
        {
            transform.position = Vector3.MoveTowards(transform.position, bawahkiri.position, step);
        }
        if (tengahb)
        {
            transform.position = Vector3.MoveTowards(transform.position, tengah.position, step);
        }
    }

    void Swipes() {

        swipeDistance = vecakhir - vecawal;
        if (Mathf.Abs(swipeDistance.x) > Mathf.Abs(swipeDistance.y))
        {
            //kanan-kiri
            if (kanann) {
                if (swipeDistance.x < 0)
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = true;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                    ataskirin = false;
                    ataskanann = false;
                    bawahkanann = false;
                    bawahkirin = false;
                }
                else
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    awal = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
            }
            if (kirin)
            {
                if (swipeDistance.x > 0)
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = true;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
                else
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
            }

            if (atasn)
            {
                if (swipeDistance.x < 0)
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = true;
                    bawahkirib = false;
                }
                else
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    awal = false;
                    ataskananb = true;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
            }
            if (bawahn)
            {
                if (swipeDistance.x < 0)
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = true;
                }
                else
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    awal = false;
                    ataskananb = false;
                    bawahkananb = true;
                    ataskirib = false;
                    bawahkirib = false;
                }
            }


            if (ataskanann)
            {
                if (swipeDistance.x < 0)
                {
                    kananb = false;
                    kirib = false;
                    atasb = true;
                    bawahb = false;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
                else
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    awal = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
            }
            if (ataskirin)
            {
                if (swipeDistance.x > 0)
                {
                    kananb = false;
                    kirib = false;
                    atasb = true;
                    bawahb = false;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
                else
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    awal = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
            }
            if (bawahkanann)
            {
                if (swipeDistance.x < 0)
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = true;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
                else
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    awal = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
            }
            if (bawahkirin)
            {
                if (swipeDistance.x > 0)
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = true;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
                else
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    awal = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
            }
            
            if (tengahn) {
                if (swipeDistance.x < 0)
                {
                    kananb = false;
                    kirib = true;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
                else
                {
                    kananb = true;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    awal = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
            }
        }
        else if (Mathf.Abs(swipeDistance.x) < Mathf.Abs(swipeDistance.y))
        {
            //atas-bawah
            if (atasn)
            {
                if (swipeDistance.y < 0)
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = true;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                    ataskirin = false;
                    ataskanann = false;
                    bawahkanann = false;
                    bawahkirin = false;
                }
                else
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    awal = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
            }
            if (bawahn)
            {
                if (swipeDistance.y > 0)
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = true;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
                else
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
            }
            if (tengahn)
            {
                if (swipeDistance.y < 0)
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = true;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
                else
                {
                    kananb = false ;
                    kirib = false;
                    atasb = true;
                    bawahb = false;
                    tengahb = false;
                    awal = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
            }
            if (kanann)
            {
                if (swipeDistance.y < 0)
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = true;
                    ataskirib = false;
                    bawahkirib = false;
                    ataskirin = false;
                    ataskanann = false;
                    bawahkanann = false;
                    bawahkirin = false;
                }
                else
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    awal = false;
                    ataskananb = true;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
            }
            if (kirin)
            {
                if (swipeDistance.y > 0)
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = true;
                    bawahkirib = false;
                }
                else
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = true;
                }
            }
            if (ataskanann)
            {
                if (swipeDistance.y > 0)
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
                else
                {
                    kananb = true;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
            }
            if (bawahkanann)
            {
                if (swipeDistance.y > 0)
                {
                    kananb = true;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
                else
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
            }
            if (bawahkirin)
            {
                if (swipeDistance.y > 0)
                {
                    kananb = false;
                    kirib = true;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
                else
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
            }
            if (ataskirin)
            {
                if (swipeDistance.y > 0)
                {
                    kananb = false;
                    kirib = false;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
                else
                {
                    kananb = false;
                    kirib = true;
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                    ataskananb = false;
                    bawahkananb = false;
                    ataskirib = false;
                    bawahkirib = false;
                }
            }
        }
        if (swipeDistance.y < 0 && swipeDistance.x <0) {
            Debug.Log("Kiri Bawah");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swaip : MonoBehaviour
{
    //versi 3 kordinat

    public Vector2 vecAwal,vecAkhir;
    public float startTime, endTime,swipeTime;
    public Vector2 swipeDistance;
    public float speed;

    //koordinatpergerakan
    public Transform  bawah, atas,tengah;
    
    //status arah pergerakan
    public bool bawahb, atasb ,tengahb;
    //status tag arah
    public bool atasn, bawahn,tengahn;
    //status arah yang available
    public bool  bawahbb, atasbb,  tengahbb;

    public bool autonya;
    public AutoPilot autopilotnya;

    public Animator animator;

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
        if (other.tag == "Atas")
        {
           
            bawahn = false;
            atasn = true;
            
            tengahn = false;
            
          
        }
        if (other.tag == "Bawah")
        {
           
            bawahn = true;
            atasn = false;
          
            tengahn = false;
            
           
        }
      
        if (other.tag == "Tengah")
        {
           
            bawahn = false;
            atasn = false;
           
            tengahn = true;
            autopilotnya.musuhlewat = false;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Naik"))
        {
            animator.SetBool("Naik", false);

        }

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Turun"))
        {
            animator.SetBool("Turun", false);

        }

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
            vecAwal = Input.mousePosition;
            startTime = Time.time;   // Storing start time
        }
        if (Input.GetMouseButtonUp(0)) {
           
            endTime = Time.time;
            vecAkhir = Input.mousePosition;

            
            swipeTime = endTime - startTime;

            if (swipeTime < 3f)
            {
                Swipes();
            }
        }
       
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
    }

    void Swipes() {

        swipeDistance = vecAkhir - vecAwal;
        if (Mathf.Abs(swipeDistance.x) < Mathf.Abs(swipeDistance.y))
        {
            //atas-bawah
            if (atasn)
            {
                if (swipeDistance.y < 0)
                {
                   
                    atasb = false;
                    bawahb = false;
                    tengahb = true;
                    animator.SetBool("Turun", true);                   
                }
                else
                {
                   
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                }
            }
            if (bawahn)
            {
                if (swipeDistance.y > 0)
                {                   
                    atasb = false;
                    bawahb = false;
                    tengahb = true;
                    animator.SetBool("Naik", true);
                }
                else
                {
                   
                    atasb = false;
                    bawahb = false;
                    tengahb = false;
                }
            }
            if (tengahn)
            {
                if (swipeDistance.y < 0)
                {                    
                    atasb = false;
                    bawahb = true;
                    tengahb = false;
                    animator.SetBool("Turun", true);
                }
                else
                {
                    animator.SetBool("Naik", true);
                    atasb = true;
                    bawahb = false;
                    tengahb = false;
                   
                }
            }
            
        }
        
    }
}

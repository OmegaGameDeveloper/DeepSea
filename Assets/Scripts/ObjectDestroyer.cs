using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Boss" || collision.collider.tag=="BossInvincible")
        {

        }else if (collision.collider.tag == "Ground")
        {

        }
        else
        {
            Destroy(collision.collider.gameObject);
        }  
    }
}

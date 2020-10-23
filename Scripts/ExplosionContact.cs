using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionContact : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public float timer,timerawal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 position = contact.point;
            Instantiate(explosionParticle, position, rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
        }
        if (collision.gameObject.tag == "Boss")
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.unscaledDeltaTime;
        if (timer <= 0)
        {
            timer = timerawal;
            Destroy(gameObject);
        }
    }
}

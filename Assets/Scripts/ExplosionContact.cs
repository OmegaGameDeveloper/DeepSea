using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionContact : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public float timer,timerawal;
    DarahBoss darahBoss;
    GameObject entityBoss;
    // Start is called before the first frame update
    void Start()
    {
        darahBoss = GetComponent<DarahBoss>();
        AudioSource audio1 = GetComponent<AudioSource>();
        audio1.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Enemy" || collision.gameObject.tag =="Boss")
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 position = contact.point;
            Instantiate(explosionParticle, position, rotation);
            AudioSource audio = collision.collider.GetComponent<AudioSource>();
            audio.Play();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
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

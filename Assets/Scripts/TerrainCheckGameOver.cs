using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCheckGameOver : MonoBehaviour
{

    public CollisionManager collisionManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (transform.gameObject.tag == "Player")
            {
                collisionManager.kenagakya = true;
                collisionManager.animl.SetBool("GameOver", true);
                Debug.Log("Tanah!");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarahBoss : MonoBehaviour
{
    public int darah = 100;
    public bool mati,damaged;
    public GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Damage(int hajar)
    {
        darah = darah - hajar;
        damaged = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (darah == 0)
        {
            mati = true;
        }
        if (damaged)
        {
            gameObject.tag = "BossInvincible";
            damaged = false;
        }

        if (mati)
        {
            gameState.isBossDead = true;
            gameObject.SetActive(false);
        }

    }
}

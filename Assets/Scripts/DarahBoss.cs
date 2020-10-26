using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DarahBoss : MonoBehaviour
{
    public int maxDarah = 100;
    public int darah = 0;
    public int kaboomStage;
    public bool mati,damaged;
    public GameState gameState;

    public Slider healthBar;
    public Material material1;
    public Material material2;
    float duration = 0.2f;
    public Renderer rend;
    public Sepawner spawn;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = maxDarah;
        healthBar.value = maxDarah;
        darah = maxDarah;
        rend.material = material1;
        kaboomStage = PlayerPrefs.GetInt("KaboomStage",0);
    }

    public void Damage(int hajar)
    {
        darah = darah - hajar;
        healthBar.value = darah;
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
            healthBar.maxValue = maxDarah;
            healthBar.value = maxDarah;
            darah = maxDarah;
            gameObject.SetActive(false);
            
            if (gameObject.name == "Plesio")
            {
                spawn.zonab2 = true;
                spawn.zonab1 = false;
                spawn.zonab3 = false;
            }
            if (gameObject.name == "Morray")
            {
                spawn.zonab3 = true;
                spawn.zonab1 = false;
                spawn.zonab2 = false;
            }
            if (gameObject.name == "Gulper")
            {
                spawn.zonab1 = true;
                spawn.zonab2 = false;
                spawn.zonab3 = false;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Peluru"&&gameObject.tag=="Boss")
        {
            if (kaboomStage == 0)
            {
                Damage(5);
                float lerp = Mathf.PingPong(Time.time, duration) / duration;
                rend.material.Lerp(material1, material2, lerp);
            }else if (kaboomStage == 1)
            {
                Damage(10);
                float lerp = Mathf.PingPong(Time.time, duration) / duration;
                rend.material.Lerp(material1, material2, lerp);
            }else if (kaboomStage == 2)
            {
                Damage(15);
                float lerp = Mathf.PingPong(Time.time, duration) / duration;
                rend.material.Lerp(material1, material2, lerp);
            }else if (kaboomStage == 3)
            {
                Damage(20);
                float lerp = Mathf.PingPong(Time.time, duration) / duration;
                rend.material.Lerp(material1, material2, lerp);
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour
{
    public Animator animl;
    public bool kenagakya;
    public int CoinSaatIni,GuardianSaatIni,AutoSaatIni,BoosterSaatIni,ShootingPartSaatIni;
    public float ShootingIni;
    public Oxygen oxy;
    public Text TeksCoin, TeksGuardian, TeksAuto, TeksBooster, TeksShooting;
    public AktivasiTameng tamengnya;
    public int boosterstage, shieldstage, kaboomstage, oxystage,shieldhealth;
    public CrossDBManager CDBM;

    void Start()
    {
        CoinSaatIni = PlayerPrefs.GetInt("CoinQty",0);
        //AutoSaatIni = PlayerPrefs.GetInt("Autonya", 0);
        GuardianSaatIni = PlayerPrefs.GetInt("ShieldQty",1);
        ShootingPartSaatIni = PlayerPrefs.GetInt("KaboomQty",1);
        BoosterSaatIni = PlayerPrefs.GetInt("BoosterQty",1);
        boosterstage = PlayerPrefs.GetInt("BoosterStage",0);
        shieldstage = PlayerPrefs.GetInt("ShieldStage",0);
        kaboomstage = PlayerPrefs.GetInt("KaboomStage",0);
        oxystage = PlayerPrefs.GetInt("OxygenStage",0);

        PlayerPrefs.SetInt("ShieldQty", 1);
        PlayerPrefs.SetInt("KaboomQty", 1);
        PlayerPrefs.SetInt("BoosterQty", 1);


        tamengnya = gameObject.GetComponent<AktivasiTameng>();
        if (shieldstage == 0)
        {
            shieldhealth = 1;
        }
        else if (shieldstage == 1)
        {
            shieldhealth = 2;
        }
        else if (shieldstage == 2)
        {
            shieldhealth = 3;
        }
        else if (shieldstage == 3)
        {
            shieldhealth = 4;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            if (transform.gameObject.tag == "Player")
            {
                kenagakya = true;
                animl.SetBool("GameOver", true);
            }
            if (transform.gameObject.tag == "Invincible")
            {
                shieldhealth -= 1;

                if (shieldhealth > 1)
                {
                    Destroy(collision.collider.gameObject);
                   
                }
                else
                {
                    Destroy(collision.collider.gameObject);
                    transform.gameObject.tag = "Player";
                    tamengnya.shieldstat = false;
                }
            }
    
        }

        if (collision.collider.tag == "Boss" || collision.collider.tag=="BossInvincible")
        {
            if (transform.gameObject.tag == "Player")
            {
                kenagakya = true;
                animl.SetBool("GameOver", true);
            }
            if (transform.gameObject.tag == "Invincible")
            {
                shieldhealth -= 1;
                if (shieldhealth > 1)
                {

                }
                else
                {
                    transform.gameObject.tag = "Player";
                    tamengnya.shieldstat = false;
                }
            }
        }
        if (collision.collider.tag == "Ground")
        {
            if (transform.gameObject.tag == "Player")
            {
                kenagakya = true;
                animl.SetBool("GameOver", true);
            }
        }

        if (collision.collider.tag == "Coin")
        {
            PlayerPrefs.SetInt("CoinQty", CoinSaatIni + 1);
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.tag == "Oxygen")
        {
            if (oxystage == 0)
            {
                if (oxy.curOxy < 89)
                {
                    oxy.curOxy += 10f;
                }
                else
                {
                    oxy.curOxy = 100f;
                }
                Destroy(collision.collider.gameObject);
            }else if(oxystage == 1)
            {
                if (oxy.curOxy < 189)
                {
                    oxy.curOxy += 10f;
                }
                else
                {
                    oxy.curOxy = 200f;
                }
                Destroy(collision.collider.gameObject);
            }
            else if (oxystage == 2)
            {
                if (oxy.curOxy < 289)
                {
                    oxy.curOxy += 10f;
                }
                else
                {
                    oxy.curOxy = 300f;
                }
                Destroy(collision.collider.gameObject);
            }
            else if (oxystage == 3)
            {
                if (oxy.curOxy < 389)
                {
                    oxy.curOxy += 10f;
                }
                else
                {
                    oxy.curOxy = 400f;
                }
                Destroy(collision.collider.gameObject);
            }
        }
        if (collision.collider.tag == "Guardian")
        {
            PlayerPrefs.SetInt("ShieldQty", GuardianSaatIni + 1);
            Destroy(collision.collider.gameObject);
            TeksGuardian.text = (GuardianSaatIni+1).ToString();
        }
        if (collision.collider.tag == "Booster")
        {
            PlayerPrefs.SetInt("BoosterQty", AutoSaatIni + 1);
            Destroy(collision.collider.gameObject);
            TeksBooster.text = (BoosterSaatIni + 1).ToString();
        }
        if (collision.collider.tag == "Kaboom Qty")
        {
            PlayerPrefs.SetInt("KaboomQty", ShootingPartSaatIni + 1);
            Destroy(collision.collider.gameObject);
            TeksShooting.text = (ShootingPartSaatIni+1).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (shieldhealth == 0)
        {

        }
        else
        {
        }

        if (oxy.curOxy<=0)
        {
            Time.timeScale = 0f;
            kenagakya = true;
            animl.SetBool("GameOver", true);
        }
        if (kenagakya)
        {
            Time.timeScale = 0f;
            CDBM.SyncData();
        }
        CoinSaatIni = PlayerPrefs.GetInt("CoinQty");
        //AutoSaatIni = PlayerPrefs.GetInt("Autonya", 0);
        GuardianSaatIni = PlayerPrefs.GetInt("ShieldQty");
        ShootingPartSaatIni = PlayerPrefs.GetInt("KaboomQty");
        BoosterSaatIni = PlayerPrefs.GetInt("BoosterQty");
        TeksGuardian.text = GuardianSaatIni.ToString();
        //TeksAuto.text = AutoSaatIni.ToString();
        TeksBooster.text = BoosterSaatIni.ToString();
        TeksShooting.text = ShootingPartSaatIni.ToString();
    }
}

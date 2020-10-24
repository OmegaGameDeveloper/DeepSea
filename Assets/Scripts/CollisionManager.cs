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
    

    void Start()
    {
        boosterstage = PlayerPrefs.GetInt("BoosterStage");
        shieldstage = PlayerPrefs.GetInt("ShieldStage");
        kaboomstage = PlayerPrefs.GetInt("KaboomStage");
        oxystage = PlayerPrefs.GetInt("OxygenStage");
        tamengnya = gameObject.GetComponent<AktivasiTameng>();
        if (oxystage == 0)
        {
            shieldhealth = 1;
        }
        else if (oxystage == 1)
        {
            shieldhealth = 2;
        }
        else if (oxystage == 2)
        {
            shieldhealth = 3;
        }
        else if (oxystage == 3)
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

        if (collision.collider.tag == "Boss")
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
            PlayerPrefs.SetInt("Coinnya", CoinSaatIni + 1);
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
            PlayerPrefs.SetInt("Guardiannya", GuardianSaatIni + 1);
            Destroy(collision.collider.gameObject);
            TeksGuardian.text = (GuardianSaatIni+1).ToString();
        }
        if (collision.collider.tag == "Auto")
        {
            PlayerPrefs.SetInt("Autonya", AutoSaatIni + 1);
            Destroy(collision.collider.gameObject);
            //TeksAuto.text = (AutoSaatIni + 1).ToString();
        }
        if (collision.collider.tag == "Booster")
        {
            PlayerPrefs.SetInt("Boosternya", AutoSaatIni + 1);
            Destroy(collision.collider.gameObject);
            TeksBooster.text = (BoosterSaatIni + 1).ToString();
        }
        if (collision.collider.tag == "Shooting Part")
        {
            PlayerPrefs.SetInt("Shooting Partnya", ShootingPartSaatIni + 1);
            Destroy(collision.collider.gameObject);
            if (kaboomstage == 0)
            {
                ShootingIni = ShootingPartSaatIni / 4;
            }else if (kaboomstage == 1)
            {
                ShootingIni = ShootingPartSaatIni / 3;
            }
            else if (kaboomstage == 2)
            {
                ShootingIni = ShootingPartSaatIni / 2;
            }
            else if (kaboomstage == 3)
            {
                ShootingIni = ShootingPartSaatIni / 1;
            }
            TeksShooting.text = (Mathf.Floor(ShootingIni)+1).ToString();
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
        }
        CoinSaatIni = PlayerPrefs.GetInt("Coinnya", 0);
        //AutoSaatIni = PlayerPrefs.GetInt("Autonya", 0);
        GuardianSaatIni = PlayerPrefs.GetInt("Guardiannya", 0);
        ShootingPartSaatIni = PlayerPrefs.GetInt("Shooting Partnya", 0);
        BoosterSaatIni = PlayerPrefs.GetInt("Boosternya", 0);
        TeksGuardian.text = GuardianSaatIni.ToString();
        //TeksAuto.text = AutoSaatIni.ToString();
        TeksBooster.text = BoosterSaatIni.ToString();
        if (kaboomstage == 0)
        {
            ShootingIni = ShootingPartSaatIni / 4;
        }
        else if (kaboomstage == 1)
        {
            ShootingIni = ShootingPartSaatIni / 3;
        }
        else if (kaboomstage == 2)
        {
            ShootingIni = ShootingPartSaatIni / 2;
        }
        else if (kaboomstage == 3)
        {
            ShootingIni = ShootingPartSaatIni / 1;
        }
        TeksShooting.text = Mathf.Floor(ShootingIni).ToString();
    }
}

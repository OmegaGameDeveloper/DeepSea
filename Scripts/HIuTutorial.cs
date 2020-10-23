using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HIuTutorial : MonoBehaviour
{
    public Animator animl;
    public bool kenagakya;
    public int CoinSaatIni, GuardianSaatIni, AutoSaatIni, BoosterSaatIni, ShootingPartSaatIni;
    public float ShootingIni;
    public Oxygen oxy;
    public Text TeksCoin, TeksGuardian, TeksAuto, TeksBooster, TeksShooting;
    public AktivasiTameng tamengnya;
    public LoadScene hmm;

    void Start()
    {
        tamengnya = gameObject.GetComponent<AktivasiTameng>();
        hmm = gameObject.GetComponent<LoadScene>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            if (transform.gameObject.tag == "Player")
            {
                hmm.LoadLevel(2);
            }
            if (transform.gameObject.tag == "Invincible")
            {
                Destroy(collision.collider.gameObject);
                transform.gameObject.tag = "Player";
                tamengnya.shieldstat = false;
            }

        }
        if (collision.collider.tag == "Coin")
        {
            PlayerPrefs.SetInt("Coinnya", CoinSaatIni + 1);
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.tag == "Oxygen")
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

        }
        if (collision.collider.tag == "Guardian")
        {
            PlayerPrefs.SetInt("Guardiannya", GuardianSaatIni + 1);
            Destroy(collision.collider.gameObject);
            TeksGuardian.text = (GuardianSaatIni + 1).ToString();
        }
        if (collision.collider.tag == "Auto")
        {
            PlayerPrefs.SetInt("Autonya", AutoSaatIni + 1);
            Destroy(collision.collider.gameObject);
            TeksAuto.text = (AutoSaatIni + 1).ToString();
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
            ShootingIni = ShootingPartSaatIni / 3;
            TeksShooting.text = (Mathf.Floor(ShootingIni) + 1).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (oxy.curOxy == 0)
        {
            hmm.LoadLevel(2);
        }
        if (kenagakya)
        {
            Time.timeScale = 0f;
        }
        CoinSaatIni = PlayerPrefs.GetInt("Coinnya", 0);
        AutoSaatIni = PlayerPrefs.GetInt("Autonya", 0);
        GuardianSaatIni = PlayerPrefs.GetInt("Guardiannya", 0);
        ShootingPartSaatIni = PlayerPrefs.GetInt("Shooting Partnya", 0);
        BoosterSaatIni = PlayerPrefs.GetInt("Boosternya", 0);
        TeksGuardian.text = GuardianSaatIni.ToString();
        TeksAuto.text = AutoSaatIni.ToString();
        TeksBooster.text = BoosterSaatIni.ToString();
        ShootingIni = ShootingPartSaatIni / 3;
        TeksShooting.text = Mathf.Floor(ShootingIni).ToString();
    }
}

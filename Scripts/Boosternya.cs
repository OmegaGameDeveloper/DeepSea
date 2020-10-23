using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boosternya : MonoBehaviour
{

    public GameObject boosterParticle,shieldParticle;
    public float timer, timerawal;
    public bool timerIsRunning, boosterstat;
    int JumlahBooster, boosterStage;
    public Button but;
    public bool isTimeAdded;

    // Start is called before the first frame update
    void Start()
    {
        boosterStage = PlayerPrefs.GetInt("BoosterStage");
    }


    public void Aktifasi()
    {
        boosterstat = true;
        JumlahBooster -= 1;
        PlayerPrefs.SetInt("BoosterQty", JumlahBooster);
        isTimeAdded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (boosterStage == 0)
        {
            timerawal = 3f;
        }else if(boosterStage == 1)
        {
            timerawal = 4f;
        }else if (boosterStage == 2)
        {
            timerawal = 5f;
        }else if (boosterStage == 3)
        {
            timerawal = 6f;
        }

        JumlahBooster = PlayerPrefs.GetInt("BoosterQty");
        if (JumlahBooster <= 0)
        {
            but.interactable = false;
        }
        else
        {
            but.interactable = true;
        }

        if (boosterstat)
        {
            boosterParticle.SetActive(true);
            gameObject.tag = "Super Invincible";
            but.interactable = false;
            timer -= Time.unscaledDeltaTime;
            Time.timeScale = 2f;
        }
        else
        {
            if (gameObject.tag == "Invincible")
            {
                boosterParticle.SetActive(false);
            }
            else
            {
                boosterParticle.SetActive(false);
                gameObject.tag = "Player";
                but.interactable = true;
                timer = timerawal;
            }
        }
        if (timer <= 0) {
            boosterParticle.SetActive(false);
            but.interactable = true;
            timer = timerawal;
            Time.timeScale = 1f;
            boosterstat = false;
            if(gameObject.tag=="Super Invincible" && shieldParticle.active == false)
            {
                gameObject.tag = "Player";
            }else
            {
                gameObject.tag = "Invincible";               
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AktivasiTameng : MonoBehaviour
{

    public GameObject shieldParticle;
    public bool shieldstat;
    int JumlahShield,shieldstage;
    public Button shieldButton;

    // Start is called before the first frame update
    void Start()
    {
        shieldstage = PlayerPrefs.GetInt("ShieldStage");
    }


    public void Aktifasi()
    {
        shieldstat = true;
        JumlahShield -= 1;
        PlayerPrefs.SetInt("ShieldQty", JumlahShield);
    }

    // Update is called once per frame
    void Update()
    {
        JumlahShield = PlayerPrefs.GetInt("ShieldQty");
        if (JumlahShield <= 0)
        {
            shieldButton.interactable = false;
        }
        else
        {
            shieldButton.interactable = true;
        }

        if (shieldstat)
        {
            shieldParticle.SetActive(true);
            gameObject.tag = "Invincible";
            shieldButton.interactable = false;
        }
        else
        {
            if (gameObject.tag!="Super Invincible"){
                shieldParticle.SetActive(false);
                gameObject.tag = "Player";
                shieldButton.interactable = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
public class Kaboom : MonoBehaviour
{

    public GameObject missileGO, player,ifEmptyText;

    public bool isShoot,isFire;
    public Animator kaboomAnimator,textAnimator;
    public ParticleSystem kaboomParticle;
    public int JumlahShield;
    public Button kaboomButton;

    public float timer, timerawal;

    public Transform lokasitembak;

    GameObject entityBoss;

    // Start is called before the first frame update
    void Start()
    {
        kaboomAnimator = player.GetComponent<Animator>();
        textAnimator = ifEmptyText.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Aktifasi()
    {
        if (JumlahShield == 0)
        {
            kaboomButton.interactable = false;
            textAnimator.SetBool("Habis", true);
            ifEmptyText.SetActive(true);
            isFire = true;
        }
        else
        {
            isFire = false;
            ifEmptyText.SetActive(false);
            textAnimator.SetBool("Habis", false);
            kaboomButton.interactable = true;
            isShoot = true;
            JumlahShield -= 1;
            PlayerPrefs.SetInt("KaboomQty", JumlahShield);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (darahBoss.damaged)
        {
            kaboomButton.interactable = false;
        }
        else
        {
            kaboomButton.interactable = true;
        }
        */
        if (isFire)
        {
            timer -= Time.unscaledDeltaTime;
        }

        if (timer <= 0)
        {
            timer = timerawal;
            ifEmptyText.SetActive(false);
            isFire = false;
        }

        JumlahShield = PlayerPrefs.GetInt("KaboomQty",1);

        if (JumlahShield == 0)
        {
            kaboomButton.interactable = false;
        }
        else
        {
            textAnimator.SetBool("Habis", false);
            kaboomButton.interactable = true;
            kaboomAnimator.SetBool("Tembak", false);
        }

        if (isShoot)
        {
            kaboomAnimator.SetBool("Tembak", true);
            kaboomButton.interactable = false;
            isShoot = false;
        }
        else
        {
            kaboomAnimator.SetBool("Tembak", false);
            kaboomButton.interactable = true;
        }
    }

    void Tembak()
    {
        kaboomParticle.Play();
        Vector3 posx = lokasitembak.transform.position;
        Quaternion rotation = lokasitembak.transform.rotation;
        Instantiate(missileGO, posx, rotation);
    }

}

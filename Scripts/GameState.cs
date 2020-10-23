using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameState : MonoBehaviour
{

    public bool pauseState;
    public GameObject Canvaspause;
    public Text zoneTeks;
    public Sepawner spawn;
    CrossDBManager CDBM;

    // Start is called before the first frame update
    void Start()
    {
        spawn = GetComponent<Sepawner>();
        CDBM = gameObject.GetComponent<CrossDBManager>();
    }

    public void RestartScene()
    {
        CDBM.SyncData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void MainMenu()
    {
        CDBM.SyncData();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseState) {
            Time.timeScale = 0;
            Canvaspause.SetActive(true);
            spawn.pausedState = true;
        } else {
            Time.timeScale = 1;
            Canvaspause.SetActive(false);
            spawn.pausedState = false;
        }
    }
}

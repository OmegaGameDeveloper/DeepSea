using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameState : MonoBehaviour
{

    public bool pauseState,isBossDead,isBossStage,takePhoto,isChangeZone;
    public GameObject Canvaspause;
    public Text zoneTeks,scoreTeks;
    public Sepawner spawn;
    public GameObject[] boss;
    public GameObject[] bossHealthbar;
    public float score,scoreZone;
    CrossDBManager CDBM;

    public GameObject loadingScreen;
    public Slider slider;
    public int urutanscene;

    public float timer, timerawal;

    public GameObject player;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        CDBM = gameObject.GetComponent<CrossDBManager>();
    }

    public void Paused()
    {
        pauseState = true;
    }

    public void Resume()
    {
        pauseState = false;
    }

    public void RestartScene()
    {
        CDBM.SyncData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu(int SceneIndex)
    {
        CDBM.SyncData();
        StartCoroutine(LoadingScreen(SceneIndex));
    }

    void OnApplicationPause(bool pauseStatus)
    {
        pauseState = pauseStatus;
    }

    IEnumerator LoadingScreen(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        zoneTeks.text = spawn.zoneName;
        if (isBossStage)
        {
            score = 0;
        }
        else
        {
            if (!isBossDead)
            {
                score += (Time.deltaTime * Time.timeScale) * 10;
            }
            else
            {
                isBossStage = false;
                isChangeZone = true;

            }
        }

        if (isChangeZone)
        {
            animator.SetBool("Change Zone", true);
            Vector3 offset = transform.forward * (transform.localScale.z / 2f) * -1f;
            Vector3 pos = transform.position + offset; //This is the position
            player.gameObject.transform.Translate(new Vector3(player.gameObject.transform.position.x,player.gameObject.transform.position.y, pos.z));
            //player pindahkan ke ujung terrain
            timer -= Time.unscaledDeltaTime;
            spawn.zonab1 = false;
            spawn.zonab2 = false;
            spawn.zonab3 = false;
        }
        else
        {
            animator.SetBool("Change Zone", false);
            timer = timerawal;
        }

        if (timer <= 0)
        {
            isChangeZone = false;
        }

        if (score >= 1000)
        {
            isBossStage = true;
            if (spawn.zonab1) { 
            boss[0].SetActive(true);
            bossHealthbar[0].SetActive(true);
            //spawn.enabled = false;
            }
            if (spawn.zonab2)
            {
                boss[1].SetActive(true);
                bossHealthbar[1].SetActive(true);
            }
        }
        else
        {
            //spawn.enabled = true;
        }

        if (pauseState) {
            Time.timeScale = 0;
            Canvaspause.SetActive(true);
            spawn.pausedState = true;
        }else if (takePhoto)
        {
            Time.timeScale = 0;
            spawn.takePhoto = true;
        }
        else {
            Time.timeScale = 1;
            Canvaspause.SetActive(false);
            spawn.pausedState = false;
            spawn.takePhoto = false;
        }
    }
}

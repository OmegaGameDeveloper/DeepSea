using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.SceneManagement;
public class CrossDBManager : MonoBehaviour
{

    public string cekFreshUrl,registerProfilerUrl, getHighScore_url, setProgress_url;
    //Response
    public GameObject goIfEmpty, goDBResponse,goNewProfile,goProfile,goIfDuplicate,goNewFreshProfile;
    public Text DBResponse,DBProfileName;
    public Text[] teksUsername, teksScore;
    public Text usernamenya;
    //DB
    public string usernameString,shieldStageString,boosterStageString,oxyStageString,coinString,kaboomStageString,scoreString;
    public InputField usernameText;
    //Local
    public string LusernameString;
    

    public Dropdown usernameDropdown;

    public string[] usernameArray,shieldArray,boosterArray,oxyArray,coinArray,kaboomArray,scoreArray;

    public int panjangArray, scoreStringBefore;
    public int scorenya;

    public List<string> usernameList,shieldList,boosterList,oxyList,coinList,kaboomList,scoreList = new List<string>();


    //AwalCek()
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Main Menu")
        {
            LusernameString = PlayerPrefs.GetString("username");
            if (LusernameString == "")
            {
                StartCoroutine(freshProfileCek());
            }
            else
            {
                usernamenya.text = LusernameString;
            }
        }
        if(scene.name=="Level 1")
        {
           
        }
    }
    //Baru
    public void NewProfile()
    {
        usernameString = usernameText.text;
        StartCoroutine(RegisterProfile());
    }

    public void GetTopHighScore()
    {
        StartCoroutine(GetHighScore());
    }

    public void SyncData()
    {
        StartCoroutine(Sync());
    }




    //CekProfileAwal()
    IEnumerator freshProfileCek()
    {
        WWWForm form = new WWWForm();

        form.AddField("username", LusernameString);

        var download = UnityWebRequest.Post(cekFreshUrl,form);

        yield return download.SendWebRequest();

        if (download.isNetworkError || download.isHttpError)
        {
            print("Error downloading: " + download.error);
            DBResponse.text = download.downloadHandler.text;
            DBResponse.text = download.error;
        }
        else if (download.downloadHandler.text == "Kosong")
        {
            goNewFreshProfile.SetActive(true);
        }
        else
        {
            JSONNode data = JSON.Parse(download.downloadHandler.text);
            panjangArray = data.Count;
            for (int i = 0; i < panjangArray; i++)
            {
                usernameString = data[i]["username"].Value;
                scoreString = data[i]["scores"].Value;
                kaboomStageString = data[i]["kaboomStages"].Value;
                shieldStageString = data[i]["shieldStages"].Value;
                boosterStageString = data[i]["boosterStages"].Value;
                oxyStageString = data[i]["oxyStages"].Value;
                coinString = data[i]["CoinQtys"].Value;
            }
            PlayerPrefs.SetInt("KaboomStage",  int.Parse(kaboomStageString));
            PlayerPrefs.SetInt("OxygenStage", int.Parse(oxyStageString));
            PlayerPrefs.SetInt("ShieldStage", int.Parse(shieldStageString));
            PlayerPrefs.SetInt("BoosterStage", int.Parse(boosterStageString));
            PlayerPrefs.SetInt("Coinnya",int.Parse(coinString));
        }
    }
    //SendRegisterProfileBaru
    IEnumerator RegisterProfile()
    {
        if (usernameText.text == "") {
            goDBResponse.SetActive(true);
            DBResponse.text = "Username Tidak Boleh Kosong!";
        }
        else
        {
            // Create a form object for sending high score data to the server
            WWWForm form = new WWWForm();

            form.AddField("username", usernameText.text);
            // Create a download object
            var download = UnityWebRequest.Post(registerProfilerUrl, form);

            // Wait until the download is done
            yield return download.SendWebRequest();

            if (download.isNetworkError || download.isHttpError)
            {
                print("Error downloading: " + download.error);
                DBResponse.text = download.downloadHandler.text;
                DBResponse.text = download.error;
            }
            else if (download.downloadHandler.text == "Berhasil")
            {
                goNewFreshProfile.SetActive(false);
                DBProfileName.text = usernameString;
                PlayerPrefs.SetString("username", usernameText.text);
            }
            else if (download.downloadHandler.text == "Gagal")
            {
                Debug.Log("Gagal Euy!");
            }
            else if (download.downloadHandler.text == "Duplikat")
            {
                goIfDuplicate.SetActive(true);
            }
            else
            {
                Debug.Log(download.downloadHandler.text);
            }
        }
    }
    //SyncDataOfflineandOnline
    IEnumerator Sync()
    {
        usernameString = PlayerPrefs.GetString("username");
        oxyStageString = PlayerPrefs.GetInt("OxygenStage").ToString();
        kaboomStageString = PlayerPrefs.GetInt("KaboomStage").ToString();
        shieldStageString = PlayerPrefs.GetInt("ShieldStage").ToString();
        boosterStageString = PlayerPrefs.GetInt("BoosterStage").ToString();
        coinString = PlayerPrefs.GetInt("Coinnya").ToString();
        scoreStringBefore = PlayerPrefs.GetInt("Score");

        int.TryParse(scoreString, out scorenya);
        if (scorenya > scoreStringBefore)
        {
            WWWForm form = new WWWForm();
            form.AddField("username", usernameString);
            form.AddField("oxyStage", oxyStageString);
            form.AddField("kaboomStage", kaboomStageString);
            form.AddField("boosterStage", boosterStageString);
            form.AddField("shieldStage", shieldStageString);
            form.AddField("CoinQty", coinString);
            var download = UnityWebRequest.Post(setProgress_url, form);
            // Wait until the download is done
            yield return download.SendWebRequest();

            if (download.isNetworkError || download.isHttpError)
            {
                print("Error downloading: " + download.error);
                DBResponse.text = download.downloadHandler.text;
                DBResponse.text = download.error;
            }
            else if (download.downloadHandler.text == "Gagal")
            {
                goDBResponse.SetActive(true);
                DBResponse.text = "Tidak Dapat Sinkronisasi!";
            }
            else
            {

            }
        }
        else
        {
            WWWForm form = new WWWForm();
            form.AddField("username", usernameString);
            form.AddField("score", scoreStringBefore);
            form.AddField("oxyStage", oxyStageString);
            form.AddField("kaboomStage", kaboomStageString);
            form.AddField("boosterStage", boosterStageString);
            form.AddField("shieldStage", shieldStageString);
            form.AddField("CoinQty", coinString);
            var download = UnityWebRequest.Post(setProgress_url, form);
            // Wait until the download is done
            yield return download.SendWebRequest();

            if (download.isNetworkError || download.isHttpError)
            {
                print("Error downloading: " + download.error);
                DBResponse.text = download.downloadHandler.text;
                DBResponse.text = download.error;
            }
            else if (download.downloadHandler.text == "Gagal")
            {
                goDBResponse.SetActive(true);
                DBResponse.text = "Tidak Dapat Sinkronisasi!";
            }
            else
            {

            }
        }
    }

    //GetHighScore 
    IEnumerator GetHighScore()
    {
        // Create a download object
        var download = UnityWebRequest.Get(getHighScore_url);

        // Wait until the download is done
        yield return download.SendWebRequest();

        if (download.isNetworkError || download.isHttpError)
        {
            print("Error downloading: " + download.error);
            DBResponse.text = download.downloadHandler.text;
            DBResponse.text = download.error;
        }
        else
        {
            JSONNode data = JSON.Parse(download.downloadHandler.text);
            int panjangArrays = data.Count;
            usernameArray = new string[panjangArrays];
            scoreArray = new string[panjangArrays];
            for (int i = 0; i < panjangArrays; i++)
            {
                usernameArray[i] = data[i]["username"].Value;
                scoreArray[i] = data[i]["scores"].Value;
                teksUsername[i].text = usernameArray[i];
                teksScore[i].text = scoreArray[i];
            }
        }

    }
}

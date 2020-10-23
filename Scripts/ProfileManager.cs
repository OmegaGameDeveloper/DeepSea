using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    public GameObject CanvasNewUser;
    string username;
    CrossDBManager CDBM;
    public static List<Object> inventory = new List<Object>();

    // Start is called before the first frame update
    void Start()
    {
        username = PlayerPrefs.GetString("Username", "");
    }

    // Update is called once per frame
    void Update()
    {
        if (username == "" || username == null)
        {
            CanvasNewUser.SetActive(true);
            
            //List<PlayerStats> boosterList = CDBM.boosterArray.ToList();
            
        }
        else
        {
            CanvasNewUser.SetActive(false);
        }
    }
}

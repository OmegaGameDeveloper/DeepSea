using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Upgradeable : MonoBehaviour
{

    //Booster
    public int boosterstage,boosterprice;
    public Text boosterteks,boosterstageteks;
    bool boosterup;
    //Shield
    public int shieldstage,shieldprice;
    bool shieldup;
    public Text shieldteks,shieldstageteks;
    //Kaboom
    public int kaboomstage,kaboomprice;
    bool kaboomup;
    public Text kaboomteks,kaboomstageteks;
    //Oxygen
    public int oxystage, oxyprice;
    public Text oxyteks,oxystageteks;
    bool oxyup;
    //Coin
    public int coin;
    public Text cointeks;
    //Common
    public int tempcoin;
    // Start is called before the first frame update
    void Start()
    {
        coin = PlayerPrefs.GetInt("Coin Qty");
        boosterstage = PlayerPrefs.GetInt("BoosterStage",0);
        shieldstage = PlayerPrefs.GetInt("ShieldStage",0);
        kaboomstage = PlayerPrefs.GetInt("KaboomStage",0);
        oxystage = PlayerPrefs.GetInt("OxygenStage",0);
    }

    public void UpKaboom()
    {
        kaboomup = true;
    }

    public void UpShield()
    {
        shieldup = true;
    }

    public void UpBooster()
    {
        boosterup = true;
    }
    public void UpOxygen()
    {
        oxyup = true;
    }

    // Update is called once per frame
    void Update()
    {
        //GetAll
        coin = PlayerPrefs.GetInt("Coinnya");
        boosterstage = PlayerPrefs.GetInt("BoosterStage");
        shieldstage = PlayerPrefs.GetInt("ShieldStage");
        kaboomstage = PlayerPrefs.GetInt("KaboomStage");
        oxystage = PlayerPrefs.GetInt("OxygenStage");
        //GetStageKaboom
        if (kaboomstage == 0)
        {
            kaboomstageteks.text = "Kaboom Stage : 1";
            kaboomteks.text = "Upgrade ↑ -10 Coin";
        }
        else if (kaboomstage == 1)
        {
            kaboomstageteks.text = "Kaboom Stage : 2";
            kaboomteks.text = "Upgrade ↑ -20 Coin";
        }
        else if (kaboomstage == 2)
        {
            kaboomteks.text = "Kaboom ↑ -30 Coin";
            kaboomstageteks.text = "Booster Stage : 3";
        }
        else
        {
            kaboomteks.text = "Maxed";
            kaboomstageteks.text = "Maxed Out";
        }
        //GetStageBooster
        if (boosterstage == 0)
        {
            boosterstageteks.text = "Booster Stage : 1";
            boosterteks.text = "Upgrade ↑ -10 Coin";
        }
        else if (boosterstage == 1)
        {
            boosterstageteks.text = "Booster Stage : 2";
            boosterteks.text = "Upgrade ↑ -20 Coin";
        }
        else if (boosterstage == 2)
        {
            boosterteks.text = "Upgrade ↑ -30 Coin";
            boosterstageteks.text = "Booster Stage : 3";
        }
        else
        {
            boosterteks.text = "Maxed";
            boosterstageteks.text = "Maxed Out";
        }
        //GetOxygenStage
        if (oxystage == 0)
        {
            oxystageteks.text = "Oxygen Stage : 1";
            oxyteks.text = "Upgrade ↑ -10 Coin";
        }
        else if (oxystage == 1)
        {
            oxystageteks.text = "Oxygen Stage : 2";
            oxyteks.text = "Upgrade ↑ -20 Coin";
        }
        else if (oxystage == 2)
        {
            oxyteks.text = "Oxygen ↑ -30 Coin";
            oxystageteks.text = "Booster Stage : 3";
        }
        else
        {
            oxyteks.text = "Maxed";
            oxystageteks.text = "Maxed Out";
        }
        //GetShieldStage
        if (shieldstage == 0)
        {
            shieldstageteks.text = "Oxygen Stage : 1";
            shieldteks.text = "Upgrade ↑ -10 Coin";
        }
        else if (shieldstage == 1)
        {
            shieldstageteks.text = "Oxygen Stage : 2";
            shieldteks.text = "Upgrade ↑ -20 Coin";
        }
        else if (shieldstage == 2)
        {
            shieldteks.text = "Oxygen ↑ -30 Coin";
            shieldstageteks.text = "Booster Stage : 3";
        }
        else
        {
            shieldteks.text = "Maxed";
            shieldstageteks.text = "Maxed Out";
        }
        //GetCoin
        cointeks.text = "Coin : "+coin.ToString();

        //UpBooster
        if (boosterup)
        {
            tempcoin = coin;
            if (boosterstage == 0)
            {
                tempcoin = tempcoin - 10;
                if (tempcoin >= 0)
                {
                    PlayerPrefs.SetInt("BoosterStage", 1);
                    PlayerPrefs.SetInt("Coin Qty", tempcoin);
                }
                else
                {
                    
                }
            }else if (boosterstage == 1)
            {
                tempcoin = tempcoin - 20;
                if (tempcoin >= 0)
                {
                    PlayerPrefs.SetInt("BoosterStage", 2);
                    PlayerPrefs.SetInt("Coin Qty", tempcoin);
                }
                else
                {

                }
            }
            else if (boosterstage == 2)
            {
                tempcoin = tempcoin - 30;
                if (tempcoin >= 0)
                {
                    PlayerPrefs.SetInt("BoosterStage", 3);
                    PlayerPrefs.SetInt("Coin Qty", tempcoin);
                }
                else
                {

                }
            }
            boosterup = false;
        }
        //UpOxygen
        if (oxyup)
        {
            tempcoin = coin;
            if (oxystage == 0)
            {
                tempcoin = tempcoin - 10;
                if (tempcoin >= 0)
                {
                    PlayerPrefs.SetInt("OxygenStage", 1);
                    PlayerPrefs.SetInt("Coin Qty", tempcoin);
                }
                else
                {

                }
            }
            else if (oxystage == 1)
            {
                tempcoin = tempcoin - 20;
                if (tempcoin >= 0)
                {
                    PlayerPrefs.SetInt("OxygenStage", 2);
                    PlayerPrefs.SetInt("Coin Qty", tempcoin);
                }
                else
                {

                }
            }
            else if (oxystage == 2)
            {
                tempcoin = tempcoin - 30;
                if (tempcoin >= 0)
                {
                    PlayerPrefs.SetInt("OxygenStage", 3);
                    PlayerPrefs.SetInt("Coin Qty", tempcoin);
                }
                else
                {

                }
            }
            oxyup = false;
        }
        //UpShield
        if (shieldup)
        {
            tempcoin = coin;
            if (shieldstage == 0)
            {
                tempcoin = tempcoin - 10;
                if (tempcoin >= 0)
                {
                    PlayerPrefs.SetInt("ShieldStage", 1);
                    PlayerPrefs.SetInt("Coin Qty", tempcoin);
                }
                else
                {

                }
            }
            else if (shieldstage == 1)
            {
                tempcoin = tempcoin - 20;
                if (tempcoin >= 0)
                {
                    PlayerPrefs.SetInt("ShieldStage", 2);
                    PlayerPrefs.SetInt("Coin Qty", tempcoin);
                }
                else
                {

                }
            }
            else if (shieldstage == 2)
            {
                tempcoin = tempcoin - 30;
                if (tempcoin >= 0)
                {
                    PlayerPrefs.SetInt("ShieldStage", 3);
                    PlayerPrefs.SetInt("Coin Qty", tempcoin);
                }
                else
                {

                }
            }
            shieldup = false;
        }
        //UpKaboom
        if (kaboomup)
        {
            tempcoin = coin;
            if (kaboomstage == 0)
            {
                tempcoin = tempcoin - 10;
                if (tempcoin >= 0)
                {
                    PlayerPrefs.SetInt("KaboomStage", 1);
                    PlayerPrefs.SetInt("Coin Qty", tempcoin);
                }
                else
                {

                }
            }
            else if (kaboomstage == 1)
            {
                tempcoin = tempcoin - 20;
                if (tempcoin >= 0)
                {
                    PlayerPrefs.SetInt("KaboomStage", 2);
                    PlayerPrefs.SetInt("Coin Qty", tempcoin);
                }
                else
                {

                }
            }
            else if (kaboomstage == 2)
            {
                tempcoin = tempcoin - 30;
                if (tempcoin >= 0)
                {
                    PlayerPrefs.SetInt("KaboomStage", 3);
                    PlayerPrefs.SetInt("Coin Qty", tempcoin);
                }
                else
                {

                }
            }
            kaboomup = false;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataManager : Singleton<DataManager>
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public bool isLoaded = false;
    public PlayerData playerData;
    public const string PLAYER_DATA = "PLAYER_DATA";


    private void OnApplicationPause(bool pause) { SaveData(); }
    private void OnApplicationQuit() { SaveData(); }

    public void LoadData()
    {
        string d = PlayerPrefs.GetString(PLAYER_DATA, "");
        if (d != "")
        {
            playerData = JsonUtility.FromJson<PlayerData>(d);
        }
        else
        {
            playerData = new PlayerData();
        }
        isLoaded = true;
        //loadskin
        //load pet

    }

    public void SaveData()
    {
        if (!isLoaded) return;
        string json = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString(PLAYER_DATA, json);
    }
    public int GetCoin()
    {

        return playerData.coin;
    }
    public void ObtainCoin(int coin)
    {
        playerData.coin += coin;
    }
}


[System.Serializable]
public class PlayerData
{
    [Header("--------- Game Setting ---------")]
    public bool isNew;
    public bool isMusic;
    public bool isSound;
    public bool isVibrate;
    public bool isNoAds;
    public int starRate;


    [Header("--------- Game Params ---------")]
    public int coin;
}

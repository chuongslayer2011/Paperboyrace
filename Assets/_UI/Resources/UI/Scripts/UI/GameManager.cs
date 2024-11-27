using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    //[SerializeField] UserData userData;
    //[SerializeField] CSVData csv;
    //private static GameState gameState = GameState.MainMenu;
    public Player player;
    protected void Awake()
    {
        DataManager.Ins.LoadData();
        //base.Awake();
        Input.multiTouchEnabled = false;
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        int maxScreenHeight = 1280;
        float ratio = (float)Screen.currentResolution.width / (float)Screen.currentResolution.height;
        if (Screen.currentResolution.height > maxScreenHeight)
        {
            Screen.SetResolution(Mathf.RoundToInt(ratio * (float)maxScreenHeight), maxScreenHeight, true);
        }
        //csv.OnInit();
        //userData?.OnInitData();

        //ChangeState(GameState.MainMenu);

        
    }

    //public static void ChangeState(GameState state)
    //{
    //    gameState = state;
    //}

    //public static bool IsState(GameState state)
    //{
    //    return gameState == state;
    //}
    private void Start()
    {
        Loading();

    }
    public void OnInit()
    {

    }

    public void OnDespawn()
    {

    }

    public void OnPlay()
    {
        UIManager.Ins.OpenUI<GamePlay>();
        Player.Ins.SetPlayingState(true);
        CameraFollow.Ins.SetCameraOnPlay();
    }

    public void OnVictory()
    {
        
        player.SetPlayingState(false);
        player.StopMoving();
        player.ChangeAnim(Cache.WIN_ANIM);
        CameraFollow.Ins.SetCameraOnVictory();
        StartCoroutine(OpenWinUI());
        DataManager.Ins.ObtainCoin(MapManager.Ins.GetObtainCoinOnCurrentMap());
    }

    public void OnLose()
    {
        
        player.SetPlayingState(false);
        player.ChangeAnim(Cache.DIE_ANIM);
        StartCoroutine(OpenLoseUI());
    }
    public void OnOpenMainMenu()
    {
        UIManager.Ins.OpenUI<MianMenu>();
        Player.Ins.SetPlayingState(false);
        player.ChangeAnim(Cache.IDLE_ANIM);
        
    }
    public void Loading()
    {
        UIManager.Ins.OpenUI<Loading>();
        CameraFollow.Ins.SetCameraOnMenu();
        MapManager.Ins.ResetRoad();
    }
    public IEnumerator OpenWinUI()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Win");
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<Win>();
    }
    public IEnumerator OpenLoseUI()
    {
        yield return new WaitForSeconds(2f);
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<Lose>();
    }
    public void OnPause()
    {
        Player.Ins.SetPlayingState(false);
        UIManager.Ins.OpenUI<PauseMenu>();
    }
}

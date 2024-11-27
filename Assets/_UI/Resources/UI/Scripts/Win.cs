using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Win : UICanvas
{
    public TMP_Text coinObtain;
    private void OnEnable()
    {
        //coinObtain.text = MapManager.Ins.GetObtainCoinOnCurrentMap().ToString();
    }
    public void MainMenuButton()
    {
        Close(0);
        GameManager.Ins.Loading();
    }
    public void ContinueButton()
    {
        Close(0);


    }
}
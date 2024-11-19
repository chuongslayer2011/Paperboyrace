using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lose : UICanvas
{
    public static Lose Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void MainMenuButton()
    {
        Close(0);
        GameManager.Ins.Loading();
    }
}

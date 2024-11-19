using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : UICanvas
{
    public void ResumeButton()
    {
        Close(0);
        GameManager.Ins.OnPlay();
    }
    public void HomeButton()
    {
        Close(0);
        GameManager.Ins.Loading();
    }
}

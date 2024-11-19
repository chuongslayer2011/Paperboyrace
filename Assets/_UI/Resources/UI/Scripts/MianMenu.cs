using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MianMenu : UICanvas
{
    public TMP_Text coinText;

    private void OnEnable()
    {
        coinText.text = DataManager.Ins.GetCoin().ToString();
    }
    public void PlayButton()
    {  

        Close(0);
        GameManager.Ins.OnPlay();
    }


}

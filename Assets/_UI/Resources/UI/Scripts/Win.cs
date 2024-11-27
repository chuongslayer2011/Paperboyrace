using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Win : UICanvas
{
    public Text coinObtain;
    public Text processText;
    public Image imageFillBar;
    public Image imageEmtyBar;
    public Sprite townSprite;
    public Sprite villageSprite;
    public Text deliveryMailQuantityCurrentLevelText;
    private int deliveryMailQuantityCurrentLevel;
    
    private void OnEnable()
    {
        coinObtain.text = MapManager.Ins.GetObtainCoinOnCurrentMap().ToString();
        StartCoroutine(ObtainMail());
    }
    public void CollectButton()
    {
        Close(0);
        GameManager.Ins.Loading();
    }
    public void ContinueButton()
    {
        Close(0);


    }
    private IEnumerator ObtainMail()
    {
        deliveryMailQuantityCurrentLevel = MapManager.Ins.GetDeliveriedMailQuantityOnCurrentLevel();
        imageFillBar.fillAmount = MapManager.Ins.GetDeliveriedMailQuantityOnCurrentZone() / 10;
        yield return new WaitForSeconds(1f);
        processText.text = MapManager.Ins.GetDeliveriedMailQuantityOnCurrentZone().ToString() + "/10";
        while (deliveryMailQuantityCurrentLevel > 0)
        {
            yield return new WaitForSeconds(1f);
            deliveryMailQuantityCurrentLevel -= 1;
            deliveryMailQuantityCurrentLevelText.text = deliveryMailQuantityCurrentLevel.ToString();            
            MapManager.Ins.UpdateDeliveriedMailQuantityOnCurrentZone();
            processText.text = MapManager.Ins.GetDeliveriedMailQuantityOnCurrentZone().ToString() + "/10";
            imageFillBar.fillAmount = MapManager.Ins.GetDeliveriedMailQuantityOnCurrentZone() / 10;

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : UICanvas
{
    [SerializeField] private Image imageFill;
    [SerializeField] private float loadingTime = 1.5f;
    private float timeCount=0;

    private void OnEnable()
    {
        StartCoroutine(SetLoadingFillAmount());
       
    }
    private IEnumerator SetLoadingFillAmount()
    {
        timeCount++;
        while (timeCount < loadingTime)
        {
            timeCount += Time.deltaTime;
            imageFill.fillAmount = Mathf.Clamp01(timeCount / loadingTime); 
            yield return null;
        }
        LoadingDone();
    }
    public void LoadingDone()
    {
        Close(0);
        GameManager.Ins.OnOpenMainMenu();
        timeCount = 0;
    }
}

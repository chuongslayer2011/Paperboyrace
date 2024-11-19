using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : UICanvas
{
    public static GamePlay instance;
    [SerializeField] private Image processImage;
    [SerializeField] private Image notFinish;
    [SerializeField] private Image finish;
    [SerializeField] private float distance = 331;
    [SerializeField] private TMP_Text mailDeliveryText;
    private int mailDelivery;
    private float finishPosition = 314f;
    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        ProcessBar();
        EventManager.DeliveryMail += DeliveryMail;
        mailDelivery = 0;
        mailDeliveryText.text = mailDelivery.ToString();
    }
    private void OnDisable()
    {
        EventManager.DeliveryMail -= DeliveryMail;
    }
    public void PauseButton()
    {
        Close(0);
        GameManager.Ins.OnPause();
    }

    public void ProcessBar()
    {
        StartCoroutine(ProcessBarRoutine());
    }
    public IEnumerator ProcessBarRoutine()
    {
        SetFinishImage(false);
        while (Player.Ins.GetZPosition() < finishPosition)
        {
            processImage.fillAmount = Player.Ins.GetZPosition() / finishPosition;
            yield return Cache.fixTime;
        }
        SetFinishImage(true);
    }
    public void SetFinishImage(bool isFinish)
    {
        finish.gameObject.SetActive(isFinish);
        notFinish.gameObject.SetActive(!isFinish);
    }
    public void DeliveryMail()
    {
        mailDelivery++;
        mailDeliveryText.text = mailDelivery.ToString();
    }
} 
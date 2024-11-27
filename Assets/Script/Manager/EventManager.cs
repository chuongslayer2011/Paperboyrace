using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager 
{
    public static event Action DeliveryMail;
    public static void CallDeliveryMailEvent()
    {
        if (DeliveryMail == null) return;
        DeliveryMail();
    }
    public static event Action OnChangeZone;
    public static void CallOnChangeZoneEvent()
    {
        if( OnChangeZone == null) return;
        OnChangeZone();
    }
}

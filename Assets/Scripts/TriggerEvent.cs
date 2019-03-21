using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public string eventName;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.TriggerEvent(eventName);
    }

}

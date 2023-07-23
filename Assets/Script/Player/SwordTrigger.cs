using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SwordTrigger : MonoBehaviour
{
    private UnityEvent swardTriggered = new UnityEvent();


    public UnityEvent GetTriggered()
    {
        return swardTriggered;
    }

    void OnTriggerEnter()
    {
         swardTriggered.Invoke();
    }
}

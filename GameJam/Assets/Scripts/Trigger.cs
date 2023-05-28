using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent TriggerEvent;
    public bool EventTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered");
        if (collision.gameObject.tag == "Player" & !EventTriggered)
        {
            Debug.Log("Triggered");
            EventTriggered = true;
            TriggerEvent?.Invoke();
        }
    }
}

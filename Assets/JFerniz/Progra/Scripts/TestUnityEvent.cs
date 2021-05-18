using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestUnityEvent : MonoBehaviour
{
    [SerializeField] UnityEvent myUnityEvent = default;

    [ContextMenu("MyEvent")]
    private void RaiseEvent()
    {
        myUnityEvent.Invoke();
    }
}

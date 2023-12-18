using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class OnStartHandler : MonoBehaviour
{
    [Header("Actions")]
    [SerializeField] List<UnityEvent> _actions;
    // Start is called before the first frame update
    void Start()
    {
        foreach (UnityEvent unityEvent in _actions)
        {
            unityEvent.Invoke();
        }
    }
}

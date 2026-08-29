using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EventManagerScript : MonoBehaviour
{
    public static EventManagerScript instance;

    [Serializable]
    public class MessageEvent : UnityEvent<string, string> { }

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of EventManagerScript found.");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public MessageEvent OnSendMessage;
    public void InvokeSendMessage(string text, string alignment)
    {
        OnSendMessage.Invoke(text, alignment);
    }

    // public UnityEvent OnMessageSent; // Unity Event for changing size of Messages box
    // public void InvokeMessageSent()
    // {
    //     OnMessageSent.Invoke();
    // }

    public event Action OnMatch;
    public event Action OnMatch2;
    public IEnumerator InvokeMatch()
    {
        Debug.Log("OnMatch invoking...");
        OnMatch.Invoke();
        yield return null;
        OnMatch2.Invoke();
    }

    public event Action OnNoMatch;
    public void InvokeNoMatch()
    {
        OnNoMatch.Invoke();
    }
}

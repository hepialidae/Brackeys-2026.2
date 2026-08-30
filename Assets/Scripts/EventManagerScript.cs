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
    public event Action OnNoMatch2;
    public event Action OnNoMatch3;
    public IEnumerator InvokeNoMatch()
    {
        OnNoMatch.Invoke();
        yield return null;
        OnNoMatch2.Invoke();

        bool temp = GamestateManagerScript.instance.lastProfile switch
        {
            12 => true,
            13 => true,
            14 => true,
            15 => true,
            16 => true,
            17 => true,
            _ => false
        };
        if (temp)
        {
            yield return null;
            OnNoMatch3.Invoke();
        }
    }

    public event Action OnEndChat;
    public event Action OnEndChat2;
    public event Action OnEndChat3;
    public IEnumerator InvokeEndChat()
    {
        OnEndChat.Invoke();
        yield return null;
        OnEndChat2.Invoke();

        bool temp = GamestateManagerScript.instance.lastProfile switch
        {
            12 => true,
            13 => true,
            14 => true,
            15 => true,
            16 => true,
            17 => true,
            _ => false
        };
        if (temp)
        {
            yield return null;
            OnEndChat3.Invoke();
        }
    }

    public event Action OnDateStart;
    public event Action OnDateStart2;
    public event Action OnDateStart3;
    public IEnumerator InvokeDateStart()
    {
        OnDateStart.Invoke();
        yield return new WaitForSeconds(2f);
        OnDateStart2.Invoke();

        bool temp = GamestateManagerScript.instance.lastProfile switch
        {
            12 => false,
            13 => false,
            14 => false,
            15 => false,
            16 => false,
            17 => false,
            _ => true
        };
        if (temp)
        {
            Debug.Log("InvokeDateStart Temp: " + temp);
            yield return null;
            OnDateStart3.Invoke();
        }
    }
}

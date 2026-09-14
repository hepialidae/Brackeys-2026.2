using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.LowLevel;

public class EventManagerScript : MonoBehaviour
{
    public static EventManagerScript instance;

    [Serializable]
    public class MessageEvent : UnityEvent<string, string> { }
    [Serializable]
    public class IntEvent : UnityEvent<int> { }

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
            DontDestroyOnLoad(gameObject);
        }
    }

    public IntEvent NextDay; 
    public void InvokeNextDay(int currentDay)
    {
        NextDay.Invoke(currentDay);
    }

    public event Action stalker; // play music, close Fumble, open Messages, close Status
    public event Action stalker2; // Start chat with stalker (MessageManagerScript)
    public IEnumerator InvokeStalker()
    {
        stalker.Invoke();
        yield return null;
        stalker2.Invoke();
        GamestateManagerScript.instance.datedBeforeStalker = false;
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

    public event Action OnMatch; // disable Fumble buttons, open Messages
    public event Action OnMatch2; // Start new Messages chat + EnterDialogueMode
    public IEnumerator InvokeMatch()
    {
        Debug.Log("OnMatch invoking...");
        OnMatch.Invoke();
        yield return null;
        OnMatch2.Invoke();
    }

    public event Action OnNoMatch; // Calculates next guy, adds +1 rejection
    public event Action OnNoMatch2; // Fumble gets a new profile, status window opens
    public event Action OnNoMatch3; // Status manager updates
    public IEnumerator InvokeNoMatch()
    {
        bool keepGoing = new bool {};
        keepGoing = true;
        if (GamestateManagerScript.instance.GetProfileIndex(GamestateManagerScript.instance.profile) == 5)
        {
            if (GamestateManagerScript.instance.day == 1)
            {
                StartCoroutine(InvokeStalker());
                keepGoing = false;
            }
            else
            {
                InvokeNextDay(GamestateManagerScript.instance.day + 1);
            }
        }

        if (keepGoing)
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
                Debug.Log("OnNoMatch3 invoked");
                yield return null;
                OnNoMatch3.Invoke();
            }
        }
    }

    public event Action OnEndChat; // Opens Fumble, GamestateManager NextGuy and +1 rejection
    public event Action OnEndChat2; // Enables Fumble buttons, Refreshes profile, (conditional) Opens status window
    public event Action OnEndChat3; // (Conditional) Updates status window
    public IEnumerator InvokeEndChat()
    {
        bool keepGoing = new bool {};
        keepGoing = true;
        if (GamestateManagerScript.instance.GetProfileIndex(GamestateManagerScript.instance.profile) == 5)
        {
            if (GamestateManagerScript.instance.day == 1)
            {
                StartCoroutine(InvokeStalker());
                keepGoing = false;
            }
            else
            {
                InvokeNextDay(GamestateManagerScript.instance.day + 1);
            }
        }

        if (keepGoing)
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
    }

    public event Action OnDateStart; // Starts LeaveHomeAnim
    public event Action OnDateStart2; // Photostrip Appear, StatusIcon ConditionalOpenWindow
    public event Action OnDateStart3; // Status Window updates
    public event Action OnDateEnd; // Opens Fumble, GamestateManager NextGuy
    public event Action OnDateEnd2; // Enables Fumble buttons, Refreshes profile
    public IEnumerator InvokeDateStart()
    {
        bool temp = GamestateManagerScript.instance.profile switch
        {
            12 => false,
            13 => false,
            14 => false,
            15 => false,
            16 => false,
            17 => false,
            _ => true
        };

        if (!temp)
        {
            BadEnding.Invoke();
        }

        OnDateStart.Invoke();
        yield return new WaitForSeconds(2f);
        OnDateStart2.Invoke();
        
        if (temp)
        {
            yield return null;
            OnDateStart3.Invoke();
        }

        if (GamestateManagerScript.instance.profile == GamestateManagerScript.instance.designatedProfile)
        {
            InvokeGoodEnding();
        }


        if (GamestateManagerScript.instance.GetProfileIndex(GamestateManagerScript.instance.profile) == 5)
        {
            if (GamestateManagerScript.instance.day == 1)
            {
                GamestateManagerScript.instance.datedBeforeStalker = true;
                StartCoroutine(InvokeStalker());
            }
            else
            {
                InvokeNextDay(GamestateManagerScript.instance.day + 1);
                yield return null;
            }
        }

        if (!GamestateManagerScript.instance.datedBeforeStalker)
        {
            OnDateEnd.Invoke();
            yield return null;
            OnDateEnd2.Invoke();
        }
    }

    public event Action BadEnding;

    public event Action NeutralEnding;
    public void InvokeNeutralEnding()
    {
        NeutralEnding.Invoke();
    }

    public event Action GoodEnding;
    public void InvokeGoodEnding()
    {
        GoodEnding.Invoke();
    }

    public IEnumerator InvokeDateEnd()
    {
        yield return null;
        OnDateEnd.Invoke();
        yield return null;
        OnDateEnd2.Invoke();
    }

    public IntEvent CustomizationChoice = new IntEvent { };
    public void InvokeCustomizationChoice(int choice)
    {
        CustomizationChoice.Invoke(choice);
    }

    public event Action OnSubmitFate; // open Fumble, GamestateManagerScript SetProfileOrder
    public event Action OnSubmitFate2; // close customization, Fumble SetProfile
    public IEnumerator InvokeSubmitFate()
    {
        Debug.Log("SubmitFate invoked");
        OnSubmitFate.Invoke();
        yield return null;
        OnSubmitFate2.Invoke();
    }
}

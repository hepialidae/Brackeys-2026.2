// Note that this Dialogue Manager only works for ONE inkJSON file.

using UnityEngine;
using TMPro;
using Ink.Runtime;
using System.Collections.Generic;

public class DialogueManagerScript : MonoBehaviour
{
    private static DialogueManagerScript instance;
    public bool DialogueIsPlaying;

    [Header("Dialogue UI")]
    private string _currentText = "";

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [Header("Ink")]
    private Story currentStory;

    [Header("Debug/Testing")]
    [SerializeField] TextAsset inkJSON;
    // [SerializeField] string knotName = null;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one dialogue manager");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public static DialogueManagerScript GetInstance()
    {
        return instance;
    }

    void Start()
    {
        DialogueIsPlaying = false;

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>(true);
            index++;
        }

        // if (inkJSON != null && knotName != null)
        // {
        //     EnterDialogueMode(knotName);
        // }
    }

    void Update()
    {
        if (!DialogueIsPlaying)
        {
            return;
        }
        else
        {
            if (currentStory.currentChoices.Count == 0 && InputManagerScript.instance.GetLeftClickPerformed())
            {
                ContinueStory();
            }
        }
    }

    public void EnterDialogueMode(string knotName)
    {
        Debug.Log("EnterDialogueMode entered. Knot: " + knotName);

        currentStory = new Story(inkJSON.text);
        DialogueIsPlaying = true;

        currentStory.ChoosePathString(knotName);

        BindEndChat();
        BindDate();
        BindEndStalker();

        ContinueStory();
    }

    public void BindEndChat()
    {
        currentStory.BindExternalFunction("EndChat", () =>
        {
            StartCoroutine(EventManagerScript.instance.InvokeEndChat());
        });
    }

    public void BindDate()
    {
        currentStory.BindExternalFunction("Date", () =>
        {
            StartCoroutine(EventManagerScript.instance.InvokeDateStart());
        });
    }

    public void BindEndStalker()
    {
        currentStory.BindExternalFunction("EndStalker", () =>
        {
            EventManagerScript.instance.InvokeNextDay(GamestateManagerScript.instance.day + 1);
            StartCoroutine(EventManagerScript.instance.InvokeDateEnd());
        });
    }

    private void ExitDialogueMode()
    {
        DialogueIsPlaying = false;
        _currentText = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            Debug.Log(_currentText);
            _currentText = currentStory.Continue();
            DisplayChoices();

            List<string> lineTags = currentStory.currentTags;
            if (lineTags != null && lineTags.Count != 0 && _currentText != "")
            {
                if (lineTags[0] != "left" || lineTags[0] != "right")
                {
                    Debug.Log("InvokeSendMessage");
                    EventManagerScript.instance.InvokeSendMessage(_currentText, lineTags[0]);
                }
                else
                {
                    Debug.LogWarning("Message alignment not left or right. Alignment: " + lineTags[0]);
                }
            }
            else
            {
                if (lineTags.Count == 0)
                {
                    Debug.LogWarning("No alignment found. Line: " + _currentText);
                }
            }
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices than the UI can support");
        }
        else
        {
            int index = 0;
            foreach (Choice choice in currentChoices)
            {
                choices[index].gameObject.SetActive(true);
                choicesText[index].text = choice.text;
                index++;
            }
            for (int i = index; i < choices.Length; i++)
            {
                choices[i].gameObject.SetActive(false);
            }
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        AudioManagerScript.instance.Play(AudioManagerScript.instance.whoosh);
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();

        if (!currentStory.canContinue && currentStory.currentChoices.Count == 0)
        {
            ExitDialogueMode();
        }
    }
}
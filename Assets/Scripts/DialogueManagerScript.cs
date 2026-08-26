using UnityEngine;
using TMPro;
using Ink.Runtime;
using System.Collections.Generic;

public class DialogueManagerScript : MonoBehaviour
{
    private static DialogueManagerScript instance;
    public bool DialogueIsPlaying;

    [Header("Dialogue UI")]
    private string _currentText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [Header("Ink")]
    private Story currentStory;

    [Header("Debug/Testing")]
    [SerializeField] TextAsset inkJSON = null;
    [SerializeField] string knotName = null;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one dialogue manager");
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

        _currentText = "";

        if (inkJSON != null && knotName != null)
        {
            EnterDialogueMode(inkJSON, knotName);
        }
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

    public void EnterDialogueMode(TextAsset inkJSON, string knotName)
    {
        Debug.Log("EnterDialogueMode entered");

        currentStory = new Story(inkJSON.text);
        DialogueIsPlaying = true;

        currentStory.ChoosePathString(knotName);

        // if (knotName.Contains("Default"))
        // {
        //     List<string> knotTags = currentStory.TagsForContentAtPath(knotName).ToList();
        //     BindLeaveCounter();
        //     OrderTracker.instance.SetOrder(knotTags);
        // }

        ContinueStory();
    }

    // public void BindEndOrder()
    // {
    //     currentStory.BindExternalFunction("endOrder", () =>
    //     {
    //         ExitDialogueMode();
    //         EventManagerScript_Counter.instance.ServeCustomer();

    //         if (CustomerManagerScript.instance.customersVisited.Count == GamestateManager.instance.customersPerDay)
    //         {
    //             EventManagerScript_Counter.instance.EndDay(GamestateManager.instance.day);
    //         }
    //     });
    // }

    private void ExitDialogueMode()
    {
        DialogueIsPlaying = false;
        _currentText = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            _currentText = currentStory.Continue();
            DisplayChoices();

            List<string> lineTags = currentStory.currentTags;
            if (lineTags != null && lineTags.Count != 0)
            {
                HandleTags(lineTags);
            }
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void HandleTags(List<string> tags)
    {
        int len = tags.Count;
        switch (len)
        {
            case 1:
                // if (tags[0] == "red")
                // {
                //     DialogueText.color = Color.red;
                //     break;
                // }
                break;
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
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();

        if (!currentStory.canContinue && currentStory.currentChoices.Count == 0)
        {
            ExitDialogueMode();
        }
    }
}
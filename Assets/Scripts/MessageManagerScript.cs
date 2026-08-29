using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class MessageManagerScript : MonoBehaviour
{
    [Header("Messaging Settings")]
    [SerializeField] private float _spacing = 0;

    [Header("Components")]
    [SerializeField] private GameObject _messageBox;
    [SerializeField] private TextMeshProUGUI _contactNameTMP;
    [SerializeField] private string[] names;
    private GameObject _parent;
    private RectTransform _parentTransform;
    public bool IsNewChat { get; private set; } = true;
    private List<GameObject> _messageHistory = new List<GameObject>();
    private Vector3 spawnPos;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _parent = GameObject.Find("Messages");
        _parentTransform = _parent.GetComponent<RectTransform>();

        EventManagerScript.instance.OnSendMessage.AddListener(SpawnMessage);
        EventManagerScript.instance.OnMatch2 += StartNewChat;
    }

    void OnDisable() 
    {
        EventManagerScript.instance.OnSendMessage.RemoveListener(SpawnMessage);
    }

    private void SpawnMessage(string text, string alignment) // right_x = 439, left_x = -438
    {
        GameObject newMessage = Instantiate(_messageBox, _parentTransform, false);
        RectTransform newMessageTransform = newMessage.GetComponent<RectTransform>();
        TextMeshProUGUI textBox = newMessage.GetComponentInChildren<TextMeshProUGUI>();
        if (textBox != null) 
        {
            textBox.text = text;
        }
        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(newMessageTransform);

        if (IsNewChat == true)
        {
            if (alignment == "right")
            {
                spawnPos = new Vector3(314, 1010, 0);
            }
            else
            {
                if (alignment == "left")
                {
                    spawnPos = new Vector3(-312, 1010, 0);
                }
                else
                {
                    Debug.LogWarning("String alignment is not right or left. Alignment: " + alignment);
                    return;
                }
            }
            IsNewChat = false;
        }
        else
        {
            float height = 0;
            // calculate _messageHistory / 2
            if (_messageHistory.Count > 0)
            {
                RectTransform oldRectTransform = _messageHistory[^1].GetComponent<RectTransform>();
                height += oldRectTransform.rect.height * oldRectTransform.lossyScale.y;
            }
            else 
            {
                Debug.LogWarning("Message history is empty while starting an existing chat.");
            }
            
            // calculate newMessage height / 2
            height += newMessageTransform.rect.height * newMessageTransform.lossyScale.y;

            if (alignment == "right")
            {
                Vector3[] corners = new Vector3[4];
                 // [0] bottom-left, [1] top-left, [2] top-right, [3] bottom-right
                _messageHistory[^1].GetComponent<RectTransform>().GetWorldCorners(corners);
                float _lastY = _parentTransform.InverseTransformPoint(corners[0]).y;
                spawnPos = new Vector3(314, _lastY - _spacing - height, 0);
            }
            else
            {
                if (alignment == "left")
                {
                    Vector3[] corners = new Vector3[4];
                    // [0] bottom-left, [1] top-left, [2] top-right, [3] bottom-right
                    _messageHistory[^1].GetComponent<RectTransform>().GetWorldCorners(corners);
                    float _lastY = _parentTransform.InverseTransformPoint(corners[0]).y;
                    spawnPos = new Vector3(-312, _lastY - _spacing - height, 0);
                } 
                else
                {
                    Debug.LogWarning("String alignment is not right or left. Alignment: " + alignment);
                    return;
                }
            }
            
        }

        newMessageTransform.anchoredPosition = spawnPos;
        _messageHistory.Add(newMessage);

        if (spawnPos.y <= -1071.5) // out of Messages frame
        {
            float newY = _parentTransform.anchoredPosition.y + newMessageTransform.rect.height * newMessageTransform.lossyScale.y * 5f + _spacing;
            _parentTransform.anchoredPosition = new Vector2(_parentTransform.anchoredPosition.x, newY);
        }

        // EventManagerScript.instance.InvokeMessageSent();
    }

    private void StartNewChat()
    {
        foreach (GameObject message in _messageHistory)
        {
            Destroy(message);
        }

        _messageHistory.Clear();
        IsNewChat = true;
        _contactNameTMP.text = names[GamestateManagerScript.instance.profile];
        string knotName = "guy" + (GamestateManagerScript.instance.profile + 1);
        DialogueManagerScript.GetInstance().EnterDialogueMode(knotName);
    }
}

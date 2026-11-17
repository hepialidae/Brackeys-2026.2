using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class MessageManagerScript : MonoBehaviour
{
    [Header("Messaging Settings")]
    [SerializeField] private float _spacing = 0;

    [Header("Components")]
    [SerializeField] private GameObject _messageBox;
    [SerializeField] private TextMeshProUGUI _contactNameTMP;
    [SerializeField] private string[] names;

    [Header("Positions")]
    [SerializeField] private float _highestY;
    [SerializeField] private float _lowestY;
    [SerializeField] private float _maxLeft;
    [SerializeField] private float _maxRight;

    private float _initialLowestY;
    private GameObject _parent;
    private RectTransform _parentTransform;
    public bool IsNewChat { get; private set; } = true;
    private List<GameObject> _messageHistory = new List<GameObject>();
    private Vector3 spawnPos;
    private Vector2 _parentSpawnPos;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _parent = GameObject.Find("Messages"); 
        _parentTransform = _parent.GetComponent<RectTransform>();

        _parentSpawnPos = _parentTransform.anchoredPosition;
        _initialLowestY = _lowestY;
    }

    void OnEnable()
    {
        EventManagerScript.instance.OnSendMessage.AddListener(SpawnMessage);
        EventManagerScript.instance.OnMatch2 += StartNewChat;
        EventManagerScript.instance.stalker2 += StartChatStalker;
    }

    void OnDisable() 
    {
        EventManagerScript.instance.OnSendMessage.RemoveListener(SpawnMessage);
        EventManagerScript.instance.OnMatch2 -= StartNewChat;
        EventManagerScript.instance.stalker2 -= StartChatStalker;
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
                spawnPos = new Vector3(_maxRight, _highestY, 0);
            }
            else
            {
                if (alignment == "left")
                {
                    spawnPos = new Vector3(_maxLeft, _highestY, 0);
                }
                else
                {
                    Debug.LogWarning("String alignment is not right or left. Alignment: " + alignment);
                    Destroy(newMessage);
                    return;
                }
            }
            IsNewChat = false;
        }
        else
        {
            RectTransform oldRectTransform = _messageHistory[^1].GetComponent<RectTransform>();
            float height = 0;

            if (_messageHistory.Count > 0)
            {
                height += oldRectTransform.rect.height * oldRectTransform.localScale.y; // only calculates old one because anchor is top left
            }
            else 
            {
                Debug.LogWarning("Message history is empty while starting an existing chat.");
            }

            if (alignment == "right")
            {
                float _lastY = oldRectTransform.anchoredPosition.y;
                spawnPos = new Vector3(_maxRight, _lastY - _spacing - height, 0);
            }
            else
            {
                if (alignment == "left")
                {
                    float _lastY = oldRectTransform.anchoredPosition.y;
                    spawnPos = new Vector3(_maxLeft, _lastY - _spacing - height, 0);
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

        float messageHeight = newMessageTransform.rect.height * newMessageTransform.localScale.y;

        if (spawnPos.y <= _lowestY)
        {
            float overflow = _lowestY - (spawnPos.y - messageHeight);
            _lowestY -= overflow;

            _parentTransform.anchoredPosition += new Vector2(0f, overflow);
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
        _parentTransform.anchoredPosition = _parentSpawnPos;
        _lowestY = _initialLowestY;
        DialogueManagerScript.GetInstance().EnterDialogueMode(knotName);
    }

    private void StartChatStalker() {
        foreach (GameObject message in _messageHistory)
        {
            Destroy(message);
        }

        _messageHistory.Clear();
        IsNewChat = true;
        _contactNameTMP.text = "???";
        _parentTransform.anchoredPosition = _parentSpawnPos;
        _lowestY = _initialLowestY;
        DialogueManagerScript.GetInstance().EnterDialogueMode("stalker");
    }
}

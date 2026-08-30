using UnityEngine;
using UnityEngine.EventSystems;

public class MessagesIconScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Sprite _normalSprite;
    [SerializeField] private Sprite _hoverSprite;
    private UnityEngine.UI.Button _button;
    private UnityEngine.UI.Image _img;
    [SerializeField] private GameObject _window;

    void Start()
    {
        _img = GetComponent<UnityEngine.UI.Image>();
        _button = GetComponent<UnityEngine.UI.Button>();
        EventManagerScript.instance.OnMatch += OnClick;
        EventManagerScript.instance.stalker += OnClick;

        _button.interactable = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _img.sprite = _hoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _img.sprite = _normalSprite;
    }

    public void OnClick()
    {
        _window.SetActive(true);
        _button.interactable = true;
    }

    public void StartNewChat()
    {
        
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class StatusIconScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Sprite _normalSprite;
    [SerializeField] private Sprite _hoverSprite;
    private UnityEngine.UI.Image _img;
    [SerializeField] private GameObject _window;

    void Start()
    {
        _img = GetComponent<UnityEngine.UI.Image>();
        EventManagerScript.instance.OnNoMatch2 += OpenWindow;
        EventManagerScript.instance.OnEndChat2 += OpenWindow;
        EventManagerScript.instance.OnDateStart2 += ConditionalOpenWindow;
        EventManagerScript.instance.stalker += CloseWindow;
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
        _img.sprite = _normalSprite;
        _window.SetActive(true);
    }

    private void OpenWindow()
    {
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
            _window.SetActive(true);
        }
    }

    private void ConditionalOpenWindow()
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
        if (temp)
        {
            _window.SetActive(true);
        }
    }

    private void CloseWindow()
    {
        _window.SetActive(false);
    }
}

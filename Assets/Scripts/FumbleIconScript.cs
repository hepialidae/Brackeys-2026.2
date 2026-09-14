using UnityEngine;
using UnityEngine.EventSystems;

public class FumbleIconScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Sprite _normalSprite;
    [SerializeField] private Sprite _hoverSprite;
    private UnityEngine.UI.Image _img;
    [SerializeField] private GameObject _window;
    [SerializeField] private GameObject _customization;
    private bool firstTime = true;

    void Start()
    {
        _img = GetComponent<UnityEngine.UI.Image>();

        EventManagerScript.instance.OnSubmitFate += OpenWindow;
        EventManagerScript.instance.OnSubmitFate2 += CloseCustomization;
        EventManagerScript.instance.OnEndChat += OpenWindow;
        EventManagerScript.instance.OnDateEnd += OpenWindow;
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
        if (firstTime)
        {
            _customization.SetActive(true);
            firstTime = false;
        }
        else
        {
            _window.SetActive(true);
        }
    }

    private void OpenWindow()
    {
        _window.SetActive(true);
    }

    private void CloseWindow()
    {
        _window.SetActive(false);
    }

    private void CloseCustomization()
    {
        _customization.SetActive(false);
    }
}

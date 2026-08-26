using UnityEngine;
using UnityEngine.EventSystems;

public class GeneralButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Sprite _normalSprite;
    [SerializeField] private Sprite _hoverSprite;
    private UnityEngine.UI.Image _img;

    void Start()
    {
        _img = GetComponent<UnityEngine.UI.Image>();
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _img.sprite = _hoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _img.sprite = _normalSprite;
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class CustomizationButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private int buttonIndex;
    [SerializeField] private Sprite selected;
    [SerializeField] private Sprite normal;
    [SerializeField] private Sprite hover;
    private UnityEngine.UI.Image _img;
    private bool isSelected = false;

    void Start()
    {
        _img = GetComponent<UnityEngine.UI.Image>();
        EventManagerScript.instance.CustomizationChoice.AddListener(BeClicked);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (!isSelected)
        {
            _img.sprite = hover;
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (!isSelected)
        {
            _img.sprite = normal;
        }
    }

    public void OnClick()
    {
        GamestateManagerScript.instance.designatedProfile = buttonIndex;
        EventManagerScript.instance.InvokeCustomizationChoice(buttonIndex);
    }

    private void BeClicked(int choice)
    {
        if (choice == buttonIndex)
        {
            isSelected = true;
            _img.sprite = selected;
        }
        else
        {
            isSelected = false;
            _img.sprite = normal;
        }
    }
}

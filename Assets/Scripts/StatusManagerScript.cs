using TMPro;
using UnityEngine;

public class StatusManagerScript : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private string[] statuses;
    private UnityEngine.UI.Image _img;
    private TextMeshProUGUI _text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _img = GetComponentInChildren<UnityEngine.UI.Image>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }
}

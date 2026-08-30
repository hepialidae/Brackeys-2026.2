using TMPro;
using UnityEditor.Rendering;
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

        EventManagerScript.instance.OnNoMatch3 += BulletDodged;
        EventManagerScript.instance.OnEndChat3 += BulletDodged;
        EventManagerScript.instance.OnDateStart3 += Date;
    }

    void OnDisable()
    {
        EventManagerScript.instance.OnNoMatch3 -= BulletDodged;
        EventManagerScript.instance.OnEndChat3 -= BulletDodged;
        EventManagerScript.instance.OnDateStart3 -= Date;
    }

    private void BulletDodged()
    {
        Debug.Log("Status BulletDodged");
        _img.sprite = sprites[3];
        _text.text = statuses[3];
    }

    private void Date()
    {
        Debug.Log("Dating");
        int temp = GamestateManagerScript.instance.lastProfile switch
        {
            0 => 0,
            1 => 0,
            2 => 0,
            3 => 0,
            4 => 0,
            5 => 0,
            7 => 2,
            8 => 2,
            9 => 2,
            10 => 1,
            11 => 1,
            12 => 1,
            _ => 99
        };

        if (temp != 99)
        {
            Debug.Log("Setting status content...");
            _img.sprite = sprites[temp];
            _text.text = statuses[temp];
        }
        else
        {
            Debug.Log("No date status issued. Current profile: " + GamestateManagerScript.instance.profile);
        }
    }
}

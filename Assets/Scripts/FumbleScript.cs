using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FumbleScript : MonoBehaviour
{
    [Header("Profile Info")]
    [SerializeField] private Sprite[] images;
    [SerializeField] private string[] namesAges;
    [SerializeField] private string[] bios;
    [SerializeField] private Color[] namesAgesColors;
    [SerializeField] private string[] aboutMes;

    [Header("Components")]
    [SerializeField] private Image _guyImage;
    [SerializeField] private TextMeshProUGUI _nameAgeTMP;
    [SerializeField] private TextMeshProUGUI _bioTMP;
    [SerializeField] private TextMeshProUGUI _aboutMeTMP;
    [SerializeField] private Button _tick;
    [SerializeField] private Button _cross;
    [SerializeField] private Scrollbar _sb;

    void Start()
    {
        EventManagerScript.instance.OnMatch += DisableButtons;
        EventManagerScript.instance.OnNoMatch2 += SetProfile;
        EventManagerScript.instance.OnEndChat += EnableButtons;
        EventManagerScript.instance.OnEndChat2 += SetProfile;

        SetProfile();
    }

    void OnDisable()
    {
        EventManagerScript.instance.OnMatch -= DisableButtons;
        EventManagerScript.instance.OnNoMatch2 -= SetProfile;
    }

    private void SetProfile() 
    {
        int guy = GamestateManagerScript.instance.profile;
        _guyImage.sprite = images[guy];
        _nameAgeTMP.text = namesAges[guy];
        _nameAgeTMP.color = namesAgesColors[guy];
        _bioTMP.text = bios[guy];
        _aboutMeTMP.text = aboutMes[guy];
        _sb.value = 1;
    }

    private void DisableButtons() 
    {
        _tick.interactable = false;
        _cross.interactable = false;
    }

    private void EnableButtons() 
    {
        _tick.interactable = true;
        _cross.interactable = true;
    }
}

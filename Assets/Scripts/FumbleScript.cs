using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FumbleScript : MonoBehaviour
{
    [Header("Profile Info")]
    [SerializeField] private Sprite[] images;
    [SerializeField] private string[] namesAges;
    [SerializeField] private string[] bios;
    [SerializeField] private string[] aboutMes;

    [Header("Components")]
    [SerializeField] private Image _guyImage;
    [SerializeField] private TextMeshProUGUI _nameAgeTMP;
    [SerializeField] private TextMeshProUGUI _bioTMP;
    [SerializeField] private TextMeshProUGUI _aboutMeTMP;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

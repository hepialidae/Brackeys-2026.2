using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;

public class PhotostripScript : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Sprite[] photostrips; // 0: bad, 1: meh, 2: good
    private RectTransform _transform;
    private UnityEngine.UI.Image _img;
    private List<int> badDates = new List<int> { 6, 7, 8 };
    private List<int> mehDates = new List<int> { 9, 10, 11 };
    private List<int> goodDates = new List<int> { 0, 1, 2, 3, 4, 5 };

    void Start()
    {
        _transform = GetComponent<RectTransform>();
        _img = GetComponent<UnityEngine.UI.Image>();
        
        EventManagerScript.instance.OnDateStart2 += Appear;
    }

    private void Appear()
    {
        gameObject.transform.DOKill();
        Vector3 pos = new Vector3(0, -930, 0);
        _transform.anchoredPosition = pos;

        int profile = GamestateManagerScript.instance.lastProfile;
        if (goodDates.Contains(profile))
        {
            _img.sprite = photostrips[2];
        }
        else
        {
            if (mehDates.Contains(profile))
            {
                _img.sprite = photostrips[1];
            }
            else
            {
                if (badDates.Contains(profile))
                {
                    _img.sprite = photostrips[0];
                }
                else
                {
                    Debug.Log("Stalker date, no photostrip.");
                    return;
                }
            }
        }

        gameObject.transform.DOMoveY(400, 0.5f).SetEase(Ease.OutBack);
    }

    public void Disappear()
    {
        gameObject.transform.DOKill();

        Vector3 pos = new Vector3(0, -930, 0);
        _transform.anchoredPosition = pos;
    }
}

using UnityEngine;

public class GlobalPosScript : MonoBehaviour
{
    private RectTransform _rectTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        Debug.Log(_rectTransform.localPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

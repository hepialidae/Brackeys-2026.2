using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways] // Allows it to update inside the Unity Editor scene view
[RequireComponent(typeof(RectTransform))]
public class MessageSizeScript : MonoBehaviour
{
    private RectTransform parentRect;
    [SerializeField] private Scrollbar _scrollbar;

    private void Awake()
    {
        parentRect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        // EventManagerScript.instance.OnMessageSent.AddListener(UpdateSize);
    }

    private void OnDisable()
    {
        // EventManagerScript.instance.OnMessageSent.RemoveListener(UpdateSize);
    }

    public void UpdateSize()
    {
        Debug.Log("In UpdateSize");
        if (transform.childCount == 0) return;

        // Initialize extreme boundary markers
        float minY = float.MaxValue;
        float maxY = float.MinValue;

        int activeChildren = 0;

        // Loop through all direct children
        for (int i = 0; i < transform.childCount; i++)
        {
            RectTransform child = transform.GetChild(i) as RectTransform;

            // Skip inactive children or objects without a RectTransform
            if (child == null || !child.gameObject.activeSelf) 
                continue;

            activeChildren++;

            // Calculate the child's corners relative to the parent local space
            Vector3 childPos = child.localPosition;
            Vector2 childSize = child.rect.size;
            Vector2 childPivot = child.pivot;

            // Determine local corner bounds of the child element
            float childBottom = childPos.y - (childSize.y * childPivot.y);
            float childTop = childPos.y + (childSize.y * (1f - childPivot.y));

            // Track the extreme values
            if (childBottom < minY) minY = childBottom;
            if (childTop > maxY) maxY = childTop;
        }

        if (activeChildren == 0) return;

        // Calculate size of the required bounding box
        float height = maxY - minY;

        // Resize the parent
        parentRect.sizeDelta = new Vector2(parentRect.rect.width, height);

        _scrollbar.value = 0;
    }
}

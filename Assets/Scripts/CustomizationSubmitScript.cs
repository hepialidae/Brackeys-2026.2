using UnityEngine;

public class CustomizationSubmitScript : MonoBehaviour
{
    public void OnClick()
    {
        StartCoroutine(EventManagerScript.instance.InvokeSubmitFate());
    }
}

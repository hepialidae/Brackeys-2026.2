using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{
    public void OnClick()
    {
        StartCoroutine(Clicked());
    }
    private IEnumerator Clicked()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("SampleScene");
    }
}

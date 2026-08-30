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
        AudioManagerScript.instance.Play(AudioManagerScript.instance.click);
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("SampleScene");
    }
}

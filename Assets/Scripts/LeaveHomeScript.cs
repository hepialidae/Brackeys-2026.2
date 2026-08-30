using System.Collections;
using UnityEngine;

public class LeaveHomeScript : MonoBehaviour
{
    private Animator _anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _anim = GetComponent<Animator>();

        EventManagerScript.instance.OnDateStart += StartShowAnim;
    }

    private void StartShowAnim()
    {
        StartCoroutine(ShowAnim());
    }

    private IEnumerator ShowAnim()
    {
        _anim.SetBool("OnDate", true);
        yield return new WaitForSeconds(0.5f);
        _anim.SetBool("OnDate", false);
    }
}

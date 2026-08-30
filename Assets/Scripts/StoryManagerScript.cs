using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class StoryManagerScript : MonoBehaviour
{
    [Header("Timeline Components")]
    [SerializeField] PlayableDirector day1_director;
    [SerializeField] GameObject day1_canvas;
    [SerializeField] PlayableDirector day2_director;
    [SerializeField] GameObject day2_canvas;
    [SerializeField] PlayableDirector day3_director;
    [SerializeField] GameObject day3_canvas;
    [SerializeField] PlayableDirector badEnding_director;
    [SerializeField] GameObject badEnding_canvas;
    [SerializeField] PlayableDirector neutralEnding_director;
    [SerializeField] GameObject neutralEnding_canvas;
    [SerializeField] PlayableDirector goodEnding_director;
    [SerializeField] GameObject goodEnding_canvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (EventManagerScript.instance == null)
        {
            Debug.LogError("EventManagerScript instance is NULL! Check script execution order or scene setup.");
        }
        else if (EventManagerScript.instance.NextDay == null)
        {
            Debug.LogError("NextDay UnityEvent is NULL! Check Unity inspector or event initialization.");
        }
        else
        {
            EventManagerScript.instance.NextDay.AddListener(StartNextDay);
            EventManagerScript.instance.BadEnding += BadEnding;
            EventManagerScript.instance.NeutralEnding += NeutralEnding;
            EventManagerScript.instance.GoodEnding += GoodEnding;
        }

        day2_canvas.SetActive(false);
        day3_canvas.SetActive(false);
        
        StartCoroutine(StartDay1());
    }

    private IEnumerator StartDay1()
    {
        day1_canvas.SetActive(true);
        day1_director.Play();
        yield return new WaitForSeconds(2.5f);
        day1_canvas.SetActive(false);
    }

    private void StartNextDay(int day)
    {
        StartCoroutine(NextDay(day));
    }

    private IEnumerator NextDay(int day)
    {
        if (day == 2)
        {
            day2_canvas.SetActive(true);
            day2_director.Play();
            yield return new WaitForSeconds(2.5f);
            day2_canvas.SetActive(false);
        }
        else
        {
            if (day == 3)
            {
                day3_canvas.SetActive(true);
                day3_director.Play();
                yield return new WaitForSeconds(2.5f);
                day3_canvas.SetActive(false);
            }
        }
    }

    private void BadEnding()
    {
        badEnding_canvas.SetActive(true);
        badEnding_director.Play();
        switch (GamestateManagerScript.instance.day)
        {
            case 1:
                AudioManagerScript.instance.Stop(AudioManagerScript.instance.day1);
                break;
            case 2:
                AudioManagerScript.instance.Stop(AudioManagerScript.instance.day2);
                break;
            case 3:
                AudioManagerScript.instance.Stop(AudioManagerScript.instance.day3);
                break;
            default:
                AudioManagerScript.instance.Stop(AudioManagerScript.instance.click);
                break;
        };
        AudioManagerScript.instance.Play(AudioManagerScript.instance.scream);
    }

    private void NeutralEnding()
    {
        neutralEnding_canvas.SetActive(true);
        neutralEnding_director.Play();
        AudioManagerScript.instance.FadeOut(AudioManagerScript.instance.day3, 0.1f);
        AudioManagerScript.instance.FadeIn(AudioManagerScript.instance.neutralEnding, 0.3f);
    }

    private void GoodEnding()
    {
        goodEnding_canvas.SetActive(true);
        goodEnding_director.Play();
        switch (GamestateManagerScript.instance.day)
        {
            case 1:
                AudioManagerScript.instance.FadeOut(AudioManagerScript.instance.day1, 0.1f);
                break;
            case 2:
                AudioManagerScript.instance.FadeOut(AudioManagerScript.instance.day2, 0.1f);
                break;
            case 3:
                AudioManagerScript.instance.FadeOut(AudioManagerScript.instance.day3, 0.1f);
                break;
            default:
                AudioManagerScript.instance.Stop(AudioManagerScript.instance.click);
                break;
        };
        AudioManagerScript.instance.FadeIn(AudioManagerScript.instance.goodEnding, 0.3f);
    }
}

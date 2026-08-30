using UnityEngine;
using System.Collections;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript instance;
    [SerializeField] public AudioSource day1; // done
    [SerializeField] public AudioSource day2; // done
    [SerializeField] public AudioSource day3; // done
    [SerializeField] public AudioSource goodEnding; // done
    [SerializeField] public AudioSource neutralEnding; // done
    [SerializeField] public AudioSource stalker; 
    [SerializeField] public AudioSource click; // done
    [SerializeField] public AudioSource photoPrint; // done
    [SerializeField] public AudioSource scream; // done
    [SerializeField] public AudioSource whoosh; // done

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of EventManagerScript found.");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        EventManagerScript.instance.NextDay.AddListener(NextDay);
        EventManagerScript.instance.stalker += Stalker;

        FadeIn(day1, 0.3f);
    }

    public void Play(AudioSource audio)
    {
        audio.volume = 1;
        audio.Play();
    }

    public void Stop(AudioSource audio)
    {
        audio.Stop();
    }

    public void FadeOut(AudioSource audio, float fadeDuration)
    {
        StartCoroutine(FadeOutCoroutine(audio, fadeDuration));
    }

    public void FadeIn(AudioSource audio, float fadeDuration)
    {
        StartCoroutine(FadeInCoroutine(audio, fadeDuration));
    }

    private void Stalker()
    {
        StartCoroutine(FadeOutCoroutine(day1, 0.1f));
        StartCoroutine(FadeInCoroutine(stalker, 0.3f));
    }

    private void NextDay(int day)
    {
        if (day == 2)
        {
            StartCoroutine(FadeOutCoroutine(stalker, 0.2f));
            StartCoroutine(FadeInCoroutine(day2, 0.5f));
        }
        else
        {
            if (day == 3)
            {
                StartCoroutine(FadeOutCoroutine(day2, 0.2f));
                StartCoroutine(FadeInCoroutine(day3, 0.5f));
            }
        }
    }

    private IEnumerator FadeInCoroutine(AudioSource audioSource, float fadeDuration)
    {
        float startVolume = audioSource.volume;

        float time = 0;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 1, time / fadeDuration);
            yield return null;
        }

        audioSource.volume = 1;
    }

    private IEnumerator FadeOutCoroutine(AudioSource audioSource, float fadeDuration)
    {
        float startVolume = audioSource.volume;

        float time = 0;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0, time / fadeDuration);
            yield return null;
        }

        audioSource.volume = 0;
        audioSource.Stop(); 
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class GamestateManagerScript : MonoBehaviour
{
    public static GamestateManagerScript instance;
    public int day { get; private set; } = 1;
    public int profile { get; private set; }
    public int lastProfile { get; private set; }
    public int rejectCount { get; private set; } = 0;
    private int[] day1_guys = new int[6];
    private int[] day2_guys = new int[6];
    private int[] day3_guys = new int[6]; 

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of GamestateManagerScript found.");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        SetProfileOrder();
        
        EventManagerScript.instance.OnNoMatch += NextGuy;
        EventManagerScript.instance.OnNoMatch += AddRejection;
        EventManagerScript.instance.OnEndChat += NextGuy;
        EventManagerScript.instance.OnEndChat += AddRejection;
        EventManagerScript.instance.OnDateStart += NextGuy;
    }

    void OnDisable()
    {
        EventManagerScript.instance.OnNoMatch -= NextGuy;
        EventManagerScript.instance.OnNoMatch -= AddRejection;
        EventManagerScript.instance.OnEndChat -= NextGuy;
        EventManagerScript.instance.OnEndChat -= AddRejection;
        EventManagerScript.instance.OnDateStart -= NextGuy;
    }

    public void NextDay()
    {
        day += 1;
    }

    public void AddRejection()
    {
        rejectCount += 1;
    }

    public int GetProfileIndex(int profile)
    {
        int output = day switch
        {
            1 => Array.IndexOf(day1_guys, profile),
            2 => Array.IndexOf(day2_guys, profile),
            3 => Array.IndexOf(day3_guys, profile),
            _ => 99
        };

        if (output == 99)
        {
            Debug.LogWarning("Day is something other than 1-3. Day: " + day);
        }

        return output;
    }

    public void NextGuy()
    {
        lastProfile = profile;
        int profileIndex = GetProfileIndex(profile);
        if (profileIndex <= 5)
        {
            profile = day switch
            {
                1 => day1_guys[profileIndex + 1],
                2 => day2_guys[profileIndex + 1],
                3 => day3_guys[profileIndex + 1],
                _ => 99
            };
        }

        if (profile == 99)
        {
            Debug.LogWarning("Day is something other than 1-3. Day: " + day);
        }
    }

    public void Shuffle<T>(T[] list)
    {
        // Loop from the last element down to the second element
        for (int i = list.Length - 1; i > 0; i--)
        {
            // Pick a random index from 0 to i
            int randomIndex = UnityEngine.Random.Range(0, i + 1);

            // Swap the elements
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    private void SetProfileOrder()
    {
        List<int> good_guys = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        List<int> bad_guys = new List<int> { 12, 13, 14, 15, 16, 17 };

        // Day 1
        for (int i = 0; i < 6; i++)
        {
            if (i == 0)
            {
                int guy = UnityEngine.Random.Range(0, bad_guys.Count);
                day1_guys[i] = bad_guys[guy];
                bad_guys.RemoveAt(guy);
            }
            else
            {
                int guy = UnityEngine.Random.Range(0, good_guys.Count);
                day1_guys[i] = good_guys[guy];
                good_guys.RemoveAt(guy);
            }
        }

        // Day 2
        for (int j = 0; j < 6; j++)
        {
            if (j == 0 || j == 1)
            {
                int guy = UnityEngine.Random.Range(0, bad_guys.Count);
                day2_guys[j] = bad_guys[guy];
                bad_guys.RemoveAt(guy);
            }
            else
            {
                int guy = UnityEngine.Random.Range(0, good_guys.Count);
                day2_guys[j] = good_guys[guy];
                good_guys.RemoveAt(guy);
            }
        }

        // Day 3
        for (int k = 0; k < 6; k++)
        {
            if (k == 0 || k == 1 || k == 2)
            {
                int guy = UnityEngine.Random.Range(0, bad_guys.Count);
                day3_guys[k] = bad_guys[guy];
                bad_guys.RemoveAt(guy);
            }
            else
            {
                int guy = UnityEngine.Random.Range(0, good_guys.Count);
                day3_guys[k] = good_guys[guy];
                good_guys.RemoveAt(guy);
            }
        }

        Shuffle<int>(day1_guys);
        Shuffle<int>(day2_guys);
        Shuffle<int>(day3_guys);

        profile = day1_guys[0];
    }
}

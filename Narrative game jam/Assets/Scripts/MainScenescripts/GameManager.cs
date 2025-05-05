using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum Mask { Friendly = 0, Cold = 1, Manipulative = 2 }

    public int reputation = 50;
    public int suspicion = 20;
    public int day = 1;
    public Mask currentMask;

    public List<EventData> events = new List<EventData>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SelectMask(int maskIndex)
    {
        currentMask = (Mask)maskIndex;
        // Optional initial stat boost based on mask
        if (maskIndex == 0) { reputation += 5; suspicion += 2; }
        if (maskIndex == 1) { reputation += 2; }
        if (maskIndex == 2) { suspicion += 5; }

        UIController.Instance.ShowEvent(events[day - 1]);
    }

    public void MakeChoice(int optionIndex)
    {
        EventData currentEvent = events[day - 1];
        int maskIndex = (int)currentMask;

        reputation += currentEvent.GetRepChange(maskIndex, optionIndex);
        suspicion += currentEvent.GetSuspChange(maskIndex, optionIndex);

        UIController.Instance.ShowSummary();
    }

    public void NextDay()
    {
        day++;
        if (day > events.Count)
        {
            UIController.Instance.ShowEnd();
        }
        else
        {
            UIController.Instance.ShowMaskSelection();
        }
    }
}

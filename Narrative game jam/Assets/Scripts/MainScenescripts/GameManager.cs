using NUnit.Framework;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int reputation = 50, suspicion = 20, day = 1;
    public enum Mask { Friendly,Cold,Manipulative}
    public Mask currentMask;
    //public List<EventData> dayEvents;

    private void Awake()
    {
        Instance = this;
    }

    public void NextDay()
    {
        day++;
        if (day > 7)
        {
            UIController.Instance.ShowEndGame();
        }
        else
        {
            UIController.Instance.ShowMaskSelection();
        }
    }
}

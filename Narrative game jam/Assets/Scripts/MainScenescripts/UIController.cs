using UnityEditor.Search;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    public GameObject maskSelectionPanel;
    public GameObject EventPanel;
    public GameObject summaryPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowMaskSelection()
    {
        
    }

    public void ShowEvent()
    {

    }

    public void ShowSummary()
    {

    }
    public void ShowEndGame()
    {

    }
}

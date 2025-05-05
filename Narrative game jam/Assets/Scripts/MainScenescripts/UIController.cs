using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [Header("Panels")]
    public GameObject maskPanel;
    public GameObject eventPanel;
    public GameObject summaryPanel;
    public GameObject endPanel;

    [Header("Event UI")]
    public TMP_Text promptText;
    public Button[] optionButtons;
    public TMP_Text[] optionTexts;

    [Header("Summary UI")]
    public TMP_Text summaryText;
    public Slider repSlider;
    public Slider suspSlider;

    [Header("End UI")]
    public TMP_Text endText;

    public TMP_Text dayCounterText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void ShowMaskSelection()
    {
        maskPanel.SetActive(true);
        eventPanel.SetActive(false);
        summaryPanel.SetActive(false);
        endPanel.SetActive(false);

        dayCounterText.text = "Day " + GameManager.Instance.day + "/" + GameManager.Instance.events.Count;
    }

    public void ShowEvent(EventData e)
    {
        maskPanel.SetActive(false);
        eventPanel.SetActive(true);
        summaryPanel.SetActive(false);

        promptText.text = e.prompt;

        for (int i = 0; i < 3; i++)
        {
            int index = i;
            optionTexts[i].text = e.options[i];
            optionButtons[i].onClick.RemoveAllListeners();
            optionButtons[i].onClick.AddListener(() => GameManager.Instance.MakeChoice(index));
        }
    }

    public void ShowSummary()
    {
        maskPanel.SetActive(false);
        eventPanel.SetActive(false);
        summaryPanel.SetActive(true);

        repSlider.value = GameManager.Instance.reputation / 100f;
        suspSlider.value = GameManager.Instance.suspicion / 100f;

        summaryText.text = $"Day {GameManager.Instance.day} Results:\n" +
                           $"Reputation: {GameManager.Instance.reputation}\n" +
                           $"Suspicion: {GameManager.Instance.suspicion}";
    }

    public void ShowEnd()
    {
        maskPanel.SetActive(false);
        eventPanel.SetActive(false);
        summaryPanel.SetActive(false);
        endPanel.SetActive(true);

        string result = "You survived the elite academy.";

        if (GameManager.Instance.suspicion >= 80)
            result = "Your lies were exposed. You've been expelled.";
        else if (GameManager.Instance.reputation <= 20)
            result = "No one trusted you. You faded into obscurity.";

        endText.text = result;
    }
}

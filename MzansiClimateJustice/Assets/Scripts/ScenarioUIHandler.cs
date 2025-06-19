using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScenarioUIHandler : MonoBehaviour
{
    public static ScenarioUIHandler Instance;

    public GameObject scenarioPanel;
    public TMP_Text[] textSlots; // Should be 3 in the Inspector
    public Button yesButton;
    public Button noButton;

    private System.Action yesCallback;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowScenario(Scenario scenario, Province province, System.Action onYes)
    {
        yesCallback = onYes;

        // Activate UI
        scenarioPanel.SetActive(true);


        Debug.Log(scenario.scenario);
        // Populate the scenario text
        textSlots[0].text = scenario.scenario;
        textSlots[1].text = scenario.character;
        textSlots[2].text = scenario.characterDialogue;

        // Set up buttons
        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();

        yesButton.onClick.AddListener(() => {
            yesCallback?.Invoke();
            scenarioPanel.SetActive(false);
            province.ScenarioOutcome(scenario, true);
        });

        noButton.onClick.AddListener(() => {
            scenarioPanel.SetActive(false);
            province.ScenarioOutcome(scenario, false);
        });
    }
}

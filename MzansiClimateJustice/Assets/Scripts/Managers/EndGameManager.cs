using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private float co2Levels;
    [SerializeField] private float energyLevels;
    [SerializeField] private float populationSatisfactionLevels;
    [SerializeField] private float gdpLevels;
    [SerializeField] private float ecologicalFootprintLevels;

    public Outcomes CO2Outcome;
    public Outcomes EnergyOutcome;
    public Outcomes GdpOutcome;
    public Outcomes EcologicalFootprintOutcome;
    public Outcomes PopSatOutcome;

    public TextMeshProUGUI co2Text;
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI populationText;
    public TextMeshProUGUI gdpText;
    public TextMeshProUGUI footprintText;

    private void Awake()
    {
        co2Levels = PlayerPrefs.GetFloat("CO2");
        energyLevels = PlayerPrefs.GetFloat("Energy");
        populationSatisfactionLevels = PlayerPrefs.GetFloat("PopSat");
        gdpLevels = PlayerPrefs.GetFloat("GDP");
        ecologicalFootprintLevels = PlayerPrefs.GetFloat("Footprint");

        SetOutcomes();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void SetOutcomes()
    {
        if (co2Levels <= 40)
        {
            co2Text.text = CO2Outcome.Good;
        }
        else if (co2Levels > 40 && co2Levels <= 120)
        {
            co2Text.text = CO2Outcome.Average;
        }
        else
        {
            co2Text.text = CO2Outcome.Bad;
        }

        if (energyLevels < 150)
        {
            energyText.text = EnergyOutcome.Bad;
        }
        else if (energyLevels >= 150 && energyLevels > 250)
        {
            energyText.text= EnergyOutcome.Average;
        }
        else
        {
            energyText.text = EnergyOutcome.Good;
        }

        if (populationSatisfactionLevels < 0)
        {
            populationText.text = PopSatOutcome.Bad;
        }
        else if (populationSatisfactionLevels >=0 && populationSatisfactionLevels < 50)
        {
            populationText.text = PopSatOutcome.Average;
        }
        else
        {
            populationText.text = PopSatOutcome.Good;
        }

        if (gdpLevels < 0)
        {
            gdpText.text = GdpOutcome.Bad;
        }
        else if (gdpLevels >=0 && gdpLevels < 100)
        {
            gdpText.text = GdpOutcome.Average;
        }
        else
        {
            gdpText.text = GdpOutcome.Good;
        }

        if (ecologicalFootprintLevels <= 20)
        {
            footprintText.text = EcologicalFootprintOutcome.Good;
        }
        else if (ecologicalFootprintLevels > 20 && ecologicalFootprintLevels < 85)
        {
            footprintText.text= EcologicalFootprintOutcome.Average;
        }
        else
        {
            footprintText.text = EcologicalFootprintOutcome.Bad;
        }

    }
}

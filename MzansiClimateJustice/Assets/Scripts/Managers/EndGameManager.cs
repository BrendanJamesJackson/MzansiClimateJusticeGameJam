using UnityEngine;

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

    private void Awake()
    {
        co2Levels = PlayerPrefs.GetFloat("CO2");
        energyLevels = PlayerPrefs.GetFloat("Energy");
        populationSatisfactionLevels = PlayerPrefs.GetFloat("PopSat");
        gdpLevels = PlayerPrefs.GetFloat("GDP");
        ecologicalFootprintLevels = PlayerPrefs.GetFloat("Footprint");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetOutcomes()
    {

    }
}

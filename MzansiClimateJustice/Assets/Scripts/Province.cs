using UnityEngine;
using System.Collections.Generic;

public class Province : MonoBehaviour
{
    public GameManager gm;

    public enum ProvinceName
    {
        NorthernCape,
        Mpumalanga,
        KwaZuluNatal,
        WesternCape,
        Gauteng,
        FreeState,
        NorthWest,
        EasternCape,
        Limpopo
    }

    public ProvinceName provinceName;
    [SerializeField] private float co2LevelsProvince;
    [SerializeField] private float energyLevelsProvince;
    [SerializeField] private float populationSatisfactionLevelsProvince;
    [SerializeField] private float gdpLevelsProvince;
    [SerializeField] private float ecologicalFootprintLevelsProvince;

    public List<HexTile> tiles;

    public Scenario[] scenarios;
    public bool[] scenarioResolved;

    public void Awake()
    {
        tiles.AddRange(GetComponentsInChildren<HexTile>());
        /*for (int i = 0; i < scenarios.Length; i++)
        {
            scenarioResolved[i] = false;
        }*/
    }

    public Scenario CheckScenarioAvailable(PowerStation.PowerType type)
    {
        for (int i = 0;i < scenarios.Length; i++)
        {
            if ((type == scenarios[i].triggerType1 || type == scenarios[i].triggerType2) && scenarioResolved[i] == false && scenarios[i].action == Scenario.Action.Build)
            {
                scenarioResolved[i] = true;
                return scenarios[i];
            }
        }
        return null;
    }

    

    public void SelectTiles()
    {
        foreach (HexTile tile in tiles)
        {
            tile.gameObject.GetComponent<SelectTile>().Select();
        }
    }

    public void DeSelectTiles()
    {
        foreach (HexTile tile in tiles)
        {
            tile.gameObject.GetComponent<SelectTile>().DeSelect();
        }
    }

    public void BuildProvince(float co2, float energy, float popSat, float gdp, float footprint)
    {
        co2LevelsProvince += co2;
        energyLevelsProvince += energy;
        populationSatisfactionLevelsProvince += popSat;
        gdpLevelsProvince += gdp;
        ecologicalFootprintLevelsProvince += footprint;
    }

    public void ScenarioOutcome(Scenario scenario, bool choseYes)
    {
        if (choseYes)
        {
            populationSatisfactionLevelsProvince -= scenario.popSatImpact;
            gm.setPopSatLevels(-scenario.popSatImpact);

        }
        else
        {
            populationSatisfactionLevelsProvince += scenario.popSatImpact;
            gm.setPopSatLevels(scenario.popSatImpact);
        }
    }
}

using UnityEngine;

public class HexTile : MonoBehaviour
{
    public bool isBuildable = false;
    public bool isOccupied = false;
    public bool isWater = false;
    public Transform buildingAnchorLocation;
    public Province province;

    private void Awake()
    {
        province = GetComponentInParent<Province>();
    }

    public void PlaceBuilding(GameObject buildingPrefab)
    {
        if (isOccupied)
        {
            return;
        }

        if (isWater && buildingPrefab.tag != "Wind")
        {
            return;
        }

        Scenario tempScenario = province.CheckScenarioAvailable(buildingPrefab.GetComponent<PowerStation>().stationType);
        if (tempScenario == null)
        {
            GameObject temp = Instantiate(buildingPrefab, buildingAnchorLocation.position, Quaternion.Euler(0,180,0));
            temp.GetComponent<PowerStation>().Build();
            PowerStation tempStation = temp.GetComponent<PowerStation>();
            province.BuildProvince(tempStation.co2Amount,tempStation.energyAmount,tempStation.satisfactionImpact,tempStation.cost,tempStation.footprintAmount);
            isOccupied = true;
        }
        else if (tempScenario.action == Scenario.Action.Build)
        {
            PresentScenario(tempScenario, buildingPrefab, province);
        }

        
    }

    public void PresentScenario(Scenario scenario, GameObject buildingPrefab, Province province)
    {
        
        ScenarioUIHandler.Instance.ShowScenario(scenario, province, () => {
            GameObject temp = Instantiate(buildingPrefab, buildingAnchorLocation.position, Quaternion.Euler(0, 180, 0));
            temp.GetComponent<PowerStation>().Build();
            PowerStation tempStation = temp.GetComponent<PowerStation>();
            province.BuildProvince(tempStation.co2Amount, tempStation.energyAmount, tempStation.satisfactionImpact, tempStation.cost, tempStation.footprintAmount);
            isOccupied = true;
        });
    }
}

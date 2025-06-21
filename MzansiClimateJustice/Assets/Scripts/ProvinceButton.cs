using UnityEngine;
using TMPro;

public class ProvinceButton : MonoBehaviour
{

    public Province province;
    public GameObject provincePanel;

    public TextMeshProUGUI textCO2;
    public TextMeshProUGUI textEnergy;
    public TextMeshProUGUI textPopSat;
    public TextMeshProUGUI textGDP;
    public TextMeshProUGUI textFootprint;

    public bool isShowing = false;

    public void ShowPanel()
    {
        if (!isShowing)
        {
            UpdateData();
            provincePanel.SetActive(true);
            isShowing = true;
            province.SelectTiles();
        }
        else if (isShowing)
        {
            provincePanel.SetActive(false);
            isShowing = false;
            province.DeSelectTiles();
        }
    }

    public void UpdateData()
    {
        textCO2.text = $"CO2 Levels: {province.co2LevelsProvince}";
        textEnergy.text = $"Energy Levels: {province.energyLevelsProvince}";
        textPopSat.text = $"Population Satisfaction: {province.populationSatisfactionLevelsProvince}";
        textGDP.text = $"GDP: {province.gdpLevelsProvince}";
        textFootprint.text = $"Ecological Footprint: {province.ecologicalFootprintLevelsProvince}";
    }
}

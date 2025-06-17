using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float co2Levels;
    [SerializeField] private float energyLevels;
    [SerializeField] private float populationSatisfactionLevels;
    [SerializeField] private float gdpLevels;
    [SerializeField] private float ecologicalFootprintLevels;

    public TextMeshProUGUI co2Tag;
    public TextMeshProUGUI energyTag;
    public TextMeshProUGUI popTag;
    public TextMeshProUGUI gdpTag;
    public TextMeshProUGUI footTag;

    private void Awake()
    {
        InitialSet();
    }

    public void InitialSet()
    {
        co2Tag.text = $"CO2 Levels: {co2Levels}";
        energyTag.text = $"Energy Levels: {energyLevels}";
        popTag.text = $"Population Satisfaction Levels: {populationSatisfactionLevels}";
        gdpTag.text = $"GDP: {gdpLevels}";
        footTag.text = $"Ecological Footprint: {ecologicalFootprintLevels}";

    }

    public void setCO2(float amount)
    {
        co2Levels += amount;
        co2Tag.text = $"CO2 Levels: {co2Levels}";
    }

    public float getCO2()
    {
        return co2Levels;
    }

    public void setEnergy(float amount)
    {
        energyLevels += amount;
        energyTag.text = $"Energy Levels: {energyLevels}";
    }

    public float getEnergy()
    {
        return energyLevels;
    }

    public void setPopSatLevels(float amount)
    {
        populationSatisfactionLevels += amount;
        popTag.text = $"Population Satisfaction Levels: {populationSatisfactionLevels}";
    }

    public float getPopSatLevels()
    {
        return populationSatisfactionLevels;
    }

    public void setGDPLevels(float amount)
    {
        gdpLevels += amount;
        gdpTag.text = $"GDP: {gdpLevels}";
    }

    public float getGDPLevels()
    {
        return gdpLevels;
    }

    public void setEcoFootprintLevels(float amount)
    {
        ecologicalFootprintLevels += amount;
        footTag.text = $"Ecological Footprint: {ecologicalFootprintLevels}";
    }

    public float getEcoFootprintLevels()
    {
        return ecologicalFootprintLevels;
    }

}

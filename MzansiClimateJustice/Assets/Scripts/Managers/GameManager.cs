using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float co2Levels;
    [SerializeField] private float energyLevels;
    [SerializeField] private float populationSatisfactionLevels;
    [SerializeField] private float gdpLevels;
    [SerializeField] private float ecologicalFootprintLevels;

    public void setCO2(float amount)
    {
        co2Levels += amount;
    }

    public float getCO2()
    {
        return co2Levels;
    }

    public void setEnergy(float amount)
    {
        energyLevels += amount;
    }

    public float getEnergy()
    {
        return energyLevels;
    }

    public void setPopSatLevels(float amount)
    {
        populationSatisfactionLevels += amount;
    }

    public float getPopSatLevels()
    {
        return populationSatisfactionLevels;
    }

    public void setGDPLevels(float amount)
    {
        gdpLevels += amount;
    }

    public float getGDPLevels()
    {
        return gdpLevels;
    }

    public void setEcoFootprintLevels(float amount)
    {
        ecologicalFootprintLevels += amount;
    }

    public float getEcoFootprintLevels()
    {
        return ecologicalFootprintLevels;
    }

}

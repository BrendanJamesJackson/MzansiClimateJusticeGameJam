using NUnit.Framework;
using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float co2Levels;
    public const float Maxco2 = 900;
    [SerializeField] private float energyLevels;
    [SerializeField] private float populationSatisfactionLevels;
    [SerializeField] private float gdpLevels = 325;
    [SerializeField] private float ecologicalFootprintLevels;

    public TextMeshProUGUI co2Tag;
    public TextMeshProUGUI energyTag;
    public TextMeshProUGUI popTag;
    public TextMeshProUGUI gdpTag;
    public TextMeshProUGUI footTag;

    public ParticleSystem fog;

    public List<HexTile> tiles;
    public GameObject coalPrefab;


    public float gdpGrowthRate = 2.0f; // GDP per in-game month
     // since 1 month = 20 real seconds

    private void Awake()
    {
        tiles.AddRange(FindObjectsByType<HexTile>(FindObjectsSortMode.None));

        SetupRandomCoal();

        InitialSet();
    }

    void SetupRandomCoal()
    {
        List<HexTile> buildableTiles = tiles.Where(tile => tile.isBuildable).ToList();
        List<HexTile> selectedTiles = buildableTiles.OrderBy(t => Random.value).Take(15).ToList();

        foreach (HexTile tile in selectedTiles)
        {
            tile.SetupPlaceCoal(coalPrefab);
        }
    }

    public void Update()
    {
        var fogMain = fog.main;

        // Safely get and modify the color if it's in Color mode
        if (fogMain.startColor.mode == ParticleSystemGradientMode.Color)
        {
            Color baseColor = fogMain.startColor.color;
            baseColor.a = Mathf.Clamp01(co2Levels / Maxco2); // Clamp to avoid over/under values
            fogMain.startColor = new ParticleSystem.MinMaxGradient(baseColor);
        }

        float gdpPerSecond = gdpGrowthRate / 20f;
        gdpLevels += gdpPerSecond * Time.deltaTime;
        gdpTag.text = $"GDP: {gdpLevels}";

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

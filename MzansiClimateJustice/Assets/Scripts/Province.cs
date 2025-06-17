using UnityEngine;
using System.Collections.Generic;

public class Province : MonoBehaviour
{
    public string nameProvince;
    [SerializeField] private float co2LevelsProvince;
    [SerializeField] private float energyLevelsProvince;
    [SerializeField] private float populationSatisfactionLevelsProvince;
    [SerializeField] private float gdpLevelsProvince;
    [SerializeField] private float ecologicalFootprintLevelsProvince;

    public List<HexTile> tiles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

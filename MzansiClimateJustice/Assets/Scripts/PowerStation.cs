using UnityEngine;

public class PowerStation : MonoBehaviour
{
    public enum PowerType
    {
        Coal,
        Solar,
        Wind,
        Nuclear,
        None
    }

    public PowerType stationType;

    public float co2Amount;
    public float energyAmount;
    public float cost;
    public float satisfactionImpact;
    public float footprintAmount;

    private GameManager gm;

    public void Awake()
    {
        gm = GameObject.FindFirstObjectByType<GameManager>();
    }

    public void Build()
    {
        gm.setCO2(co2Amount);
        gm.setEnergy(energyAmount);
        gm.setGDPLevels(cost);
        gm.setPopSatLevels(satisfactionImpact);
        gm.setEcoFootprintLevels(footprintAmount);
    }

    public void Decommission()
    {

    }

}

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

    private void OnMouseDown()
    {
        BuildingRemovalManager.Instance.RequestRemoval(this);
    }

    public void RemoveBuilding()
    {

        gm.setCO2(-co2Amount);
        gm.setEnergy(-energyAmount);
        gm.setGDPLevels(-cost/2);
        gm.setPopSatLevels(-satisfactionImpact/2);
        gm.setEcoFootprintLevels(-footprintAmount/2);

        Province prov = GetComponentInParent<Province>();
        prov.RemoveProvince(co2Amount,energyAmount,satisfactionImpact,cost,footprintAmount);

        Destroy(gameObject);
    }

}

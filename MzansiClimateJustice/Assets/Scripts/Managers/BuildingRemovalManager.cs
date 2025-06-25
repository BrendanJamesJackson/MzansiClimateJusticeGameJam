using UnityEngine;
using UnityEngine.UIElements;

public class BuildingRemovalManager : MonoBehaviour
{

    public static BuildingRemovalManager Instance;

    public GameObject confirmPanel;
    private PowerStation targetBuilding;


    void Awake()
    {
        Instance = this;
    }

    public void RequestRemoval(PowerStation building)
    {
        targetBuilding = building;
        confirmPanel.SetActive(true);
    }

    public void ConfirmRemoval()
    {
        if (targetBuilding != null)
        {
            targetBuilding.RemoveBuilding();
            targetBuilding = null;
        }
        confirmPanel.SetActive(false);
    }

    public void CancelRemoval()
    {
        targetBuilding = null;
        confirmPanel.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

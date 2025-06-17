using UnityEngine;

public class HexTile : MonoBehaviour
{
    public bool isOccupied = false;
    public Transform buildingAnchorLocation;

    public void PlaceBuilding(GameObject buildingPrefab)
    {
        if (isOccupied)
        {
            return;
        }

        GameObject temp = Instantiate(buildingPrefab, buildingAnchorLocation.position, Quaternion.Euler(0,180,0));
        temp.GetComponent<PowerStation>().Build();
        isOccupied = true;
    }
}

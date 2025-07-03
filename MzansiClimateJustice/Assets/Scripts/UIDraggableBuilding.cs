using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UIDraggableBuilding : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject buildingPrefab;
    private GameObject dragIcon;
    private Canvas canvas;


    public GameObject infoPanel;
    public TextMeshProUGUI[] text;

    private SelectTile lastSelected = null;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void ShowInfo()
    {
        infoPanel.SetActive(!infoPanel.activeSelf);
        text[0].text = $"{buildingPrefab.GetComponent<PowerStation>().co2Amount}";
        text[1].text = $"{buildingPrefab.GetComponent<PowerStation>().energyAmount}";
        text[2].text = $"{buildingPrefab.GetComponent<PowerStation>().cost}";
        text[3].text = $"{buildingPrefab.GetComponent<PowerStation>().satisfactionImpact}";
        text[4].text = $"{buildingPrefab.GetComponent<PowerStation>().footprintAmount}";
    }

    

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragIcon = new GameObject("DragIcon");
        dragIcon.transform.SetParent(canvas.transform);
        dragIcon.transform.SetAsLastSibling();

        Image image = dragIcon.AddComponent<Image>();
        image.sprite = GetComponent<Image>().sprite;
        image.SetNativeSize();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragIcon != null)
        {
            RectTransform rt = dragIcon.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(128, 128);
            rt.position = Input.mousePosition;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            HexTile tile = hit.collider.GetComponent<HexTile>();
            SelectTile currentTile = hit.collider.GetComponent<SelectTile>();


            if (tile != null && !tile.isOccupied && tile.isBuildable)
            {
                if (lastSelected != null && lastSelected != currentTile)
                {
                    lastSelected.DeSelect();
                }
                
                if (currentTile != null && lastSelected != currentTile)
                {
                    currentTile.Select();
                    lastSelected = currentTile;
                }
                    
            }
            else
            {
                if (lastSelected != null)
                {
                    lastSelected.DeSelect();
                    lastSelected = null;
                }
            }
        }
        else
        {
            if (lastSelected != null)
            {
                lastSelected.DeSelect();
                lastSelected = null;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragIcon != null)
        {
            Destroy(dragIcon);
        }

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                HexTile tile = hit.collider.GetComponent<HexTile>();
                if (tile != null && !tile.isOccupied)
                {
                    tile.PlaceBuilding(buildingPrefab);
                    hit.collider.GetComponent <SelectTile>().DeSelect();
                }
            }
        }

        if (lastSelected != null)
        {
            lastSelected.DeSelect();
            lastSelected = null;
        }

    }
}

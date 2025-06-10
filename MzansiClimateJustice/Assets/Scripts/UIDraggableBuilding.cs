using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDraggableBuilding : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject buildingPrefab;
    private GameObject dragIcon;
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
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
                }
            }
        }
    }
}

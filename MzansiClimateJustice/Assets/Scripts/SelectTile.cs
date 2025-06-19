using UnityEngine;

public class SelectTile : MonoBehaviour
{
    public Material original;
    public Material selected;

    public void Select()
    {
        original = this.GetComponent<MeshRenderer>().material;
        this.GetComponent<MeshRenderer>().material = selected;
    }

    public void DeSelect()
    {
        this.GetComponent<MeshRenderer>().material = original;
    }
}

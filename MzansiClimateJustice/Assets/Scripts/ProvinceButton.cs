using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProvinceButton : MonoBehaviour
{

    public Province province;
    public GameObject provincePanel;

    public TextMeshProUGUI textCO2;
    public TextMeshProUGUI textEnergy;
    public TextMeshProUGUI textPopSat;
    public TextMeshProUGUI textGDP;
    public TextMeshProUGUI textFootprint;

    public bool isShowing = false;

    public Image Card;

    public Sprite CardSprite;

    public DeselectProvince Deselect;

    public GameObject provinceInfo;

    public void ShowPanel()
    {
        if (!isShowing)
        {
            UpdateData();
            provincePanel.SetActive(true);
            provinceInfo.SetActive(true);
            isShowing = true;
            province.SelectTiles();
        }
        else if (isShowing)
        {
            provincePanel.SetActive(false);
            provinceInfo.SetActive(false);
            isShowing = false;
            province.DeSelectTiles();
        }
        
        Deselect.province = province;
    }

    

    public void UpdateData()
    {
        textCO2.text = $"{province.co2LevelsProvince}";
        textEnergy.text = $"{province.energyLevelsProvince}";
        textPopSat.text = $"{province.populationSatisfactionLevelsProvince}";
        textGDP.text = $"{province.gdpLevelsProvince}";
        textFootprint.text = $"{province.ecologicalFootprintLevelsProvince}";
        Card.sprite = CardSprite;
    }
}

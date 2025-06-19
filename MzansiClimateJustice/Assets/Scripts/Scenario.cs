using UnityEngine;


[CreateAssetMenu]
public class Scenario : ScriptableObject
{
    /*public enum ProvinceName
    { 
        NorthernCape,
        Mpumalanga,
        KwaZuluNatal,
        WesternCape,
        Gauteng,
        FreeState,
        NorthWest,
        EasternCape,
        Limpopo
    }*/
    
    

    public enum Action
    {
        Build,
        Remove
    }

    public Province.ProvinceName ProvinceName; 
    public PowerStation.PowerType triggerType1;
    public PowerStation.PowerType triggerType2;
    public Action action;

    public string scenario;
    public string character;
    public string characterDialogue;

    public float popSatImpact;
    public float footPrintImpact;


}

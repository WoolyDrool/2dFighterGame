using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTemplate : MonoBehaviour
{
    [Header("Main Variables")]
    public string ItemName = "DefaultValue";
    public string ItemDescription = "DefaultValue";
    public ItemType type;


    public enum ItemType { STAMINA, HEALTH, MISC};

    [Header("Benefit")]
    public float healthBenefit;
    public float staminaBenefit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseItem()
    {

    }
}

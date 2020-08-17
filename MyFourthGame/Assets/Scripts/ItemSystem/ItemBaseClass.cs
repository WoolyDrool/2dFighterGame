using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items {
[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class ItemBaseClass : ScriptableObject
{
    public int ID;
    public string Name = "DefaultName";
    public string Description = "Default Description";
    public Sprite model;
    public int Value = 15;
    public ItemType type = ItemType.DEFAULT;

    public enum ItemType { HEALTH, STAMINA, KEY, UPGRADEMATERIAL, DEFAULT};
}
}

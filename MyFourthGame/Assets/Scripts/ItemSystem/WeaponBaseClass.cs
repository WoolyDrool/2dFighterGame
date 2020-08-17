using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons {
[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class WeaponBaseClass : ScriptableObject
{
    public int ID;
    public string Name = "DefaultName";
    public string Description = "Default Description";
    public int minDamage = 5;
    public int maxDamage = 5;
    public Sprite model;
    public Animator weaponAnimator;
    public GameObject CharacterRig;
    public int Durability = 100;
    public int Value = 15;
    public bool isBroken;
    public WeaponType type = WeaponType.MELEE;

    public enum WeaponType { MELEE, SMALLFIREARM, LARGEFIREARM, AMMUNITION};

    private void Awake() {
        
    }
}
}

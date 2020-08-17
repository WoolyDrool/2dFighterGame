using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;
using Items;

public class Inventory : MonoBehaviour
{
    public WeaponBaseClass[] weaponList = new WeaponBaseClass[20];
    public ItemBaseClass[] itemList = new ItemBaseClass[20];

    public bool AddWeapon(WeaponBaseClass weapon)
    {
        for(int i = 0; i < weaponList.Length; i++)
        {
            if(weaponList[i] == null)
            {
                weaponList[i] = weapon;
                return true;
            }
        }
        return false;
    }

    public bool AddItem(ItemBaseClass item)
    {
        for(int i = 0; i < weaponList.Length; i++)
        {
            if(itemList[i] == null)
            {
                itemList[i] = item;
                return true;
            }
        }
        return false;
    }
}

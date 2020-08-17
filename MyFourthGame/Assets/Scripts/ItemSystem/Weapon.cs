using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Weapons{
public class Weapon : MonoBehaviour
{
    [Header("Scriptable Object")]
    public WeaponBaseClass weapon;

    [Header ("Weapon Variables")]
    public SpriteRenderer weaponSprite;
    public Animator am;

    void Awake() {
        weaponSprite.sprite = weapon.model;
        am = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void Attack()
    {
        float damage = Random.Range(weapon.minDamage, weapon.maxDamage);

        Debug.Log("I did " + damage.ToString());
    }
}
}

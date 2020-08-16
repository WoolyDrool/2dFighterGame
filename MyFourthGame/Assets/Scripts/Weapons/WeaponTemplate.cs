using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTemplate : MonoBehaviour
{
    [Header("Weapon Information")]
    public string Name = "DefaultValue";
    public string Description = "DefaultValue";
    public float Damage =  10;
    public float attackSpeed = 1.5f;
    float nextAttack;
    public float WeaponDurability = 100;
    public bool isBroken = false;
    public float attackReach = 4;
    
    public WeaponType type;
    public Animator weaponAnimator;
    public GameObject CharacterRig;

    public enum WeaponType { MELEE, SMALLFIREARM, LARGEFIREARM};

    // Start is called before the first frame update
    void Start()
    {
        CharacterRig = GameObject.FindWithTag("PlayerRig");
        weaponAnimator = CharacterRig.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FireWeapon()
    {
       

        if (WeaponDurability <= 0)
        {
            isBroken = true;
            StopFiringWeapon();
        }

        if (!isBroken)
        {
         
            #region MeleeWeapon;
            if (type.Equals(WeaponType.MELEE) && Time.time > nextAttack)
            {
                WeaponDurability--;
                RaycastHit2D hitRay;
                weaponAnimator.SetBool("isAttackingMelee", true);

                

                nextAttack = Time.time + attackSpeed;
            }

            #endregion

            #region FirearmWeapon



            #endregion
        }
   
        
    }
    public void StopFiringWeapon()
    {
        if(type.Equals(WeaponType.MELEE))
        {
            weaponAnimator.SetBool("isAttackingMelee", false);
            this.GetComponentInParent<PlayerLocomotionController>().playerCanMove = true;
        }
    }
}

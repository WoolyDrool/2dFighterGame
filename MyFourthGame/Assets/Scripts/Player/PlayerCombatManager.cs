﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatManager : MonoBehaviour
{
    [Header("Variables")]
    public WeaponTemplate curWeapon;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (curWeapon != null && !curWeapon.isBroken && !GetComponent<PlayerLocomotionController>().isMoving)
        {
            if (this.GetComponent<PlayerLocomotionController>().isJumping == false)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    //Combat stuff
                    curWeapon.FireWeapon();
                }
                else
                {
                    curWeapon.StopFiringWeapon();
                }
            }
        }
       
    }
}
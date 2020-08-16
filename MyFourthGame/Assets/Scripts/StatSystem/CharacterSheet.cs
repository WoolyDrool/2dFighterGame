using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSheet : MonoBehaviour
{
    [Header("Base Stats")]
    public int vitality = 10;
    public int endurance = 10;
    public int agility = 10;
    public int mWeapons = 10;
    public int fWeapons = 10;

    [Header("Character Info")]
    public int health = 0;
    private int maxHealth;
    public float stamina = 0;
    float maxStamina;
    public int curXP;
    public int xpNeededToLevelUp;
    public int curLevel = 1;
    public int maxLevel = 99;

    [Header("DevStats")]
    public static CharacterSheet cs;
    float staminaRegenDelay = 2;
    private Coroutine regen;
    float staminaRegenSpeed = 0.1f;
    public float staminaRegenAmount = 7; 
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    public float vitholder;
    public float endholder;
    public float agholder;
    public float melholder;
    public float faholder;

    [Header("UI")]
    public Slider staminaBar;
    public Slider healthBar;
    public TextMeshProUGUI VitNumber;
    public TextMeshProUGUI EndNumber;
    public TextMeshProUGUI AgiNumber;
    public TextMeshProUGUI MelNumber;
    public TextMeshProUGUI FaNumber;
    public TextMeshProUGUI XP;
    public TextMeshProUGUI XPNeededToLevel;
    public TextMeshProUGUI Level;

    private void Awake()
    {
        cs = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        RollStats();
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RollStats()
    {
        vitholder = vitality;
        endholder = endurance;
        agholder = agility;
        melholder = mWeapons;
        faholder = fWeapons;

        //Health
        int newCalculatedHealth = 10 * vitality;
        maxHealth = newCalculatedHealth;
        health = maxHealth;

        //Stamina
        int newCalculatedStamina = 5 * endurance;
        maxStamina = newCalculatedStamina;
        stamina = newCalculatedStamina;

        xpNeededToLevelUp = (700 * curLevel / 2);
        Mathf.Round(xpNeededToLevelUp);

        VitNumber.SetText(vitality.ToString());
        EndNumber.SetText(endurance.ToString());
        AgiNumber.SetText(agility.ToString());
        MelNumber.SetText(mWeapons.ToString());
        FaNumber.SetText(fWeapons.ToString());
        XP.SetText("XP: " + curXP.ToString());
        XPNeededToLevel.SetText("XP Needed for Level: " + xpNeededToLevelUp.ToString());
        //Debug.Log(health.ToString());
    }

    public void UseStamina(int amount)
    {
        if(stamina - amount >= 0)
        {
            stamina -= amount;
            staminaBar.value = stamina;

            if(regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenStamina());
        }
        else 
        {
            Debug.Log("Not enough stamina");
        }
    }

    private IEnumerator RegenStamina()
    {
        Debug.Log("Started coroutine");
        yield return new WaitForSeconds(staminaRegenDelay);

        while(stamina < maxStamina)
        {
            stamina += staminaRegenAmount;
            staminaBar.value = stamina;
            stamina = Mathf.Clamp(stamina, 0, maxStamina);
            yield return regenTick;
        } 
        regen = null;

    }

#region LevelUpStuff
    #region Vitality
    public void LevelUp_Vitality()
    {
        if(curXP >= xpNeededToLevelUp)
        {
            vitality++;
            VitNumber.SetText(vitality.ToString());
            curXP -= xpNeededToLevelUp;
            XP.SetText("XP: " + curXP.ToString());
            curLevel++;
        }
    }
    public void LevelDown_Vitality()
    {
        if(vitality > vitholder)
        {
            vitality--;
            VitNumber.SetText(vitality.ToString());
            curXP += xpNeededToLevelUp;
            XP.SetText("XP: " + curXP.ToString());
            curLevel--;
        }       
    }
    #endregion
    #region Endurance
    public void LevelUp_Endurance()
    {
        if(curXP >= xpNeededToLevelUp)
        {
            endurance++;
            EndNumber.SetText(endurance.ToString());
            curXP -= xpNeededToLevelUp;
            XP.SetText("XP: " + curXP.ToString());
        }
    }
    public void LevelDown_Endurance()
    {
        if(endurance > endholder)
        {
            endurance--;
            EndNumber.SetText(endurance.ToString());
            curXP += xpNeededToLevelUp;
            XP.SetText("XP: " + curXP.ToString());
        }  
    }
    #endregion
    #region  Agility
    public void LevelUp_Agility()
    {
        if(curXP >= xpNeededToLevelUp)
        {
            agility++;
            AgiNumber.SetText(agility.ToString());
            curXP -= xpNeededToLevelUp;
            XP.SetText("XP: " + curXP.ToString());
        }
    }
    public void LevelDown_Agility()
    {
        if(agility > agholder)
        {
            agility--;
            AgiNumber.SetText(agility.ToString());
            curXP += xpNeededToLevelUp;
            XP.SetText("XP: " + curXP.ToString());
        }  
    }
    #endregion
    #region Melee Weapons
    public void LevelUp_MWeapons()
    {
        if(curXP >= xpNeededToLevelUp)
        {
            mWeapons++;
            MelNumber.SetText(mWeapons.ToString());
            curXP -= xpNeededToLevelUp;
            XP.SetText("XP: " + curXP.ToString());
        }
    }
    public void LevelDown_MWeapons()
    {
        if(mWeapons > melholder)
        {
            mWeapons--;
            MelNumber.SetText(mWeapons.ToString());
            curXP += xpNeededToLevelUp;
            XP.SetText("XP: " + curXP.ToString());
        } 
    }
    #endregion
    #region Firearms
    public void LevelUp_Firearms()
    {
        if(curXP >= xpNeededToLevelUp)
        {
            fWeapons++;
            FaNumber.SetText(fWeapons.ToString());
            curXP -= xpNeededToLevelUp;
            XP.SetText("XP: " + curXP.ToString());
        }
    }
    public void LevelDown_Firearms()
    {
        if(fWeapons > faholder)
        {
            fWeapons--;
            FaNumber.SetText(fWeapons.ToString());
            curXP += xpNeededToLevelUp;
            XP.SetText("XP: " + curXP.ToString());
        } 
    }

    public void AcceptSelection()
    {
        RollStats();
    }
    #endregion
#endregion
}

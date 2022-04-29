using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    private PlayerSkills playerSkills;
    public Axe axe;
    public Hero hero;
    public Weapon weapon;
    public bonfireHeal bonfireHeal;
    public PickupSoul pickupSoul;
    private void Start()
    {
        axe._damageAxe = 50;
        weapon.doubleAxe = false;
        bonfireHeal.firstRange = 1;
        bonfireHeal.lastRange = 4;
        hero.soulCountMax = 15;
        pickupSoul.timeDieSoul = 5;
    }
    private void Awake()
    {
       
        playerSkills = new PlayerSkills();
        playerSkills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;
    }

    private void PlayerSkills_OnSkillUnlocked(object sender, PlayerSkills.OnSkillUnlockedEventArgs e)
    {
        switch (e.skillType)
        {
            case PlayerSkills.SkillType.Atack1:
                axe._damageAxe = axe._damageAxe * 1.5f;
                break;
            case PlayerSkills.SkillType.Atack2:
                axe._damageAxe = axe._damageAxe * 1.5f;
                break;
            case PlayerSkills.SkillType.Atack3:
                weapon.doubleAxe = true;
                break;
            case PlayerSkills.SkillType.Speed1:
                bonfireHeal.firstRange = 4;
                bonfireHeal.lastRange = 8;
                break;
            case PlayerSkills.SkillType.Speed2:
                hero.soulCountMax = 25;
                break;
            case PlayerSkills.SkillType.Speed3:
                pickupSoul.timeDieSoul = 10;
                break;
            case PlayerSkills.SkillType.Defence1:
                Debug.Log("a");
                break;
            case PlayerSkills.SkillType.Defence2:
                Debug.Log("b");
                break;
            case PlayerSkills.SkillType.Defence3:
                Debug.Log("c");
                break;

        }
    }

 
    public PlayerSkills GetPlayerSkills()
    {
        return playerSkills;
    }
    public bool CanUseEarthshatter()
    {
        return playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Atack1);
    }

    public bool CanUseWhirlwind()
    {
        return playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Atack2);
    }

 

}

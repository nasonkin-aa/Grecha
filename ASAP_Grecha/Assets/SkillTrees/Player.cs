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
    public Animator animUI;
    public Fence fence;
    public Fence2 fence2;
    public Camp camp;
    private void Start()
    {
        axe._damageAxe = 50;
        weapon.doubleAxe = false;
        bonfireHeal.firstRange = 1;
        bonfireHeal.lastRange = 4;
        hero.soulCountMax = 15;
        pickupSoul.timeDieSoul = 5;
        hero._livesHero = 100;
        hero._maxLivesHero = 100;
        fence.liveFence = 500;
        fence2.liveFence = 500;
        weapon.delayAttack = 0.5f;
        camp.liveCamp = 300;
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
                weapon.delayAttack = 0.3f;
                break;
            case PlayerSkills.SkillType.Atack2:
                weapon.doubleAxe = true;
                break;
            case PlayerSkills.SkillType.Atack3:
                axe._damageAxe = 100;
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
                fence.liveFence = 750;
                fence2.liveFence = 750;
                camp.liveCamp = 300;
                break;
            case PlayerSkills.SkillType.Defence2:
                hero._livesHero = 200;
                hero._maxLivesHero = 200;
                camp.liveCamp = 300;
                break;
            case PlayerSkills.SkillType.Defence3:
                hero._livesHero = 300;
                hero._maxLivesHero = 300;
                fence.liveFence = 1000;
                fence2.liveFence = 1000;
                camp.liveCamp = 300;
                break;

        }
        animUI.SetBool("IsUITreeOn", false);
        Time.timeScale = 1f;
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

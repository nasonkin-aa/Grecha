/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    
    private PlayerSkills playerSkills;

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
                Debug.Log("a");
                break;
            case PlayerSkills.SkillType.Atack2:
                Debug.Log("b");
                break;
            case PlayerSkills.SkillType.Atack3:
                Debug.Log("c");
                break;
            case PlayerSkills.SkillType.Speed1:
                Debug.Log("a");
                break;
            case PlayerSkills.SkillType.Speed2:
                Debug.Log("b");
                break;
            case PlayerSkills.SkillType.Speed3:
                Debug.Log("c");
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

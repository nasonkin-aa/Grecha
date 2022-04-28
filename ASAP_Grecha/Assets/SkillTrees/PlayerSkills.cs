using System;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerSkills : MonoBehaviour
{
    public event EventHandler OnSkillPointsChanged;
    public event EventHandler<OnSkillUnlockedEventArgs> OnSkillUnlocked;
    public class OnSkillUnlockedEventArgs : EventArgs
    {
        public SkillType skillType;
    }
    public enum SkillType
    {
        None,
        Atack1,
        Atack2,
        Atack3,
        Defence1,
        Defence2,
        Defence3,
        Speed1,
        Speed2,
        Speed3,

    }
    private List<SkillType> unlockedSkillTypeList;
    private int skillPoints = 10;

    public PlayerSkills()
    {
        unlockedSkillTypeList = new List<SkillType>(); 
    }
    public void AddSkillPoint()
    {
        skillPoints++;
        OnSkillPointsChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetSkillPoints()
    {
        return skillPoints;
    }
    private void UnlockSkill(SkillType skillType)
    {
        if (!IsSkillUnlocked(skillType))
        {
            unlockedSkillTypeList.Add(skillType);
            OnSkillUnlocked?.Invoke(this, new OnSkillUnlockedEventArgs { skillType = skillType });
        }
    }
    public bool IsSkillUnlocked(SkillType skillType)
    {
        return unlockedSkillTypeList.Contains(skillType);    
    }

    public SkillType GetSkillRequirement(SkillType skillType)
    {
        switch (skillType)
        {
            case SkillType.Atack2: return SkillType.Atack1;
            case SkillType.Atack3: return SkillType.Atack2;
            case SkillType.Defence2: return SkillType.Defence1;
            case SkillType.Defence3: return SkillType.Defence2;
            case SkillType.Speed2: return SkillType.Speed1;
            case SkillType.Speed3: return SkillType.Speed2;
        }
        return SkillType.None;
    }



    public bool CanUnlock(SkillType skillType)
    {
        SkillType skillRequirement = GetSkillRequirement(skillType);

        if (skillRequirement != SkillType.None)
        {
            if (IsSkillUnlocked(skillRequirement))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }
    public bool TryUnlockSkill(SkillType skillType)
    {
        if (CanUnlock(skillType))
        {
            if (skillPoints > 0)
            {
                Debug.Log("try");
                skillPoints--;
                OnSkillPointsChanged?.Invoke(this, EventArgs.Empty);
                UnlockSkill(skillType);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}

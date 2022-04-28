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
using UnityEngine.UI;
using CodeMonkey.Utils;

public class SkillsTree : MonoBehaviour
{

    [SerializeField] private Material skillLockedMaterial;
    [SerializeField] private Material skillUnlockableMaterial;
    [SerializeField] private SkillUnlockPath[] skillUnlockPathArray;
    [SerializeField] private Sprite lineSprite;
    [SerializeField] private Sprite lineGlowSprite;

    private PlayerSkills playerSkills;
    private List<SkillButton> skillButtonList;
    private TMPro.TextMeshProUGUI skillPointsText;

    private void Awake()
    {
        skillPointsText = transform.Find("skillPointsText").GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void SetPlayerSkills(PlayerSkills playerSkills)
    {
        this.playerSkills = playerSkills;

        skillButtonList = new List<SkillButton>();
        skillButtonList.Add(new SkillButton(transform.Find("Atack1"), playerSkills, PlayerSkills.SkillType.Atack1, skillLockedMaterial, skillUnlockableMaterial));
        skillButtonList.Add(new SkillButton(transform.Find("Atack2"), playerSkills, PlayerSkills.SkillType.Atack2, skillLockedMaterial, skillUnlockableMaterial));
        skillButtonList.Add(new SkillButton(transform.Find("Atack3"), playerSkills, PlayerSkills.SkillType.Atack3, skillLockedMaterial, skillUnlockableMaterial));
       
        playerSkills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;
        playerSkills.OnSkillPointsChanged += PlayerSkills_OnSkillPointsChanged;

        UpdateVisuals();
        UpdateSkillPoints();
    }

    private void PlayerSkills_OnSkillPointsChanged(object sender, System.EventArgs e)
    {
        UpdateSkillPoints();
    }

    private void PlayerSkills_OnSkillUnlocked(object sender, PlayerSkills.OnSkillUnlockedEventArgs e)
    {
        UpdateVisuals();
    }

    private void UpdateSkillPoints()
    {
        skillPointsText.SetText(playerSkills.GetSkillPoints().ToString());
    }

    private void UpdateVisuals()
    {
        foreach (SkillButton skillButton in skillButtonList)
        {
            skillButton.UpdateVisual();
        }

        // Darken all links
        foreach (SkillUnlockPath skillUnlockPath in skillUnlockPathArray)
        {
            foreach (Image linkImage in skillUnlockPath.linkImageArray)
            {
                linkImage.color = new Color(.5f, .5f, .5f);
                linkImage.sprite = lineSprite;
            }
        }

        foreach (SkillUnlockPath skillUnlockPath in skillUnlockPathArray)
        {
            if (playerSkills.IsSkillUnlocked(skillUnlockPath.skillType) || playerSkills.CanUnlock(skillUnlockPath.skillType))
            {
                // Skill unlocked or can be unlocked
                foreach (Image linkImage in skillUnlockPath.linkImageArray)
                {
                    linkImage.color = Color.white;
                    linkImage.sprite = lineGlowSprite;
                }
            }
        }
    }

    /*
     * Represents a single Skill Button
     * */
    private class SkillButton
    {

        private Transform transform;
        private Image image;
        private Image backgroundImage;
        private PlayerSkills playerSkills;
        private PlayerSkills.SkillType skillType;
        private Material skillLockedMaterial;
        private Material skillUnlockableMaterial;

        public SkillButton(Transform transform, PlayerSkills playerSkills, PlayerSkills.SkillType skillType, Material skillLockedMaterial, Material skillUnlockableMaterial)
            {
                this.transform = transform;
            this.playerSkills = playerSkills;
            this.skillType = skillType;
            this.skillLockedMaterial = skillLockedMaterial;
            this.skillUnlockableMaterial = skillUnlockableMaterial;

            image = transform.Find("image").GetComponent<Image>();
            backgroundImage = transform.Find("background").GetComponent<Image>();

            transform.GetComponent<Button_UI>().ClickFunc = () => {
                if (!playerSkills.IsSkillUnlocked(skillType))
                {
                    // Skill not yet unlocked
                    if (!playerSkills.TryUnlockSkill(skillType))
                    {
                        Debug.Log(":=");
                        //Tooltip_Warning.ShowTooltip_Static("Cannot unlock " + skillType + "!");
                    }
                }
            };
        }

        public void UpdateVisual()
        {
           if (playerSkills.IsSkillUnlocked(skillType))
            {
                image.material = null;
                backgroundImage.material = null;
            }
            else
            {
                if (playerSkills.CanUnlock(skillType))
                {
                    image.material = skillUnlockableMaterial;
                    backgroundImage.color = Color.clear;
                    transform.GetComponent<Button_UI>().enabled = true;
                }
                else
                {
                    image.material = skillLockedMaterial;
                    backgroundImage.color = new Color(.3f, .3f, .3f);
                    transform.GetComponent<Button_UI>().enabled = false;
                }
            }
        }

    }


    [System.Serializable]
    public class SkillUnlockPath
    {
        public PlayerSkills.SkillType skillType;
        public Image[] linkImageArray;
    }

}
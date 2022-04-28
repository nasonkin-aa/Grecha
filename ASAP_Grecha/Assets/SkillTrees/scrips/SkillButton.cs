using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillButton : MonoBehaviour
{
    [SerializeField]
    private Text skillDesText;
    public Image skillImage;

    public int skillButtonId;//Each Button has one unique Button id correspond with the same order as the Skill array

    //MARKER This method will be called when we press each skill
    public void PressSkillButton()
    {
        Debug.Log("dasd");
        SkillManager.instance.activateSkill = transform.GetComponent<Skill>();
        skillImage.sprite = SkillManager.instance.skills[skillButtonId].skillSprite;
        skillDesText.text = SkillManager.instance.skills[skillButtonId].skillDes;
    }


}

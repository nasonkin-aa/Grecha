using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillButton : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshPro skillDesText;

    public int skillButtonId;//Each Button has one unique Button id correspond with the same order as the Skill array
    [SerializeField]
    //MARKER This method will be called when we press each skill

    private void OnMouseEnter()
    {
        SkillManager.instance.activateSkill = transform.GetComponent<Skill>();
        skillDesText.text = SkillManager.instance.skills[skillButtonId].skillDes;
    }
    private void OnMouseExit()
    {
        skillDesText.text = "Choose your skill!";
    }


}

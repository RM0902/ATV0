using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillPanel : MonoBehaviour
{
  public GameObject[] skillButtons;
  public Text[] skilButtonLabels;

  private void Awake()
  {
    this.Hide();

    foreach (var btn in this.skillButtons)
    {
      btn.SetActive(false);
    }
  }

  public void ConfigureButtons(int index, string skillName)
  {
    this.skillButtons[index].SetActive(true);
      this.skilButtonLabels[index].text = skillName;
  }

  public void Show()
  {
    this.gameObject.SetActive(true);
    
  }
  public void Hide()
  {
    this.gameObject.SetActive(false);
    
  }
}

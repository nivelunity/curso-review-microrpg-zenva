using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
   public TextMeshProUGUI levelText;
   public TextMeshProUGUI inventoryText;
   public Image healthBarFill;
   public Image xpBarFill;


   private Player player;
   private void Awake()
   {
      player = FindObjectOfType<Player>();
   }

   public void UpdateLevelText()
   {
      levelText.text = "Lvl \n" + player.curLevel;
   }
   
   public void UpdateHealthBar()
   {
      healthBarFill.fillAmount =  (float)player.curHp / (float)player.maxHp;
   }
   public void UpdateXpBar()
   {
      xpBarFill.fillAmount =  (float)player.curXp / (float)player.xpToNextLevel;
   }
}

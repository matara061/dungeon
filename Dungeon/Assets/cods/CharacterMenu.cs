﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    // text fields
    public Text levelText, hitpointText, pesosText, upgradeCostText, upgradeCostTextW, xpText;

    // logic
    private int currentCharacterSeletion = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public Image gunSprite;
    public RectTransform xpBar;

    // Character selection
    public void OnArrowClick(bool right)
    {
        if (right)
        {
            currentCharacterSeletion++;

            // if we went too far away
            if (currentCharacterSeletion == GameManager.instance.playerSprites.Count)
                currentCharacterSeletion = 0;

            OnSelectionChanged();
        }
        else
        {
            currentCharacterSeletion--;

            if (currentCharacterSeletion < 0)
                currentCharacterSeletion = GameManager.instance.playerSprites.Count - 1;

            OnSelectionChanged();

        }
    }

    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSeletion];
    }

    // weapon upgrade
    public void OnUpgradeClick()
    {
        Debug.Log("uppppppp");
        if (GameManager.instance.TryUpgradeWeapon())
            UpdateMenu();
    }

    // gun upgrade
    public void OnUpgradeClickW()
    {
        Debug.Log("uppppppp");
        if (GameManager.instance.TryUpgradeGun())
            UpdateMenu();
    }

    // update character information 
    public void UpdateMenu()
    {
        // Weapon
        weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.weapon.weaponLevel];
        if (GameManager.instance.weapon.weaponLevel == GameManager.instance.weaponPrices.Count)
            upgradeCostText.text = "MAX";
        else
            upgradeCostText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.weaponLevel].ToString();

        // gun
        gunSprite.sprite = GameManager.instance.gunSprites[GameManager.instance.gun.gunLevel];
        if (GameManager.instance.gun.gunLevel == GameManager.instance.gunPrices.Count)
            upgradeCostTextW.text = "MAX";
        else
            upgradeCostTextW.text = GameManager.instance.gunPrices[GameManager.instance.gun.gunLevel].ToString();

        // Meta
        levelText.text = GameManager.instance.GetCurrentLevel().ToString();
        hitpointText.text = GameManager.instance.player.hitpoint.ToString();
        pesosText.text = GameManager.instance.pesos.ToString();

        // XP bar

        int currLevel = GameManager.instance.GetCurrentLevel();
        if (GameManager.instance.GetCurrentLevel() == GameManager.instance.xpTable.Count)
        {
            xpText.text = GameManager.instance.experience.ToString() + " total experience points"; // mostra total xp
            xpBar.localScale = Vector3.one;
        }
        else
        {
            int prevLevelXp = GameManager.instance.GetXpToLevel(currLevel - 1);
            int currLevelXp = GameManager.instance.GetXpToLevel(currLevel);

            int diff = currLevelXp - prevLevelXp;
            int currXpIntoLevel = GameManager.instance.experience - prevLevelXp;

            float completionRatio = (float)currXpIntoLevel / (float)diff;
            xpBar.localScale = new Vector3(completionRatio, 1, 1);
            xpText.text = currXpIntoLevel.ToString() + " / " + diff;
        }

       // xpText.text = "NOT IMPLEMENTED";
       // xpBar.localScale = new Vector3(0.5f, 0, 0);
    }
}

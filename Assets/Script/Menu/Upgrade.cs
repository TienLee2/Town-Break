using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    private static float speed, health, crit, regen;

    public TextMeshProUGUI speedText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI critText;
    public TextMeshProUGUI regenText;

    public TextMeshProUGUI UpgradespeedText;
    public TextMeshProUGUI UpgradehealthText;
    public TextMeshProUGUI UpgradecritText;
    public TextMeshProUGUI UpgraderegenText;

    public static float countSpeed, countHealth, countCrit, countRegen;
    public static int upgradeSpeed, upgradeHealth, upgradeCrit, upgradeRegen;


    void Start()
    {
        speed = PlayerPrefs.GetFloat("Speed", 0);
        health = PlayerPrefs.GetFloat("Health", 0);
        crit = PlayerPrefs.GetFloat("Crit", 0);
        regen = PlayerPrefs.GetFloat("Regen", 0);

        countSpeed = PlayerPrefs.GetFloat("countSpeed", 0);
        countHealth = PlayerPrefs.GetFloat("countHealth", 0);
        countCrit = PlayerPrefs.GetFloat("countCrit", 0);
        countRegen = PlayerPrefs.GetFloat("countRegen", 0);

        upgradeSpeed = PlayerPrefs.GetInt("upgradeSpeed", 0);
        upgradeHealth = PlayerPrefs.GetInt("upgradeHealth", 0);
        upgradeCrit = PlayerPrefs.GetInt("upgradeCrit", 0);
        upgradeRegen = PlayerPrefs.GetInt("upgradeRegen", 0);

        DisplaySpeed();
        DisplayHealth();
        DisplayCrit();
        DisplayRegen();

        DisplayUpgradeHealth();
        DisplayUpgradeSpeed();
        DisplayUpgradeCrit();
        DisplayUpgradeRegen();
    }

    public static float GetSpeed()
    {
        return speed;
    }
    public static float GetCrit()
    {
        return crit;
    }
    public static float GetHealth()
    {
        return health;
    }
    public static float GetRegen()
    {
        return regen;
    }
    
    public static void SetSpeed(float speedToSet)
    {
        speed = speedToSet;
        PlayerPrefs.SetFloat("Speed", speed);
    }
    public static void SetHealth(float healthToSet)
    {
        health = healthToSet;
        PlayerPrefs.SetFloat("Health", health);
    }
    public static void SetCrit(float critToSet)
    {
        crit = critToSet;
        PlayerPrefs.SetFloat("Crit", crit);
    }
    public static void SetRegen(float regenToSet)
    {
        regen = regenToSet;
        PlayerPrefs.SetFloat("Regen", regen);
    }

    public void Health()
    {
        if (Wallet.GetAmount() >= upgradeHealth)
        {
            Upgrade.SetHealth(Upgrade.GetHealth() + 20f);
            Wallet.SetAmount(Wallet.GetAmount() - upgradeHealth);
            countHealth++;
            upgradeHealth++;
            PlayerPrefs.SetFloat("countHealth", countHealth);
            PlayerPrefs.SetInt("upgradeHealth", upgradeHealth);
            
            DisplayHealth();
            DisplayUpgradeHealth();
        }
    }
    public void Speed()
    {
        if (Wallet.GetAmount() >= upgradeSpeed)
        {
            Upgrade.SetSpeed(Upgrade.GetSpeed() + 0.2f);
            Wallet.SetAmount(Wallet.GetAmount() - upgradeSpeed);
            countSpeed++;
            upgradeSpeed++;
            PlayerPrefs.SetFloat("countSpeed", countSpeed);
            PlayerPrefs.SetInt("upgradeSpeed", upgradeSpeed);
            
            DisplaySpeed();
            DisplayUpgradeSpeed();
        }
    }
    public void Crit()
    {
        if (Wallet.GetAmount() >= upgradeCrit)
        {
            Upgrade.SetCrit(Upgrade.GetCrit() + 2f);
            Wallet.SetAmount(Wallet.GetAmount() - upgradeCrit);
            countCrit++;
            upgradeCrit++;
            PlayerPrefs.SetFloat("countCrit", countCrit);
            PlayerPrefs.SetInt("upgradeCrit", upgradeCrit);
            
            DisplayCrit();
            DisplayUpgradeCrit();
        }
    }
    public void Regen()
    {
        if (Wallet.GetAmount() >= upgradeRegen)
        {
            Upgrade.SetRegen(Upgrade.GetRegen() + 0.2f);
            Wallet.SetAmount(Wallet.GetAmount() - upgradeRegen);
            countRegen++;
            upgradeRegen++;
            PlayerPrefs.SetFloat("countRegen", countRegen);
            PlayerPrefs.SetInt("upgradeRegen", upgradeRegen);
            
            DisplayRegen();
            DisplayUpgradeRegen();
        }
    }


    public void DisplaySpeed()
    {
        speedText.text = countSpeed.ToString();
    }
    public void DisplayHealth()
    {
        healthText.text = countHealth.ToString();
    }
    public void DisplayCrit()
    {
        critText.text = countCrit.ToString();
    }
    public void DisplayRegen()
    {
        regenText.text = countRegen.ToString();
    }

    public void DisplayUpgradeHealth()
    {
        UpgradehealthText.text = upgradeHealth.ToString();
    }
    public void DisplayUpgradeSpeed()
    {
        UpgradespeedText.text = upgradeSpeed.ToString();
    }
    public void DisplayUpgradeCrit()
    {
        UpgradecritText.text = upgradeCrit.ToString();
    }
    public void DisplayUpgradeRegen()
    {
        UpgraderegenText.text = upgradeRegen.ToString();
    }
}

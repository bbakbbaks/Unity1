using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgradebutton : MonoBehaviour {

    public Text upgradeDisplay;
    public string upgradeName;

    public int goldByUpgrade;
    public int startGoldByUpgrade = 1;

    public int currentCost = 1;
    public int startCurrentCost;

    public int level = 1;

    public float upgradePow = 1.07f;
    public float costPow = 3.14f;

	// Use this for initialization
	void Start () {
        currentCost = startCurrentCost;
        level = 1;
        goldByUpgrade = startGoldByUpgrade;
        UpdateUI();
	}

    public void PuerchaseUpgrade()
    {
        if(DataController.GetInstance().GetGold()>=currentCost)
        {
            DataController.GetInstance().SubGold(currentCost);
            level++;
            DataController.GetInstance().AddGoldPerClick(goldByUpgrade);
            UpdateUpgrade();
            UpdateUI();
        }
    }

    public void UpdateUpgrade()
    {
        goldByUpgrade = startGoldByUpgrade + (int)Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost + (int)Mathf.Pow(costPow, level);
    }
	
	// Update is called once per frame
	void UpdateUI () {
        upgradeDisplay.text = upgradeName + "\nCost: " + currentCost + "\nNextGold: " + level + "\nAddClickPerGold: " + goldByUpgrade;
	}
}

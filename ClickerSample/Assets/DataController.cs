using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {

    private static DataController instance;

    public static DataController GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<DataController>();
            if(instance == null)
            {
                GameObject container = new GameObject("DataController");
                instance = container.AddComponent<DataController>();
            }
        }
        return instance;
    }


    [SerializeField]
    private int m_gold = 0;
    [SerializeField]
    private int m_goldPerClick = 0;

    void Awake()
    {
        PlayerPrefs.DeleteAll();
        m_gold = PlayerPrefs.GetInt("Gold");
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1);
    }

    public void SetGold(int newGold)
    {
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold);
    }

    public void AddGold(int newGold)
    {
        m_gold += newGold;
        SetGold(m_gold);
    }

    public void SubGold(int newGold)
    {
        m_gold -= newGold;
        SetGold(m_gold);
    }

    public int GetGold()
    {
        return m_gold;
    }

    public int GetGoldPerClick()
    {
        return m_goldPerClick;
    }

    public void SetGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick = newGoldPerClick;
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);
    }

    public void AddGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick += newGoldPerClick;
        SetGoldPerClick(m_goldPerClick);
    }

    public void LoadUpgradeButton(Upgradebutton upgradebutton)
    {
        string key = upgradebutton.upgradeName;
        upgradebutton.level = PlayerPrefs.GetInt(key + "_level", 1);
        upgradebutton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradebutton.startGoldByUpgrade);
        upgradebutton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradebutton.startCurrentCost);
    }

    public void SaveUpgradeButton(Upgradebutton upgradebutton)
    {
        string key = upgradebutton.upgradeName;
        PlayerPrefs.SetInt(key + "_level", upgradebutton.level);
        PlayerPrefs.SetInt(key + "_goldByUpgrad", upgradebutton.goldByUpgrade);
        PlayerPrefs.SetInt(key + "_cost", upgradebutton.currentCost);
    }

    public void LoadItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;
        itemButton.level = PlayerPrefs.GetInt(key + "_level");
        itemButton.currentCost = PlayerPrefs.GetInt(key + "_cost", itemButton.startCurrentCost);
        itemButton.goldPerSec = PlayerPrefs.GetInt(key + "_goldPerSec");
        if(PlayerPrefs.GetInt(key+"_isPurchased")==1)
        {
            itemButton.isPurchased = true;
        }
        else
        {
            itemButton.isPurchased = false;
        }
    }

    public void SaveItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;
        PlayerPrefs.SetInt(key + "_level", itemButton.level);
        PlayerPrefs.SetInt(key + "_cost", itemButton.currentCost);
        PlayerPrefs.SetInt(key + "_goldPerSec", itemButton.goldPerSec);
        if(itemButton.isPurchased==true)
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 1);
        }
        else
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 0);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

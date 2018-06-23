using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour {

    //public int gold = 0;
    //public int goldPerClick = 1;
    public Text goldText;
    public DataController dataController;

    public void Onclick()
    {
        //gold += goldPerClick;
        //goldText.text = gold.ToString();
        int goldPerClick = dataController.GetGoldPerClick();
        dataController.AddGold(goldPerClick);
        //goldText.text = dataController.GetGold().ToString();
    }
}

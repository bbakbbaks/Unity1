using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {

    public Text goldText;
    public Text goldPerClickText;
    public DataController dataController;

    void Update()
    {
        goldText.text = "Gold: " + dataController.GetGold();
        goldPerClickText.text = "Gold/Click: " + dataController.GetGoldPerClick();
    }
}

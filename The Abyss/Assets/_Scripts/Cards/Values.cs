﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Values : MonoBehaviour {

    public Text HP;
    public Text DMG;
    public Text COST;
    public int hp;
    public int dmg;
    public int cost;
    void Start () {
		
	}
	
	
	void Update () {
        HP.text = hp.ToString();
        DMG.text = dmg.ToString();
        COST.text = cost.ToString();
    }
}

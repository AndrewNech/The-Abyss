using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Values : MonoBehaviour {

    public Text HP;
    public Text DMG;
    public Text COST;
    public Text Name;
    public string cardname;
    public int hp;
    public int dmg;
    public int cost;
    void Start () {
        hp = GetComponent<CardCollectable>().hp;
        cardname = GetComponent<CardCollectable>().cardname;
        dmg = GetComponent<CardCollectable>().dmg;
        cost = GetComponent<CardCollectable>().cost;
    }
	
	
	void Update () {
        HP.text = hp.ToString();
        DMG.text = dmg.ToString();
        COST.text = cost.ToString();
        Name.text = cardname;
    }
}

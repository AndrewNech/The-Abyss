using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Values : MonoBehaviour {

    public Text HP;
    public Text DMG;
    public Text COST;
    public Text NAME;

    public string cardname;
    public AllCard allcard;

    public int id;
    public int hp;
    public int dmg;
    public int cost;

    void Awake () {
        hp = GetComponent<CardCollectable>().hp;
       
        dmg = GetComponent<CardCollectable>().dmg;
        cost = GetComponent<CardCollectable>().cost;
    }
    private void Start()
    {
        allcard = GetComponent<CardCollectable>().GetAllCard();
    }

    void Update () {
        HP.text = hp.ToString();
        DMG.text = dmg.ToString();
        COST.text = cost.ToString();
        NAME.text = allcard.cardName[id];
    }
}

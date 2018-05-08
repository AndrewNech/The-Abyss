using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mana : MonoBehaviour {

    public int mana;
    private Text MANA;
	void Start () {
        MANA = GameObject.Find("MANA_1").GetComponent<Text>();
	}
	
	
	void Update () {
        MANA.text = mana.ToString();
    }
}

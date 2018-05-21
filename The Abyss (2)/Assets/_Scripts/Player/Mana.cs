using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mana : MonoBehaviour {

    public int mana
    {
        get
        {
            return m_mana;
        }
        set
        {
            MANA.text = value.ToString();
        }
    }
    public int m_mana;
    private Text MANA;
	void Start () {
        MANA = GameObject.Find("MANA_1").GetComponent<Text>();
	}
}

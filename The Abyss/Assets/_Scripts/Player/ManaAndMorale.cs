using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaAndMorale : MonoBehaviour {
    public int mana;
    public int morale;
    private Text MORALE;
	void Start () {
        MORALE = GameObject.Find("MORALE_1").GetComponent<Text>();
	}
	
	
	void Update () {
        MORALE.text = morale.ToString();
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (hit.collider!=null) {
                if (hit.collider.tag == "Card")
                {
                    morale -= hit.collider.GetComponent<Values>().cost;
                }
            }
        }
    }
}

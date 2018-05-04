using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Mana : NetworkBehaviour {
    [SyncVar]
    public int mana;
    private Text MANA;
	void Start () {
        MANA = GameObject.Find("MANA_1").GetComponent<Text>();
	}
	
	
	void Update () {
        MANA.text = mana.ToString();
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (hit.collider!=null) {
                if (hit.collider.tag == "Card")
                {
                    CmdOnClick(hit.collider.GetComponent<Values>().cost);
                }
            }
        }
    }
    [Command]
    void CmdOnClick(int cost)
    {
        mana -= cost;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardOnField : MonoBehaviour {
    
    public GameObject player;
    public bool onhand, onfield;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        onhand = false;
        onfield = false;
    }

	void Update () {
        if (!Input.GetKey(KeyCode.Mouse0))
        {
            ChangeColor();
        }
    }
    void ChangeColor()
    {
        if (!Input.GetKey(KeyCode.Mouse0))
        {
            GetComponent<Image>().color = Color.white;
        }
        if (onfield == false)
        {
            GetComponent<Image>().color = Color.white;
        }
        if (onfield == true && Input.GetKey(KeyCode.Mouse0))
        {
            GetComponent<Image>().color = Color.red;
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Hand")
        {
            onhand = true;
            ChangeColor();
        }
        if (other.gameObject.name == "GameField")
        {
            onfield = true;
            ChangeColor();
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Hand")
        {
            onhand = false;
            ChangeColor();
        }
        if (other.gameObject.name == "GameField")
        {
            onfield = false;
            ChangeColor();
        }
    }
}

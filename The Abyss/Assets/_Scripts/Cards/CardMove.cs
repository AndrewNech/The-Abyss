using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMove : MonoBehaviour {

    public GameObject cardchoosed;
    public GameObject hand;
    public GameObject lastcard;
    public float speed;
	void Start () {
        lastcard = null;
        cardchoosed = null;

    }
	
	
	void Update () {
        
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        if (Input.GetKey(KeyCode.Mouse0)&&cardchoosed!=null)
        {
            lastcard = cardchoosed;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Card")
                {

                    cardchoosed = hit.collider.gameObject;
                }
                if (hit.collider.gameObject.tag != "Card")
                {
                    cardchoosed = null;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            cardchoosed = null;
        }
        if (cardchoosed != null)
        {
            cardchoosed.transform.position = Vector3.MoveTowards(cardchoosed.transform.position, new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), speed * Time.deltaTime);
        }
        if (lastcard!=null) {
            if (lastcard.transform.position != new Vector3(hand.transform.position.x, hand.transform.position.y, lastcard.transform.position.z) && lastcard != cardchoosed)
            {
                lastcard.transform.position = Vector3.Lerp(lastcard.transform.position, new Vector2(hand.transform.position.x, hand.transform.position.y), speed / 100 * Time.deltaTime);
            }
        }
    }

}

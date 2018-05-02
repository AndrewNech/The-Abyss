using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardOnClick : MonoBehaviour {

    private GameObject biggercard;
    void Start () {
    }
	

	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject == this.gameObject)
            {

                if (biggercard == null)
                {
                    biggercard = Instantiate(this.gameObject, transform);
                    biggercard.transform.SetParent(this.transform);
                    biggercard.transform.position = transform.position + Vector3.right * 3 + Vector3.up * 3;
                    biggercard.transform.localScale = new Vector3(2f, 2f, 3f);
                    biggercard.GetComponent<CardOnClick>().enabled = false;
                    biggercard.GetComponent<CardOnField>().enabled = false;
                    biggercard.GetComponent<BoxCollider2D>().enabled = false;
                }
            }


            if (hit.collider.gameObject != this.gameObject)
            {
                Destroy(biggercard);
            }
        }
        if (hit.collider==null)
        {
            Destroy(biggercard);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Destroy(biggercard);
        }
    }

}

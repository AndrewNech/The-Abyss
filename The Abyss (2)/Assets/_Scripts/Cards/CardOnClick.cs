using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardOnClick : MonoBehaviour {

    private GameObject biggercard;
    private GameObject canvas;
    void Start () {
        canvas = GameObject.Find("Canvas");
    }
	

	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject == this.gameObject&& biggercard == null&&GetComponent<CardOnField>().onhand==true)
            {

                    biggercard = Instantiate(this.gameObject, transform);
                    
                    biggercard.transform.eulerAngles = new Vector3(0f,0f,0f);
                    
                    
                    biggercard.transform.localScale = new Vector3(2f, 2f, 3f);
                    biggercard.transform.SetParent(canvas.transform);
                    GetComponent<Image>().enabled = false;
                    GetComponent<Values>().HP.enabled = false;
                    GetComponent<Values>().COST.enabled = false;
                    GetComponent<Values>().DMG.enabled = false;
                    biggercard.GetComponent<CardOnClick>().enabled = false;
                    biggercard.GetComponent<CardOnField>().enabled = false;
                    biggercard.GetComponent<BoxCollider2D>().enabled = false;
                    biggercard.GetComponent<CardMove>().enabled = false;
                    biggercard.GetComponent<Image>().enabled = true;
                biggercard.GetComponent<CardClickHelper>().enabled = true;
                biggercard.GetComponent<CardClickHelper>().smallcard = this.gameObject;
                    biggercard.transform.SetAsLastSibling();
            }

        }
        if (biggercard!=null)
        {
            biggercard.transform.position = transform.position ;
        }

       
        if (hit.collider==null|| Input.GetKey(KeyCode.Mouse0)|| hit.collider.gameObject != this.gameObject && hit.collider != null)
        {
            GetComponent<Image>().enabled = true;
            GetComponent<Values>().HP.enabled = true;
            GetComponent<Values>().COST.enabled = true;
            GetComponent<Values>().DMG.enabled = true;
            Destroy(biggercard);
        }

        
    }

}

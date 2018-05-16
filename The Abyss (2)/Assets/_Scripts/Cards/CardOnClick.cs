using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardOnClick : MonoBehaviour {

    public GameObject biggercard;
    private GameObject canvas;
    public LayerMask masktosee;
    void Start () {
        canvas = GameObject.Find("Canvas");
        masktosee = GetComponent<CardMove>().masktosee;
    }
	

	void FixedUpdate () {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, Mathf.Infinity, masktosee);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject == this.gameObject&& biggercard == null&&Vector2.Distance(transform.position,GetComponent<CardMove>().SetStartCoord) <0.6f)
            {

                if (!Input.GetKey(KeyCode.Mouse0)) {
                    biggercard = Instantiate(this.gameObject, transform.position + Vector3.up * 1.5f, Quaternion.identity,this.transform);
                    biggercard.GetComponent<BoxCollider2D>().enabled = false;
                    biggercard.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                    biggercard.GetComponent<Image>().enabled = true;

                    biggercard.transform.localScale = new Vector3(2f, 2f, 3f);
                    biggercard.transform.SetParent(canvas.transform);
                    GetComponent<Image>().enabled = false;
                    GetComponent<Values>().HP.enabled = false;
                    GetComponent<Values>().COST.enabled = false;
                    GetComponent<Values>().DMG.enabled = false;
                    GetComponent<Values>().NAME.enabled = false;
                    biggercard.GetComponent<CardOnClick>().enabled = false;
                    biggercard.GetComponent<CardOnField>().enabled = false;
                    biggercard.GetComponent<CardMove>().enabled = false;
                    biggercard.GetComponent<CardPlay>().enabled = false;

                    biggercard.GetComponent<CardClickHelper>().enabled = true;
                    biggercard.GetComponent<CardClickHelper>().smallcard = this.gameObject;
                }
            }

        }
        if (biggercard!=null)
        {
            biggercard.transform.SetAsLastSibling();
            biggercard.transform.position = transform.position+Vector3.up*1.5f ;
        }

       
        if (hit.collider==null|| Input.GetKey(KeyCode.Mouse0)|| hit.collider.gameObject != this.gameObject && hit.collider != null)
        {
            GetComponent<Image>().enabled = true;
            GetComponent<Values>().HP.enabled = true;
            GetComponent<Values>().NAME.enabled = true;
            GetComponent<Values>().COST.enabled = true;
            GetComponent<Values>().DMG.enabled = true;
            Destroy(biggercard);
        }

        
    }

}

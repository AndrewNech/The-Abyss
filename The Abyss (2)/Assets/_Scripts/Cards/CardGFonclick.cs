using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGFonclick : MonoBehaviour {

    public GameObject biggercard;
    public LayerMask masktosee;
    void Start () {
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, Mathf.Infinity, masktosee);
        if (biggercard != null)
        {
            SetCard();
        }
        if (hit.collider != null)
        {
            if (hit.transform.gameObject == this.gameObject && biggercard == null)
            {

                if (!Input.GetKey(KeyCode.Mouse0))
                {
                    ShowCard();
                }
            }
        }

        if (hit.collider == null || Input.GetKey(KeyCode.Mouse0) || hit.collider.gameObject != this.gameObject && hit.collider != null)
        {
            DestroyCard();
        }
    }
    void SetCard()
    {
        biggercard.transform.SetAsLastSibling();
        biggercard.transform.position = transform.position + Vector3.up * 1.5f + Vector3.right * 2;
    }
    void ShowCard()
    {
        biggercard = Instantiate(this.gameObject, transform.position + Vector3.up * 1.5f + Vector3.right * 2, Quaternion.identity);
        biggercard.GetComponent<BoxCollider2D>().enabled = false;
        biggercard.transform.SetParent(this.gameObject.transform);
        biggercard.transform.localScale = new Vector3(2f, 2f, 3f);
        biggercard.GetComponent<Values>().m_hp = int.Parse(GetComponent<Values>().allcard.Attributes["health"].Value);
        biggercard.GetComponent<Values>().m_cost = int.Parse(GetComponent<Values>().allcard.Attributes["cost"].Value);
        biggercard.GetComponent<Values>().m_dmg = int.Parse(GetComponent<Values>().allcard.Attributes["damage"].Value);
        biggercard.GetComponent<Values>().m_cardname = GetComponent<Values>().allcard.Attributes["name"].Value;
    }
    void DestroyCard()
    {
        Destroy(biggercard);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnergy : MonoBehaviour
{

    public int maxenergy;
    public int energy;
    private bool coroutineenergystarted;
    private bool attackline;
    public GameObject linerenderer;
    private GameObject instantiatedline;
    public LayerMask masktosee;

    private CardOnGameField cardOnGameField;

    void Start()
    {
        cardOnGameField = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CardOnGameField>();
        coroutineenergystarted = false;
        maxenergy = int.Parse(GetComponent<Values>().allcard.Attributes["energy"].Value);
    }
    IEnumerator Energyplus()
    {
        coroutineenergystarted = true;
        yield return new WaitForSeconds(0.1f);
        energy = energy + 1;
        coroutineenergystarted = false;

    }
    void Update()
    {

        if (energy < maxenergy && coroutineenergystarted == false)
        {
            StartCoroutine(Energyplus());
        }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, Mathf.Infinity, masktosee);
        if (hit.collider != null)
        {
            //if hit=this
            if (hit.collider.gameObject == this.gameObject)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    instantiatedline = Instantiate(linerenderer, transform);
                    attackline = true;
                }

            }
            //if hit=other card
                if (Input.GetKeyUp(KeyCode.Mouse0)&& energy == maxenergy && hit.collider.gameObject != this.gameObject)
                {
                 energy = 0;
                for(int i = 0; i < cardOnGameField.cardsOnGameField.Count; i++)
                {
                    if (hit.collider.gameObject == cardOnGameField.cardsOnGameField[i])
                    {
                        cardOnGameField.cardsOnGameField.RemoveAt(i);
                        Destroy(hit.collider.gameObject);
                    }
                }

            }
        }
        
            if (!Input.GetKey(KeyCode.Mouse0))
            {
                attackline = false;
                Destroy(instantiatedline);
            }

            if (attackline == true)
            {
                instantiatedline.GetComponent<LineRenderer>().positionCount = 2;
                instantiatedline.GetComponent<LineRenderer>().SetPosition(0, new Vector3(transform.position.x, transform.position.y, 0));
                instantiatedline.GetComponent<LineRenderer>().SetPosition(1, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0));
            }

        
    }
}

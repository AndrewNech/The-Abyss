using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pages : MonoBehaviour {
    public int page;
    public GameObject next, prev;

    public void NextPage()
    {
        page++;
        MoveCardsLeft();
        if (GetComponent<CollectionCard>().cardsincollection.Count<page*10)
        {
            next.SetActive(false);
        }
        prev.SetActive(true);
    }
    public void PreviousPage()
    {
        MoveCardsRight();
        page--;
        if (GetComponent<CollectionCard>().cardsincollection.Count>=page*10)
        {
            next.SetActive(true);
        }
        if (page <= 0)
        {
            prev.SetActive(false);
        }

    }
    public void MoveCardsLeft()
    {

            for (int i=0; i< GetComponent<CollectionCard>().cardsincollection.Count; i++)
            {
            Debug.Log(i);
                GetComponent<CollectionCard>().cardsincollection[i].transform.position = GetComponent<CollectionCard>().cardsincollection[i].transform.position + Vector3.left * 18f;
            }
    }
    public void MoveCardsRight()
    {
       
        for (int i = 0; i < GetComponent<CollectionCard>().cardsincollection.Count; i++)
        {
          
                GetComponent<CollectionCard>().cardsincollection[i].transform.position = GetComponent<CollectionCard>().cardsincollection[i].transform.position -Vector3.left * 18f;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardOnHand : MonoBehaviour
{
    private Vector3 startPos = new Vector3(0, -361, 0);

    private List<GameObject> cardsOnHand = new List<GameObject>();
    public GameObject Prefab;

    private int maxLenght = 10;
    public int cardCount;

    private bool keyForCouroutine = true;
    

    void Start()
    {


        for (int i = 0; i < cardCount; i++)
        {
            try
            {
                cardsOnHand.Add(Instantiate(Prefab, startPos, Quaternion.identity));
                cardsOnHand[i].transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
               
            }
            catch (ArgumentOutOfRangeException)
            {

            } 
        }
        ReprlaceCard();

    }

    
    public void AddCard()
    {

        if (cardsOnHand.Count < 10 && keyForCouroutine)
        {
            StartCoroutine(newCard());
        }
    }
    public IEnumerator newCard()
    {
        keyForCouroutine = false;
        yield return new WaitForSeconds(1f);
        cardsOnHand.Add(Instantiate(Prefab, startPos, Quaternion.identity));
        cardsOnHand[cardsOnHand.Count - 1].transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        keyForCouroutine = true;
        ReprlaceCard();
    }
    public void ReprlaceCard()
    {
        float _distance;
        for (int i = 0; i < cardsOnHand.Count; i++)
        {

            try
            {
                _distance = (-Distance() * cardsOnHand.Count / 2 + Distance() * i);
                cardsOnHand[i].transform.localPosition = startPos;
                cardsOnHand[i].transform.position = new Vector3(cardsOnHand[i].transform.position.x + _distance, cardsOnHand[i].transform.position.y - ((1 + (Mathf.Pow((-(cardsOnHand.Count - 1f) / 2 + i), 2) / (3.5f * 3.5f))) * 0.1f) * 4f, cardsOnHand[i].transform.position.z - i / 100f);
                cardsOnHand[i].transform.localRotation = new Quaternion(0, 0, cardsOnHand[i].transform.position.x / 2f, -12f);

                cardsOnHand[i].transform.SetSiblingIndex(1 + i);

                cardsOnHand[i].GetComponent<CardMove>().cardplaceid = i;
                cardsOnHand[i].GetComponent<CardMove>().startrot = cardsOnHand[i].transform.localRotation;
                cardsOnHand[i].GetComponent<CardMove>().startcoord = cardsOnHand[i].transform.position;
                cardsOnHand[i].GetComponent<CardMove>().sibling = cardsOnHand[i].transform.GetSiblingIndex();
            }
            catch (MissingReferenceException)
            {
                cardsOnHand.RemoveAt(i);
                ReprlaceCard();
            }
        }
       
        if (cardsOnHand.Count < 10)
        {
            AddCard();
        }
    }
    #region Distance
    private float Distance()
    {
        if (cardCount < 4)
        {
            return 1f;
        }
        else if (cardCount < 8)
        {
            return 0.9f;
        }
        else
        {
            return 0.7f;
        }
    }
    #endregion
}

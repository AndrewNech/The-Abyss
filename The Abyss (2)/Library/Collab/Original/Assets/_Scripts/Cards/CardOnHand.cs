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
    public void ReprlaceCard()
    {
        float _distance;
        for (int i = 0; i < cardsOnHand.Count; i++)
        {     _distance = (-Distance() * cardCount / 2 + Distance() * i);
            cardsOnHand[i].transform.position = new Vector3(cardsOnHand[i].transform.position.x + _distance, cardsOnHand[i].transform.position.y - ((1 + (Mathf.Pow(_distance, 2) / (3.5f * 3.5f))) * 0.1f), cardsOnHand[i].transform.position.z + i / 100f);
            cardsOnHand[i].transform.localRotation = new Quaternion(0, 0, cardsOnHand[i].transform.position.x*2, -12f);


            //if (i % 2 == 0)
            //{
            //    cardsOnHand[i].transform.position = new Vector3(cardsOnHand[i].transform.position.x - Distance() * i, cardsOnHand[i].transform.position.y, cardsOnHand[i].transform.position.z + i / 100f);
            //    cardsOnHand[i].transform.localRotation = new Quaternion(0, 0, 2f * i / 10, 12f);
            //    cardsOnHand[i].GetComponent<CardMove>().startcoord = cardsOnHand[i].transform.position;
            //}
            //else
            //{
            //    cardsOnHand[i].transform.position = new Vector3(cardsOnHand[i].transform.position.x + Distance() + Distance() * i, cardsOnHand[i].transform.position.y, cardsOnHand[i].transform.position.z);
            //    cardsOnHand[i].transform.localRotation = new Quaternion(0, 0, -2f * i / 10, 12f);
            //    cardsOnHand[i].GetComponent<CardMove>().startcoord = cardsOnHand[i].transform.position;
            //}
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

    void Update()
    {

    }
}

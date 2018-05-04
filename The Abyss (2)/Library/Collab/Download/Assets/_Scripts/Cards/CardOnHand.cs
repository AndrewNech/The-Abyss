﻿using System;
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
        for(int i = 0; i < cardsOnHand.Count; i++)
        {   
            if (i % 2 == 0)
            {
                cardsOnHand[i].transform.position = new Vector3(cardsOnHand[i].transform.position.x - Distance() * i, cardsOnHand[i].transform.position.y - ((1 + (Mathf.Pow(i, 2) / (3.5f * 3.5f))) * 0.1f), i*10);
                cardsOnHand[i].transform.localRotation = new Quaternion(0, 0, 2f*i/10, 12f);
                cardsOnHand[i].transform.SetSiblingIndex(-i+10);
                cardsOnHand[i].GetComponent<CardMove>().startrot = cardsOnHand[i].transform.localRotation;
                cardsOnHand[i].GetComponent<CardMove>().startcoord = cardsOnHand[i].transform.position;
            }
            else
            {
                
                cardsOnHand[i].transform.position = new Vector3(cardsOnHand[i].transform.position.x + Distance() + Distance() * i, cardsOnHand[i].transform.position.y - ((1 + (Mathf.Pow(i, 2) / (3.5f * 3.5f))) * 0.1f), i*10);
                cardsOnHand[i].transform.localRotation = new Quaternion(0, 0, -2f * i / 10, 12f);
                cardsOnHand[i].transform.SetSiblingIndex(-i+10);
                cardsOnHand[i].GetComponent<CardMove>().startrot = cardsOnHand[i].transform.localRotation;
                cardsOnHand[i].GetComponent<CardMove>().startcoord = cardsOnHand[i].transform.position;
            }
        }
       

    }
    private float Distance()
    {
        if (cardCount < 4)
        {
            return 1f;
        }
        else if (cardCount < 8)
        {
            return 0.7f;
        }
        else
        {
            return 0.5f;
        }
    }

    void Update()
    {

    }
}

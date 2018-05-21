﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlay : MonoBehaviour
{

    private List<GameObject> cardsOnGameField = new List<GameObject>();

    public GameObject prefabPersonage;
    private GameObject canvas;
    private GameObject player;


    private CardOnGameField gameField;
    private CardOnHand CardOnHand;


    private Vector3 startPos = new Vector3(0, -100, 0);

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.Find("Canvas");
        gameField = canvas.GetComponent<CardOnGameField>();
        CardOnHand = canvas.GetComponent<CardOnHand>();
    }


    void Update()
    {
        if (GetComponent<CardOnField>().onfield == true && Input.GetKeyUp(KeyCode.Mouse0))
        {
            Cardplay();
        }
    }

    void Cardplay()
    {
        transform.SetAsFirstSibling();
        if (gameField.AddCardOnGameField()) 
        {
            player.GetComponent<Mana>().mana -= GetComponent<Values>().m_cost;
            Destroy(this.gameObject);
            CardOnHand.ReprlaceCard();
        }
    }

}

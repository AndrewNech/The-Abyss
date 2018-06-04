using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

public class CollectionCard : MonoBehaviour
{

    

    AllCards allCards;
    public GameObject emptycard;
    public List<GameObject> cardsincollection = new List<GameObject>();
    private XmlDocument playercards=new XmlDocument();

    private Vector3 startPos = new Vector3(-750, 250, 0);

    void Start()
    {
        allCards = GameObject.Find("AllCardsScripter").GetComponent<AllCards>();
        playercards = allCards.accestocard.playercardsxml;
        ShowCardOnCollection();

    }
    public void ShowCardOnCollection()
    {
        XmlNodeList playercardsnodelist = playercards.GetElementsByTagName("card");

        for (int i=0;i<playercardsnodelist.Count;i++)
        {
            
            if (int.Parse(playercardsnodelist[i].Attributes["count"].Value) > 0)
            {
              GameObject newcard=Instantiate(emptycard, startPos, Quaternion.identity);
                cardsincollection.Add(newcard);
              newcard.transform.localPosition = startPos;
                newcard.transform.SetParent(GameObject.Find("CardsInCollection").transform, false);

                newcard.transform.localScale *= 2.5f;
                newcard.GetComponent<Values>().id = int.Parse(playercardsnodelist[i].Attributes["id"].Value);
                newcard.GetComponent<CardPlay>().enabled = false;
                newcard.GetComponent<CardMove>().enabled = false;
                newcard.GetComponent<CardClickHelper>().enabled = false;
                newcard.GetComponent<CardOnClick>().enabled = false;
                newcard.GetComponent<CardOnField>().enabled = false;
            }
        }
        bool check = false;
        for (int i = 0; i < cardsincollection.Count; i++)
        {
            if (i % 5 == 0&&i!=0)
            {
                check = !check;
            }
            if (check==false) {
                cardsincollection[i].transform.position = new Vector3(cardsincollection[i].transform.position.x + i * 1.8f, cardsincollection[i].transform.position.y, 0);
            }
            if (check == true)
            {
                cardsincollection[i].transform.position = new Vector3(cardsincollection[i].transform.position.x + (i-5) * 1.8f, cardsincollection[i].transform.position.y-3f, 0);
            }
        }
        
    }
}
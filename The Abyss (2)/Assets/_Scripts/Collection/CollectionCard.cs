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
        int ver = 0;
        int hor = 0;
        int column = 1;
        foreach (XmlNode node in playercardsnodelist)
        {
            
            if (int.Parse(node.Attributes["count"].Value) > 0)
            {
              GameObject newcard=Instantiate(emptycard, startPos, Quaternion.identity);
              newcard.transform.localPosition = startPos;
                newcard.transform.position = new Vector3(newcard.transform.position.x, newcard.transform.position.y - ver, newcard.transform.position.z);
                newcard.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

                newcard.transform.localScale *= 2.5f;
                if (hor % 5 == 0 && hor != 0)
                {
                    hor = 0;
                    ver++;
                }
                newcard.transform.position = new Vector3(newcard.transform.position.x + hor * 1.8f, newcard.transform.position.y - ver * 2.7f, newcard.transform.position.z);

                newcard.GetComponent<Values>().id = int.Parse(node.Attributes["id"].Value);
                newcard.GetComponent<CardPlay>().enabled = false;
                newcard.GetComponent<CardMove>().enabled = false;
                newcard.GetComponent<CardClickHelper>().enabled = false;
                newcard.GetComponent<CardOnClick>().enabled = false;
                newcard.GetComponent<CardOnField>().enabled = false;
            }
            hor++;
        }
 
    }
}
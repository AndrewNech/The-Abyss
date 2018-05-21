using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;

public class Deck : MonoBehaviour
{

    public LayerMask masktosee;

    public List<GameObject> cardsindeck = new List<GameObject>();
    public Button deckbutton;
    private AllCards allcardsscripter;
    private int deckchoosedid;
    public GameObject objInDeck;
    private GameObject canvas;
    private int tempi = 0;
    private List<GameObject> cardsInDecVisual = new List<GameObject>();//Те которые будут визуализироваться в сцене

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        allcardsscripter = GameObject.Find("AllCardsScripter").GetComponent<AllCards>();
        XmlNodeList decks = allcardsscripter.accestocard.playercardsxml.GetElementsByTagName("decks");
        for (int i=0;i<= int.Parse(decks[0].Attributes["deckcount"].Value)-1;i++)
        {
            tempi++;
            Button button = Instantiate(deckbutton, canvas.transform);
            button.transform.position = new Vector3(transform.position.x-10f, transform.position.y + 2.5f - i+1 / 2, transform.position.z);
            button.GetComponentInChildren<Text>().text = "Deck "+i.ToString();
        }
    }

    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, Mathf.Infinity, masktosee);
        if (hit.collider != null && hit.collider.tag == "Card")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                AddCardInDeck(hit.collider.gameObject);
            }
        }


    }
    public void CreateNewDeck()
    {
        XmlNodeList decks = allcardsscripter.accestocard.playercardsxml.GetElementsByTagName("decks");
        if (int.Parse(decks[0].Attributes["deckcount"].Value)<6) {
            int temp = int.Parse(decks[0].Attributes["deckcount"].Value) + 1;
            decks[0].Attributes["deckcount"].Value = temp.ToString();
            Button button = Instantiate(deckbutton, canvas.transform);
            button.transform.position = new Vector3(transform.position.x-10f, transform.position.y+2.5f - int.Parse(decks[0].Attributes["deckcount"].Value)+ tempi / 2, transform.position.z);
            button.GetComponentInChildren<Text>().text = "Deck " + decks[0].Attributes["deckcount"].Value;
            allcardsscripter.accestocard.playercardsxml.Save(Application.dataPath + "/Resources/XML/PlayerCards.xml");
        }
    }

    void AddCardInDeck(GameObject card)
    {
        cardsindeck.Add(card);
        XmlNodeList alldecks = allcardsscripter.accestocard.playercardsxml.GetElementsByTagName("deck");

        foreach (XmlNode deck in alldecks)
        {
            if (int.Parse(deck.Attributes["id"].Value) == 1)
            {
                if (deck.Attributes["cards"].Value != "")
                {
                    deck.Attributes["cards"].Value = deck.Attributes["cards"].Value + "," + card.GetComponent<Values>().id.ToString();
                }
                else
                {
                    deck.Attributes["cards"].Value = deck.Attributes["cards"].Value + card.GetComponent<Values>().id.ToString();
                }
                allcardsscripter.accestocard.playercardsxml.Save(Application.dataPath + "/Resources/XML/PlayerCards.xml");
            }
        }
        //Добавление в визуальную коллекцию
        if (cardsInDecVisual.Count != 0)
        {
            cardsInDecVisual.Add(Instantiate(objInDeck, new Vector3(0, 0, 0), new Quaternion()));
            cardsInDecVisual[cardsInDecVisual.Count - 1].transform.SetParent(GameObject.FindGameObjectWithTag("Deck").transform, false);
            cardsInDecVisual[cardsInDecVisual.Count - 1].transform.position = new Vector3(cardsInDecVisual[cardsInDecVisual.Count - 2].transform.position.x, cardsInDecVisual[cardsInDecVisual.Count - 2].transform.position.y - 0.3f, 0);
            cardsInDecVisual[cardsInDecVisual.Count - 1].transform.Find("Text").GetComponent<Text>().text = card.GetComponent<Values>().allcard.Attributes["name"].Value;
        }
        else
        {
            cardsInDecVisual.Add(Instantiate(objInDeck, new Vector3(0, 0, 0), new Quaternion()));
            cardsInDecVisual[cardsInDecVisual.Count - 1].transform.SetParent(GameObject.FindGameObjectWithTag("Deck").transform, false);
            cardsInDecVisual[cardsInDecVisual.Count - 1].transform.localPosition = new Vector3(0, 350f, 0);
            cardsInDecVisual[cardsInDecVisual.Count - 1].transform.Find("Text").GetComponent<Text>().text = card.GetComponent<Values>().allcard.Attributes["name"].Value;
        }


    }
}


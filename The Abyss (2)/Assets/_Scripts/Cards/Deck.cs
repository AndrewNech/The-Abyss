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
    private List<GameObject> deckbuttons = new List<GameObject>();
    public GameObject deckbutton;
    private AllCards allcardsscripter;
    private int deckchoosedid;
    public GameObject objInDeck;
    private GameObject canvas;
    private List<GameObject> cardsInDecVisual = new List<GameObject>();//Те которые будут визуализироваться в сцене

    void Start() 
    {
        canvas = GameObject.Find("Canvas");
        allcardsscripter = GameObject.Find("AllCardsScripter").GetComponent<AllCards>();
        XmlNodeList decks = allcardsscripter.accestocard.playercardsxml.GetElementsByTagName("decks");
        CreateNewDeck(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            ChangeDeckName();
        }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, Mathf.Infinity, masktosee);
        if (hit.collider != null && hit.collider.tag == "Card")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                AddCardInDeck(hit.collider.gameObject);
            }
        }
        if (hit.collider != null && hit.collider.tag == "DeckButton")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ChooseDeck(hit.collider.gameObject);
                
            }
        }


    }
    public void ChooseDeck(GameObject button)
    {
        for (int i = 0; i < deckbuttons.Count; i++)
        {
            deckbuttons[i].GetComponent<Image>().color = Color.white;
        }
        button.GetComponent<Image>().color = Color.blue;
        deckchoosedid = button.GetComponent<DeckID>().id;
    }
    public void ChangeDeckName()
    {
        XmlNodeList alldecks = allcardsscripter.accestocard.playercardsxml.GetElementsByTagName("deck");
        
        foreach (XmlNode deck in alldecks)
        {
                if (int.Parse(deck.Attributes["id"].Value) == deckchoosedid)
                {
                    if (deckbuttons[deckchoosedid].GetComponentInChildren<InputField>().text!="") {
                        deck.Attributes["name"].Value = deckbuttons[deckchoosedid].GetComponentInChildren<InputField>().text; 
                        allcardsscripter.accestocard.playercardsxml.Save(Application.dataPath + "/Resources/XML/PlayerCards.xml");
                    }
                }
            
        }
    }
    
    public void CreateNewDeck(bool start)
    {
        XmlNodeList alldecks = allcardsscripter.accestocard.playercardsxml.GetElementsByTagName("deck");
        XmlNodeList decks = allcardsscripter.accestocard.playercardsxml.GetElementsByTagName("decks");
        if (int.Parse(decks[0].Attributes["deckcount"].Value) < 6||start==true)
        {
            if (!start)
            {
                int temp = int.Parse(decks[0].Attributes["deckcount"].Value) + 1;
                decks[0].Attributes["deckcount"].Value = temp.ToString();
            }

            for (int i = 0; i < int.Parse(decks[0].Attributes["deckcount"].Value); i++)
            {
                deckbuttons.Add(Instantiate(deckbutton, canvas.transform));
                deckbuttons[i].transform.position = new Vector3(-5f, 3f - i, transform.position.z);
                deckbuttons[i].GetComponent<DeckID>().id = i;
                deckbuttons[i].GetComponentInChildren<InputField>().text = alldecks[i].Attributes["name"].Value;
                allcardsscripter.accestocard.playercardsxml.Save(Application.dataPath + "/Resources/XML/PlayerCards.xml");
            }
        }
            
    }
    void AddCardInDeck(GameObject card)
    {
        cardsindeck.Add(card);
        XmlNodeList alldecks = allcardsscripter.accestocard.playercardsxml.GetElementsByTagName("deck");
        
        foreach (XmlNode deck in alldecks)
        {
            if (int.Parse(deck.Attributes["id"].Value) == deckchoosedid)
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
        Destroy(card);
        Camera.main.GetComponent<CollectionCard>().cardsincollection.Remove(card);
    }
}


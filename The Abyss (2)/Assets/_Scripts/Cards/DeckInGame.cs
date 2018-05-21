using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;

public class DeckInGame : MonoBehaviour {

    private AllCards allcards;
    public List<int> ids = new List<int>();
    void Awake () {
        allcards = GameObject.Find("AllCardsScripter").GetComponent<AllCards>();
        XmlNodeList decks = allcards.accestocard.playercardsxml.GetElementsByTagName("deck");

            string cards = decks[1].Attributes["cards"].Value;
            string[] characters = cards.Split(',');
        foreach (string str in characters)
        {
              if (str!="") {
              ids.Add(int.Parse(str));
              }
        }
        
	}

}


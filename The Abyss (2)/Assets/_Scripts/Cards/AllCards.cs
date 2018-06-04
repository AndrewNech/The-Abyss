using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;

public class AllCards : MonoBehaviour
{
    private string path;
    public Cards accestocard = new Cards();

    private void Awake()
    {
        //XmlHelper
        accestocard.Awake();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            accestocard.AddCardInCollection(1);
        }
    }
}
[Serializable]
public class Cards
{
    public XmlDocument allcardsxml = new XmlDocument();
    public XmlDocument playercardsxml = new XmlDocument();
    public void Awake()
    {
        //XML
        TextAsset ptext = (TextAsset)Resources.Load("XML/PlayerCards");
        TextAsset ctext = (TextAsset)Resources.Load("XML/Cards");
        allcardsxml.LoadXml(ctext.text);
        playercardsxml.LoadXml(ptext.text);
    }
    public void AddCardInCollection(int cardid)
    {
        XmlNodeList playercardsnodelist = playercardsxml.GetElementsByTagName("card");
        foreach (XmlNode node in playercardsnodelist)
        {
            if (int.Parse(node.Attributes["id"].Value) == cardid)
            {
                int temp = int.Parse(node.Attributes["count"].Value) + 1;
                node.Attributes["count"].Value = temp.ToString();
                playercardsxml.Save(Application.dataPath+"/Resources/XML/PlayerCards.xml");
            }
        }
    }
}





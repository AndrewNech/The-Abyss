using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Linq;
using System;
public class Values : MonoBehaviour {

    public Text HP;
    public Text DMG;
    public Text COST;
    public Text NAME;
    private GameObject allcardsscripter;
    public XmlNode allcard;

    public int id;
    private int hp
    {
        get
        {
            return m_hp;
        }
        set
        {
            HP.text = value.ToString();
        }
    }
    private int dmg
    {
        get
        {
            return m_dmg;
        }
        set
        {
            DMG.text = value.ToString();
        }
    }
    private int cost
    {
        get
        {
            return m_cost;
        }
        set
        {
            COST.text = value.ToString();
        }
    }
    public string cardname
    {
        get
        {
            return m_cardname;
        }
        set
        {
            NAME.text = value;
        }
    }
    public int m_hp;
    public string m_cardname;
    public int m_cost;
    public int m_dmg;


    private void Start()
    {
        allcardsscripter = GameObject.Find("AllCardsScripter");
        XmlNodeList nodelist = allcardsscripter.GetComponent<AllCards>().accestocard.allcardsxml.GetElementsByTagName("card");
        allcard = nodelist[id];
        m_hp = int.Parse(allcard.Attributes["health"].Value);
        m_dmg = int.Parse(allcard.Attributes["damage"].Value);
        m_cost = int.Parse(allcard.Attributes["cost"].Value);
        COST.text = cost.ToString();
        DMG.text = dmg.ToString();
        HP.text = hp.ToString();
        NAME.text = allcard.Attributes["name"].Value;
        m_cardname = allcard.Attributes["name"].Value;
        if (Type.GetType(allcard.Attributes["script"].Value)!=null) {
            AddScript();
        }
    }
    void AddScript()
    {
        gameObject.AddComponent(Type.GetType(allcard.Attributes["script"].Value));
    }
    public void UpdateStatsToEmpty()
    {
        allcardsscripter = GameObject.Find("AllCardsScripter");
        XmlNodeList nodelist = allcardsscripter.GetComponent<AllCards>().accestocard.allcardsxml.GetElementsByTagName("card");
        allcard = nodelist[id];
        m_hp = int.Parse(allcard.Attributes["health"].Value);
        m_dmg = int.Parse(allcard.Attributes["damage"].Value);
        m_cost = int.Parse(allcard.Attributes["cost"].Value);
        COST.text = cost.ToString();
        DMG.text = dmg.ToString();
        HP.text = hp.ToString();
        NAME.text = allcard.Attributes["name"].Value;
        m_cardname = allcard.Attributes["name"].Value;
    }
}

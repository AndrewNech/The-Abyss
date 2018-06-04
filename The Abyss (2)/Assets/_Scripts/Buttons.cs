using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Linq;
using System;
using UnityEngine.UI;
public class Buttons : MonoBehaviour {


    public GameObject settings;
    private GameObject allcardsscripter;
    public void Start()
    {
        allcardsscripter = GameObject.Find("AllCardsScripter");
        //SetSettingsFromXML
        XmlNodeList nodelist = allcardsscripter.GetComponent<AllCards>().accestocard.playercardsxml.GetElementsByTagName("qualitylevel");
        QualitySettings.SetQualityLevel(int.Parse(nodelist[0].Attributes["index"].Value));

    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Play()
    {
        Application.LoadLevel("Test");
    }
    public void Settings()
    {
        settings.SetActive(true);
    }
    public void Collection()
    {
        Application.LoadLevel("Collection");
    }

    //SettingsButtons
    public void Fantastic()
    {
        QualitySettings.SetQualityLevel(5);
    }
    public void Beautiful()
    {
        QualitySettings.SetQualityLevel(4);
    }
    public void Good()
    {
        QualitySettings.SetQualityLevel(3);
    }
    public void Simple()
    {
        QualitySettings.SetQualityLevel(2);
    }
    public void Fast()
    {
        QualitySettings.SetQualityLevel(1);
    }
    public void Fastest()
    {
        QualitySettings.SetQualityLevel(0);
    }
    public void Apply()
    {
        XmlNodeList quality = allcardsscripter.GetComponent<AllCards>().accestocard.playercardsxml.GetElementsByTagName("qualitylevel");
        quality[0].Attributes["index"].Value = QualitySettings.GetQualityLevel().ToString();
        allcardsscripter.GetComponent<AllCards>().accestocard.playercardsxml.Save(Application.dataPath + "/Resources/XML/PlayerCards.xml");
    }
    public void ExitSettings()
    {
        settings.SetActive(false);
        XmlNodeList nodelist = allcardsscripter.GetComponent<AllCards>().accestocard.playercardsxml.GetElementsByTagName("qualitylevel");
        QualitySettings.SetQualityLevel(int.Parse(nodelist[0].Attributes["index"].Value));
    }
}

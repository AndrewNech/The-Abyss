using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CollectionCard : MonoBehaviour
{

    public CollectCard collectCard = new CollectCard() { cardcount = new int[2], ids = new int[2] };

    AllCards allCards;

    public List<GameObject> cardOnScene = new List<GameObject>();

    private string json;

    private Vector3 startPos = new Vector3(0, 1, 0);

    void Start()
    {
        allCards = GameObject.Find("AllCardsScripter").GetComponent<AllCards>();
        CollectLoad();
        ShowCardOnCollection();
    }
    public void CollectLoad()
    {
        try
        {
            json = File.ReadAllText(Application.streamingAssetsPath+"/Save.json");
            collectCard = JsonUtility.FromJson<CollectCard>(json);
        }
        catch(Exception ex)
        {
            print(ex.Message);
        }

    }
    public void ShowCardOnCollection()
    {
        for (int i = 0; i < collectCard.ids.Length; i++)
        {
           
            if (collectCard.cardcount[i] > 0)
            {
                cardOnScene.Add(Instantiate(allCards.allcards[collectCard.ids[i] - 1], startPos, Quaternion.identity));
                cardOnScene[i].transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                 cardOnScene[i].transform.localPosition = startPos;
                cardOnScene[i].transform.position = new Vector3(cardOnScene[i].transform.position.x, cardOnScene[i].transform.position.y - i*3, cardOnScene[i].transform.position.z);

                cardOnScene[i].GetComponent<CardPlay>().enabled = false;
                cardOnScene[i].GetComponent<CardMove>().enabled = false;
                cardOnScene[i].GetComponent<CardClickHelper>().enabled = false;
                cardOnScene[i].GetComponent<CardOnClick>().enabled = false;
                cardOnScene[i].GetComponent<CardOnField>().enabled = false;
            }
        }
    }
}
public class CollectCard
{
    public int[] cardcount;
    public int[] ids;

}
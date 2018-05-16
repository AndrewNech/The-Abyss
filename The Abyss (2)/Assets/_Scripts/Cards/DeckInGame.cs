using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DeckInGame : MonoBehaviour {

    public List<GameObject> cards = new List<GameObject>();
    public int deckcount;
    private List<int> ids = new List<int>();
    public CardsInDeck cardsjson = new CardsInDeck();
    private string path;
    private AllCards allcards; 
    private string json;
	void Awake () {
        allcards = GameObject.Find("AllCardsScripter").GetComponent<AllCards>();
        path = Application.persistentDataPath + "/" + deckcount.ToString() + "deck.json";
        json = File.ReadAllText(path);
        cardsjson = JsonUtility.FromJson<CardsInDeck>(json);

        for (int i = 0; i < cardsjson.cardcount; i++)
        {
            cards.Add(allcards.allcards[cardsjson.ids[i]-1]);
        }
	}

    private void Update()
    {

    }
}
public class CardsInDeck
{
    public int cardcount;
    public int[] ids;

}

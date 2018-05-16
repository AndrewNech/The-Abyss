using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Deck : MonoBehaviour {

    public LayerMask masktosee;
    private string path;
    private int deckcount;
    public SaveDeck sd = new SaveDeck();
    public List<GameObject> cardsindeck = new List<GameObject>();
    void Start () {
        path = Application.persistentDataPath + "/" + deckcount.ToString() + "deck.json";
        if (File.Exists(path))
        {
            sd = JsonUtility.FromJson<SaveDeck>(File.ReadAllText(path));
        }
        if (!File.Exists(path))
        {
            string newdeck = JsonUtility.ToJson(sd);
            File.WriteAllText(path, newdeck);
        }
    }
	
	void Update () {
        
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, Mathf.Infinity, masktosee);
        if (hit.collider != null&&hit.collider.tag=="Card")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                if (Camera.main.GetComponent<CollectionCard>().collectCard.cardcount[hit.collider.gameObject.GetComponent<CardCollectable>().id-1] > 0) {
                    cardsindeck.Add(hit.collider.gameObject);
                    Camera.main.GetComponent<CollectionCard>().collectCard.cardcount[hit.collider.gameObject.GetComponent<CardCollectable>().id-1]--;
                    sd.ids.Add(hit.collider.gameObject.GetComponent<CardCollectable>().id);
                    sd.cardcount++;
                    string newdeck = JsonUtility.ToJson(sd);
                    File.WriteAllText(path, newdeck);
                }
            }
        }


    }
}
[Serializable]
public class SaveDeck{
    public int cardcount;
    public List<int> ids = new List<int>();
}

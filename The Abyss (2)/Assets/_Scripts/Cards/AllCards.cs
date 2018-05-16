using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class AllCards : MonoBehaviour {
    private string path;
    private ToSave save= new ToSave();
    public List<GameObject> allcards = new List<GameObject>();

    void Start() {
        //Json
        path = Application.persistentDataPath + "/" + "data.json";

        if (File.Exists(path))
        {
            save = JsonUtility.FromJson<ToSave>(File.ReadAllText(path));
        }
       
        for (int i = 0; i < allcards.Count; i++)
        {
            save.cardcount.Add(allcards[i].GetComponent<CardCollectable>().countofcards);
            save.ids.Add(allcards[i].GetComponent<CardCollectable>().id);
        }
        Debug.Log(path);
        if (!File.Exists(path))
        {
            string newcard=JsonUtility.ToJson(save);
            File.WriteAllText(path,newcard);
        }
        
    }




   }
[Serializable]
public class ToSave
{
    public List<int> cardcount = new List<int>();
    public List<int> ids = new List<int>();
}




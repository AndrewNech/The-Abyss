using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardOnHand : MonoBehaviour
{
    private Vector3 startPos = new Vector3(0, -361, 0);

    public List<GameObject> cardsOnHand = new List<GameObject>();
    public GameObject Prefab;

    private int maxLenght = 10;
    public int cardCount;

    private bool keyForCouroutine = true;
    public bool keyForMove = true;
    private GameObject canvas;

    void Start()
    {
        canvas = GameObject.Find("Canvas");

        for (int i = 0; i < cardCount; i++)
        {
            try
            {
                if (canvas.GetComponent<DeckInGame>().cards.Count != 0)
                {
                    int nextcard = UnityEngine.Random.Range(0, canvas.GetComponent<DeckInGame>().cards.Count);

                    cardsOnHand.Add(Instantiate(canvas.GetComponent<DeckInGame>().cards[nextcard], startPos, Quaternion.identity));
                    canvas.GetComponent<DeckInGame>().cards[nextcard] = null;
                    canvas.GetComponent<DeckInGame>().cards.RemoveAt(nextcard);

                    cardsOnHand[i].transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                    cardsOnHand[i].GetComponent<CardMove>().cardId = i;

                }
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }
        ReprlaceCard();

    }


    public void AddCard()
    {

        if (cardsOnHand.Count < 10 && keyForCouroutine)
        {
            StartCoroutine(newCard());
        }
    }
    public IEnumerator newCard()
    {

        keyForCouroutine = false;
        yield return new WaitForSeconds(1f);
        //Take random card.
        if (canvas.GetComponent<DeckInGame>().cards.Count != 0)
        {
            int nextcard = UnityEngine.Random.Range(0, canvas.GetComponent<DeckInGame>().cards.Count);

            cardsOnHand.Add(Instantiate(canvas.GetComponent<DeckInGame>().cards[nextcard], startPos, Quaternion.identity));
            canvas.GetComponent<DeckInGame>().cards[nextcard] = null;
            canvas.GetComponent<DeckInGame>().cards.RemoveAt(nextcard);

            cardsOnHand[cardsOnHand.Count - 1].transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            cardsOnHand[cardsOnHand.Count - 1].GetComponent<CardMove>().cardId = cardsOnHand.Count - 1;

        }
        keyForCouroutine = true;

        ReprlaceCard();

    }
    public void ReprlaceCard()
    {
        try
        {
            float _distance;
            for (int i = 0; i < cardsOnHand.Count; i++)
            {

                try
                {
                    _distance = (-Distance() * cardsOnHand.Count / 2 + Distance() * i);
                    cardsOnHand[i].transform.localPosition = startPos;

                    cardsOnHand[i].transform.position = new Vector3(cardsOnHand[i].transform.position.x + _distance, cardsOnHand[i].transform.position.y - ((1 + (Mathf.Pow((-(cardsOnHand.Count - 1f) / 2 + i), 2) / (3.5f * 3.5f))) * 0.1f) * 4f, cardsOnHand[i].transform.position.z - i / 100f);
                  //  cardsOnHand[i].GetComponent<CardMove>().SetStartCoord = new Vector3(cardsOnHand[i].transform.position.x + _distance, cardsOnHand[i].transform.position.y - ((1 + (Mathf.Pow((-(cardsOnHand.Count - 1f) / 2 + i), 2) / (3.5f * 3.5f))) * 0.1f) * 4f, cardsOnHand[i].transform.position.z - i / 100f);

                    cardsOnHand[i].transform.localRotation = new Quaternion(0, 0, cardsOnHand[i].transform.position.x / 2f, -12f);

                    cardsOnHand[i].transform.SetSiblingIndex(1 + i);

                    cardsOnHand[i].GetComponent<CardMove>().cardplaceid = i;
                    cardsOnHand[i].GetComponent<CardMove>().startrot = cardsOnHand[i].transform.localRotation;
                    cardsOnHand[i].GetComponent<CardMove>().SetStartCoord = cardsOnHand[i].transform.position;
                    cardsOnHand[i].GetComponent<CardMove>().sibling = cardsOnHand[i].transform.GetSiblingIndex();
                }
                catch (MissingReferenceException)
                {
                    cardsOnHand.RemoveAt(i);
                    ReprlaceCard();
                }


                if (cardsOnHand.Count < 10)
                {
                    AddCard();
                }
            }

        }
        catch (Exception exception)
        {
            print(exception.Message);
        }
    }
    #region Distance
    private float Distance()
    {
        if (cardCount < 4)
        {
            return 1f;
        }
        else if (cardCount < 8)
        {
            return 0.9f;
        }
        else
        {
            return 0.7f;
        }
    }
    #endregion

}
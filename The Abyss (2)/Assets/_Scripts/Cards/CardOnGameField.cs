using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardOnGameField : MonoBehaviour
{

    public List<GameObject> cardsOnGameField = new List<GameObject>();

    public GameObject prefabPersonage;

    private Vector3 startPos = new Vector3(0, -100, 0);

    private float _distance;

    public bool AddCardOnGameField()
    {
        if (cardsOnGameField.Count < 10)
        {
            cardsOnGameField.Add(Instantiate(prefabPersonage, startPos, Quaternion.identity));
            cardsOnGameField[cardsOnGameField.Count - 1].transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            cardsOnGameField[cardsOnGameField.Count - 1].transform.SetParent(GameObject.FindGameObjectWithTag("Pers").transform, false);
            ResortCardOnGF();
            return true;
        }
        return false;
    }
    public void ResortCardOnGF()
    {
        if (cardsOnGameField.Count % 2 == 0)
        {
            for (int i = 0; i < cardsOnGameField.Count; i++)
            {
                _distance = (-1f * cardsOnGameField.Count / 2 + 1f * i);

                cardsOnGameField[i].transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                cardsOnGameField[i].transform.localPosition = startPos;
                if (i % 2 == 0)
                {
                    cardsOnGameField[i].transform.position = new Vector3(cardsOnGameField[i].transform.position.x + _distance, cardsOnGameField[i].transform.position.y, cardsOnGameField[i].transform.position.z - i / 100f);
                }
                else
                {
                    cardsOnGameField[i].transform.position = new Vector3(cardsOnGameField[i].transform.position.x - _distance, cardsOnGameField[i].transform.position.y, cardsOnGameField[i].transform.position.z - i / 100f);
                }
            }
        }
        else
        {
            cardsOnGameField[cardsOnGameField.Count - 1].transform.position = new Vector3(cardsOnGameField[cardsOnGameField.Count - 1].transform.position.x, cardsOnGameField[cardsOnGameField.Count - 1].transform.position.y, cardsOnGameField[cardsOnGameField.Count - 1].transform.position.z);
            cardsOnGameField[cardsOnGameField.Count - 1].transform.localPosition = startPos;
            for (int i = cardsOnGameField.Count - 2; i >= 0; i--)
            {
                _distance = (1f + 0.5f * i);

                cardsOnGameField[i].transform.localPosition = startPos;
                if (i % 2 == 0)
                {
                    cardsOnGameField[i].transform.position = new Vector3(cardsOnGameField[i].transform.position.x - _distance, cardsOnGameField[i].transform.position.y, cardsOnGameField[i].transform.position.z - i / 100f);
                }
                else
                {
                    cardsOnGameField[i].transform.position = new Vector3(cardsOnGameField[i].transform.position.x + _distance - 0.5f, cardsOnGameField[i].transform.position.y, cardsOnGameField[i].transform.position.z - i / 100f);
                }
            }
        }
    }
}

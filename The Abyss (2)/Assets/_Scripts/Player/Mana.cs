using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mana : MonoBehaviour
{

    public int mana;

    private bool key = true;

    private Text MANA;
    void Start()
    {
        MANA = GameObject.Find("MANA").GetComponent<Text>();
        ManaChange(0);
    }

    public void ManaChange(int manachange)
    {
        mana = mana - manachange;

        Loop();

        MANA.text = mana.ToString();
    }
    private void Loop()
    {
        if (key)
        {
            StartCoroutine(EnlargeMana());
        }
        
    }
    private IEnumerator EnlargeMana()
    {
        key = false;
        yield return new WaitForSeconds(2f);
        mana++;
        MANA.text = mana.ToString();
        key = true;
        Loop();
    }
}

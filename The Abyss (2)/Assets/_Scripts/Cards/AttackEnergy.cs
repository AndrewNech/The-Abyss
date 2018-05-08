using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnergy : MonoBehaviour {

    public int maxenergy;
    public int energy;
    private bool coroutineenergystarted;
    public LayerMask masktosee;
	void Start () {
        coroutineenergystarted = false;
        maxenergy = GetComponent<CardCollectable>().energy;
    }
    IEnumerator Energyplus()
    {
        coroutineenergystarted = true;
        yield return new WaitForSeconds(0.1f);
        energy = energy + 1;
        coroutineenergystarted = false;

    }
	void Update () {

        if (energy<maxenergy&& coroutineenergystarted==false)
        {
            StartCoroutine(Energyplus());
        }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, Mathf.Infinity, masktosee);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject == this.gameObject)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (energy==maxenergy) {
                        energy = 0;
                    }
                }
            }
        }
        }
}

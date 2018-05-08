using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollectable : MonoBehaviour {

    public int hp, cost, dmg, energy;
    public enum ComponentType { Common = 1, Rare = 2, Mythical=3, Ancient=4 };
    public ComponentType rarity;
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

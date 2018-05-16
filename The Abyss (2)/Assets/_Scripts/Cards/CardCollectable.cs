using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CardCollectable : MonoBehaviour
{

    public int hp, cost, dmg, energy;
    public enum ComponentType { Common = 1, Rare = 2, Mythical = 3, Ancient = 4 };
    public ComponentType rarity;
    public int id;
    public int countofcards;
    public string cardname;
}
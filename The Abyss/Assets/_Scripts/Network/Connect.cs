using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Connect : NetworkBehaviour {
    [SerializeField]
    Behaviour[] componentstodisable;
	// Use this for initialization
	void Start () {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentstodisable.Length; i++)
            {
                componentstodisable[i].enabled = false;
            }
        }
	}
	


}

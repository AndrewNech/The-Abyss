using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Connect : NetworkBehaviour {
    public List<Behaviour> componentstodisable = new List<Behaviour>();
    // Use this for initialization
    void Start () {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentstodisable.Count; i++)
            {
                componentstodisable[i].enabled = false;
            }
        }
	}
	


}

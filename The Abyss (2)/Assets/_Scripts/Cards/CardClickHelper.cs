using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClickHelper : MonoBehaviour {

    public GameObject smallcard;
	void Start () {
		
	}

    private void OnDestroy()
    {
        if (smallcard!=null) {
            smallcard.transform.position = smallcard.transform.position + Vector3.up / 2.5f;
        }
    }
}

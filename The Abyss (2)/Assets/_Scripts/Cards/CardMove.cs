﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMove : MonoBehaviour
{
    public bool onmouse;
    public GameObject hand;
    public float speed;
    public Vector3 startcoord;
    public Quaternion startrot;
    private GameObject canvas;
    public LayerMask masktosee;
    public int sibling;
    public int cardplaceid;
    public RaycastHit2D hit;
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        onmouse = false;
    }


    void Update()
    {
        
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward,Mathf.Infinity,masktosee);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject == this.gameObject)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    onmouse = true;
                }
            }
            if (hit.collider.gameObject != this.gameObject&& !Input.GetKey(KeyCode.Mouse0))
            {
                    onmouse = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            onmouse = false;
        }
        if (onmouse == false)
        {
            transform.SetSiblingIndex(sibling-1);
            transform.localRotation = startrot;
            transform.position = Vector3.Lerp(transform.position, new Vector3(startcoord.x, startcoord.y, transform.position.z), speed / 100 * Time.deltaTime);
        }
        if (onmouse == true)
        {
            transform.SetAsLastSibling();
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0f);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z), speed * Time.deltaTime);
        }

    }
}

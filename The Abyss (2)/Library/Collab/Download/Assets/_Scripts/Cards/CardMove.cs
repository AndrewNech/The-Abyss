using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CardMove : NetworkBehaviour
{
    public bool onmouse;
    public GameObject hand;
    public float speed;
    public Vector3 startcoord;
    public Quaternion startrot;
    private GameObject canvas;
    public int cardplaceid;
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        onmouse = false;
    }


    void Update()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject == this.gameObject)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    onmouse = true;
                }
            }
            if (hit.collider.gameObject != this.gameObject)
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
            transform.localRotation = startrot;
            transform.position = Vector3.Lerp(transform.position, new Vector3(startcoord.x, startcoord.y, transform.position.z), speed / 100 * Time.deltaTime);
        }
        if (onmouse == true)
        {
            transform.localEulerAngles=new Vector3(0,0,0);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z), speed * Time.deltaTime);
        }

    }
}

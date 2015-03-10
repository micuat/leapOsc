using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityOSC;

public class PositionLogger : MonoBehaviour
{

    GameObject palm, handController;
    int id = 0;
    bool isClosed = true;
    Vector3 prevPosition = new Vector3();

    // Use this for initialization
    void Start()
    {
        palm = transform.parent.parent.Find("palm").gameObject;
        handController = GameObject.Find("HandController");
        id = ++handController.GetComponent<HandController>().count;
    }

    // Update is called once per frame
    void Update()
    {
        // closed
        if (Vector3.Distance(prevPosition, transform.position) < 0.00001f)
            return;
        List<object> list = new List<object>();
        list.Add(id);
        list.Add(transform.position.x);
        list.Add(transform.position.y);
        list.Add(transform.position.z);
        list.Add(1.0f);
        list.Add(0.0f);
        list.Add(0.0f);
        OSCHandler.Instance.SendMessageToClient("leapDrawing", "/sharedFace/canvas/leap/index/coord", list);
        prevPosition.x = transform.position.x;
        prevPosition.y = transform.position.y;
        prevPosition.z = transform.position.z;
    }
}

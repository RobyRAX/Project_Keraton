using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform charTransform;

    public Vector3 offset;

    bool isXavailable, isZavailable; 

    // Start is called before the first frame update
    void Start()
    {
        isXavailable = true;
        isZavailable = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (charTransform.position.x > -2.5f && charTransform.position.x < 2.5f)
            isXavailable = true;
        else
            isXavailable = false;
        if (charTransform.position.z > -2f)
            isZavailable = true;
        else
            isZavailable = false;

        //Debug.Log("X = " + isXavailable + "; Y = " + isZavailable);

        if (isXavailable && isZavailable)
            this.transform.position = charTransform.position + offset;
        else if (!isXavailable && isZavailable)
            this.transform.position = new Vector3(this.transform.position.x, charTransform.position.y + offset.y, charTransform.position.z + offset.z);
        else if(isXavailable && !isZavailable)
            this.transform.position = new Vector3(charTransform.position.x + offset.x, charTransform.position.y + offset.y, this.transform.position.z);
        else if(!isXavailable && !isZavailable)
            this.transform.position = new Vector3(this.transform.position.x + offset.x, charTransform.position.y + offset.y, this.transform.position.z);
    }
}

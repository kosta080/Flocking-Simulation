using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class a : MonoBehaviour
{
    public GameObject b;
    public Quaternion rotationfix;


    void Update()
    {
        //Debug.Log(rotationfix);
        Debug.Log("s");
        //transform.LookAt(b.transform);
        //transform.Rotate(0, 90, -90);
        Vector3 lookVector = (b.transform.position - transform.position).normalized;

        Quaternion rotation = Quaternion.LookRotation(lookVector, Vector3.forward);
        
        rotation = rotation * rotationfix;
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 5);

        //Debug.Log(rotationfix);
        //transform.eulerAngles = new Vector3(0f, 0f, 120f);
    }
}

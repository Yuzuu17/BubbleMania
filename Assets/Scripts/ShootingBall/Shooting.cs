using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float Force;

     void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.back * Force, ForceMode.Impulse);
    }



}

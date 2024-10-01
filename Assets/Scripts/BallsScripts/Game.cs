using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject Baseball;


    private void OnTriggerStay(Collider other)                      
    {                                                            

        if (other.gameObject.tag == "Player")                       
        {
            Destroy(Baseball);
             
        }
      }
    }
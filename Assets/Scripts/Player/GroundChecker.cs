using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GroundChecker : MonoBehaviour
{
    public bool IsGrounded {get; private set;}

    private void Awake()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.transform.GetComponent<Block>() != null)
        {
            if (IsGrounded == false)
            {
                IsGrounded = true;
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.transform.GetComponent<Block>() != null)
        {
            IsGrounded = false;
        }
    }

}

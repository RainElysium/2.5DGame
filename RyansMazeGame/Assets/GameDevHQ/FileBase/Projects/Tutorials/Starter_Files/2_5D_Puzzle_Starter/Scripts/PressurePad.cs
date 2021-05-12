using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Moving Box"))
        {
            Vector3 boxPos = other.transform.position;

            if (boxPos.x - transform.position.x <= .5f)
            {
                Rigidbody body = other.GetComponent<Rigidbody>();
                if (!body)
                {
                    Debug.Log("No rigidbody found!");
                    return;
                }
                else
                {
                    body.isKinematic = true;
                    MeshRenderer color = GetComponentInChildren<MeshRenderer>();

                    if (!color)
                    {
                        Debug.Log("No MeshRenderer found!");
                        return;
                    }
                    else
                    {
                        color.material.color = Color.blue;

                        Destroy(this);
                    }
                }
            }
        }
    }
}

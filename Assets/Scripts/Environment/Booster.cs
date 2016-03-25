using UnityEngine;
using System.Collections;

public class Booster : MonoBehaviour
{
    public Transform launchTarget;
    public float launchForce = 100f;
    public bool additive = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("throwing player?");

            //need to throw the player in a direction? toward a transform?
            Rigidbody rigBod = other.GetComponentInChildren<Rigidbody>();

            if(!additive) rigBod.velocity = Vector3.zero;

            rigBod.AddForce(launchTarget.forward * launchForce);
        }
    }
}

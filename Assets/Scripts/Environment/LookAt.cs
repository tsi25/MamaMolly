using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour
{
    public Transform target;


    private void Awake()
    {
        transform.LookAt(target.position);
    }
}

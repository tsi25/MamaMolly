using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour
{
    public float followDelay = 0.2f;
    public GameObject target;


    private void Update()
    {
        transform.position = target.transform.position;
    }

    
   /* private IEnumerator Move()
    {
        float elapsedTime = 0;

        Vector3 startPos = transform.position;
        Vector3 endPos = 
        while(elapsedTime < followDelay)
        {
            = Vector3.Lerp(startPos, endPos, elapsedTime / followDelay);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        StartCoroutine(Move());
    }


    private void Awake()
    {
        StartCoroutine(Move());
    }*/
}

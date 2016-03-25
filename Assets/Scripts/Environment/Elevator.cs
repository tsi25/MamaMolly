using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{
    public Transform top;
    public Transform bottom;

    public GameObject platform;

    public float liftTime;
    public bool goingUp = true;

    private IEnumerator Move()
    {
        float elapsedTime = 0f;
        Transform target = top;
        if (goingUp) target = bottom;

        while(elapsedTime <= liftTime)
        {
            platform.transform.position = Vector3.Lerp(platform.transform.position, target.position, elapsedTime / liftTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        goingUp = !goingUp;
        StartCoroutine(Move());
    }


    private void Awake()
    {
        StartCoroutine(Move());
    }
}

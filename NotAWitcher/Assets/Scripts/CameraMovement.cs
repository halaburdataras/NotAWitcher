using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    private float nextTimeToSearch = 0;

    void Update()
    {
        if(target == null)
        {
            FindPlayer();
        }

        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
    }

    void FindPlayer()
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag("Player");
            if (searchResult != null)
                target = searchResult.transform;
            nextTimeToSearch = Time.time + 0.5f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, targetPosition, .2f);
    }
}

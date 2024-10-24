using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconFollow2 : MonoBehaviour
{
    public Transform target; 

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPosition = target.position;
            newPosition.y = transform.position.y; 
            transform.position = newPosition;
        }
    }
}

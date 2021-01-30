using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camCon : MonoBehaviour
{
    public Transform camPos;
    public Vector3 offset;
    private void LateUpdate()
    {
        transform.position = camPos.position + offset;
    }
}

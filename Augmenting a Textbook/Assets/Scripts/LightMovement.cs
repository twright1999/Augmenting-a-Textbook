using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour
{

    public float lightSpeed = 100f;
    private GameObject parent;

    // Update is called once per frame
    void Update()
    {
        parent = transform.parent.gameObject;
        transform.RotateAround(parent.transform.position, Vector3.up, lightSpeed * Time.deltaTime);

    }
}


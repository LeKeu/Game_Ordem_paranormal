using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMov : MonoBehaviour
{
    public Transform player;
    public float velCam;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posQuero = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, posQuero, velCam * Time.deltaTime);
    }
}

using System;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject ground;
    public Transform generationPoint;

    private float groundWidth;

    public GroundPooler theGroundPool;

    void Start()
    {
        groundWidth = ground.GetComponent<BoxCollider2D>().size.x;

    }

    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + groundWidth, transform.position.y, transform.position.z);
            //Instantiate(ground, transform.position, transform.rotation);
            GameObject newPlatform = theGroundPool.GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

        }
    }


}
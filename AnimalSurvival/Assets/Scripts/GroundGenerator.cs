using System;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject ground;

    public Transform generationPoint;
    public float cameraOffset = 20;

    private float groundWidth;
    private float previousX;
    private float startX;

    public GroundPooler theGroundPool;

    public CameraController camera;

    private BadStuffGenerator theBadStuffGenerator;

    void Start()
    {
        groundWidth = ground.GetComponent<BoxCollider2D>().bounds.size.x;
        previousX = ground.transform.position.x;
        startX = previousX;
        theBadStuffGenerator = FindObjectOfType<BadStuffGenerator>();
    }

    void Update()
    {

        if (camera.transform.position.x - previousX >= groundWidth/2 - cameraOffset)
        {
            previousX += groundWidth;
            transform.position = new Vector3(previousX, ground.transform.position.y, ground.transform.position.z);
            //Instantiate(ground, transform.position, transform.rotation);
            GameObject newPlatform = theGroundPool.GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.transform.localScale = ground.transform.localScale;
            newPlatform.SetActive(true);
            theBadStuffGenerator.SpawnBadStuff(transform.position, groundWidth);

        }
    }

    public void restart() {
        previousX = startX - groundWidth/2 - cameraOffset;
        transform.position = new Vector3(previousX, ground.transform.position.y, ground.transform.position.z);
    }
    

}
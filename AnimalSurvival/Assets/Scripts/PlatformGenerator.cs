using UnityEngine;
using System.Collections;

public class PlatformGenerator: MonoBehaviour {

    public GameObject platform;
    public Transform generationPoint;
    private float distanceBetweeen;

    //private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private int platformSelector;
    //public GameObject[] platforms;

    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;


    void Start()
    {
        //platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[theObjectPools.Length];
        for(int i=0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
    }

    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetweeen = Random.Range(distanceBetweenMin, distanceBetweenMax);
            platformSelector = Random.Range(0, theObjectPools.Length);
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else
            {
                if (heightChange < minHeight)
                {
                    heightChange = minHeight;
                }
            }
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector])/2 + distanceBetweeen, heightChange, transform.position.z);
            

            //Instantiate(platforms[platformSelector], transform.position, transform.rotation);
            GameObject newPlatform= theObjectPools[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]) / 2, transform.position.y, transform.position.z);

        }
    }

}

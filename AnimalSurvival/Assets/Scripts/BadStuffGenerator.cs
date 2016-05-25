using UnityEngine;
using System.Collections;

public class BadStuffGenerator : MonoBehaviour {

    public ObjectPooler[] badStuffPools;

    public void SpawnBadStuff(Vector3 startPosition, float sizeX)
    {
        int i = Random.Range(0, badStuffPools.Length);
        GameObject badStuff = badStuffPools[i].GetPooledObject();
        float f0 = Random.Range(startPosition.x-8f,startPosition.x);
        badStuff.transform.position = new Vector3(f0, startPosition.y - 0.2f, startPosition.z);
        badStuff.SetActive(true);

        i = Random.Range(0, badStuffPools.Length);
        float f1 = Random.Range(startPosition.x+1f, 8f+ startPosition.x);
        if (Mathf.Abs(f1 - f0) < 3)
        {
            f1 = f0 + 12f;
        }
        GameObject badStuff2 = badStuffPools[i].GetPooledObject();
        badStuff2.transform.position = new Vector3(f1,startPosition.y - 0.2f, startPosition.z);
        badStuff2.SetActive(true);

       /* i = Random.Range(0, badStuffPools.Length);
        float f2 = Random.Range(startPosition.x+13f, 15f + startPosition.x);
        if (Mathf.Abs(f2- f1) < 3)
        {
            f2 = f1 + 6f;
        }
        if (Mathf.Abs(f2 - f0) < 3)
        {
            f2 = f0 + 6f;
        }
        GameObject badStuff3 = badStuffPools[i].GetPooledObject();
        badStuff3.transform.position = new Vector3(f2, startPosition.y-0.2f, startPosition.z);
        badStuff3.SetActive(true);
        */
    }
}

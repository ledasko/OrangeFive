using UnityEngine;
using System.Collections;

public class BadStuffGenerator : MonoBehaviour
{

    public ObjectPooler[] badStuffPools;

    public void SpawnBadStuff(Vector3 startPosition, float sizeX)
    {
        int i = Random.Range(0, 8);
        GameObject badStuff = badStuffPools[i].GetPooledObject();
        float f0 = Random.Range(startPosition.x, sizeX + startPosition.x);
        badStuff.transform.position = new Vector3(f0, startPosition.y + 0.2f, startPosition.z);
        badStuff.SetActive(true);

        i = Random.Range(0, 8);
        float f1 = Random.Range(startPosition.x, sizeX + startPosition.x);
        if (f1 == f0 || (f1 - f0) < 3)
        {
            f1 = f0 + 3f;
        }
        GameObject badStuff2 = badStuffPools[i].GetPooledObject();
        badStuff2.transform.position = new Vector3(f1, startPosition.y + 0.2f, startPosition.z);
        badStuff2.SetActive(true);
    }
}

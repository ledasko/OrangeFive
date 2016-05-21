using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FruitGenerator : MonoBehaviour {

    public ObjectPooler[] fruitPools;

    public void SpawnFruit(Vector3 startPosition, float platformSizeX)
    {
        int i = Random.Range(0, 7); 
        if (platformSizeX == 0.8f)
            CreateOne(startPosition,i);
        if (platformSizeX == 1.19f)
            WhoToCall2(startPosition, i);
        if (platformSizeX == 1.94f)
            WhoToCall3(startPosition, i);
        if (platformSizeX == 2.62f)
            WhoToCall4(startPosition, i);
    }

    private void WhoToCall2(Vector3 startPosition, int j)
    {
        int i = Random.Range(1, 3);
        if (i == 1)
            CreateOne(startPosition, j);
        if (i == 2)
            CreateTwo(startPosition, j);
    }

    private void WhoToCall3(Vector3 startPosition, int j)
    {
        int i = Random.Range(1, 4);
        if (i == 1)
            CreateOne(startPosition, j);
        if (i == 2)
            CreateTwo(startPosition, j);
        if (i == 3)
            CreateThree(startPosition, j);
    }

    private void WhoToCall4(Vector3 startPosition, int j)
    {
        int i = Random.Range(1, 5);
        if (i == 1)
            CreateOne(startPosition, j);
        if (i == 2)
            CreateTwo(startPosition, j);
        if (i == 3)
            CreateThree(startPosition, j);
        if (i == 4)
            CreateFour(startPosition, j);
    }

    private void CreateOne(Vector3 startPosition, int i)
    {
        GameObject fruit = fruitPools[i].GetPooledObject();
        fruit.transform.position = new Vector3(startPosition.x, startPosition.y + 0.5f, startPosition.z);
        fruit.SetActive(true);
    }

    private void CreateTwo(Vector3 startPosition, int i)
    {
        GameObject fruit1 = fruitPools[i].GetPooledObject();
        fruit1.transform.position = new Vector3(startPosition.x - 0.3f, startPosition.y + 0.5f, startPosition.z);
        fruit1.SetActive(true);

        GameObject fruit2 = fruitPools[i].GetPooledObject();
        fruit2.transform.position = new Vector3(startPosition.x + 0.3f, startPosition.y + 0.5f, startPosition.z);
        fruit2.SetActive(true);
    }

    private void CreateThree(Vector3 startPosition, int i)
    {
        GameObject fruit1 = fruitPools[i].GetPooledObject();
        fruit1.transform.position = new Vector3(startPosition.x, startPosition.y + 0.5f, startPosition.z);
        fruit1.SetActive(true);

        GameObject fruit2 = fruitPools[i].GetPooledObject();
        fruit2.transform.position = new Vector3(startPosition.x - 0.7f, startPosition.y + 0.5f, startPosition.z);
        fruit2.SetActive(true);

        GameObject fruit3 = fruitPools[i].GetPooledObject();
        fruit3.transform.position = new Vector3(startPosition.x + 0.7f, startPosition.y + 0.5f, startPosition.z);
        fruit3.SetActive(true);
    }

    private void CreateFour(Vector3 startPosition, int i)
    {
        GameObject fruit1 = fruitPools[i].GetPooledObject();
        fruit1.transform.position = new Vector3(startPosition.x-0.9f, startPosition.y + 0.5f, startPosition.z);
        fruit1.SetActive(true);

        GameObject fruit2 = fruitPools[i].GetPooledObject();
        fruit2.transform.position = new Vector3(startPosition.x +0.9f, startPosition.y + 0.5f, startPosition.z);
        fruit2.SetActive(true);

        GameObject fruit3 = fruitPools[i].GetPooledObject();
        fruit3.transform.position = new Vector3(startPosition.x + 0.3f, startPosition.y + 0.5f, startPosition.z);
        fruit3.SetActive(true);

        GameObject fruit4 = fruitPools[i].GetPooledObject();
        fruit4.transform.position = new Vector3(startPosition.x - 0.3f, startPosition.y + 0.5f, startPosition.z);
        fruit4.SetActive(true);
    }
}

using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

    public GameObject DestructionPoint;

	// Use this for initialization
	void Start () {
        DestructionPoint = GameObject.Find("DestructionPoint");

	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < DestructionPoint.transform.position.x)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
	}
}

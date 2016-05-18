using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    // Checks for destroyed platforms.
    private Destroyer[] platformList;

    private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
        // TODO This we need.
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        scoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RestartGame()
    {
        StartCoroutine("RestartGameCoroutine");
    }

    public IEnumerator RestartGameCoroutine()
    {
        // TODO This is where you reset position and all that jazz.
        thePlayer.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        scoreManager.scoreIncrease = false;

        // Used to remove all created objects on death.
        platformList = FindObjectsOfType<Destroyer>();
        for(int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;

        thePlayer.gameObject.SetActive(true);
        scoreManager.scoreCount = 0;
        scoreManager.scoreIncrease = true;
    }
}

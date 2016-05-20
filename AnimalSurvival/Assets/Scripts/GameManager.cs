using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    public GroundGenerator groundGenerator;
    private Vector3 groundGeneretorStartPosition;

    // Checks for destroyed platforms.
    private Destroyer[] destructionList;
    private DestroyByContact[] destroyByContactList;

    private ScoreManager scoreManager;
    public DesertDeathMenu deathMenu;

    // Use this for initialization
    void Start () {
        // TODO This we need.
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        groundGeneretorStartPosition = groundGenerator.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RestartGame()
    {
        scoreManager.scoreIncrease = false;
        thePlayer.gameObject.SetActive(false);

        deathMenu.gameObject.SetActive(true);
    }

    public void Reset()
    {
        deathMenu.gameObject.SetActive(false);

        destructionList = FindObjectsOfType<Destroyer>();
        for (int i = 0; i < destructionList.Length; i++)
        {
            destructionList[i].gameObject.SetActive(false);
        }

        destroyByContactList = FindObjectsOfType<DestroyByContact>();
        foreach (DestroyByContact o in destroyByContactList)
        {
            o.gameObject.SetActive(false);
        }


        groundGenerator.restart();

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;

        // TODO Health reset.
        FindObjectOfType<PlayerHealth>().ResetHealth();

        thePlayer.gameObject.SetActive(true);
        scoreManager.scoreCount = 0;
        scoreManager.scoreIncrease = true;
    }
}

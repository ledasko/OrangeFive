using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    public Vector3 playerStartPoint;

    public GroundGenerator groundGenerator;
    private Vector3 groundGeneretorStartPosition;

    // Checks for destroyed platforms.
    private Destroyer[] destructionList;
    private DestroyByContact[] destroyByContactList;

    private ScoreManager scoreManager;
    public DesertDeathMenu deathMenu;

    public GameObject countDown;
    public GameObject pauseButton;

    // Use this for initialization
    void Start()
    {
        // TODO This we need.
        scoreManager = FindObjectOfType<ScoreManager>();
        thePlayer = FindObjectOfType<PlayerController>();
        StartCoroutine(countdown());
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        groundGeneretorStartPosition = groundGenerator.transform.position;
    }

    //meni drugacije ne radi
    IEnumerator countdown()
    {
        Time.timeScale = 1f;
        GameObject go = pauseButton;
        go.SetActive(false);
        float moveSpeed = thePlayer.moveSpeed;
        thePlayer.moveSpeed = 0;
        if (thePlayer.moveSpeed == 0)
        {
            Debug.Log("HEj");
        }
        

        scoreManager.scoreIncrease = false;
        countDown.SetActive(true);
        Text tekst = countDown.GetComponent<Text>();
        tekst.text = "3";
        yield return new WaitForSeconds(1f);

        tekst.text = "2";
        yield return new WaitForSeconds(1f);

        tekst.text = "1";
        yield return new WaitForSeconds(1f);

        tekst.text = "GO!";
        yield return new WaitForSeconds(1f);

        countDown.SetActive(false);
        thePlayer.moveSpeed = moveSpeed;

        scoreManager.scoreIncrease = true;
        go.SetActive(true);
        

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        scoreManager.deathHighscore.gameObject.SetActive(false);
        GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject g in grounds)
        {
            g.GetComponent<GroundContact>().touchingGround = false;
        }
        scoreManager.scoreIncrease = false;
        scoreManager.NewHighscore();
        thePlayer.gameObject.SetActive(false);
        Time.timeScale = 0f;
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
        FindObjectOfType<CameraController>().ResetCamera();

        // TODO Health reset.


        thePlayer.reset();
        thePlayer.gameObject.SetActive(true);
        scoreManager.scoreCount = 0;
        scoreManager.scoreIncrease = true;
        scoreManager.NewHighscore();

        PlayerHealth thePlayerHealth = FindObjectOfType<PlayerHealth>();
        thePlayerHealth.isDead = false;
        thePlayerHealth.ResetHealth();
        Time.timeScale = 1f;
        StartCoroutine(countdown());

    }

    public void Continue()
    {
        deathMenu.gameObject.SetActive(false);
        CactusContact[] destroyByContactList;
        destroyByContactList = FindObjectsOfType<CactusContact>();
        foreach (CactusContact o in destroyByContactList)
        {
            o.gameObject.SetActive(false);
        }


        thePlayer.gameObject.SetActive(true);
        scoreManager.scoreIncrease = true;

        PlayerHealth thePlayerHealth = FindObjectOfType<PlayerHealth>();
        thePlayerHealth.isDead = false;
        thePlayerHealth.ResetHealth();
        Time.timeScale = 1f;
        FindObjectOfType<CameraController>().ResetCamera();

    }
}

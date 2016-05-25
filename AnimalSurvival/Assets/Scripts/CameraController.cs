using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public PlayerController thePlayer;
    private Vector3 lastPlayerPosition;
    private float distanceToMove;
    private GameManager gameManager;
    int counter = 0;
    private Vector3 startPosition;
    private Vector3 velocity = Vector3.zero;
    private PlayerHealth playerHealth;

    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        lastPlayerPosition = thePlayer.transform.position;
        gameManager = GameObject.FindObjectOfType<GameManager>();
        startPosition = transform.position;
        playerHealth = FindObjectOfType<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 90)
            return;
        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
        if (!gameManager.countDown.activeSelf && !GameObject.FindObjectOfType<DesertPauseMenu>().pauseMenu.activeSelf)
        {
            if (distanceToMove == 0)
            {
                if (counter < 1)
                {
                    distanceToMove = 0;
                }
                else
                {
                    distanceToMove = 0.1f;
                }
                counter++;
            }
            else
            {
                if (counter > 1)
                {
                    distanceToMove = -(0.1f * (counter - 2));
                    counter = 0;
                }
                else counter = 0;

            }
        }
        if (playerHealth != null)
        {
            if ((thePlayer.transform.position.x - transform.position.x < -13.5) &&
                !playerHealth.isDead && counter != 0)
            {
                distanceToMove = 0;
                playerHealth.isDead = true;
            }
        }
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
        lastPlayerPosition = thePlayer.transform.position;

    }

    public void ResetCamera()
    {
        this.transform.position = startPosition;
        lastPlayerPosition = gameManager.playerStartPoint;
        counter = 0;
    }
}
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    public bool isReady;

    public ShakeCamera shakeCam;

    [Header("Bullet")]
    public GameObject bulletPlayerOne;
    public GameObject bulletPlayerTwo;

    public Transform bulletSpawnOne;
    public Transform bulletSpawnTwo;

    [Header("Player Animations")]
    public Animator player1Anim;
    public Animator player2Anim;

    private float playerOneReaction;
    private float playerTwoReaction;

    private bool canFirePlayerOne;
    private bool canFirePlayerTwo;

    private float playerOneReactionTimer;
    private float playerTwoReactionTimer;


        // Use this for initialization
    void Start ()
    {
        canFirePlayerOne = true;
        canFirePlayerTwo = true;
	}

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            playerOneReactionTimer += Time.deltaTime;
            playerTwoReactionTimer += Time.deltaTime;

            if (playerOneReaction > playerTwoReaction)
            {
                PlayerOneWon();
            }
            else if(playerOneReaction < playerTwoReaction)
            {
                PlayerTwoWon();
            }
        }
        if (CrossPlatformInputManager.GetButtonDown("PlayerOneFire"))
        {
            if (isReady)
            {
                if (canFirePlayerOne)
                {
                    Debug.Log("Fired and Ready P1");
                    playerOneReaction = playerOneReactionTimer;
                    canFirePlayerOne = false;
                    canFirePlayerTwo = false;
                    shakeCam.DoShake();
                    player2Anim.SetTrigger("Dead");
                    player1Anim.SetTrigger("Shoot");
                    Instantiate(bulletPlayerOne, bulletSpawnOne.position, bulletSpawnOne.rotation);
                }   
            }
            else
            {
                if (canFirePlayerOne)
                {
                    Debug.Log("Fired and Not Ready P1");
                    canFirePlayerOne = false;
                    canFirePlayerTwo = false;
                    PlayerOneLost();
                    shakeCam.DoShake();
                    player2Anim.SetTrigger("Dead");
                    player1Anim.SetTrigger("Shoot");
                    Instantiate(bulletPlayerOne, bulletSpawnOne.position, bulletSpawnOne.rotation);
                }
            }
        }
        if (CrossPlatformInputManager.GetButtonDown("PlayerTwoFire"))
        {
            if (isReady)
            {
                if (canFirePlayerTwo)
                {
                    Debug.Log("Fired and Ready P2");
                    playerTwoReaction = playerTwoReactionTimer;
                    canFirePlayerTwo = false;
                    canFirePlayerTwo = false;
                    shakeCam.DoShake();
                    player2Anim.SetTrigger("Shoot");
                    player1Anim.SetTrigger("Dead");
                    Instantiate(bulletPlayerTwo, bulletSpawnTwo.position, bulletSpawnTwo.rotation);
                }
            }
            else
            {
                if (canFirePlayerTwo)
                {
                    Debug.Log("Fired and Not Ready P2");
                    canFirePlayerTwo = false;
                    canFirePlayerTwo = false;
                    PlayerTwoLost();
                    shakeCam.DoShake();
                    player2Anim.SetTrigger("Shoot");
                    player1Anim.SetTrigger("Dead");
                    Instantiate(bulletPlayerTwo, bulletSpawnTwo.position, bulletSpawnTwo.rotation);
                }
            }
        }
    }
    void PlayerOneWon()
    {
        Debug.Log("PlayerOneWon");
    }
    void PlayerOneLost()
    {
        Debug.Log("PlayerOneLost");
    }
    void PlayerTwoWon()
    {
        Debug.Log("PlayerTwoWon");
    }
    void PlayerTwoLost()
    {
        Debug.Log("PlayerTwoLost");
    }
    void ResetGame()
    {

    }
}

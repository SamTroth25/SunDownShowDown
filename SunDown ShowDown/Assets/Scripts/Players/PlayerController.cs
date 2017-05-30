using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public bool isReady;

    public ShakeCamera shakeCam;

    [Header("Bullet")]
    public GameObject[] bulletPlayer;

    public Transform[] bulletSpawners;

    [Header("PlayerArt")]
    public GameObject[] player1Art;
    public GameObject[] player2Art;
    public int player1ArtNum;
    public int player2ArtNum;

    [Header("Player Animations")]
    private Animator player1Anim;
    private Animator player2Anim;

    [Header("Player Canvas")]
    public GameObject[] playerCanvas; 

    private float playerOneReaction;
    private float playerTwoReaction;

    private bool canFirePlayerOne;
    private bool canFirePlayerTwo;

    public float playerOneReactionTimer;
    public float playerTwoReactionTimer;

    private AudioSource aS;
    public AudioClip bulletSound;


    // Use this for initialization
    void Start ()
    {
        player1ArtNum = Random.Range(0, player1Art.Length);
        player2ArtNum = Random.Range(0, player2Art.Length);
        player1Random();
        player2Random();
        aS = GetComponent<AudioSource>();
        canFirePlayerOne = true;
        canFirePlayerTwo = true;
        for (int i = 0; i < playerCanvas.Length; i++)
        {
            playerCanvas[i].SetActive(false);
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            for (int i = 0; i < player1Art.Length; i++)
            {
                player1Art[i].SetActive(false);
            }
            for (int i = 0; i < player2Art.Length; i++)
            {
                player2Art[i].SetActive(false);
            }
            player1ArtNum = Random.Range(0, player1Art.Length);
            player2ArtNum = Random.Range(0, player2Art.Length);
            player1Random();
            player2Random();
        }
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
                    Instantiate(bulletPlayer[0], bulletSpawners[0].position, bulletSpawners[0].rotation);
                    PlayAudio();
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
                    Instantiate(bulletPlayer[0], bulletSpawners[0].position, bulletSpawners[0].rotation);
                    PlayAudio();
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
                    Instantiate(bulletPlayer[1], bulletSpawners[1].position, bulletSpawners[1].rotation);
                    PlayAudio();
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
                    Instantiate(bulletPlayer[1], bulletSpawners[1].position, bulletSpawners[1].rotation);
                    PlayAudio();
                }
            }
        }
    }

    void player1Random()
    {
        player1Art[player1ArtNum].SetActive(true);       
        player1Anim = player1Art[player1ArtNum].GetComponent<Animator>();       
    }
    void player2Random()
    {
        player2Art[player2ArtNum].SetActive(true);
        player2Anim = player2Art[player2ArtNum].GetComponent<Animator>();
    }

    void PlayerOneWon()
    {
        Debug.Log("PlayerOneWon");
        playerCanvas[0].SetActive(true);
    }
    void PlayerOneLost()
    {
        Debug.Log("PlayerOneLost");
        playerCanvas[1].SetActive(true);
    }
    void PlayerTwoWon()
    {
        Debug.Log("PlayerTwoWon");
        playerCanvas[2].SetActive(true);
    }
    void PlayerTwoLost()
    {
        Debug.Log("PlayerTwoLost");
        playerCanvas[3].SetActive(true);
    }
    void ResetGame()
    {

    }
    void PlayAudio()
    {
        aS.pitch = Random.Range(0.98f, 1.02f);
        aS.PlayOneShot(bulletSound, 0.7f);
    }
}

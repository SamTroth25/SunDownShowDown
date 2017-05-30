using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WantedPoster : MonoBehaviour
{
    public Text wantedMoney;
    public Text ReactionTime;
    public Text PlayerName;

    public PlayerController pc;
    public string[] possibleFirstNames;
    public string[] possibleNickname;
    public string[] possibleLastNames;

    public GameObject[] possibleImages;
    public bool player1;
    public bool reactionTime;

	// Use this for initialization
	void Start ()
    {
        if (player1)
        {
            possibleImages[pc.player1ArtNum].SetActive(true);
            if (reactionTime)
            {
                ReactionTime.text = ("Reaction Time : " + pc.playerOneReactionTimer + " seconds");
            }
            else
            {
                ReactionTime.text = ("Wait for the sun to set before firing");
            }
        }
        else
        {
            possibleImages[pc.player2ArtNum].SetActive(true);
            if (reactionTime)
            {
                ReactionTime.text = ("Reaction Time : " + pc.playerTwoReactionTimer + " seconds");
            }
            else
            {
                ReactionTime.text = ("Wait for the sun to set before firing");
            }
        }
        wantedMoney.text = ("$ " + Random.Range(200, 100000));
        PlayerName.text = ("" + possibleFirstNames[Random.Range(0, possibleFirstNames.Length)] + possibleNickname[Random.Range(0, possibleNickname.Length)] + possibleLastNames[Random.Range(0, possibleLastNames.Length)]);

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}

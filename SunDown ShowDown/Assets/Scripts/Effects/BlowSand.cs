using UnityEngine;
using System.Collections;

public class BlowSand : MonoBehaviour {

    public float timeLeft;
    private Animator anim;
    private AudioSource audioS;

    public AudioClip windSFX;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
        timeLeft = Random.Range(0.5f, 2.0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {         
            SetAnimTrigger();
        }
    }
    void SetAnimTrigger()
    {
        audioS.pitch = Random.Range(0.95f, 1.05f);
        audioS.PlayOneShot(windSFX, 0.2f);
        timeLeft = Random.Range(2.0f, 7.0f);
        anim.SetTrigger("Blow");
    }
}

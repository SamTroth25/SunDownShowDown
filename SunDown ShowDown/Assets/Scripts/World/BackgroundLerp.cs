using UnityEngine;
using System.Collections;

public class BackgroundLerp : MonoBehaviour {

    private Renderer rend;
    public Transform player;

    public float LerpSpeed = 25.0f;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    void Update()
    {
        float lerp = Mathf.PingPong(player.position.y, player.position.y)/ LerpSpeed;
        rend.material.SetFloat("_Blend", Mathf.Clamp(-lerp, 0.0f, 1.0f));
    }
}
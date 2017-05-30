using UnityEngine;
using System.Collections;

public class ScrollTexture : MonoBehaviour
{
    public float scrollSpeed = 0.5F;
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_TexMat1", new Vector2(offset, 0));
        rend.material.SetTextureOffset("_TexMat2", new Vector2(offset, 0));
    }
}
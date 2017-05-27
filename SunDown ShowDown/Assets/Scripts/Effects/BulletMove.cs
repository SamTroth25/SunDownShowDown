using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

    public float BulletSpeed;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * BulletSpeed);
    }
}

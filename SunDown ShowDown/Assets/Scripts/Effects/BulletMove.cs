using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

    public float BulletSpeed;
    public Rigidbody2D rb;

    public GameObject hit;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(particleSpawn(0.39f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * BulletSpeed);
        Destroy(gameObject, 0.4f);
    }
    IEnumerator particleSpawn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Instantiate(hit, transform.position, transform.rotation);
    }
}

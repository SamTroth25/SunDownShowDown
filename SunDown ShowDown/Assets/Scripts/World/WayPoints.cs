using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WayPoints : MonoBehaviour {
	public Transform[] patrolPoints;
	private float moveSpeed;
	private int currentPoint;

    public GameObject[] UI;

    private bool shownUi;

    // Use this for initialization
    void Start () 
	{
        moveSpeed = Random.Range(0.12f, 0.5f);
		transform.position = patrolPoints [0].position;
		currentPoint = 0;
	}
	
	// Update is called once per frame
	void Update ()
    { 
     if (transform.position == patrolPoints[currentPoint].position)
		{
			currentPoint++;
        }
		if (currentPoint >= patrolPoints.Length)
		{
			currentPoint = 1;
            ShowReadyUI();           
        }
		transform.position = Vector3.MoveTowards (transform.position, patrolPoints[currentPoint].position, moveSpeed* Time.deltaTime);
	}
    void ShowReadyUI()
    {
        if (!shownUi)
        {
            shownUi = true;
            UI[Random.Range(0, UI.Length)].SetActive(true);
        }
    }
}

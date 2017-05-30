using UnityEngine;
using System.Collections;

public class SortingLayer : MonoBehaviour {

	public string SortingLayerName = "Default";
	public int SortingOrder = 100;

	void Awake ()
	{
		gameObject.GetComponent<TrailRenderer> ().sortingLayerName = SortingLayerName;
		gameObject.GetComponent<TrailRenderer> ().sortingOrder = SortingOrder;
	}
}
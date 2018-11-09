using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalDetector : MonoBehaviour {
    public GameObject victory;
    public GameObject lose;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "puck")
        {
            Debug.Log("Goal!");
            victory.SetActive(true);
        }
        if (collision.gameObject.tag == "Player")
        {
            lose.SetActive(true);
        }
    }
}

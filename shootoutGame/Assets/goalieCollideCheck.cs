using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalieCollideCheck : MonoBehaviour {
    public GameObject fail;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            fail.SetActive(true);
            playerController.shotOnce = false;
        }
    }
}

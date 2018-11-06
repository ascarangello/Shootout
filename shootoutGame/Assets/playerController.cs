using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    Rigidbody2D player;
    public int speed;
	// Use this for initialization
	void Start () {
      player = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("w"))
        {
            player.AddForce(new Vector2(0, speed));
        }
        if (Input.GetKey("s"))
        {
            player.AddForce(new Vector2(0, -speed));
        }
        if (Input.GetKey("a"))
        {
            player.AddForce(new Vector2(-speed, 0));
        }
        if (Input.GetKey("d"))
        {
            player.AddForce(new Vector2(speed, 0));
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }
}

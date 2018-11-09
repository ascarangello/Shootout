using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {
    public GameObject displayPuck;
    public GameObject goalie;
    public GameObject puck;
    public int forceFactor;
    Rigidbody2D goalieRB;
    Rigidbody2D player;
    public int speed;
    public int goalieSpeed;
    public Slider chargeSlider;
    bool shotOnce;
	// Use this for initialization
	void Start () {
        shotOnce = false;
      goalieRB = goalie.GetComponent<Rigidbody2D>();
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
        if (Input.GetKey(KeyCode.Keypad8))
        {
            goalieRB.AddForce(new Vector2(0, goalieSpeed));
        }
        if (Input.GetKey(KeyCode.Keypad5))
        {
            goalieRB.AddForce(new Vector2(0, -goalieSpeed));
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            goalieRB.AddForce(new Vector2(-goalieSpeed, 0));
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            goalieRB.AddForce(new Vector2(goalieSpeed, 0));
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            chargeSlider.value = 1;
        }
        if(Input.GetMouseButton(0))
        {
            if (!shotOnce)
            {
                chargeSlider.value += Time.deltaTime;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if (!shotOnce)
            {
                displayPuck.SetActive(false);
                GameObject shot;
                Vector3 inFront = new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z);
                Vector3 forceDir = (mousePos - player.transform.position).normalized;
                shot = Instantiate(puck, player.transform.position + forceDir, transform.rotation);
                Rigidbody2D shotRB = shot.GetComponent<Rigidbody2D>();
                shotRB.velocity = player.velocity;
                shotRB.AddForce(forceDir * (20 * chargeSlider.value), ForceMode2D.Impulse);
                chargeSlider.value = 1;
                shotOnce = true;
            }
        }
    }
}

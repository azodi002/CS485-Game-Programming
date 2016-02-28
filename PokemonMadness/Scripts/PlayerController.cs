using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

	public float speed;

	public Text countText;
	public Text winText;


	private Rigidbody rb;
	private int count; //Counter for score



	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText();
		winText.text = "";
	}
	
	void FixedUpdate() //Physics code
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");


		Vector3 movement = new Vector3 (moveHorizontal,0 , moveVertical);
		/*Y-axis is 0, because we don't want ball to go up*/

		rb.AddForce (movement * speed); 
			 
		//Control of movement value from editor
	}

	//Touch another trigger collider we destroy the game object
	//All children, components of the objects are removed
	//For this game we will deactivate it.
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText();
			/*Deactivate the object when collided with*/
		}
	}

	void SetCountText()
	{
		countText.text = "Pokemon Caught: " + count.ToString ();

		if (count == 3) {
			winText.text = "You Caught Em' All";		
		}

	}

}

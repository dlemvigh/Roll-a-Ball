using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;
	private int totalCount;
	private string countFormat;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		countFormat = countText.text;
		count = 0;
		SetCountText ();
		winText.gameObject.SetActive (false);
		totalCount = GameObject.FindGameObjectsWithTag ("Pick Up").Length;
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
			if (count >= totalCount) {
				winText.gameObject.SetActive (true);
			}
		}
	}

	void SetCountText()
	{
		countText.text = string.Format(countFormat, count);
	}
}

using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour
{
	
	public float speed = 100;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 gravity = new Vector3 (Input.GetAxis ("X"), Input.GetAxis ("Z"), Input.GetAxis ("Y")) * Time.deltaTime * speed;
		gravity += new Vector3 (Input.acceleration.x, Input.acceleration.y, -Input.acceleration.z) * Time.deltaTime * speed;
		Physics.gravity = gravity;
		//print (gravity);
		
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}
}

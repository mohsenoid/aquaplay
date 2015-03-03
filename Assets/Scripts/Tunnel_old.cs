using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tunnel_old : MonoBehaviour
{
		List<GameObject> gameObjects = new List<GameObject> ();
		public float speed = 50000;
		public ParticleSystem bubbles;
		int objectsInTrigger = 0;
		public Transform cap;
	
		void OnUpdate ()
		{
		}
	
		void OnTriggerEnter (Collider other)
		{          
				GameObject gObject = other.transform.parent.gameObject;
				if (gObject.tag == "Player") {
						objectsInTrigger++;
						gameObjects.Add (gObject);
//						print ("Object name : " + gObject);
				}
		}
		
		void OnTriggerExit (Collider other)
		{
				GameObject gObject = other.transform.parent.gameObject;
				if (gObject.tag == "Player") {
						objectsInTrigger--;
						gameObjects.Remove (gObject);
//						print ("Object name : " + gObject);
				}
		}
	
		void startPresure ()
		{
				print ("startPresure!");
				//foreach (GameObject gObject in GameObject.FindGameObjectsWithTag("Player")) {
				foreach (GameObject gObject in gameObjects) {
//						print (gObject);
						if (gObject.rigidbody.velocity.y <= 0) {
								float factor = (gObject.transform.position.z - cap.position.z) * 5000f;
								print (gObject.rigidbody.velocity.y);
				if(gObject.rigidbody.velocity.y>-2)
								gObject.rigidbody.AddForce (Vector3.up * speed * factor * Time.deltaTime);
						}
						gObject.rigidbody.AddTorque (Vector3.up * Time.deltaTime);
				}

				if (bubbles.isPlaying)
						bubbles.Stop ();
				bubbles.Play ();
		}
}

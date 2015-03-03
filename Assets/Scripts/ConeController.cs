using UnityEngine;
using System.Collections;

public class ConeController : MonoBehaviour
{
		public GameObject gameController;

		void OnTriggerEnter (Collider other)
		{  
				if (other.tag.Contains ("Rock") || other.tag.Contains ("Player")) {
						if (other.GetComponentInChildren<MeshCollider> () != null) {
								other.GetComponentInChildren<MeshCollider> ().convex = false;
						}
				}

				if (other.tag.Contains ("PlayerCenter")) {
						gameController.SendMessage ("incrementScore");
//						ScoreController.incrementScore ();
			
				}
						
		}

		void OnTriggerExit (Collider other)
		{  
				if (other.tag.Contains ("Rock") || other.tag.Contains ("Player")) {
						if (other.GetComponentInChildren<MeshCollider> () != null) {
								other.GetComponentInChildren<MeshCollider> ().convex = true;
						}
				}

				if (other.tag.Contains ("PlayerCenter")) {
						gameController.SendMessage ("decrementScore");
//						ScoreController.decrementScore ();
				}
						
		}


}
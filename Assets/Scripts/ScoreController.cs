using UnityEngine;
using System.Collections;
using Facebook;

public class ScoreController : MonoBehaviour
{
	
		public static int score = 0;
		public GUIText sTextScore, sTextNiceJob;
		public static bool finished = false;
		public int totalRings = 8;

		public void incrementScore ()
		{
				score++;
				showScore ();
				if (score == totalRings) {
						finished = true;
						showFinished ();
				}
		}

		public void decrementScore ()
		{
				score--;
				showScore ();
		}

		public void showScore ()
		{
				sTextScore.text = "Score: " + score;
		}

		public void showFinished ()
		{
				sTextNiceJob.text = "Nice Job!";
				//makes a GUI button at coordinates 10, 100, and a size of 200x40
//				if (GUI.Button (new Rect (Screen.width / 2 - 40, Screen.height / 2 - 40, 80, 80), "Restart...")) {
//						//Loads a level
//						Application.LoadLevel ("Main");
//				}
		}

		void OnGUI ()
		{
				if (finished) {
						//makes a GUI button at coordinates 10, 100, and a size of 200x40
						if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 30, 100, 50), "Restart")) {
								//Loads a level
								Application.LoadLevel ("Classic");
								finished = false;
								score = 0;
								TimerController.time = 0;
								sTextNiceJob.text = "";
						}

//						if (GUI.Button (new Rect (Screen.width / 2 - 70, Screen.height / 2 + 30, 140, 50), "Share high-score...")) {
////								Application.CaptureScreenshot ("Screenshot.png");
//								TakeScreenshot ();
//						}
				}
		}

		bool isEnabled;
		bool isLogged;
		string userId;

		private void TakeScreenshot ()
		{
				var snap = new Texture2D (Screen.width, Screen.height, TextureFormat.RGB24, false);
				snap.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0);
				snap.Apply ();
				var screenshot = snap.EncodeToPNG ();
		
				var wwwForm = new WWWForm ();
				wwwForm.AddBinaryData ("image", screenshot, "screenShot.png", "image/png");

//				string url = "https://graph.facebook.com/me/photos?access_token=" + FB.AccessToken;
//		
//				var w = new  WWW (url, wwwForm);
//		
//				yield return w;
//		
//				if (string.IsNullOrEmpty (w.error)) {
//						Debug.Log ("Picture posted to facebook");
//				} else {
//						Debug.LogError (w.error);
//				}
		
				FB.API ("me/photos", HttpMethod.POST, LoginCallback, wwwForm);
		}

		void Start ()
		{
		
				// Must call FB.Init Once
		
				FB.Init (SetInitFB, SetAvailability);
		
				FB.PublishInstall ();
		
		}
	
		void Awake ()
		{
		
				isEnabled = false;
		
				isLogged = false;
		
				userId = "not received";
		
		}
	
		private void SetInitFB ()
		{
		
				// This method method will be called withing the callback received by FB.Init()
		
				isEnabled = true;
		
		}
	
		private void SetAvailability (bool a_status)
		{
		
				// This method method will be called withing the callback received each time Unity gets or looses Focus (True/false)
		
		}

		void LoginCallback (FBResult result)
		{
				if (result.Error != null) {
						Debug.Log ("Receive callback login error :: " + result.Error.ToString ());
				} else {
						if (FB.IsLoggedIn) {
								// Case login was successful 
								isLogged = true;
								userId = FB.UserId;
						} else {
								// Case login failed (because of cancelling for example)
								isLogged = false;
						}
				}
		}


//		private IEnumerator<WWW> PostPictureToFacebook (string caption, byte[] bytes)
//		{
//				// Create a Web Form
//				var form = new WWWForm ();
//				form.AddField ("message", caption);
//				form.AddBinaryData ("source", bytes, "screenShot.png", "image/png");
//		
//				string url = "https://graph.facebook.com/me/photos?access_token=" + FB.AccessToken;
//		
//				var w = new  WWW (url, form);
//		
//				yield return w;
//		
//				if (string.IsNullOrEmpty (w.error)) {
//						Debug.Log ("Picture posted to facebook");
//				} else {
//						Debug.LogError (w.error);
//				}
//		}
}
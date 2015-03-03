using UnityEngine;
using System.Collections;

public class TimerController : MonoBehaviour
{
	
		public static float time = 0;
		public GUIText sTextTimer;

		void Update ()
		{
				if (!ScoreController.finished) {
						time += Time.deltaTime;
			
						int minutes = (int)time / 60;
						int seconds = (int)time % 60;
						int fraction = (int)(time * 100) % 100;
			
						sTextTimer.text = "Timer: " + string.Format ("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
				}
		}


}
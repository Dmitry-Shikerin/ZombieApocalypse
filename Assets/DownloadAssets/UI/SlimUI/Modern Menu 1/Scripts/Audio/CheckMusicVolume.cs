using UnityEngine;

namespace DownloadAssets.UI.SlimUI.Modern_Menu_1.Scripts.Audio{
	public class CheckMusicVolume : MonoBehaviour {
		public void  Start (){
			// remember volume level from last time
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
		}

		public void UpdateVolume (){
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
		}
	}
}
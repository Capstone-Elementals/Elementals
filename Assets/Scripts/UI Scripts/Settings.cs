using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class Settings : MonoBehaviour {

	public static float volume;

		void MasterSound() {
			AudioListener.volume = 0.5F;
		}

}



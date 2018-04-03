using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour {

	public AudioMixer Mixer;


	public void SetMasterVolume (float volume)
	{
		Mixer.SetFloat ("volume", volume);

	}

}



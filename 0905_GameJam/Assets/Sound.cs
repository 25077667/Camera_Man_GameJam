using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
//this is a class for the AudioManager script
public class Sound {
	public string name;
	public AudioClip clip;

	[Range(0f,1f)]
	//a slider for the values
	public float volume;
	[Range(0.1f,3f)]
	public float pitch = 1;

	public bool loop;

	[HideInInspector]
	public AudioSource source;
}

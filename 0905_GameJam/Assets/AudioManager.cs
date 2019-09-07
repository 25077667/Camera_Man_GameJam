using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
//full explanation on https://www.youtube.com/watch?v=6OT43pvUyfY

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	public static AudioManager instance;

	void Start()
	{
		instance = this;
		instance.play("BGM");
	}

	// Use this for initialization
	void Awake () {
		//the music will continue when loading a new scene
		DontDestroyOnLoad (gameObject);
		if (instance == null)
			instance = this;
		else {
			Destroy (gameObject);
			return;
		}

		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}

	}

	public Sound findAudio(string name){
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) {
			Debug.Log ("sound doesn't exist!!!");
			return null;
		}
		return s;
	}


	public void play(string name){
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) {
			Debug.Log ("sound doesn't exist!!!");
			return;
		}
		s.source.Play();
		//Debug.Log("playing" + name);
	}
}

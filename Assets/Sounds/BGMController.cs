using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour {

	public AudioSource bgm;
	public AudioSource rocketSound;
	public AudioSource successBeep;

	// kill bgm variable
	bool startKilling = false;
	float killTime;
	float killDuration;

	// Use this for initialization
	void Start () {
		RocketSoundLow();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SuccessBeepPlay();
		}

		if (Input.GetKeyDown(KeyCode.K))
		{
			KillBGM(2);
		}

		// killing the bgm
		if (startKilling)
		{
			bgm.pitch = 1 - (Time.time - killTime) / killDuration;
			bgm.volume = 1 - (Time.time - killTime) / killDuration;
			if (Time.time >= killTime + killDuration)
			{
				BGMStop();
				startKilling = false;
			}
		}
	}

	// BGB related controls
	public void BGMPlay() {
		bgm.Play();
		bgm.volume = 1;
		bgm.pitch = 1;
	}
	public void BGMStop() {
		bgm.Stop();
	}

	// Rocket sound related controls
	public void RocketSoundPlay() {
		rocketSound.Play();
	}
	public void RocketSoundStop() {
		rocketSound.Stop();
	}
	public void RocketSoundLow() {
		rocketSound.volume = 0.25f;
	}
	public void RocketSoundHigh() {
		rocketSound.volume = 0.5f;
	}

	// Success Beep related controls
	public void SuccessBeepPlay() {
		successBeep.pitch = 0.2f + Random.value;
		successBeep.Stop();
		successBeep.Play();
	}

	// Method for slowly killing the bgm in a particular seconds
	public void KillBGM(float duration) {
		if (startKilling == false)
		{
			startKilling = true;
			killTime = Time.time;
			killDuration = duration;
		}
	}
}

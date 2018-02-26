using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Common.CMonoSingleton<AudioManager> {
	public SAudioData AudioData;
	public AudioSource AudioSourcePrefab;

	private List<AudioSource> AudioSourceList = new List<AudioSource>();

	private void Awake(){
		DontDestroyOnLoad(gameObject);
	}

	public void PlayBGM(string name){
		for(int i = 0; i < AudioData.clips.Count; ++i){
			if(AudioData.clips[i].name == name){
				Play(AudioData.clips[i]);
				return;
			}
		}
	}

	private void Play(AudioClip clip){
		AudioSource audioSource = null;
		for(int i = 0; i < AudioSourceList.Count; ++i){
			if(!AudioSourceList[i].isPlaying){
				audioSource = AudioSourceList[i];
				break;
			}
		}
		if(audioSource == null){
			audioSource = Instantiate(AudioSourcePrefab);
			audioSource.transform.SetParent(transform);
			AudioSourceList.Add(audioSource);
		}
		audioSource.clip = clip;
		audioSource.loop = true;
		audioSource.spatialBlend = 0f;
		audioSource.Play();
	}

	public void Stop(string name){
		for(int i = 0; i < AudioSourceList.Count; ++i){
			if(AudioSourceList[i].clip.name == name){
				AudioSourceList[i].Stop();
				break;
			}
		}
	}

}

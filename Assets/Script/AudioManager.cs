using System;
using System.Diagnostics;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance { get; private set; }

	private AudioSource _mySfx;
	[SerializeField] private AudioClip clipGameOver;
	[SerializeField] private AudioClip clipHit;
	
	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		_mySfx = GetComponent<AudioSource>();
	}

	public void Play(AudioClip clip, float volume = 1)
	{
		_mySfx.PlayOneShot(clip, volume);
	}

	public void Play(SoundType type)
	{
		var clip = GetClip(type);
		Play(clip);
	}

	private AudioClip GetClip(SoundType type)
	{
		return type switch
		{
			SoundType.GameOver => clipGameOver,
			SoundType.Hit => clipHit,
			_ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
		};
	}
}

public enum SoundType
{
	GameOver,
	Hit
}
using System.Collections;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Audio Event/Simple")]
public class SimpleAudioEvent : AudioEvent
{
    public AudioClip[] Clips;

    public RangedFloat Volume;

    [MinMaxRange(0f,2f)]
    public RangedFloat Pitch;

    public override void Play(AudioSource source)
    {
        if (Clips.Length == 0)
            return;

        source.clip = Clips[Random.Range(0, Clips.Length - 1)];
        source.volume = Random.Range(Volume.minValue, Volume.maxValue);
        source.pitch = Random.Range(Pitch.minValue, Pitch.maxValue);
        source.Play();
    }
}

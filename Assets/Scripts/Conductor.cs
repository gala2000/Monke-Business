using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Conductor : MonoBehaviour
{
    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public float songBpm;

    //The number of seconds for each song beat
    public float secPerBeat;

    //The offset to the first beat of the song in seconds
    public float firstBeatOffset;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    public float dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    public UnityEvent onBeat;
    public UnityEvent onHalfBeat;

    //PLACEHOLDER
    int beatTracker;
    int halfBeatTracker;
   
    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();
    }

    void Update()
    {
        //determine how many seconds since the song started relative to when the first beat occurs.
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;

        CheckBeat();
    }

    //PLACEHOLDER
    void CheckBeat()
    {
        if (songPositionInBeats >= beatTracker)
        {
            onBeat.Invoke();
            beatTracker++;
        }
        if(songPositionInBeats >= halfBeatTracker)
        {
            onHalfBeat.Invoke();
            halfBeatTracker += 2;
        }
    }
}

using Random = System.Random;
using System.Collections.Generic;
using UnityEngine;

namespace Interface
{
    public class Music : MonoBehaviour
    {
        public List<AudioClip> listTracks = new List<AudioClip>();

        private AudioSource audioSource;

        private int currentTrackIndex;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();

            currentTrackIndex = new Random().Next(0, listTracks.Count);
            audioSource.clip = listTracks[currentTrackIndex];
            audioSource.Play();
        }

        private void Update()
        {
            if (audioSource.time >= listTracks[currentTrackIndex].length - 0.1f)
            {
                currentTrackIndex = (currentTrackIndex + 1) % listTracks.Count;
                audioSource.clip = listTracks[currentTrackIndex];
                audioSource.Play();
            }
        }
    }
}

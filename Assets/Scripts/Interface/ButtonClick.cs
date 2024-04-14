using UnityEngine;

namespace Interface
{
    public class ButtonClick : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip audioClip;

        public void PlayClip()
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}

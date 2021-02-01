using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Monomite.Common
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class AudioController : MonoBehaviour
    {
        [SerializeField]
        private AudioSource AudioSource;

        [SerializeField]
        [Range(0, 10)]
        private int RatioNotPlay;

        protected void PlayClip(AudioClip clip)
        {
            if(AudioSource != null)
            {
                AudioSource.PlayOneShot(clip);
            }
        }

        protected void PlayRandomClip(ICollection<AudioClip> clips)
        {
            AudioClip randomClip = GameUtils.RandomElement<AudioClip>(clips);

            PlayClip(randomClip);
        }

        protected void PlayRandomClipOrNot(ICollection<AudioClip> clips)
        {
            int randomNumber = Random.Range(0, 10);
            if(randomNumber < RatioNotPlay)
            {
                PlayRandomClip(clips);
            }
        }

        protected void Stop()
        {
            AudioSource.Stop();
        }
    }
}
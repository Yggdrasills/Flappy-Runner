using BaseCore.Utils.Singleton;
using UnityEngine;

namespace FlappyRunner.Game
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundsPlayer : MonoBehaviour
    {
        public static SoundsPlayer Instance { get; private set; }
        private AudioSource _source;

        private void Awake()
        {
            Instance = this;
            _source = GetComponent<AudioSource>();
            _source.loop = false;
            _source.playOnAwake = false;
            _source.volume = 1;
        }

        public void PlaySound(AudioClip clip)
        {
            _source.PlayOneShot(clip);
        }
    }
}
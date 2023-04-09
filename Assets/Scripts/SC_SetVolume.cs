using UnityEngine;
using UnityEngine.Audio;

namespace DefaultNamespace
{
    public class SC_SetVolume : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;

        public void audioOff(int volume)
        {
            audioMixer.SetFloat("audioMixerVolume", volume);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Slider MasterSlider;
    [SerializeField] Slider BGMSlider;
    [SerializeField] Slider SESlider;

    // Start is called before the first frame update
    void Start()
    {
        audioMixer.GetFloat("Master", out float masterVolume);
        MasterSlider.value = masterVolume;

        audioMixer.GetFloat("BGM", out float bgmVolume);
        BGMSlider.value = bgmVolume;

        audioMixer.GetFloat("SE", out float seVolume);
        SESlider.value = seVolume;
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Master", volume);
    }

    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGM", volume);
    }

    public void SetSEVolume(float volume)
    {
        audioMixer.SetFloat("SE", volume);
    }
}

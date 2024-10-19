using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Image musicImage;
    [SerializeField] private Image sfxImage;
    [SerializeField] private Sprite musicOnSprite;
    [SerializeField] private Sprite musicOffSprite;
    [SerializeField] private Sprite sfxOnSprite;
    [SerializeField] private Sprite sfxOffSprite;

    private bool isMusicOn;
    private bool isSfxOn;

    private const string MusicVolumeKey = "musicVolume";
    private const string SfxVolumeKey = "sfxVolume";

    private void Start()
    {
        Debug.Log("AUDIO");
        LoadPreferences();
    }

    public void OnMusicButtonClicked()
    {
        isMusicOn = !isMusicOn;
        UpdateMusicSettings();
    }

    public void OnSfxButtonClicked()
    {
        isSfxOn = !isSfxOn;
        UpdateSfxSettings();
    }

    private void LoadPreferences()
    {
        isMusicOn = PlayerPrefs.GetInt(MusicVolumeKey, 1) == 1;
        isSfxOn = PlayerPrefs.GetInt(SfxVolumeKey, 1) == 1;

        UpdateMusicSettings();
        UpdateSfxSettings();
    }

    private void UpdateMusicSettings()
    {
        musicImage.sprite = isMusicOn ? musicOnSprite : musicOffSprite;
        audioMixer.SetFloat("music", isMusicOn ? 0 : -80);
        PlayerPrefs.SetInt(MusicVolumeKey, isMusicOn ? 1 : 0);
    }

    private void UpdateSfxSettings()
    {
        sfxImage.sprite = isSfxOn ? sfxOnSprite : sfxOffSprite;
        audioMixer.SetFloat("sfx", isSfxOn ? 0 : -80);
        PlayerPrefs.SetInt(SfxVolumeKey, isSfxOn ? 1 : 0);
    }
}

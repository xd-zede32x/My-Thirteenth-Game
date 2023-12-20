using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource[] _audioSources;
    [SerializeField] private Image _musicButton;
    [SerializeField] private Sprite _musicOn;
    [SerializeField] private Sprite _musicOff;
    [SerializeField] private Text _text;

    public void OnClickMusicButton()
    {
        foreach (var audioSource in _audioSources)
        {
            if (audioSource.volume >= 0.1f)
            {
                audioSource.volume = 0f;
                IsActiveImage(_musicOff);
                _text.text = "Music Off";
            }

            else if (audioSource.volume == 0f)
            {
                audioSource.volume = 0.1f;
                IsActiveImage(_musicOn);
                _text.text = "Music On";
            }
        }
    }

    private void IsActiveImage(Sprite musicInfo)
    {
        _musicButton.GetComponent<Image>().sprite = musicInfo;
    }
}
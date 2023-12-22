using UnityEngine;

public class IsPurchaseSuccessful : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private AudioSource _audioSource;

    public void AudioPlayback(int index)
    {
        _audioSource.PlayOneShot(_audioClips[index]);
    }
}
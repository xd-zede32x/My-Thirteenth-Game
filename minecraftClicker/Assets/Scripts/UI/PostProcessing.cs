using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _postProcessingOn;
    [SerializeField] private Sprite _postProcessingOff;
    [SerializeField] private PostProcessVolume _postProcessingVolume;

    public void Processing()
    {
        if (_postProcessingVolume.weight >= 0.1f)
        {
            _postProcessingVolume.weight = 0f;
            _image.GetComponent<Image>().sprite = _postProcessingOff;
            _text.text = "Processing Off";
        }

        else if (_postProcessingVolume.weight == 0)
        {
            _postProcessingVolume.weight = 1f;
            _image.GetComponent<Image>().sprite = _postProcessingOn;
            _text.text = "Processing On";
        }
    }
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using System.Runtime.InteropServices;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void PlayerInfoData();

    [SerializeField] private Text _userNameText;
    [SerializeField] private RawImage _userIconImage;

    public void EnterButton()
    {
        PlayerInfoData();
    }

    public void SetName(string name)
    {
        _userNameText.text = name;
    }

    public void SetPhoto(string url)
    {
        StartCoroutine(DownloadImage(url));
    }

    public IEnumerator DownloadImage(string mediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);

        else
            _userIconImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }
}
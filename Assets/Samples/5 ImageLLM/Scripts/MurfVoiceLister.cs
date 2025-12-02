using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MurfVoiceLister : MonoBehaviour
{
    [Header("Paste Your Murf API Key")]
    public string murfApiKey;

    private void Start()
    {
        StartCoroutine(GetVoices());
    }

    IEnumerator GetVoices()
    {
        UnityWebRequest req = UnityWebRequest.Get("https://api.murf.ai/v1/speech/voices");
        req.SetRequestHeader("api-key", murfApiKey);

        yield return req.SendWebRequest();

        if (req.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("❌ Failed to fetch voices: " + req.error);
        }
        else
        {
            Debug.Log("🎙 Murf Voice List Response:\n" + req.downloadHandler.text);
        }
    }
}

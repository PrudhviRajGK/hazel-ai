using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

namespace QuestCameraKit.OpenAI
{
    public class TtsManager : MonoBehaviour
    {
        [Header("🎙 MURF AI TTS CONFIG")]
        [Tooltip("Your Murf API Key — paste from dashboard")]
        [SerializeField] private string murfApiKey = "";

        [Tooltip("Voice ID exactly from Murf API: ex: en-US-alina, en-US-wayne")]
        [SerializeField] private string murfVoiceId = "en-US-wayne";

        [Tooltip("Audio format: mp3, wav, flac, ogg, alaw, ulaw, pcm")]
        [SerializeField] private string audioFormat = "mp3";

        [Tooltip("Sample rate: 8000, 24000, 44100, 48000")]
        [SerializeField] private int sampleRate = 24000;

        [Tooltip("Channel type: mono or stereo")]
        [SerializeField] private string channelType = "mono";

        [Space(10)]
        [SerializeField] private AudioPlayer audioPlayer;

        private void Awake()
        {
            if (audioPlayer == null)
                audioPlayer = GetComponentInChildren<AudioPlayer>();

            if (audioPlayer == null)
                Debug.LogError("❌ AudioPlayer not assigned! Drag AudioPlayer into TTSManager inspector.");
        }

        public void SynthesizeAndPlay(string text)
        {
            if (string.IsNullOrWhiteSpace(murfApiKey))
            {
                Debug.LogError("❌ Murf API Key is EMPTY — set it in Inspector!");
                return;
            }

            if (string.IsNullOrWhiteSpace(murfVoiceId))
            {
                Debug.LogError("❌ Murf Voice ID EMPTY — example: en-US-wayne");
                return;
            }

            StartCoroutine(RequestMurfSpeech(text));
        }

        private IEnumerator RequestMurfSpeech(string text)
        {
            Debug.Log($"🔊 MURF TTS Synthesizing → \"{text}\"");

            // ✅ CORRECT: Use camelCase for Murf API
            var requestBody = new MurfRequest
            {
                text = text,
                voiceId = murfVoiceId,        // camelCase, not voice_id
                format = audioFormat,
                sampleRate = sampleRate,      // camelCase, not sample_rate
                channelType = channelType,    // camelCase, not channel_type
                encodeAsBase64 = false        // camelCase, not encode_as_base64
            };

            string json = JsonUtility.ToJson(requestBody);
            Debug.Log($"📤 Sending JSON: {json}");

            byte[] raw = Encoding.UTF8.GetBytes(json);

            UnityWebRequest req = new UnityWebRequest("https://api.murf.ai/v1/speech/generate", "POST");
            req.uploadHandler = new UploadHandlerRaw(raw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            req.SetRequestHeader("api-key", murfApiKey);

            yield return req.SendWebRequest();

            if (req.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"❌ Murf Request Failed → {req.error}");
                Debug.LogError($"Response Code: {req.responseCode}");
                Debug.LogError($"Response Body: {req.downloadHandler.text}");
                yield break;
            }

            Debug.Log($"✅ Murf Response (Code {req.responseCode}): {req.downloadHandler.text}");

            // ✅ CORRECT: Response field is audioFile (camelCase)
            MurfResponse response = JsonUtility.FromJson<MurfResponse>(req.downloadHandler.text);

            if (string.IsNullOrEmpty(response.audioFile))
            {
                Debug.LogError("❌ No audioFile URL returned from Murf!");
                Debug.LogError($"Full response: {req.downloadHandler.text}");
                yield break;
            }

            Debug.Log($"⬇ Downloading audio from: {response.audioFile}");
            yield return StartCoroutine(DownloadAndPlay(response.audioFile));
        }

        private IEnumerator DownloadAndPlay(string url)
        {
            // ✅ Compatible with all Unity versions
            UnityWebRequest audioReq = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);
            yield return audioReq.SendWebRequest();

            if (audioReq.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"❌ Failed to download Murf audio: {audioReq.error}");
                yield break;
            }

            // Get the raw audio bytes
            byte[] audioBytes = audioReq.downloadHandler.data;

            Debug.Log($"🎧 Playing Murf TTS Audio ({audioBytes.Length} bytes)...");
            audioPlayer.ProcessAudioBytes(audioBytes);

            audioReq.Dispose();
        }

        // ✅ CORRECT: Murf API uses camelCase for all fields
        [System.Serializable]
        private class MurfRequest
        {
            public string text;
            public string voiceId;        // NOT voice_id
            public string format;
            public int sampleRate;        // NOT sample_rate
            public string channelType;    // NOT channel_type
            public bool encodeAsBase64;   // NOT encode_as_base64
        }

        // ✅ CORRECT: Response uses camelCase
        [System.Serializable]
        private class MurfResponse
        {
            public string audioFile;      // NOT audio_url
            public int audioDuration;
            public string voiceId;
            public bool success;
        }
    }
}
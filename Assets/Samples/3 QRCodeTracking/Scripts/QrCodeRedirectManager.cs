using UnityEngine;
using System;

public class QrCodeRedirectManager : MonoBehaviour
{
    [SerializeField] private QrCodeScanner scanner;

    private async void Update()
    {
#if ZXING_ENABLED
        if (scanner == null) return;

        var results = await scanner.ScanFrameAsync();
        if (results != null && results.Length > 0)
        {
            foreach (var result in results)
            {
                Debug.Log("[QR Detected] " + result.text);

                // ✅ Redirect only if QR is a valid URL
                if (Uri.IsWellFormedUriString(result.text, UriKind.Absolute))
                {
                    Application.OpenURL(result.text);
                }
            }
        }
#endif
    }
}

using CielaSpike.Unity.Barcode;
using UnityEngine;
using System.Collections;

/// <summary>
/// Shows the qr code popup
/// </summary>
public class ShowQRCodeReader : TTMonoSingleton<ShowQRCodeReader>
{
    #region Variables

    WebCamTexture cameraTexture;

    Material cameraMat;

    WebCamDecoder decoder;

    IBarcodeEncoder qrEncoder, pdf417Encoder;

    bool DoCancel = false;

    // Variables
    #endregion

    #region CancelShowReader

    /// <summary>
    /// Stops the show reader popup
    /// </summary>
    public static void CancelShowReader()
    {
        instance.DoCancel = true;
    }

    // CancelShowReader
    #endregion

    #region ShowReader

    /// <summary>
    /// Shows the web cam pop up with a QR code decoder
    /// Call with Coroutine<>, returns a string with the QR code
    /// </summary>
    /// <param name="targetPlane">plane to display the web cam image on</param>
    /// <returns></returns>
    public IEnumerator ShowReader(GameObject targetPlane)
    {
        // reset cancel flag
        DoCancel = false;

        // get the material on the mesh renderer
        cameraMat = targetPlane.GetComponent<MeshRenderer>().material;

        // get a reference to web cam decoder component;
        decoder = GetComponent<WebCamDecoder>();

        if (decoder == null)
            Debug.Log("Decoder is null");
            
        // get encoders;
        qrEncoder = Barcode.GetEncoder(BarcodeType.QrCode, new QrCodeEncodeOptions()
        {
            ECLevel = QrCodeErrorCorrectionLevel.H
        });

        pdf417Encoder = Barcode.GetEncoder(BarcodeType.Pdf417);

        qrEncoder.Options.Margin = 1;
        pdf417Encoder.Options.Margin = 2;

        // init web cam;
        if (Application.platform == RuntimePlatform.OSXWebPlayer ||
            Application.platform == RuntimePlatform.WindowsWebPlayer)
        {
            yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        }

        var devices = WebCamTexture.devices;
        var deviceName = devices[0].name;
        cameraTexture = new WebCamTexture(deviceName, 1920, 1080);
        cameraTexture.Play();

        // start decoding;
        yield return StartCoroutine(decoder.StartDecoding(cameraTexture));

        cameraMat.mainTexture = cameraTexture;

        // adjust texture orientation;
        targetPlane.transform.rotation = targetPlane.transform.rotation *
            Quaternion.AngleAxis(cameraTexture.videoRotationAngle, Vector3.up);

        // loop until cancelled or we found a qr code
        string ResultText = string.Empty;
        bool decoded = false;
        while ((!decoded) && (!DoCancel))
        {
            // wait a frame
            yield return new WaitForEndOfFrame();

            // get decode result;
            DecodeResult result = decoder.Result;
            if (!result.Success)
                continue;

            // we got it
            decoded = true;
            ResultText = result.Text;
            Debug.Log(string.Format("Decoded: [{0}]{1}", result.BarcodeType, ResultText));
        }

        // clean up
        decoder.StopDecoding();

        // wait
        yield return new WaitForEndOfFrame();

        // hide the plane
        targetPlane.SetActive(false);

        // return the Result
        yield return ResultText;
    }

    // ShowReader
    #endregion
}

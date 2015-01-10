using UnityEngine;
using System.Collections;

public class ShowQRButton : TTMonoBehaviour 
{
    #region Variables

    public GameObject TargetPlane;

    private readonly Rect ShowRect = new Rect(10, 10, 100, 60);
    private readonly Rect CancelRect = new Rect(10, 75, 100, 60);

    bool? DoPopup = null;

    // Variables
    #endregion

    #region Start

    /// <summary>
    /// Start function
    /// </summary>
    void Start()
    {
        StartCoroutine(HandlePopup());
    }

    // Start
    #endregion

    #region HandlPopup

    IEnumerator HandlePopup()
    {
        while (true)
        {
            // wait until we have a value
            while (! DoPopup.HasValue)
                yield return new WaitForEndOfFrame();

            // start
            if (DoPopup.Value)
            {
                // activate the plane
                TargetPlane.SetActive(true);

                Coroutine<string> DoQrRoutine = StartCoroutine<string>(ShowQRCodeReader.instance.ShowReader(TargetPlane));
                yield return DoQrRoutine.coroutine;

                // get result
                Debug.Log(string.Format("Got it: {0}", DoQrRoutine.Value));

                // reset popup
                DoPopup = false;
            }

            // wait and loop
            yield return new WaitForEndOfFrame();
        }
        
            
    }

    // HandlPopup
    #endregion
    

    #region OnGUI

    /// <summary>
    /// OnGUI function
    /// </summary>
    void OnGUI()
    {
        if (((!DoPopup.HasValue) || (!DoPopup.Value)) && (GUI.Button(ShowRect, "Show Popup")))
            DoPopup = true;

        if (((DoPopup.HasValue) && (DoPopup.Value)) && (GUI.Button(CancelRect, "Cancel")))
        {
            DoPopup = false;
            ShowQRCodeReader.CancelShowReader();
        }
    }

    // OnGUI
    #endregion
    
}

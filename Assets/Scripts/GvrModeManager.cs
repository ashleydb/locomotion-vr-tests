using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class GvrModeManager : MonoBehaviour {

	// We need a reference to the gvr components
	public GameObject gvrViewerMain = null;
	public Camera mainCamera = null;

	// This is to enable/disable the reticule
	private GvrReticle gvrReticle = null;
	// This is to access the gvr SDK functions
	private GvrViewer gvrViewer = null;

	public void Start()
	{
		if (gvrViewerMain != null) {
			gvrViewer = gvrViewerMain.GetComponentInChildren<GvrViewer> ();
			if (gvrViewer != null) {
				// Save a flag in the local player preferences to initialize VR mode
				// This way when the app is restarted, it is in the mode that was last used.
				int doVR = PlayerPrefs.GetInt ("VREnabled");
				gvrViewer.VRModeEnabled = (doVR == 1);
				gvrViewer.enabled = gvrViewer.VRModeEnabled;

				gvrReticle = mainCamera.GetComponentInChildren<GvrReticle> ();
				if (gvrReticle != null) {
					gvrReticle.gameObject.SetActive (gvrViewer.VRModeEnabled);
				}
			}
		}
	}

	// The event handler to call to toggle gvr mode.
	public void ChangeVrMode()
	{
		if (gvrViewer != null) {
			if (gvrViewer.VRModeEnabled) {
				// disabling.  rotate back to the original rotation.
				mainCamera.transform.localRotation = Quaternion.identity;
			}
			gvrViewer.VRModeEnabled = !gvrViewer.VRModeEnabled;
			gvrViewer.enabled = gvrViewer.VRModeEnabled;
			gvrReticle.gameObject.SetActive (gvrViewer.VRModeEnabled);
			PlayerPrefs.SetInt ("VREnabled", gvrViewer.VRModeEnabled ? 1 : 0);
			PlayerPrefs.Save ();
		}
	}

	// The gvr SDK can show a back button, (escaspe key on keyboard,) which we will use to get out of VR view
	void Update () {
		if (gvrViewer.BackButtonPressed) {
			ChangeVrMode();
		}
	}
}

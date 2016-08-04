using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GroundTriggers : MonoBehaviour, IPointerClickHandler, IScrollHandler {

	public PlayerController player;

	// Will work for clicks and Cardboard trigger presses
	public void OnPointerClick(PointerEventData eventData)
	{
		//player.viewMarker.transform.position = eventData.pointerCurrentRaycast.worldPosition;
		player.SetPoint (eventData.pointerCurrentRaycast.worldPosition);
	}

	// TODO: Doesn't seem to work. IScrollHandler? As the gaze moves around, move the view marker
	public void OnScroll(PointerEventData eventData)
	{
		//player.viewMarker.transform.position = eventData.pointerCurrentRaycast.worldPosition;
	}
}
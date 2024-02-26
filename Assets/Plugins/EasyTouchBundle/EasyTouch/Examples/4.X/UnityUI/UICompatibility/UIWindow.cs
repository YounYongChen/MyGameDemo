using UnityEngine;
using UnityEngine.EventSystems;
using HedgehogTeam.EasyTouch;

public class UIWindow : MonoBehaviour, IDragHandler{

	public void OnDrag (PointerEventData eventData){
		transform.position += (Vector3)eventData.delta;
	}

}

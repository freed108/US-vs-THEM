using UnityEngine;
using System.Collections;

public class Mouse_Point : MonoBehaviour {

	RaycastHit hit;

	public static GameObject CurrentlySelectedUnit;

	public static ArrayList CurrentlySelectedUnits = new ArrayList ();

	public GameObject RightClickMarker;

	public GameObject TargetMarker;

	public GameObject Target;

	public static Vector3 mouseDownPoint = Vector3.zero;

	public static bool UserIsDragging;
	private static float TimeLimitBeforeDeclareDrag = 1f;
	private static float TimeLeftBeforeDeclareDrag;
	private static Vector2 MouseDragStart;

	private static float clickDragZone = 1.3f;
	
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {

			if (Input.GetMouseButtonDown (0))
				mouseDownPoint = hit.point;

			//MouseDrag
			if(Input.GetMouseButtonDown(0))
			{
				TimeLeftBeforeDeclareDrag = TimeLimitBeforeDeclareDrag;
				MouseDragStart = Input.mousePosition;
			}
			else if(Input.GetMouseButton(0))
			{
				if(!UserIsDragging)
				{
					TimeLeftBeforeDeclareDrag -= Time.deltaTime;

					if(TimeLeftBeforeDeclareDrag <= 0f || UserDraggingByPosition(MouseDragStart, Input.mousePosition))
						UserIsDragging = true;
				}
				//User is dragging, compute GUI
				if(UserIsDragging)
					Debug.Log ("Yes, user is dragging!");
			}
			else if(Input.GetMouseButtonUp(0))
			{
				Debug.Log ("User no longer dragging");
				TimeLeftBeforeDeclareDrag = 0f;
				UserIsDragging = false;
			}

			//MouseClick
			if (!UserIsDragging)
			{
				if (hit.collider.name == "Terrain") {
					if (Input.GetMouseButtonDown (1)) {
						if(CurrentlySelectedUnits.Count > 0)
						{
							GameObject Marker = Instantiate (RightClickMarker, hit.point, Quaternion.identity) as GameObject;
							Marker.name = "Marker Instantiated";
							foreach(GameObject Unit in CurrentlySelectedUnits)
							{
								//Debug.Log ("Moving units!");

								//Debug.Log(Unit.GetComponents()["Move Spot"].ToString());

								//GameObject Move = Unit.transform.FindChild("Move Spot").gameObject;
								//Move.transform.Translate(RightClickMarker.transform.position);

								//Unit.transform.FindChild("Move Spot").gameObject.transform.Translate(RightClickMarker.transform.position);

								//Debug.Log(Unit.transform.parent.gameObject.transform.parent.gameObject.name);

								GameObject Move = Unit.transform.parent.gameObject.transform.parent.gameObject;

								Move.transform.FindChild("Move Spot").transform.position = new Vector3(hit.point.x, hit.point.y + 0.35f, hit.point.z);
								/*foreach (Transform child in transform) {
									if (child.gameObject.name == "Move Spot") {
										Move = child.gameObject;
										Move.transform.Translate(Marker.transform.position);
									}
								}*/

								//Debug.Log(move.ToString());
							}
							//GameObject SelectedObj = hit.collider.transform.FindChild ("Selected").gameObject;
						}
					} else if (Input.GetMouseButtonUp (0) && DidUserClickLeftMouse (mouseDownPoint)) {
						if (!ShiftKeysDown ())
							DeselectGameobjectsIfSelected ();
					}
				} 

				else if (hit.collider.transform.FindChild ("Blue Army")) {
					if (Input.GetMouseButtonDown (1)) {
						if(CurrentlySelectedUnits.Count > 0)
						{
							GameObject Marker2 = Instantiate (TargetMarker, hit.point, Quaternion.identity) as GameObject;
							Marker2.name = "Targeting Instantiated";
							foreach(GameObject Unit in CurrentlySelectedUnits)
							{
								//Debug.Log ("Moving units!");
								
								//Debug.Log(Unit.GetComponents()["Move Spot"].ToString());
								
								//GameObject Move = Unit.transform.FindChild("Move Spot").gameObject;
								//Move.transform.Translate(RightClickMarker.transform.position);
								
								//Unit.transform.FindChild("Move Spot").gameObject.transform.Translate(RightClickMarker.transform.position);
								
								//Debug.Log(Unit.transform.parent.gameObject.transform.parent.gameObject.name);

								Target = hit.transform.parent.gameObject.transform.parent.gameObject;

								/*foreach (Transform child in transform) {
									if (child.gameObject.name == "Move Spot") {
										Move = child.gameObject;
										Move.transform.Translate(Marker.transform.position);
									}
								}*/
								
								//Debug.Log(move.ToString());
							}
							//GameObject SelectedObj = hit.collider.transform.FindChild ("Selected").gameObject;
						}
					} 
				}

				else {
					//Hitting other objects
					if (Input.GetMouseButtonUp (0) && DidUserClickLeftMouse (mouseDownPoint)) {
						//is the user hitting a unit?
						if (hit.collider.transform.FindChild ("Selected")) {
							//found a unit we can select
							Debug.Log ("Found a unit!");

							//are we selecting a different object?
							if (!UnitAlreadyInCurrentlySelectedUnits (hit.collider.gameObject)) {
								//if the shift key is not down, remove the rest of the units
								if (!ShiftKeysDown ())
									DeselectGameobjectsIfSelected ();

								GameObject SelectedObj = hit.collider.transform.FindChild ("Selected").gameObject;
								SelectedObj.SetActive (true);
								//add unit to currently selected units
								CurrentlySelectedUnits.Add (hit.collider.gameObject);
							} else {
								//remove unit from currently selected units
								if (ShiftKeysDown ())
									RemoveUnitFromCurrentlySelectedUnits (hit.collider.gameObject);
								else {
									DeselectGameobjectsIfSelected ();
									GameObject SelectedObj = hit.collider.transform.FindChild ("Selected").gameObject;
									SelectedObj.SetActive (true);
									CurrentlySelectedUnits.Add (hit.collider.gameObject);
								}
							}
						} else {
							//if this object is not a unit
							if (!ShiftKeysDown ())
								DeselectGameobjectsIfSelected ();
						}
					}
				}

			} else {
				if (Input.GetMouseButtonUp (0) && DidUserClickLeftMouse (mouseDownPoint))
				if (!ShiftKeysDown ())
					DeselectGameobjectsIfSelected ();
			}
		}
		
		Debug.DrawRay (ray.origin, ray.direction * Mathf.Infinity, Color.red);
	}

	//Is the user dragging, relative to the mouse drag start point?
	public bool UserDraggingByPosition(Vector2 DragStartPoint, Vector2 NewPoint)
	{
		if ((NewPoint.x > DragStartPoint.x + clickDragZone || NewPoint.x < DragStartPoint.x - clickDragZone) ||
			(NewPoint.y > DragStartPoint.y + clickDragZone || NewPoint.y < DragStartPoint.y - clickDragZone))
			return true;
		else
			return false;
	}

	//Did user perform a mouse click?
	public bool DidUserClickLeftMouse(Vector3 hitPoint)
	{
		if((mouseDownPoint.x < hitPoint.x + clickDragZone && mouseDownPoint.x > hitPoint.x - clickDragZone) &&
		   (mouseDownPoint.y < hitPoint.y + clickDragZone && mouseDownPoint.y > hitPoint.y - clickDragZone) &&
		   (mouseDownPoint.z < hitPoint.z + clickDragZone && mouseDownPoint.z > hitPoint.z - clickDragZone))
			return true;
		else
			return false;
	}

	//Deselects units if selected
	public void DeselectGameobjectsIfSelected()
	{
		if(CurrentlySelectedUnits.Count > 0) {
			for(int i = 0; i < CurrentlySelectedUnits.Count; i++)
			{
				GameObject ArrayListUnit = CurrentlySelectedUnits[i] as GameObject;
				ArrayListUnit.transform.FindChild("Selected").gameObject.SetActive(false);
			}
			CurrentlySelectedUnits.Clear();
		}
	}

	//check if a unit is already in the currently selected units arraylist
	public static bool UnitAlreadyInCurrentlySelectedUnits(GameObject Unit)
	{
		if (CurrentlySelectedUnits.Count > 0) {
			for (int i = 0; i < CurrentlySelectedUnits.Count; i++) {
				GameObject ArrayListUnit = CurrentlySelectedUnits [i] as GameObject;
				if (ArrayListUnit == Unit)
					return true;
			}
			return false;
		} else
			return false;
	}

	//remove a unit from the currently selected units arraylist
	public void RemoveUnitFromCurrentlySelectedUnits(GameObject Unit)
	{
		if (CurrentlySelectedUnits.Count > 0) {
			for (int i = 0; i < CurrentlySelectedUnits.Count; i++) {
				GameObject ArrayListUnit = CurrentlySelectedUnits [i] as GameObject;
				if (ArrayListUnit == Unit)
				{
					CurrentlySelectedUnits.RemoveAt(i);
					ArrayListUnit.transform.FindChild("Selected").gameObject.SetActive(false);
				}
			}
			return;
		} else
			return;
	}

	//are the shift keys being held down?
	public static bool ShiftKeysDown()
	{
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift))
			return true;
		else
			return false;
	}
}

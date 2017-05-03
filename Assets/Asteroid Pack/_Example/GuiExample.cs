using UnityEngine;
using System.Collections;

public class GuiExample : MonoBehaviour {

	public GameObject[] asteroids;

	private int index;
	private GameObject currentAsteroid;
	private Vector2 oldMouse;
	private bool move;
	private float zoom;
	private float currentZ;

	void Start () {
		index=5;
		currentAsteroid = (GameObject)Instantiate( asteroids[index],Vector3.zero,Quaternion.identity);
		currentZ = Camera.main.transform.position.x;
	}

	void Update(){
		if (currentAsteroid!=null){
			currentAsteroid.transform.Rotate(new Vector3(0.5f,1f,0)*20*Time.deltaTime);
		}
	}

	void OnGUI(){

		/*
		// Mouse drag
		Event e = Event.current;

		Vector2 currentMousePosition = e.mousePosition;

		float x = oldMouse.x - currentMousePosition.x;
		float y = oldMouse.y - currentMousePosition.y;

		oldMouse = currentMousePosition;

		if (move){
			currentAsteroid.transform.Rotate( new Vector3(0,x,-y),Space.World);
		}

		if (e.button==0 && e.isMouse){
			move = true;
		}
		else{
			move=false;
		}*/


		// zoom
		GUI.Label( new Rect(460,0,50,20),"Zoom");
		zoom = GUI.HorizontalSlider( new Rect(380,20,200,30),zoom,30,0);
		Camera.main.transform.position = new Vector3(currentZ-zoom ,Camera.main.transform.position.y,Camera.main.transform.position.z );

		// drag
		//GUI.Label( new Rect(410,40,300,30),"Drag to rotate asteroid");

		// Prev and next
		if (GUI.Button( new Rect(50,290,100,20),"Prev")){
			index--;
			if (index<0) index=11;
			CreateAsteroid(index);
		}
		
		if (GUI.Button( new Rect(810,290,100,20),"Next")){
			index++;
			if (index>11) index=0;
			CreateAsteroid(index);
		}


		// LOD
		float offset= 150;
		if (GUI.Button( new Rect(50 +offset,560,125,20),"Dynamic")){
			currentAsteroid.GetComponent<LODGroup>().ForceLOD(-1);
		}

		if (GUI.Button( new Rect(200+offset,560,125,20),"LOD 0 : 2000 poly")){
			currentAsteroid.GetComponent<LODGroup>().ForceLOD(0);
		}

		if (GUI.Button( new Rect(350+offset,560,125,20),"LOD 1 : 1000 poly")){
			currentAsteroid.GetComponent<LODGroup>().ForceLOD(1);
		}

		if (GUI.Button( new Rect(500+offset,560,125,20),"LOD 2 : 500 poly")){
			currentAsteroid.GetComponent<LODGroup>().ForceLOD(2);
		}
	}

	void CreateAsteroid(int ind){

		if (currentAsteroid!=null){
			Destroy(currentAsteroid);
		}

		currentAsteroid = (GameObject)Instantiate( asteroids[ind],Vector3.zero,Quaternion.identity);
	}
}

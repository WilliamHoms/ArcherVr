using UnityEngine;
using System.Collections;

public class GrabTower : MonoBehaviour {
    private VRTK.VRTK_InteractableObject scriptInteractable;
    private Tower towerscript;

    private GameObject pointDeRefScale;


    private float minimumDistance = 60;
    private float maximumDistance = 150;

    private float minimumDistanceScale = 0.1f;
    private float maximumDistanceScale = 0.01f;


	// Use this for initialization
	void Start () {
        scriptInteractable = GetComponent<VRTK.VRTK_InteractableObject>();
        towerscript = GetComponent<Tower>();
        pointDeRefScale = GameObject.Find("PointDeRefScale");



	}
	
	// Update is called once per frame
	void Update () {
        if (scriptInteractable.IsGrabbed()) {

            float distance = (transform.position - pointDeRefScale.transform.position).magnitude;
            float norm = (distance - minimumDistance) / (maximumDistance - minimumDistance);
            norm = Mathf.Clamp01(norm);

            Vector3 minScale = Vector3.one * maximumDistanceScale;
            Vector3 maxScale = Vector3.one * minimumDistanceScale;


            transform.localScale = Vector3.Lerp(maxScale, minScale, norm);

           
        }
	
	}

    void OnTriggerStay(Collider col) {
        if (col.gameObject.CompareTag("SpotTower"))
        {

            scriptInteractable.isDroppable = true;
            towerscript.awake = true;
        }
        else {
            scriptInteractable.isDroppable = false;
            towerscript.awake = false;
        }
    }
}

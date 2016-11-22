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

    bool inTrash = false;

	void Start () {
        scriptInteractable = GetComponent<VRTK.VRTK_InteractableObject>();
        towerscript = GetComponent<Tower>();
        pointDeRefScale = GameObject.Find("PointDeRefScale");
        scriptInteractable.isDroppable = false;



	}
	

	void Update () {
        Debug.Log(scriptInteractable.isDroppable);

        //On check si la tour est grabbée
        if (scriptInteractable.IsGrabbed()) {
            //on la scale avec la distance de l'objet pointdeRefScale
            float distance = (transform.position - pointDeRefScale.transform.position).magnitude;
            float norm = (distance - minimumDistance) / (maximumDistance - minimumDistance);
            norm = Mathf.Clamp01(norm);

            Vector3 minScale = Vector3.one * maximumDistanceScale;
            Vector3 maxScale = Vector3.one * minimumDistanceScale;


            transform.localScale = Vector3.Lerp(maxScale, minScale, norm);

           
        }

        if (scriptInteractable.IsGrabbed() == false && inTrash)
        {
            Destroy(gameObject);
        }

    }


    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.CompareTag("SpotTower"))
        {
            Debug.Log("Colliding with SpotTower");
            Droppable(true);
            //activer la tour
            //towerscript.awake = true;


        }

        if (col.gameObject.CompareTag("Trashcan"))
        {
            Droppable(true);

            inTrash = true;
        }
    }

    void OnTriggerExit (Collider col)
    {
        if (col.gameObject.CompareTag("SpotTower"))
        {
            Droppable(false);
            //désactiver la tour
            //towerscript.awake = false;


        }
        if (col.gameObject.CompareTag("Trashcan"))
        {
            Droppable(false);
            inTrash = false;
        }

    }

    void Droppable(bool drop) {
        if (drop)
        {
            scriptInteractable.isDroppable = true;



        }
        else {
            scriptInteractable.isDroppable = false;



        }
    }
}

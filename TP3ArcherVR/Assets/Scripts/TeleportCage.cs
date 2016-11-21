using UnityEngine;
using System.Collections;

public class TeleportCage : MonoBehaviour {

    public string state = "No state";

    //lorsque l'on touche les triggers d'une touche on envoie son tag ici
    public string selected = "No selection";
    private Transform destination;

    public Transform godview;
    public Transform tourMilieu;
    public Transform tourArriere;
    public Transform tourAvant;

    //objets à activer/désactiver quand on se téléporte
    public GameObject triggersSelection;
    public GameObject headQuiver;

    public float speed = 5f;

    //lorsque cette variable est vraie on se téléporte
    public bool activateTeleport = false;



	void Start () {
        //on désactive le teleport si jamais il est activé en démarrant le jeu
        activateTeleport = false;
        //destination de base est le god view
        destination = godview;
	}
	

	void Update () {

        //si on est pas loin de la destination on désactive le teleport. Lerp nous fait jamais arriver à la position exacte donc on peut pas faire de check absolue;
        if (activateTeleport)
        {
            float distance = 0.01f;

            if (Vector3.Distance(transform.position, destination.position) < distance)
            {
                activateTeleport = false;
            }
        }

        //DEBUG: Si pas de state 
        if (state == "No state") {
            Debug.Log("No state");
        }

        if (state == "God") {
            //activer les triggers / désactiver le quiver et les flèches;
            triggersSelection.SetActive(true);
            headQuiver.SetActive(false);
        }else
        {
            //désactiver les triggers /activer le quiver et les flèches;
            triggersSelection.SetActive(false);
            headQuiver.SetActive(true);
        }



        //Lorsque le teleport est activé : teleporter
        if (activateTeleport)
        {

            //si aucune sélection on définit la destination de base à GOd view;
            if (selected == "No selection")
            {
                destination = godview;
            }
            //on définit la destination suivant ce que l'on touche
            if (selected == "TourMilieu")
            {
                destination = tourMilieu;
            }
            if (selected == "TourAvant")
            {
                destination = tourAvant;
            }
            if (selected == "TourArriere")
            {
                destination = tourArriere;
            }


            //si on est en godview on ne peut pas se retéléporter en godview;
            if (state == "God")
            {
                if (selected != "No selection")
                {
                    TeleportMe();
                }
            }
            else
            {
                selected = "No selection";
                TeleportMe();
            }
        }


       

	}




    void OnTriggerEnter (Collider col)
    {
        //si on collide avec notre destination on désactive le teleporte
        if (col.gameObject.CompareTag("GodView") && activateTeleport)
        {
            if (Vector3.Distance(transform.position, destination.position) < 0.1f)
            {
                activateTeleport = false;

            }
            state = "God";

        }
        if (col.gameObject.CompareTag("TourMilieu") && activateTeleport)
        {
            activateTeleport = false;
            destination = godview;
            state = "Milieu";

        }
        if (col.gameObject.CompareTag("TourAvant") && activateTeleport)
        {
            activateTeleport = false;
            destination = godview;
            state = "Avant";

        }
        if (col.gameObject.CompareTag("TourArriere") && activateTeleport)
        {
            activateTeleport = false;
            destination = godview;
            state = "Arriere";

        }
    }

    void TeleportMe() {

        // change la position, la rotation et le scale.
        transform.position = Vector3.Lerp(transform.position, destination.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, destination.rotation, speed * Time.deltaTime);
        transform.localScale = Vector3.Lerp(transform.localScale, destination.localScale, speed * Time.deltaTime);



    }
}

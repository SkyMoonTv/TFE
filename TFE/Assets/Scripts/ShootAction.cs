using UnityEngine;
using UnityEngine.Events;

public class ShootAction : MonoBehaviour
{

    //Dommage que le Gun inflige
    [SerializeField]
    private int gunDamage = 1;

    //Port�e du tir
    [SerializeField]
    private float weaponRange = 200f;

    //Force de l'impact du tir
    [SerializeField]
    private float hitForce = 100f;

    //La cam�ra
    private Camera fpsCam;

    //Temps entre chaque tir (en secondes)
    [SerializeField]
    private float fireRate = 0.1f;

    //Son pour le fire
    [SerializeField]
    private AudioClip audioFire = null;
    //Son pour le Hit
    [SerializeField]
    private AudioClip audioHit = null;

    private AudioSource gun_AudioSource;

    private AudioSource hit_AudioSource;

    //Float : m�morise le temps du prochain tir possible
    private float nextFire;

    //D�termine sur quel Layer on peut tirer
    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private LayerMask noLayerMask;

    private void Awake()
    {
        gun_AudioSource = GetComponent<AudioSource>();
        hit_AudioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {

        //R�f�rence de la cam�ra. GetComponentInParent<Camera> permet de chercher une Camera
        //dans ce GameObject et dans ses parents.
        fpsCam = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // V�rifie si le joueur a press� le bouton pour faire feu (ex:bouton gauche souris)
        // Time.time > nextFire : v�rifie si suffisament de temps s'est �coul� pour pouvoir tirer � nouveau
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            //Nouveau tir

            //Son au tir
            gun_AudioSource.PlayOneShot(audioFire);

            //Met � jour le temps pour le prochain tir
            //Time.time = Temps �coul� depuis le lancement du jeu
            //temps du prochain tir = temps total �coul� + temps qu'il faut attendre
            nextFire = Time.time + fireRate;

            //On va lancer un rayon invisible qui simulera les balles du gun

            //Cr�e un vecteur au centre de la vue de la cam�ra
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            //RaycastHit : permet de savoir ce que le rayon a touch�
            RaycastHit hit;

            // V�rifie si le raycast a touch� quelque chose
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward,out hit, weaponRange,layerMask))
            {
                
                // V�rifie si la cible a un RigidBody attach�
                if (hit.rigidbody != null)
                {
                    //AddForce = Ajoute Force = Pousse le RigidBody avec la force de l'impact
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                    
                    //S'assure que la cible touch�e a un composant ReceiveAction
                    if (hit.collider.gameObject.GetComponent<ReceiveAction>() != null)
                    {
                        //Envoie les dommages � la cible
                        hit.collider.gameObject.GetComponent<ReceiveAction>().GetDamage(gunDamage);

                        //Joue le son du Hit
                        hit_AudioSource.PlayOneShot(audioHit);
                    }

                    //S'assure que la cible touch�e a un composant ReceiveActionOpen
                    if (hit.collider.gameObject.GetComponent<ReceiveActionOpen>() != null)
                    {
                        //Envoie les dommages � la cible
                        hit.collider.gameObject.GetComponent<ReceiveActionOpen>().GetDamage(gunDamage);

                        //Joue le son du Hit
                        hit_AudioSource.PlayOneShot(audioHit);

                    }

                    //S'assure que la cible touch�e a un composant ReceiveActionOpen
                    if (hit.collider.gameObject.GetComponent<ReceiveActionSpawn>() != null)
                    {
                        //Envoie les dommages � la cible
                        hit.collider.gameObject.GetComponent<ReceiveActionSpawn>().GetDamage(gunDamage);

                        //Joue le son du Hit
                        hit_AudioSource.PlayOneShot(audioHit);

                    }
                }   
            }
        }
    }
}
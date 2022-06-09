using UnityEngine;
public class ShowTarget : MonoBehaviour
{

    //J'importe le Script Timer qui va avec le GameObject Timer
    public GameObject target;
    //Fonction quand je rentre en collision
    private void OnTriggerEnter(Collider other)
    {
        //Recherche le GameObject Player
        if (GameObject.Find("Player"))
        {
            //Active la fonction Finnish
            target.SetActive(true);
        }
    }
}

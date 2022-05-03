using UnityEngine;
public class EndTimerBox : MonoBehaviour
{

    //J'importe le Script Timer qui va avec le GameObject Timer
    public Timer Timer;
    //Fonction quand je rentre en collision
    private void OnTriggerEnter(Collider other)
    {
        //Recherche le GameObject Player
        if (GameObject.Find("Player"))
        {
            Timer = GameObject.FindObjectOfType(typeof(Timer)) as Timer;
            //Active la fonction Finnish
            Timer.Finnish();
        }
    }
}

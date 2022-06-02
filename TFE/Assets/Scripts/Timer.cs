using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{

    //Pour inclure le Timer Text
    [SerializeField]
    private Text timerText;

    private float startTime;

    //Pour arrêter le timer
    private bool finnished = false;

    // Start is called before the first frame update
    private void Start()
    {
        //donne le temps depuis que la scène a commencé
        startTime = Time.time;
    }

    // Update is called once per frame
    private void Update()
    {

        if(finnished)
            return ;

        //Donne le temps depuis que l'appli a commencé
        float t = Time.time - startTime;

        //calcule les minutes
        string minutes = ((int) t / 60).ToString("0,0");
        //calcule les secondes. Le f2 dans le ToString sert à garder le nombre à 2 chiffres après la virgule
        string secondes = (t % 60).ToString("N3");

        //Affiche minutes:secondes
        timerText.text = minutes + ':' + secondes;
    }

    //Fonction de Fin de Timer
    public void Finnish()
    {
        //fini le timer
        finnished = true;
        //met la couleur du timer en rouge
        timerText.color = Color.red;
    }
}

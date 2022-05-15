using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public GameObject Panel;
    bool visible = false;

    public Dropdown DResolution;

    public AudioSource audioSource;
    public Slider slider;
    public Text TextVolume;

    private bool FixeView;

    private void Start()
    {
        SliderChange();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            visible = !visible;
            Panel.SetActive(visible);
            Cursor.visible = true;
            
        }
    }

    public void SetResolution()
    {
        switch (DResolution.value)
        {
            case 0:
                Screen.SetResolution(640, 360, true);
                break;

            case 1:
                Screen.SetResolution(1280, 720, true);
                break;

            case 2:
                Screen.SetResolution(1920, 1080, true);
                break;
        }
    }

    public void SliderChange()
    {
        audioSource.volume = slider.value;
        TextVolume.text = "Volume " + (audioSource.volume * 100).ToString("00") + "%";
    }

    public void Quit()
    {
        Application.Quit();
    }
}

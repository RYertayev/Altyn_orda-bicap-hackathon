using UnityEngine;
using UnityEngine.UI;
public class Collection : MonoBehaviour
{
    int tenge = 0;
    int dombyra = 0;
    int choco = 0;
    int health = 100;
    public Text tenge_text;
    public Text dombyra_text;
    public Text choco_text;
        public Text health_text;
    public AudioSource source;
    public AudioClip pickup_clip;
    public AudioClip damage_sound;
    public Slider slider;
    public GameObject deadPanel;
    public Text Ayaulym;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Dead();
        if (tenge == 5|| dombyra == 10 || choco == 10)
        {
            Ayaulym.text = "ј€улым выходи за мен€";
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            tenge++;
            collision.gameObject.SetActive(false);
            tenge_text.text = tenge.ToString();
            source.PlayOneShot(pickup_clip);
        }
        else if (collision.gameObject.tag == "dombyra")
        {
            dombyra++;
            collision.gameObject.SetActive(false);
            dombyra_text.text = dombyra.ToString();
            source.PlayOneShot(pickup_clip);
        }
        else if (collision.gameObject.tag == "choco")
        {
            choco++;
            collision.gameObject.SetActive(false);
            choco_text.text = choco.ToString();
            source.PlayOneShot(pickup_clip);
        }
        if(collision.gameObject.tag == "damage")
        {
            slider.value -= 5;
            health -= 5;
            health_text.text = health.ToString();
            source.PlayOneShot(damage_sound);
        }
    }
    void Dead()
    {
        if(slider.value <= 0)
        {
            
            deadPanel.SetActive(true);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Cardidentity : MonoBehaviour
{
    [Header("Buttons")]
    public Button main_target_btn;

    [Header("Images")]
    public Image target_img;
    public Image question_mark_img;

    [Header("INT")]
    [SerializeField] float show_delay=1.5f;

    [SerializeField] private AudioSource click_audio;

    // Start is called before the first frame update
    void Start()
    {
        main_target_btn.onClick.AddListener(_Card_Click);
    }

   public void _Card_Click()
    {
        target_img.gameObject.SetActive(true);
        question_mark_img.gameObject.SetActive(false);
        click_audio.Play();
    }


    private void OnEnable()
    {
        Invoke(nameof(Hide_All_Images), show_delay);
    }

   public void Hide_main_img_after_check()
    {
        Invoke(nameof(Hide_All_Images), 1f);
    }

    void Hide_All_Images()
    {
        main_target_btn.interactable = true;
        target_img.gameObject.SetActive(false);
        question_mark_img.gameObject.SetActive(true);
    }




}//End of the class

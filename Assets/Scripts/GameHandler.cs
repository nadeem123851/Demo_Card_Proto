using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{


    [Header("INT")]
    [SerializeField] private int final_turns_count;
    [SerializeField] private int final_match_count;

    [Header("UI")]
    public GameObject main_menu;
    public GameObject main_grid;
    public Text game_end_text;
    [SerializeField] private Text turns_count_text;
    [SerializeField] private Text match_count_text;

    [SerializeField]private  Button[] buttons;
    [SerializeField] private Button lastClickedButton;
    [SerializeField] private Button currentClickedButton;

    [SerializeField] private AudioSource turn_audio;
    [SerializeField] private AudioSource match_audio;

    private void Start()
    {

    }

    private void OnButtonClick(Button clickedButton)
    {
         lastClickedButton = currentClickedButton;
         currentClickedButton = clickedButton;

        clickedButton.interactable = false;

        if (lastClickedButton != null)
        {
            if (lastClickedButton.name == currentClickedButton.name)
            {
                StartCoroutine(Final_check_match());
            }
            else
            {
               StartCoroutine(Final_check_turn());
            }
        }

        UI_Score_Update();
    }

    private System.Collections.IEnumerator Final_check_turn()
    {
        check_turn(lastClickedButton, currentClickedButton);
        // Simulate some work
        yield return new WaitForEndOfFrame();
        lastClickedButton = null;
        currentClickedButton = null;
    }

    private System.Collections.IEnumerator Final_check_match()
    {
        check_match(lastClickedButton, currentClickedButton);
        // Simulate some work
        yield return new WaitForEndOfFrame();
        lastClickedButton = null;
        currentClickedButton = null;


    }

    private void check_turn(Button lastClickedButton, Button currentClickedButton)
    {
        lastClickedButton.GetComponent<Cardidentity>().Hide_main_img_after_check();
        currentClickedButton.GetComponent<Cardidentity>().Hide_main_img_after_check();
        final_turns_count++;

        turn_audio.Play();

        // No need to nullify the buttons here since they are local variables
    }

    private void check_match(Button lastClickedButton, Button currentClickedButton)
    {      
        Destroy(lastClickedButton.gameObject, 0.3f);
        Destroy(currentClickedButton.gameObject, 0.3f);

        final_match_count++;
        final_turns_count++;

        match_audio.Play();
    }

    public void UI_Score_Update()
    {
        match_count_text.text = final_match_count.ToString();
        turns_count_text.text = final_turns_count.ToString();
    }

    // Restart Scene
    public void _Load_Scene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }


    public void Start_btn_Click()
    {
        main_menu.SetActive(false);
        main_grid.SetActive(true);

        buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }


}//End of the Class

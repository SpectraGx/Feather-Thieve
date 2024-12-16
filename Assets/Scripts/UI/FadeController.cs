using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private Menu menuController;

    [Header("Animations")]
    private Animator animator;
    private string currentState;
    const string Fade_In = "fade_in";
    const string Fade_Out = "fade_out";

    private void Start()
    {
        animator = GetComponent<Animator>();
        FadeIn();
    }

    public void FadeIn()
    {
        ChangeAnimationState(Fade_In);
    }

    public void FadeOut()
    {
        ChangeAnimationState(Fade_Out);
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }

    public void CloseTitlePanel()
    {
        gameObject.SetActive(false);
        menuController.OpenPanel(menuController.mainMenu);
    }

}

using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Build;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private bool isPressingUp = false;
    private bool isPressingDown = false;
    private bool isPressingLeft = false;
    private bool isPressingRight = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimation();
    }

    void SetAnimation()
    {

        if (FindObjectOfType<GameOver>().gameOver == true)
        {
            animator.SetBool("GameOver", true);
            animator.SetBool("isFacingUp", false);
            animator.SetBool("isFacingDown", false);
            animator.SetBool("isFacingLeft", false);
            animator.SetBool("isFacingRight", false);
            return;
        }
        else
        {        
            isPressingUp = Input.GetKeyDown(KeyCode.W);
            isPressingDown = Input.GetKeyDown(KeyCode.S);
            isPressingLeft = Input.GetKeyDown(KeyCode.A);
            isPressingRight = Input.GetKeyDown(KeyCode.D);

            animator.SetBool("isFacingUp", isPressingUp);
            animator.SetBool("isFacingDown", isPressingDown);
            animator.SetBool("isFacingLeft", isPressingLeft);
            animator.SetBool("isFacingRight", isPressingRight);
        }
    }
}

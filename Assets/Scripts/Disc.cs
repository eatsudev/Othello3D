using UnityEngine;

public class Disc : MonoBehaviour
{
    [SerializeField] private Player up;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Flip()
    {
        if (up == Player.Black)
        {
            animator.Play("BlacktoWhite");
            up = Player.White;
        }
        else
        {
            animator.Play("WhitetoBlack");
            up = Player.Black;
        }
    }
}

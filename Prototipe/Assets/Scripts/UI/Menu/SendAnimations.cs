using UnityEngine;

public class SendAnimations : MonoBehaviour
{
    [SerializeField] private Animator menuAnimator;

    public void SetBoatAnimation()
    {
        menuAnimator.SetBool("EnterGame", true);
    }
}

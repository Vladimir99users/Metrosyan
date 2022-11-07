using UnityEngine;

public class AnimationChest : MonoBehaviour
{
    [SerializeField] private Animator _animator => GetComponent<Animator>();

    
    public void OpenChest()
    {
        _animator.SetBool("OpenChest",true);
        
    }

}

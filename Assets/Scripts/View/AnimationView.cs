using UnityEngine;

[RequireComponent(typeof(Animation))]
public class AnimationView : MonoBehaviour
{
    private Animation _animation;
    private Character _characterModel;

    // Start is called before the first frame update
    void Awake()
    {
        _animation = GetComponent<Animation>();
    }

    private void Play(string animName)
    {
        _animation.Play(animName);
    }

    public void Subscribe(Character character)
    {
        character.onAnimationPlay += Play;
        _characterModel = character;
    }

    public void OnDestroy()
    {
        _characterModel.onAnimationPlay -= Play;
    }
}

using UnityEngine;


public class ModifyEffector : MonoBehaviour
{
    [SerializeField] private Modify _modify;
    [SerializeField] private ParticleSystem _particleSystem;

    private void OnEnable()
    {
        _modify.ModifyActived += PlayEffect;
    }

    private void OnDisable()
    {
        _modify.ModifyActived -= PlayEffect;
    }

    private void PlayEffect()
    {
        _particleSystem.Play();
    }
}
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ModifyEffector))]
public abstract class Modify : MonoBehaviour
{
    [SerializeField] private float _cooldown;

    private WaitForSeconds _cooldownWait;
    private bool _cauUse;

    protected KeyCode _key;

    public event Action ModifyActived;

    protected virtual void Awake() 
    { 
        _cooldownWait = new WaitForSeconds(_cooldown);
        _cauUse = true;
    }

    protected virtual void Update()
    {
        if (_cauUse && Input.GetKeyDown(_key))
        {
            Debug.Log("used");
            Use();
            _cauUse = false;
            ModifyActived?.Invoke();

            StartCoroutine(StartCooldown());
        }
    }

    private IEnumerator StartCooldown()
    {
        yield return _cooldownWait;

        _cauUse = true;
    }

    protected abstract void Use();
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DurabilityDecreaser : MonoBehaviour
{
    [SerializeField] private int _decreaseAmount = 2;

    [SerializeField] private float _decreaseDelay = 1;

    private float _minDecreaseDelay = 0.1f;
    
    private WaitForSeconds _decreaseWait;
    private List<Coroutine> _coroutines = new List<Coroutine>();

    private Dictionary<Durability, Coroutine> _decreases = new Dictionary<Durability, Coroutine>();

    private void OnDisable()
    {
        foreach(Durability durability in _decreases.Keys)
        {
            if(_decreases[durability] != null)
            {
                StopCoroutine(_decreases[durability]);
                _decreases.Remove(durability);
            }
        }
    }

    private void Awake()
    {
        _decreaseWait = new WaitForSeconds(_decreaseDelay);
    }

    private IEnumerator Decrease(Durability durability)
    {
        while (enabled)
        {
            yield return _decreaseWait;

            durability.DecreaseAmount(_decreaseAmount);
        }
    }

    public void StartDecrease(Durability durability)
    {
        Coroutine newCoroutine = _coroutines.FirstOrDefault(coroutine => coroutine == null);

        newCoroutine = StartCoroutine(Decrease(durability));
        _decreases.Add(durability, newCoroutine);
    }

    public void StopDecrease(Durability durability)
    {
        Coroutine coroutine = _decreases[durability];

        StopCoroutine(coroutine);
        _decreases.Remove(durability);
        coroutine = null;
    }

    public void IncreaseDurability(int amount)
    {
        if(amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        _decreaseAmount += amount;
    }

    public void DecreaseDelay(float amount)
    {
        _decreaseDelay = Mathf.Max(_decreaseDelay - amount, _minDecreaseDelay);
    }
}
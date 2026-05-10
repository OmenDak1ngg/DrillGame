using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DurabilityDecreaser : MonoBehaviour
{
    [SerializeField] private int _decreaseAmount = 2;

    [SerializeField] private float _decreaseDelay = 1;

    private WaitForSeconds _decreaseWait;
    private List<Coroutine> _coroutines = new List<Coroutine>();

    private Dictionary<Durability, Coroutine> _decreases = new Dictionary<Durability, Coroutine>();

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
}
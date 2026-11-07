using UnityEngine;

public class SplashJump : Modify
{
    [SerializeField] private OreTracker _oreTracker;
    
    [SerializeField] private float _splashRadius = 3f;
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _layerMask;

    protected override void Awake()
    { 
        base.Awake();
        _key = KeyCode.Space;
    }

    protected override void Use()
    {
        var ores = Physics.OverlapSphere(transform.position, _splashRadius, _layerMask);
        Debug.Log("used");
        if(ores.Length != 0)
        {
            foreach(var ore in ores)
            {
                if (_oreTracker.IsCollected(ore.GetComponent<Ore>()))
                    continue;

                ore.GetComponent<Durability>().DecreaseAmount(_damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        
        Gizmos.DrawWireSphere(transform.position,_splashRadius);
    }
}
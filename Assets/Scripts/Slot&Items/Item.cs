using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ModifyTypes _type;

    public ModifyTypes Type => _type;
}
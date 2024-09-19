using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public bool notDiscovered = true;
    public GameObject symbol;
    public GameObject description;

    public GameObject player;

    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private Transform  _interactionPoint;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numfound;

    void Start()
    {
        description.SetActive(false);
    }

    void Update()
    {
        _numfound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);
        if (notDiscovered == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                symbol.SetActive(false);
                description.SetActive(true);
                notDiscovered = false;
            }
            
        } else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                description.SetActive(false);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}

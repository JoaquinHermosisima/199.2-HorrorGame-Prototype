using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    [SerializeField] GameObject prompt;
    public bool notDiscovered = true;
    public GameObject symbol;
    public GameObject description;

    public GameObject player;

    [SerializeField] private float _interactionPointRadius = 1.7f;
    [SerializeField] private Transform  _interactionPoint;
    [SerializeField] private LayerMask _interactableMask;

    [SerializeField] private GameObject notebook;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numfound;

    void Start()
    {
        description.SetActive(false);
        prompt.SetActive(false);
    }

    void Update()
    {
        float distance = (_interactionPoint.position - player.transform.position).magnitude;
        _numfound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);
        
        if (notDiscovered == true && (distance <= _interactionPointRadius))
        {
            prompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                symbol.SetActive(false);
                description.SetActive(true);
                notDiscovered = false;
                notebook.SetActive(true);
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

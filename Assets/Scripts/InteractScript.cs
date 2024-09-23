using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public bool notDiscovered = true;
    public GameObject symbol;

    public GameObject player;


    [SerializeField] private float _interactionPointRadius = 1.7f;
    [SerializeField] private Transform  _interactionPoint;
    [SerializeField] private LayerMask _interactableMask;

    [SerializeField] private GameObject notebook;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numfound;

    void Start()
    {

    }

    void Update()
    {
        float distance = (_interactionPoint.position - player.transform.position).magnitude;
        _numfound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);
        
        if (notDiscovered == true && (distance <= _interactionPointRadius))
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                symbol.SetActive(false);
                notebook.SetActive(true);
                notDiscovered = false;
                //StartCoroutine(DestroyCanvas());
            }
            
        }

        

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }

    IEnumerator DestroyCanvas()
    {
        yield return new WaitForSeconds(5);
    }
}

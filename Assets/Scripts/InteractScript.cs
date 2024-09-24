using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public bool notDiscovered = true;
    public bool collide = false;
    public GameObject symbol;

    public GameObject player;


    [SerializeField] private float _interactionPointRadius = 2f;
    [SerializeField] private Transform  _interactionPoint;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] public GameObject showPressX;
    [SerializeField] private GameObject notebook;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numfound;

    void Start()
    {
        showPressX.SetActive(false);
    }

    void Update()
    {
        float distance = (_interactionPoint.position - player.transform.position).magnitude;
        _numfound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

        if (notDiscovered == true && (distance <= _interactionPointRadius))
        {
            showPressX.SetActive(true);
            //collide = true;
            if (Input.GetKeyDown(KeyCode.X))
            {
                //collide = false;
                symbol.SetActive(false);
                notebook.SetActive(true);
                notDiscovered = false;
                //StartCoroutine(DestroyCanvas());
            }
        } else
        {
            showPressX.SetActive(false);
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

    public bool getCollide()
    {
        return collide;
    }
}

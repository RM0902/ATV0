using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;
    private Vector2 input;

    private Animator animator;

    public LayerMask solidOjectsLayer;
    public LayerMask interactuablesLayer;
    public LayerMask battleLayer;


    private void Awake()
    {
        animator =GetComponent<Animator>();
    }

    public void HandleUpdate()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

        



            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x +=input.x;
                targetPos.y +=input.y;

                if(IsWalkable(targetPos))

                StartCoroutine(Move(targetPos));
            }

        }

        animator.SetBool("isMoving", isMoving);


        if (Input.GetKeyDown(KeyCode.Z))
            Interact();

        
    }

    void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactuablesLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
            
        }
        
    }
        




    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        
        transform.position = targetPos;
        isMoving = false;

        CheckForEncounters();
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.0f, solidOjectsLayer | interactuablesLayer) != null)
        {
            return false;
        }

        return true;
    }

    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.01f, battleLayer) != null)
        {
            if (Random.Range(1,100) <= 50)
            {
                Debug.Log("La batalla comienzaa");
            }
            
        }

    }
}

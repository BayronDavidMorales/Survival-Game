using StarterAssets;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class BasicRigidBodyPush : MonoBehaviour
{
    public AudioSource  drag;
    public Animator     animator;
    public ThirdPersonController thirdPersonController;


    public LayerMask pushLayers;
	public bool canPush = true;

	[Range(0.5f, 5f)] public float strength = 1.1f;


    private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (canPush) PushRigidBodies(hit);
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (canPush)
        {
            PlayPush(collision);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (canPush)
        {
            PlayPush(collision);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        StopPush(collision);
    }

    private void PushRigidBodies(ControllerColliderHit hit)
    {
        // https://docs.unity3d.com/ScriptReference/CharacterController.OnControllerColliderHit.html
        // make sure we hit a non kinematic rigidbody
        
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null) return;

        // make sure we only push desired layer(s)
        var bodyLayerMask = 1 << body.gameObject.layer;
        if ((bodyLayerMask & pushLayers.value) == 0) return;


        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3f) return;

        // Calculate push direction from move direction, horizontal motion only
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0.0f, hit.moveDirection.z);

        // Apply the push and take strength into account
        body.AddForce(pushDir * strength, ForceMode.Impulse);
    }

    private void PlayPush(Collision collision)
    {
        animator.SetBool("Push", true);
        thirdPersonController.MoveSpeed = 1.0f;
        thirdPersonController.SprintSpeed = 1.0f;
        drag.Play();
    }

    private void StopPush(Collision collision)
    {
        animator.SetBool("Push", false);
        thirdPersonController.MoveSpeed = 2.0f;
        thirdPersonController.SprintSpeed = 5.335f;
        drag.Pause();
    }
}
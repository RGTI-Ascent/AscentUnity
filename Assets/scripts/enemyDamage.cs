using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Hit: " + other.gameObject.name);
        
        playerScript player = other.GetComponent<playerScript>();
        if(player == null) {
            player = other.GetComponentInParent<playerScript>();
        }
        
        if(player != null) {
            Rigidbody playerBody = other.GetComponent<Rigidbody>();
            if(playerBody == null) {
                playerBody = other.GetComponentInParent<Rigidbody>();
            }
            
            if(playerBody != null && playerBody.linearVelocity.y < 0) {
                player.StompJump();
                PlayDeathAnimation();
            } else {
                player.TakeDamage();
            }
        } else {
            Debug.Log("playerScript not found");
        }
    }

    void PlayDeathAnimation() {
        Debug.Log("Enemy Death");
        GetComponentInChildren<Animator>().SetTrigger("Death");
        Destroy(gameObject, 0.2f);
    }
}
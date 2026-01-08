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
            
            // check if player is falling onto enemy
            if(playerBody != null && playerBody.linearVelocity.y < 0) {
                player.StompJump();
                Destroy(gameObject); 
            } else {
                player.TakeDamage();
            }
        } else {
            Debug.Log("playerScript not found");
        }
    }
}
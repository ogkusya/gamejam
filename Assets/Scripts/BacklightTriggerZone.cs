using UnityEngine;

public class BacklightTriggerZone : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "DamageGround")
        {
            this.transform.position = new Vector3 (PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"), PlayerPrefs.GetFloat("zPos"));
        }
        if (other.tag == "Respawn")
        {
            PlayerPrefs.SetFloat("xPos",transform.position.x);
            PlayerPrefs.SetFloat("yPos",transform.position.y);
            PlayerPrefs.SetFloat("zPos",transform.position.z);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Platform"))
        { 
            this.transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Platform"))
        {
            this.transform.parent = null;
        }
    }
}

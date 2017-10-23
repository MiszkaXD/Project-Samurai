using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMove : MonoBehaviour{


	public ActionMove()
    {

    }

    public void MoveLogic() { } // Zostawiam to na razię puste by program się miejscami nie sypał gdzie nie przyjmuje funkcja żadnych wartości

    public void MoveLogic(Vector3 target, Vector3 position)
    {
            Vector3 throwSpeed = calculateBestThrowSpeed(position, target, 2f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.DrawRay(ray.origin, hit.point);
            }
            this.GetComponent<Animation>().Play("walk_1");
            
            GetComponent<Rigidbody2D>().AddForce(throwSpeed, ForceMode2D.Impulse); 
            
            Debug.Log("Move");
    }

    public Vector3 calculateBestThrowSpeed(Vector3 origin, Vector3 target, float timeToTarget)
    {
        Vector3 toTarget = target - origin;
        Vector3 toTargetXZ = toTarget;
        toTargetXZ.y = 0;

        float y = toTarget.y;
        float xz = toTargetXZ.magnitude;

        float t = timeToTarget;
        float v0y = y / t + 0.5f * Physics.gravity.magnitude * t;
        float v0xz = xz / t;

        Vector3 result = toTargetXZ.normalized;      
        result *= v0xz;                                
        result.y = v0y;                               

        return result;
    }
}

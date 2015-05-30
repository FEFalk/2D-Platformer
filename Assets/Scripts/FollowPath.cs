using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FollowPath : MonoBehaviour
{
    public enum FollowType
    {
        MoveTowards,
        Lerp
    }

    public FollowType Type = FollowType.MoveTowards;
    public PathDefinition Path;
    public float Speed = 1;
    public float MaxDistanceToGoal = .1f;

    private IEnumerator<Transform> _currentPoint;
    private GameObject player;
    private GameObject gun;
    
    public void Start()
    {
        player = GameObject.Find("Player");
        gun = GameObject.Find("Pikkadoll");

        if (Path == null)
        {
            Debug.LogError("Path is null", gameObject);
            return;
        }

        _currentPoint = Path.GetPathEnumerator();
        _currentPoint.MoveNext();

        if (_currentPoint.Current == null)
            return;

        transform.position = _currentPoint.Current.position;

    }

    public void Update()
    {
        if (_currentPoint == null || _currentPoint.Current == null)
            return;

        if (Type == FollowType.MoveTowards)
            transform.position = Vector3.MoveTowards(transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);
        else if (Type == FollowType.Lerp)
            transform.position = Vector3.Lerp(transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);

        var distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;
        if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
            _currentPoint.MoveNext();
    }

    //If character collides with the platform, make it its child.
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (player.GetComponent<UnityStandardAssets.CrossPlatformInput.PlayerController>().isMoving == true)
                coll.gameObject.transform.parent = null;

            else
                coll.gameObject.transform.parent = this.gameObject.transform;
        }
        else
            coll.gameObject.transform.parent = this.gameObject.transform;

        
    }
    //Once it leaves the platform, become a normal object again.
    void OnCollisionExit2D(Collision2D coll)
    {
        coll.gameObject.transform.parent = null;
    }
}

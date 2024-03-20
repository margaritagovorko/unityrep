using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	[SerializeField] private string _horizontalAxicName;
	[SerializeField] private string _verticalAxicName;
	

	[SerializeField] private float _speed = 1f;

	[SerializeField] private Rigidbody2D _rigidbody2D;
	
	
	// Start is called before the first frame update
    void Start()
    {
	    _rigidbody2D = GetComponent<Rigidbody2D>();
		print(message:"Hello from the start");
    }

    // Update is called once per frame
    void Update()
    {
	    float xAxis = Input.GetAxis(_horizontalAxicName);
	    float yAxis = Input.GetAxis(_verticalAxicName);

	    _rigidbody2D.velocity = new Vector2(xAxis, yAxis) * _speed;
	    
    }
}

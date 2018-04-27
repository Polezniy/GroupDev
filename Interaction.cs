using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
	public Transform _stoneSpawn; //Stone spawn position in rockpile
    public Transform _throwSpawn; //throwing start point
	public GameObject inv; //position of inventory
	public bool carying; //flag to indicate if object is picked up
	public Rigidbody rockPrefab;//rock
	public Image imgPrefab;//image of rock
    public float force;//use the force Luke
    public GameObject empty;
	public Camera c;

	private GameObject player;
    private GameObject rockpile;
	private Image imgInst;
	private Rigidbody rockInst;
    private bool _spawned;



    // Use this for initialization
    void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
        rockpile = GameObject.FindGameObjectWithTag("RockPile");
        
        carying = false;
        _spawned = false;

		c = Camera.main;
	}

	// Update is called once per frame
	void Update ()
	{
        // Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);

		//Vector3 mousePos = c.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, (c.pixelHeight - Input.mousePosition.y), c.nearClipPlane));

		//Debug.Log (mousePos);

		//Vector3 mousePos = new Vector3(Input.mousePosition.x,Input.mousePosition.y, 0);
        //Debug.Log(mousePos);
       // empty.GetComponent<Transform>().position = mousePos;

		if (rockpile)
		{
			float _rockpileDist = Vector3.Distance(rockpile.GetComponent<Transform>().position, player.GetComponent<Transform>().position); //distance between player and rockpile

			if (Input.GetKeyDown(KeyCode.E) && _spawned == false && _rockpileDist < 1.2f) 
			{
				_spawned = true;
				rockInst = Instantiate(rockPrefab, _stoneSpawn.position, _stoneSpawn.rotation) as Rigidbody;
			}


			if (Input.GetKeyDown(KeyCode.E) && carying == false && _spawned == true)
			{
				float _rockDist = Vector3.Distance(GameObject.FindGameObjectWithTag("Rock").GetComponent<Transform>().position, player.GetComponent<Transform>().position);//distance between player and stone

				if (_rockDist < 1.4f)//picked up stone
				{

					Destroy(GameObject.FindGameObjectWithTag("Rock"));

					carying = true;//flag

					//creating icon of rock in the inventory window

					//imgInst = Instantiate (imgPrefab, inv.transform.position, inv.transform.rotation);
					//imgInst.transform.SetParent (inv.transform);
					//imgInst.transform.localScale = new Vector3 (1f, 1f, 0.5f);
				}
				else if (_rockpileDist < 1.2f)
				{
					Destroy(GameObject.FindGameObjectWithTag("Rock"));
					carying = true;
				}
			}

			if (Input.GetMouseButtonDown (1) && carying)
			{

				// Debug.Log(empty.transform.position);

				rockInst = Instantiate(rockPrefab, _throwSpawn.position, _throwSpawn.rotation) as Rigidbody;

				//force = Vector2.Distance(_throwSpawn.position, );

				//Debug.Log(Vector2.Distance(_throwSpawn.position, mousePos));

				rockInst.AddForce(transform.forward * 300);//THROWING
				rockInst.AddForce(transform.up * 400);//THROWING
				//rockInst.AddForce(_throwSpawn.forward * force);//THROWING

				//imgInst.transform.SetParent (null); //inventory
				Destroy(GameObject.FindGameObjectWithTag("RockUI"));
				carying = false;

			}
		}
	}

}

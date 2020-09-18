using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10; // meters/second
    private float turnSpeed = 50; 
    private float horizontalInput;
    private float forwardInput;
    private int count = 0; // count of frame number for debug output...

    // Arrow Function Format of ToString()...
    // public override string ToString() => GetType().FullName;

    public override string ToString()
    {
        return GetType().FullName;
    }

    public string ToString(MethodBase m)
    {
        // return GetType().FullName;
        // MethodBase m = MethodBase.GetCurrentMethod();
        // Console.WriteLine("Executing {0}.{1}",
        //                  m.ReflectedType.Name, m.Name);
        return ($"{m.ReflectedType.Name}.{m.Name}");
    }

    

    /**
    * @see https://docs.unity3d.com/ScriptReference/Debug.Log.html
    */
    PlayerController() {
        this.count = 0;

        // Debug.Log("PlayerController::PlayerController() -- constructor -- I'll be back, Bennett!");
        Debug.Log($" {ToString(MethodBase.GetCurrentMethod())} -- I'll be back, Bennett!");

        Debug.Log($" {ToString(MethodBase.GetCurrentMethod())} -- this.speed = {this.speed} meters/second...");
        Debug.Log($" {ToString(MethodBase.GetCurrentMethod())} -- this.turnSpeed = {this.turnSpeed} meters/second...");
    }

    ~PlayerController() {
        Debug.Log($" {ToString(MethodBase.GetCurrentMethod())} -- Let off some steam, Bennett!");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame...50-60 times per second...1/50-1/60 seconds per frame...0.02-0.01666 seconds per frame...
    void Update()
    {
        this.count++;

        // Get player input:
        // Procure horizontalInput and forwardInput from Input manager
        // See Horizontal and Vertical in Edit | Project Settings | Input 
        this.horizontalInput = Input.GetAxis("Horizontal");
        this.forwardInput = Input.GetAxis("Vertical");

        // Move the vehicle forward...
        this.transform.Translate(Vector3.forward * Time.deltaTime * this.speed * this.forwardInput );
        
        // Rotate about the y-axis or about the Vector3.up axis...
        this.transform.Rotate(Vector3.up, Time.deltaTime * this.turnSpeed * this.horizontalInput);

        // 1 meter * 1 / 50 seconds per frame = 1/50 meter/frame; 1/50 meters/frame * 50 frames/second = 1 meter/second
        Debug.Log($"{ToString(MethodBase.GetCurrentMethod())}: {this.count}: Time.time = {Time.time}:\n" +
            $"Time.deltaTime = {Time.deltaTime}, this.transform.position = {this.transform.position}..."
        );
    }

}
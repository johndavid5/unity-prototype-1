using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f; // meters/second
    public float turnSpeed = 10.0f; 
    public float horizontalInput;

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

    public int count;

    /**
    * @see https://docs.unity3d.com/ScriptReference/Debug.Log.html
    */
    PlayerController() {
        this.count = 0;

        // Debug.Log("PlayerController::PlayerController() -- constructor -- I'll be back, Bennett!");
        Debug.Log($" {ToString(MethodBase.GetCurrentMethod())} -- I'll be back, Bennett!");

        Debug.Log($" {ToString(MethodBase.GetCurrentMethod())} -- this.speed = ${this.speed} meters/second...");
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
        // Procure horizontalInput from Input manager...see Horizontal in Edit | Project Settings | Input 
        this.horizontalInput = Input.GetAxis("Horizontal");

        // Move the vehicle forward...
        this.count++;
        this.transform.Translate(Vector3.forward * Time.deltaTime * this.speed );
        this.transform.Translate(Vector3.right * Time.deltaTime * this.turnSpeed * this.horizontalInput);

        // 1 meter * 1 / 50 seconds per frame = 1/50 meter/frame; 1/50 meters/frame * 50 frames/second = 1 meter/second
        Debug.Log($"{ToString(MethodBase.GetCurrentMethod())}: {this.count}: Time.time = {Time.time}:\n" +
            $"this.turnSpeed * this.horizontalInput = {this.turnSpeed * this.horizontalInput}\n" +
            $"Time.deltaTime = {Time.deltaTime},\n" +
            $"this.transform.position = {this.transform.position}..." );
    }

}
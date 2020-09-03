using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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

        // Message with a GameObject name.
        // Debug.Log("Hello: " + gameObject.name);
        // NOTE: Console.WriteLine() doesn't appear in the Unity console...
        // Console.WriteLine($"The {ToString()} constructor is executing.");
        this.count = 0;

        // Debug.Log("PlayerController::PlayerController() -- constructor -- I'll be back, Bennett!");
        Debug.Log($" {ToString(MethodBase.GetCurrentMethod())} -- I'll be back, Bennett!");
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
        // Move the vehicle forward...
        this.count++;
        int v_meters_per_second = 20;        
        this.transform.Translate(Vector3.forward * Time.deltaTime * v_meters_per_second );
        // 1 meter * 1 / 50 seconds per frame = 1/50 meter/frame; 1/50 meters/frame * 50 frames/second = 1 meter/second
        Debug.Log($"{ToString(MethodBase.GetCurrentMethod())}: {this.count}: Time.time = {Time.time}: Move the vehicle forward, Time.deltaTime = {Time.deltaTime}, transform.position = {transform.position}..." );
    }

}
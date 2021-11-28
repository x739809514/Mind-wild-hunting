using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification
{
    public GameObject sender;
    public EventArgs param;
    public string message;
    public Notification()
    {
        
    }

    public Notification(GameObject sender, EventArgs param)
    {
        this.sender = sender;
        this.param = param;
    }

    public Notification(EventArgs param)
    {
        this.sender = null;
        this.param = param;
    }

    public Notification(string msg)
    {
        this.message = msg;
    }
    public Notification(GameObject sender,string msg)
    {
        this.sender = sender;
        this.message = msg;
    }
}

public class EventArgsTest:EventArgs
{
    public GameObject sender;
    public string msg;

    public EventArgsTest(string msg)
    {
        this.msg = msg;
    }

    public EventArgsTest(GameObject obj, string msg)
    {
        this.sender = obj;
        this.msg = msg;
    }
}

using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System;
using System.IO;
using System.Text;


public class UDP_left: MonoBehaviour
{

    // Use this for initialization
    TcpListener listener;
    String msg;
    private Animator Anim;

    void Start()
    {
        listener = new TcpListener(55002);
        listener.Start();
        print("is listening");
    }
    // Update is called once per frame
    void Awake()
    {
        Anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (!listener.Pending())
        {
        }
        else
        {
            print("socket comes");
            TcpClient client = listener.AcceptTcpClient();
            NetworkStream ns = client.GetStream();
            StreamReader reader = new StreamReader(ns);
            msg = reader.ReadToEnd();
            if (msg[0] == '2')
            {
                Anim.SetBool("BoolRighthand", true);
                print(msg);
            }

            else
            {
                print("´«Êä´íÎó");
            }

        }
    }
}
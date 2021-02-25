using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;

//  Author: Schulte Marc-Rafael
//  Created: 25.02.2021
//  Last Change: 25.02.2021
//  Description: Hosting the Server, managing the communication between two clients

namespace Server
{
    class Program
    {
        private static int playerCounter;
        private static Dictionary<int, Socket> socketList;

        private delegate void NewPlayerThread();
        private static NewPlayerThread newPlayerThreadPointer;

        private static IPHostEntry host;
        private static IPAddress ipAdress;
        private static IPEndPoint endPoint;
        private static Socket listenerSocket;
        

        static void Main(string[] args)
        {
            Console.WriteLine("Server-Setup started...");
            setup();
            Console.WriteLine("Server is starting...");
            startServer();
            
        }

        private static void setup()
        {
            playerCounter = 1;
            socketList = new Dictionary<int, Socket>();
            newPlayerThreadPointer = new NewPlayerThread(communicationThread);

            ipAdress = IPAddress.Parse("192.168.178.39");
            endPoint = new IPEndPoint(ipAdress, 11000);
            listenerSocket = new Socket(ipAdress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listenerSocket.Bind(endPoint);
        }

        private static void startServer()
        {
            try
            {
                Console.WriteLine("Server is running...");
                Console.WriteLine("Waiting for a Player to connect...");

                while (true)
                {
                    if (playerCounter == 2)
                    {
                        startGame();
                        break;
                    }

                    listenerSocket.Listen(10);
                    Socket clientSocket = listenerSocket.Accept();
                    Console.WriteLine("A Player connected to the Server");
                    Thread newPlayer_thread = new Thread(newPlayerThreadPointer.Invoke);
                    newPlayer_thread.Name = playerCounter.ToString();
                    socketList.Add(playerCounter, clientSocket);
                    newPlayer_thread.Start();
                    playerCounter++;                    
                }



            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void communicationThread()
        {
            try
            {
                string data = null;
                byte[] bytes = null;

                int player_id = Convert.ToInt32(Thread.CurrentThread.Name);
                Socket playerSocket = null;

                socketList.TryGetValue(player_id, out playerSocket);

                playerSocket.Send(Encoding.ASCII.GetBytes("[SETUP]" + player_id.ToString() + ";")); // First message with information for client

                while(true)
                {
                    while (true)
                    {
                        bytes = new byte[1024];
                        int recievedBytes = playerSocket.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, recievedBytes);

                        if (data.Contains("[MOVE]"))
                        {

                            break;
                        }
                        else
                        if (data.Contains(""))
                        {

                            break;
                        }
                    }

                    data = "";
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void startGame()
        {
            //Sending message to start the game
        }
    }
}

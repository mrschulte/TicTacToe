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

        private static List<int> boxes1;
        private static List<int> boxes2;


        static void Main(string[] args)
        {
            setup();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Server-Setup started...");
                Console.WriteLine("Server is starting...");
                startServer();
            }
            
        }

        private static void setup()
        {
            playerCounter = 1;
            boxes1 = new List<int>();
            boxes2 = new List<int>();
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
                    if (playerCounter == 3)
                    {
                        Console.WriteLine("Game is starting");
                        while(listenerSocket.Connected)
                        {

                        }
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
                    
                    if(playerCounter == 3)
                    {
                        Console.WriteLine("Game is starting");
                        while(playerCounter == 3)
                        {

                        }
                        break;
                    }
                }



            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void sendToAll(string message)
        {
            try
            {
                for (int i = 1; i < 3; i++)
                {
                    Socket player = null;
                    socketList.TryGetValue(i, out player);
                    player.Send(Encoding.ASCII.GetBytes(message));
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

                playerSocket.Send(Encoding.ASCII.GetBytes(player_id.ToString() + "[SETUP]")); // First message with information for client

                while(true)
                {
                    while (true)
                    {
                        bytes = new byte[1024];
                        int recievedBytes = playerSocket.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, recievedBytes);

                        if(data.Contains("[READY]"))
                        {
                            sendToAll("[START]");
                            break;
                        }
                        else
                        if (data.Contains("[MOVE]"))
                        {
                            int box = Convert.ToInt32(data[0].ToString());
                            int player = Convert.ToInt32(data[2].ToString());

                            Console.WriteLine("Spieler: " + player + " hat Feld " + box + " geklickt");
                            if (checkIfWin(box, player))
                            {
                                sendToAll("[WIN]" + player + ";" + box + "[MOVE]");
                            }
                            else
                            {
                                Console.WriteLine("kein win");
                                string msg = "";
                                if((boxes1.Count + boxes2.Count) == 9)
                                {
                                    msg = "[NOWIN]" + player + ";" + box + "[MOVE]";
                                }
                                else
                                {
                                    msg = player + ";" + box + "[MOVE]";
                                }
                                sendToAll(msg);
                                Console.WriteLine("gesendet");
                            }

                            break;
                        }
                        else
                        if(data.Contains("[RESTART]"))
                        {
                            playerCounter = 1;
                            boxes1.Clear();
                            boxes2.Clear();
                            break;
                        }
                    }

                    Console.WriteLine(data);
                    data = "";
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static bool checkIfWin(int box, int player)
        {
            if(player == 1)
            {
                boxes1.Add(box);

                if( boxes1.Contains(1) && boxes1.Contains(2) && boxes1.Contains(3) )
                {
                    return true;
                }
                else
                if( boxes1.Contains(4) && boxes1.Contains(5) && boxes1.Contains(6) )
                {
                    return true;
                }
                else
                if( boxes1.Contains(7) && boxes1.Contains(8) && boxes1.Contains(9) )
                {
                    return true;
                }
                else
                if( boxes1.Contains(1) && boxes1.Contains(4) && boxes1.Contains(7) )
                {
                    return true;
                }
                else
                if( boxes1.Contains(2) && boxes1.Contains(5) && boxes1.Contains(8) )
                {
                    return true;
                }
                else
                if( boxes1.Contains(3) && boxes1.Contains(6) && boxes1.Contains(9) )
                {
                    return true;
                }
                else
                if( boxes1.Contains(1) && boxes1.Contains(5) && boxes1.Contains(9) )
                {
                    return true;
                }
                else
                if( boxes1.Contains(3) && boxes1.Contains(5) && boxes1.Contains(7) )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                boxes2.Add(box);

                if (boxes2.Contains(1) && boxes2.Contains(2) && boxes2.Contains(3))
                {
                    return true;
                }
                else
                if (boxes2.Contains(4) && boxes2.Contains(5) && boxes2.Contains(6))
                {
                    return true;
                }
                else
                if (boxes2.Contains(7) && boxes2.Contains(8) && boxes2.Contains(9))
                {
                    return true;
                }
                else
                if (boxes2.Contains(1) && boxes2.Contains(4) && boxes2.Contains(7))
                {
                    return true;
                }
                else
                if (boxes2.Contains(2) && boxes2.Contains(5) && boxes2.Contains(8))
                {
                    return true;
                }
                else
                if (boxes2.Contains(3) && boxes2.Contains(6) && boxes2.Contains(9))
                {
                    return true;
                }
                else
                if (boxes2.Contains(1) && boxes2.Contains(5) && boxes2.Contains(9))
                {
                    return true;
                }
                else
                if (boxes2.Contains(3) && boxes2.Contains(5) && boxes2.Contains(7))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}

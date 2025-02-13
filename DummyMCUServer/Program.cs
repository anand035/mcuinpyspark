using System;
using System.Net.Sockets;
using System.Text;

namespace DummyMCUServer // Note: actual namespace depends on the project name.
{
  internal class Program
  {
      static void Main(string[] args)
      {
          // Create an instance of McuModel
          McuModel model = new McuModel();
  
          // Initialize a TCP listener on port 5678
          var listener = new TcpListener(System.Net.IPAddress.Any, 5678);
          listener.Start(); // Start the listener
          while(true)
          {
              Console.WriteLine("Waiting for connection");
              var client = listener.AcceptTcpClient(); // Accept incoming client connection
              Console.WriteLine("Client accepted");
              var stream = client.GetStream(); // Get the network stream for reading and writing
              var sr = new StreamReader(stream); // StreamReader for reading from the stream
              var sw = new StreamWriter(stream); // StreamWriter for writing to the stream
  
              try
              {
                  // Buffer to store incoming data
                  byte[] buffer = new byte[1024];
                  var bytesRead = stream.Read(buffer, 0, buffer.Length); // Read data from the stream into the buffer
                  int recv = 0; // Variable to count non-zero bytes
                  foreach (byte b in buffer)
                  {
                      if(b != 0)
                      {
                          recv++; // Count non-zero bytes
                      }
                  }
  
                  // Convert the received bytes to a string
                  var hero = Encoding.UTF8.GetString(buffer, 0, recv).TrimEnd();
                  var power = model.GetPower(hero); // Get the power of the hero from the model
                  Console.WriteLine("request received: " + hero);
                  sw.WriteLine($"{hero} => {power}"); // Send the response back to the client
                  sw.Flush(); // Flush the StreamWriter to ensure data is sent
              }
              catch (Exception e)
              {
                  sw.WriteLine("Server error: " +  e.Message); // Send error message to the client
                  sw.Flush(); // Flush the StreamWriter to ensure data is sent
              }
          }
      }
  }
}

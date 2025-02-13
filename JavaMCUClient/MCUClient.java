/**
 * 
 */
package com.JavaUDFProj;

import java.net.*;
import java.io.*;

import org.apache.spark.sql.api.java.UDF1;

/**
 * @author anand desai
 *
 */
public class MCUClient implements UDF1<String, String>, Serializable {

    /**
     * @param args
     */
    public static void main(String[] args) {
        // Comment this main method out, its just to test client server connection
        String processName = "~\\DummyMCUServer\\DummyMCUServer\\bin\\Release\\net6.0\\start.bat"; 
        try {
            // Start the server process
            Process process = new ProcessBuilder(processName).start();
            System.out.println("Process started");
        } catch (Exception e) {
            // Print stack trace if an exception occurs
            e.printStackTrace();
        }
        
        // Server hostname and port
        String hostname = "127.0.0.1";
        int port = 5678;
        // Array of hero names to query
        String[] heros = new String [] {"captainamerica", "thor", "groot", "hulk"};
        for(String h : heros)
        { 
            try (Socket socket = new Socket(hostname, port)) 
            {
                // Get output and input streams from the socket
                OutputStream output = socket.getOutputStream();
                InputStream input = socket.getInputStream();            
                // Write hero name to the socket and read the response
                String power = WriteToScket(h, output, input);
                System.out.println(power);
                
            } 
            catch (UnknownHostException ex) 
            {
                // Handle case where the server is not found
                System.out.println("Server not found: " + ex.getMessage());
            } 
            catch (IOException ex) 
            {
                // Handle I/O errors
                System.out.println("I/O error: " + ex.getMessage());
            }
        }
    }
    
    // Method to write hero name to the socket and read the response
    private static String WriteToScket(String hero, OutputStream output, InputStream input) throws IOException
    {
        // Write hero name to the output stream
        PrintWriter writer = new PrintWriter(output, true);
        writer.println(hero);

        // Read response from the input stream
        BufferedReader reader = new BufferedReader(new InputStreamReader(input));
        String line;

        while ((line = reader.readLine()) != null) {
            return line; // Return the response
        }
        
        return "";
    }

    @Override
    public String call(String hero) throws Exception 
    {
        // Server hostname and port
        String hostname = "127.0.0.1";
        int port = 5678;
          
        String power = "not found";
        try (Socket socket = new Socket(hostname, port)) 
        {
            // Get output and input streams from the socket
            OutputStream output = socket.getOutputStream();
            InputStream input = socket.getInputStream();            
            // Write hero name to the socket and read the response
            power = WriteToScket(hero, output, input);
            
        } 
        catch (UnknownHostException ex) 
        {
            // Handle case where the server is not found
            System.out.println("Server not found: " + ex.getMessage());
        } 
        catch (IOException ex) 
        {
            // Handle I/O errors
            System.out.println("I/O error: " + ex.getMessage());
        }
        return power; // Return the power of the hero
    }

}

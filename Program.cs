using System;
using System.IO;
using System.Net;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            FileServer();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
    static void FileServer()
    {
        string wwwroot = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory );

        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:3000/");
        listener.Start();

        while (true)
        {
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest req = context.Request;
            HttpListenerResponse res = context.Response;

            // req.RawUrlÇ…ÅA"/"Ç∆Ç©"/index.html"Ç∆Ç©ì¸Ç¡ÇƒÇ≠ÇÈÇ¡Ç€Ç¢
            string urlPath = req.RawUrl;
            Console.WriteLine(urlPath);
            if (urlPath == "/") urlPath = "/index.html";
            
            string path = wwwroot + urlPath.Replace("/", "\\");
            
            try
            {
                res.StatusCode = 200;
                byte[] content = File.ReadAllBytes(path);
                res.OutputStream.Write(content, 0, content.Length);
            }
            catch (Exception ex)
            {
                res.StatusCode = 404;
                byte[] content = Encoding.UTF8.GetBytes(ex.Message);
                res.OutputStream.Write(content, 0, content.Length);
            }
            res.Close();
        }
    }
}
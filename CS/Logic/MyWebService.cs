﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Blinky.Logic;

namespace blink.Logic
{
    public class MyWebService
    {

        private const uint BufferSize = 8192;
        public TextBox text;
        public string ss;
        public string query;
        public Raspberry rasp;

        public MyWebService()
        {
            text = new TextBox() { Text = "ss", MaxLength = 200 };
            query = "huj";
            rasp=new Raspberry();
        }

        public async void Listenear()
        {
            var listener = new StreamSocketListener();

           
            listener.ConnectionReceived += async (sender, args) =>
            {
                var request = new StringBuilder();

                using (var input = args.Socket.InputStream)
                {
                    var data = new byte[BufferSize];
                    IBuffer buffer = data.AsBuffer();
                    var dataRead = BufferSize;

                    while (dataRead == BufferSize)
                    {
                        await input.ReadAsync(
                             buffer, BufferSize, InputStreamOptions.Partial);
                        request.Append(Encoding.UTF8.GetString(
                                                      data, 0, data.Length));
                        dataRead = buffer.Length;
                    }
                }
               
                var query = GetQuery(request);
                RunRaspberry(query);

                using (var output = args.Socket.OutputStream)
                {
                    using (var response = output.AsStreamForWrite())
                    {
                        var html = Encoding.UTF8.GetBytes(
                        $"<html><head><title>Background Message</title></head><body>Hello from the background process!<br/>{query}</body></html>");
                        using (var bodyStream = new MemoryStream(html))
                        {
                            var header = $"HTTP/1.1 200 OK\r\nContent-Length: {bodyStream.Length}\r\nConnection: close\r\n\r\n";
                            var headerArray = Encoding.UTF8.GetBytes(header);
                            await response.WriteAsync(headerArray,
                                                      0, headerArray.Length);
                            await bodyStream.CopyToAsync(response);
                            await response.FlushAsync();
                        }
                    }
                }
            };

            await listener.BindServiceNameAsync("8081", SocketProtectionLevel.PlainSocket);
        }

        private string GetQuery(StringBuilder request)
        {
            var requestLines = request.ToString().Split(' ');

            var url = requestLines.Length > 1 ? requestLines[1] : string.Empty;

            var uri = new Uri("http://localhost" + url);
            var query = uri.Query;
            return query;

        }

        public void RunRaspberry(string query)
        {
            rasp.Switch(query);
            // Raspberry.Switch(query);
        }


    }
}

﻿using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAssWPF
{
    /*public class ChatService
    {
        private HubConnection _hubConnection;

        // Sự kiện khi nhận tin nhắn
        public event Action<string, string> OnMessageReceived;

        public async Task StartConnection(string url)
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            _hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                OnMessageReceived?.Invoke(user, message);
            });

            try
            {
                await _hubConnection.StartAsync();
                Console.WriteLine("WPF Connected to SignalR Hub.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection error: {ex.Message}");
            }
        }

        public async Task SendMessage(string user, string message)
        {
            if (_hubConnection != null && _hubConnection.State == HubConnectionState.Connected)
            {
                await _hubConnection.InvokeAsync("SendMessage", user, message);
            }
        }
    }*/
    public class ChatService
    {
        private readonly HubConnection _connection;

        public event Action<string, string> OnMessageReceived;

        public ChatService()
        {
            // Bỏ qua SSL nếu cần thiết
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;

            _connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44302/chathub") // URL của Hub
                .Build();

            _connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                OnMessageReceived?.Invoke(user, message);
            });
        }

        /*public async Task StartConnectionAsync()
        {
            *//*await _connection.StartAsync();*//*
            // Bỏ qua xác thực SSL (Chỉ sử dụng trong môi trường phát triển)
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;

            try
            {
                await _connection.StartAsync();
                Console.WriteLine("WPF Connected to SignalR Hub.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection error: {ex.Message}");
            }

        }*/
        public async Task StartConnectionAsync()
        {
           /* System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;*/

            _connection.Reconnecting += error =>
            {
                Console.WriteLine("Attempting to reconnect...");
                return Task.CompletedTask;
            };

            _connection.Reconnected += connectionId =>
            {
                Console.WriteLine("Reconnected to SignalR Hub.");
                return Task.CompletedTask;
            };

            _connection.Closed += async error =>
            {
                Console.WriteLine("Connection closed. Trying to reconnect...");
                await Task.Delay(2000); // Đợi một chút trước khi thử kết nối lại
                await StartConnectionAsync();
            };

            try
            {
                await _connection.StartAsync();
                Console.WriteLine("Connected to SignalR Hub.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to SignalR Hub: {ex.Message}");
            }
        }


        /*public async Task SendMessage(string user, string message)
        {
            await _connection.InvokeAsync("SendMessage", user, message);
        }*/
        public async Task SendMessage(string user, string message)
        {
            if (_connection != null && _connection.State == HubConnectionState.Connected)
            {
                try
                {
                    await _connection.InvokeAsync("SendMessage", user, message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending message: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Connection is not active. Unable to send message.");
                // Optional: Try to reconnect here if needed.
            }
        }

    }
}

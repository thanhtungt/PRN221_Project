﻿using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Repositories;
using Repositories.Implementation;
using ProjectAssWPF;
using Microsoft.AspNetCore.SignalR.Client;

namespace TranMinhThienWPF
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    /// 
    public partial class AdminView : Window
    {
        private ShowName _currentShow;

        // Customer
        private ICustomerRepository _customerRepository = new CustomerRepository();
        private List<Customer?> _listCustomer = new();

        // Flower
        private IFlowerBouquetRepository _flowerBouquetRepository = new FlowerBouquetRepository();
        private List<FlowerBouquet> _listFlower = new();

        // Order
        private List<Order> _listOrder = new();
        private List<OrderDetail> _listOrderDetails = new();
        private readonly IOrderRepository _orderRepository = new OrderRepository();
        private readonly IOrderDetailRepository _orderDetailRepository = new OrderDetailRepository();

        //chat
        private readonly ChatService _chatService;
        private HubConnection _connection;

        private int _indexSelect = -1;

        public AdminView()
        {
            InitializeComponent();
            InitializeConnection();
            // ResetDisplay();
            // CustomerBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
            // _currentShow = ShowName.Customer;
            // CustomerManagement.Visibility = Visibility.Visible;
            // LoadAndShowAllCustomer();
            /* _chatService = new ChatService();
             StartChatConnection();*/
            //_chatService = new ChatService();
            //_chatService.OnMessageReceived += (user, message) =>
            //{
            //    Dispatcher.Invoke(() =>
            //    {
            //        MessagesListBox.Items.Add($"{user}: {message}");
            //    });
            //};

            /*StartChatConnection();*/
            //_chatService.StartConnectionAsync();
        }

        /*private async void StartChatConnection()
        {
            // Kết nối tới SignalR Hub tại URL của Razor Pages
            await _chatService.StartConnection("https://localhost:5001/chathub");

            // Đăng ký sự kiện để nhận tin nhắn
            _chatService.OnMessageReceived += (user, message) =>
            {
                Dispatcher.Invoke(() =>
                {
                    MessagesListBox.Items.Add($"{user}: {message}");
                });
            };
        }*/
        /*private async void StartChatConnection()
        {
            await _chatService.StartConnectionAsync();
        }


        private async void OnClickSendMessage(object sender, RoutedEventArgs e)
        {
            string message = MessageTextBox.Text;

            if (!string.IsNullOrEmpty(message))
            {
                await _chatService.SendMessage("Admin", message);
                MessagesListBox.Items.Add($"Me (Admin): {message}"); // Hiển thị tin nhắn của Admin
                MessageTextBox.Clear(); // Xóa TextBox sau khi gửi
            }
        }*/
        private async void InitializeConnection()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44302/chathub")
                .Build();

            _connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Dispatcher.Invoke(() =>
                {
                    // Cập nhật UI để hiển thị tin nhắn
                    MessagesListBox.Items.Add($"{user}: {message}");
                });
            });

            try
            {
                await _connection.StartAsync();
                MessagesListBox.Items.Add("Connected to chat.");
            }
            catch (Exception ex)
            {
                MessagesListBox.Items.Add($"Connection error: {ex.Message}");
            }
        }

        private async void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            /* if (_connection != null)
             {
                 var user ="Admin";
                 var message = MessageTextBox.Text;
                 await _connection.InvokeAsync("SendMessage", user, message);
                 MessageTextBox.Clear();
             }*/
            if (_connection.State == HubConnectionState.Disconnected)
            {
                try
                {
                    await _connection.StartAsync();
                    MessagesListBox.Items.Add("Reconnected to chat.");
                }
                catch (Exception ex)
                {
                    MessagesListBox.Items.Add($"Reconnection error: {ex.Message}");
                    return;
                }
            }

            if (_connection.State == HubConnectionState.Connected)
            {
                var user = "ADMIN";
                var message = MessageTextBox.Text;
                await _connection.InvokeAsync("SendMessage", user, message);
                MessageTextBox.Clear();
            }
            else
            {
                MessagesListBox.Items.Add("Connection is not active.");
            }
        }
        // Phương thức này sẽ được gọi khi nhấn nút Chat
        private void OnClickChat(object sender, RoutedEventArgs e)
        {
            // Sử dụng ResetDisplay để ẩn tất cả các phần khác trước khi hiển thị ChatManagement
            ResetDisplay();
            // Thiết lập style cho nút Chat và hiển thị ChatManagement
            ChatBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
            _currentShow = ShowName.Chat;
            ChatManagement.Visibility = Visibility.Visible;
            // Đặt tất cả các phần khác thành Collapsed và chỉ hiển thị ChatManagement
            CustomerManagement.Visibility = Visibility.Collapsed;
            FlowerManagement.Visibility = Visibility.Collapsed;
            OrderManagement.Visibility = Visibility.Collapsed;
            ReportManagement.Visibility = Visibility.Collapsed;
            ChatManagement.Visibility = Visibility.Visible;
        }

        private void Awake(object sender, RoutedEventArgs e)
        {
            ResetDisplay();
            CustomerBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
            _currentShow = ShowName.Customer;
            CustomerManagement.Visibility = Visibility.Visible;
            LoadAndShowAllCustomer();
            CustomerFindType.SelectedIndex = -1;
            CustomerFindType.Items.Clear();
            CustomerFindType.Items.Add("By name");
            CustomerFindType.Items.Add("By email");
            CustomerFindType.Items.Add("By city");
            CustomerFindType.Items.Add("By country");
            CustomerFindType.SelectedIndex = 0;
        }
        #region View Manager

        // View event
        private void OnClickCustomer(object sender, RoutedEventArgs e)
        {
            if (_currentShow != ShowName.Customer)
            {
                ResetDisplay();
                CustomerBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
                _currentShow = ShowName.Customer;
                CustomerManagement.Visibility = Visibility.Visible;
                LoadAndShowAllCustomer();
                CustomerFindType.SelectedIndex = -1;
                CustomerFindType.Items.Clear();
                CustomerFindType.Items.Add("By name");
                CustomerFindType.Items.Add("By email");
                CustomerFindType.Items.Add("By city");
                CustomerFindType.Items.Add("By country");
                CustomerFindType.SelectedIndex = 0;
            }
        }

        private void OnClickOder(object sender, RoutedEventArgs e)
        {
            if (_currentShow != ShowName.Order)
            {
                ResetDisplay();
                OrderBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
                _currentShow = ShowName.Order;
                OrderManagement.Visibility = Visibility.Visible;
                LoadDataOrder();
                ShowOrder();
            }
        }

        private void OnClickFlowerBouquet(object sender, RoutedEventArgs e)
        {
            if (_currentShow != ShowName.Flower)
            {
                ResetDisplay();
                FlowerBouquetBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
                FlowerManagement.Visibility = Visibility.Visible;
                _currentShow = ShowName.Flower;
                LoadAndShowAllFlower();
                FlowerSearchType.SelectedIndex = -1;
                FlowerSearchType.Items.Clear();
                FlowerSearchType.Items.Add("By Name");
                FlowerSearchType.Items.Add("By Description");
                FlowerSearchType.SelectedIndex = 0;
            }
        }

        private void OnClickReport(object sender, RoutedEventArgs e)
        {
            if (_currentShow != ShowName.Report)
            {
                ResetDisplay();
                ReportBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
                ReportManagement.Visibility = Visibility.Visible;
                _currentShow = ShowName.Report;
                LoadAndShowAllFlower();
                ReportStart.SelectedDate = DateTime.Today;
                ReportEnd.SelectedDate = DateTime.Today;
            }
        }

        private void ResetDisplay()
        {
            CustomerManagement.Visibility = Visibility.Collapsed;
            OrderManagement.Visibility = Visibility.Collapsed;
            FlowerManagement.Visibility = Visibility.Collapsed;
            ReportManagement.Visibility = Visibility.Collapsed;
            ChatManagement.Visibility = Visibility.Collapsed; // Ẩn luôn khung ChatManagement
            _indexSelect = -1;
            switch (_currentShow)
            {
                case ShowName.Customer:
                {
                    CustomerBtn.Style = (Style)Application.Current.Resources["MenuBtn"];
                    CustomerView.SelectedIndex = -1;
                    break;
                }
                case ShowName.Order:
                {
                    OrderBtn.Style = (Style)Application.Current.Resources["MenuBtn"];
                    break;
                }
                case ShowName.Flower:
                {
                    FlowerBouquetBtn.Style = (Style)Application.Current.Resources["MenuBtn"];
                    FlowerView.SelectedIndex = -1;
                    break;
                }
                case ShowName.Report:
                {
                    ReportBtn.Style = (Style)Application.Current.Resources["MenuBtn"];
                    break;
                }
            }
        }

        private enum ShowName
        {
            Customer,
            Order,
            Flower,
            Report,
            Chat
        }

        // Oder

        private void ClearOrderDetail()
        {
            OrderDetailView.ItemsSource = null;
        }

        private void ShowOrderDetail()
        {
            var viewModel = new List<OrderDetailViewModel>();
            foreach (OrderDetail detail in _listOrderDetails)
            {
                viewModel.Add(new(detail.OrderId, GetFlowerName(detail.FlowerBouquetId), detail.UnitPrice,
                    detail.Quantity, detail.Discount));
            }

            OrderDetailView.ItemsSource = viewModel;
        }

        private void ShowOrder()
        {
            OrderView.ItemsSource = _listOrder;
        }

        // Report
        private void ShowOrderReportRaw()
        {
            ReportView.ItemsSource = _listOrder;
            TotalProfit.Text = _listOrder.Sum(p => p.Total).ToString();
        }

        private void ShowOrderRenameSort()
        {
            var sortedList = _listOrder.OrderByDescending(p => p.Total).ToList();
            ReportView.ItemsSource = sortedList;
        }

       

        #endregion

        #region Controller

        // ORDER 
        private void LoadDataOrder()
        {
            try
            {
                _listOrder = _orderRepository.GetAllOrders();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }

        private void LoadDataOrderDetail(int id)
        {
            if (id == -1)
            {
                _listOrderDetails = new List<OrderDetail>();
            }

            try
            {
                _listOrderDetails = _orderDetailRepository.GetOrderDetailById(id);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }

        // FLOWER
        private void LoadAndShowAllFlower()
        {
            try
            {
                _listFlower = _flowerBouquetRepository.GetAllFlower();
                FlowerView.ItemsSource = _listFlower;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }

        private string GetFlowerName(int id)
        {
            try
            {
                var name = _flowerBouquetRepository.GetFlowerName(id);
                return name;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
                return "";
            }
        }

        private void ShowAllFlower()
        {
            try
            {
                FlowerView.ItemsSource = _listFlower;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }

        //CUSTOMER
        private void ShowAllCustomer()
        {
            try
            {
                CustomerView.ItemsSource = _listCustomer;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }

        private void LoadAndShowAllCustomer()
        {
            try
            {
                _listCustomer = _customerRepository.GetAllCustomer();
                CustomerView.ItemsSource = _listCustomer;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }

        // REPORT
        private void LoadDataReport()
        {
           
            _listOrder =
                _orderRepository.GetDataInRange(ReportStart.SelectedDate.Value, ReportEnd.SelectedDate.Value, out var message);

            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "ERROR");
            }
        }

        #endregion

        #region CUSTOMER Event

        private void OnClickSearchCustomer(object sender, RoutedEventArgs routedEventArgs)
        {
            try
            {
                _listCustomer = _customerRepository.FindCustomer(CustomerFindType.SelectedIndex, SearchValueCustomer.Text);
                ShowAllCustomer();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR");
            }
        }

        private void OnChangeSelectedCustomer(object sender, SelectionChangedEventArgs e)
        {
            _indexSelect = CustomerView.SelectedIndex;
        }

        private void OnClickShowAllCustomer(object sender, RoutedEventArgs e)
        {
            LoadAndShowAllCustomer();
        }

        private void OnClickDeleteCustomer(object sender, RoutedEventArgs e)
        {
            if (_indexSelect != -1)
            {
                MessageBoxResult result =
                    MessageBox.Show("Are you sure to delete " + _listCustomer[_indexSelect].CustomerName,
                        "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _customerRepository.DeleteCustomer(_listCustomer[_indexSelect].CustomerId);
                        MessageBox.Show("Delete successfully ", "Notification");
                        LoadAndShowAllCustomer();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Delete fail: " + exception.Message, "ERROR");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an customer", "Warning");
            }
        }

        private void OnClickUpdateCustomer(object sender, RoutedEventArgs e)
        {
            if (_indexSelect != -1)
            {
                CustomerEditor customerEditor = new CustomerEditor(_listCustomer[_indexSelect], OnFinishUpdateCustomer);
                customerEditor.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Please select an customer", "Warning");
            }
        }

        private void OnClickAddNewCustomer(object sender, RoutedEventArgs e)
        {
            CustomerEditor customerEditor = new CustomerEditor(null, OnFinishCreateCustomer);
            customerEditor.Show();
            Hide();
        }

        private void OnFinishCreateCustomer(Customer? newCustomer)
        {
            Show();
            LoadAndShowAllCustomer();
            _indexSelect = -1;
            CustomerView.SelectedIndex = -1;
        }

        private void OnFinishUpdateCustomer(Customer? newCustomer)
        {
            Show();
            LoadAndShowAllCustomer();
            _indexSelect = -1;
            CustomerView.SelectedIndex = -1;
        }

        #endregion

        #region Flower Event

        private void OnClickSearchFlower(object sender, RoutedEventArgs routedEventArgs)
        {
            try
            {
                _listFlower = _flowerBouquetRepository.FindFlower(FlowerSearchType.SelectedIndex, SearchValueFlower.Text);
                ShowAllFlower();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR");
            }
        }

        private void OnClickShowAllFlower(object sender, RoutedEventArgs e)
        {
            LoadAndShowAllFlower();
        }

        private void OnClickDeleteFlower(object sender, RoutedEventArgs e)
        {
            if (_indexSelect != -1)
            {
                MessageBoxResult result =
                    MessageBox.Show("Are you sure to delete " + _listFlower[_indexSelect].FlowerBouquetName,
                        "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _flowerBouquetRepository.DeleteFlower(_listFlower[_indexSelect].FlowerBouquetId);
                        MessageBox.Show("Delete successfully ", "Notification");
                        LoadAndShowAllFlower();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Delete fail: " + exception.Message, "ERROR");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an customer", "Warning");
            }
        }

        private void OnClickUpdateFlower(object sender, RoutedEventArgs e)
        {
            if (_indexSelect != -1)
            {
                FlowerEditor flowerEditor = new FlowerEditor(_listFlower[_indexSelect], OnFinishEditFlower);
                flowerEditor.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Please select a flower", "Warning");
            }
        }

        private void OnClickAddNewFlower(object sender, RoutedEventArgs e)
        {
            FlowerEditor flowerEditor = new FlowerEditor(null, OnFinishEditFlower);
            flowerEditor.Show();
            Hide();
        }

        private void OnFinishEditFlower()
        {
            Show();
            LoadAndShowAllFlower();
            _indexSelect = -1;
            FlowerView.SelectedIndex = -1;
        }

        private void OnSelectionChangedFlower(object sender, SelectionChangedEventArgs e)
        {
            _indexSelect = FlowerView.SelectedIndex;
        }

        #endregion


        #region Order Event

        private void OnChangeSelectedOrder(object sender, SelectionChangedEventArgs e)
        {
            if (_indexSelect != OrderView.SelectedIndex)
            {
                _indexSelect = OrderView.SelectedIndex;
                LoadDataOrderDetail(_listOrder[_indexSelect].OrderId);
                ShowOrderDetail();
            }
        }
        

        private void OnClickShowAllOrder(object sender, RoutedEventArgs e)
        {
            LoadDataOrder();
            ShowOrder();
        }

        private void OnClickDeleteOrder(object sender, RoutedEventArgs e)
        {
            if (_indexSelect != -1)
            {
                MessageBoxResult result =
                    MessageBox.Show("Are you sure to delete " + _listOrder[_indexSelect].OrderId,
                        "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _orderRepository.DeleteOrder(_listOrder[_indexSelect].OrderId);
                        MessageBox.Show("Delete successfully ", "Notification");
                        _indexSelect = -1;
                        OrderView.SelectedIndex = -1;
                        LoadDataOrder();
                        ShowOrder();
                        ClearOrderDetail();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Delete fail: " + exception.Message, "ERROR");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an customer", "Warning");
            }
        }

        private void OnClickUpdateOrder(object sender, RoutedEventArgs e)
        {
            if (OrderView.SelectedIndex != -1)
            {
                OrderEditor orderEditor = new OrderEditor(_listOrder[OrderView.SelectedIndex], OnFinishEditOrder);
                orderEditor.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Select a order");
            }
        }

        private void OnClickAddNewOrder(object sender, RoutedEventArgs e)
        {
            OrderEditor orderEditor = new OrderEditor(OnFinishEditOrder);
            orderEditor.Show();
            Hide();
        }

        private void OnFinishEditOrder()
        {
            Show();
            LoadDataOrder();
            ShowOrder();
            _indexSelect = -1;
            OrderView.SelectedIndex = -1;
            ShowOrderDetail();
        }

        #endregion


        #region Report Event

        private void OnClickSearchReport(object sender, RoutedEventArgs e)
        {
            LoadDataReport();
            ShowOrderReportRaw();
        }

        private void OnClickSortReport(object sender, RoutedEventArgs e)
        {
            ShowOrderRenameSort();
        }

        #endregion

      
    }
}
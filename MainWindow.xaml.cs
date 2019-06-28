using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.AddWindow;
using TaskManager.EditWindow;
using TaskManager.TaskClass;

namespace TaskManager
{
    public partial class MainWindow : Window
    {
        //Link do połączenia z bazą, Połączenie z lokalną bazą sql serwer
        public static string connectionString = ConfigurationManager.ConnectionStrings["MyConnect"].ConnectionString;
     
        
        public MainWindow()
        {
            InitializeComponent();
            LoadTasks();
            TaskGrid.CanUserAddRows = false;  
        }

        //Reakcja na wciśnięcie przycisku dodaj task - otwiera nowe okno w którym tworzymy task (treść, priorytet, status itp.)
        private void openAddTaskWindow(object sender, RoutedEventArgs e)
        {
            AddTask add = new AddTask(connectionString);
            add.Owner = this;
            add.Show();
        }

        //Wywołanie ładowania tasków do grida z wykorzystaniem LINQ
        public void LoadTasks()
        {
            string selectQuery = "Select Id,Text,priority,status, 'End_Date'=convert(varchar(10),End_Date,5) From dbo.Tasks";
            SqlConnection con = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand command = new SqlCommand(selectQuery, con);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            TaskGrid.ItemsSource= dt.DefaultView;
            con.Close();
        }
        //Funkcja Delete Task
        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)TaskGrid.CurrentItem;
            string id = dataRow.Row.ItemArray[0].ToString();
            string deleteQuery = "Delete From dbo.Tasks WHERE id=@id";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command = new SqlCommand(deleteQuery, con);
            command.Parameters.AddWithValue("@id",id);
            command.ExecuteNonQuery();
            con.Close();
            LoadTasks();
        }
        //Funkcja Edit - otwiera nowe okno
        private void EditTask(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)TaskGrid.CurrentItem;
            
            TaskObject task = new TaskObject((int)dataRow.Row.ItemArray[0],
                dataRow.Row.ItemArray[1].ToString(), 
                dataRow.Row.ItemArray[2].ToString(), 
                dataRow.Row.ItemArray[3].ToString(),
                dataRow.Row.ItemArray[4].ToString());

            Edit edit = new Edit(connectionString, task);
            edit.Owner = this;
            edit.Show();
        }
        //Filtrowanie - W przypadku DropDownClosed ponieważ SelectChanged wywołuje się już w trakcie kompilacji programu i wyrzuca wyjątek
        
        private void Priority_DropDownClosed(object sender, EventArgs e)
        {
            string selectQuery = "Select * From dbo.Tasks WHERE priority=@priority";
            SqlConnection con = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand command = new SqlCommand(selectQuery, con);
            if (Priority.Text.Equals("Wszystkie"))
            {
                LoadTasks();
                Status.SelectedIndex = 0;
            }
            else
            {
                command.Parameters.AddWithValue("@priority", Priority.Text);
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                TaskGrid.ItemsSource = dt.DefaultView;
                con.Close();
                Status.SelectedIndex = 0;
            }
                
        }

        private void Status_DropDownClosed(object sender, EventArgs e)
        {
            string selectQuery = "Select * From dbo.Tasks WHERE status=@status";
            SqlConnection con = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand command = new SqlCommand(selectQuery, con);
            if (Status.Text.Equals("Wszystkie"))
            {
                LoadTasks();
                Priority.SelectedIndex = 0;
            }
            else
            {
                command.Parameters.AddWithValue("@status", Status.Text);
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                TaskGrid.ItemsSource = dt.DefaultView;
                con.Close();
                Status.SelectedIndex=0;
                
            }
           
        }
    }
}

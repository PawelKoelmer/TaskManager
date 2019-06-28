using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using TaskManager.TaskClass;

namespace TaskManager.AddWindow
{
    //Przykład dodawania danych za pomocą połączenia z bazą danych SQL poprzez connection String
    public partial class AddTask : Window
    {
        //Zmienna przechowująca connectionString
       
        public string connect;
        public AddTask(string connectionString)
        {
            this.connect = connectionString;
            InitializeComponent();
            
        }

        //utworzenie tasku - następnie wykorzystanie go do wysłania do bazy danych
        private void createTask(object sender, RoutedEventArgs e)
        {
            //Utworzenie Taska - nadanie wartości (pobranie ich z odpowiednich kontrolek)
            TaskObject task = new TaskObject();
            task.taskContent = TaskText.Text;
            task.taskPriority = priority.Text;
            task.taskStatus = status.Text;
            //Zapytanie do inserta do tablicy - po utworzeniu obiektu wysyła dane do tablicy
            string insertQuery = "Insert Into Tasks (Text,priority,status,End_Date) values (@text,@priority,@status,@Date)";

            //Sprawdzenie czy dodano treść zadania
            if (task.taskContent.Length>0)
            {
            //Połączenie do bazy danych link
            try
            {
                SqlConnection con = new SqlConnection(connect);
                SqlCommand command = new SqlCommand(insertQuery, con);
                //Dodawanie obiektu do zapytania - czytelniejsze niż budowanie stringa zapytania
                command.Parameters.AddWithValue("@text", task.taskContent);
                command.Parameters.AddWithValue("@priority", task.taskPriority);
                command.Parameters.AddWithValue("@status", task.taskStatus);
                //Warunek jeśli chcesz dodać datę zakończenia - jeśli checkbox zaznaczony to dodaj datę z datepicker jeśli nie to NULL
                if (endDate.IsChecked == true)
                {
                        //Sprawdza czy na pewno wybrano datę - jeśli użytkownik zaznaczy comboboxa ale nie wybierze daty - wtedy funkcja nie doda parametru i wróci do stanu początkowego
                        if (endDateCalendar.SelectedDate.ToString().Length > 0)
                        {
                            command.Parameters.AddWithValue("@Date", endDateCalendar.SelectedDate);
                        }
                        else
                        {
                            MessageBox.Show("Nie wybrano daty");
                            return;
                        }
                }
                else
                {
                    command.Parameters.AddWithValue("@Date", DBNull.Value);
                }
                //otworzenie połączenia z bazą
                con.Open();
                int result = command.ExecuteNonQuery();
                //Sprawdzenie czy prawidłowo dodano element
                if (result < 0)
                {
                    MessageBox.Show("Błąd dodawania elementu");
                }
                
                //zamknięcie połączenia
                con.Close();
                    //Mechanizm wywołania funkcji LoadTasks() w głównym oknie po dodaniu taska
                    ((MainWindow)this.Owner).LoadTasks();
                    MessageBox.Show("Dodano Task");
                    
                this.Close();

            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            }
            else{ MessageBox.Show("Brak treści zadania"); }
        }
        
    }
}

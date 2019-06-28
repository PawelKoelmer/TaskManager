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

namespace TaskManager.EditWindow
{
    
    public partial class Edit : Window
    {
        public bool comboBoxCheck=false;
        public string connect;
        public TaskObject task { get; set; }
        public Edit(string connectionString, TaskObject t)
        {
            this.task = t;
            this.connect = connectionString;
            InitializeComponent();
            setFields();
        }

        public void setFields()
        {
            TaskText.AppendText(task.taskContent);
            priority.Text = task.taskPriority;
            status.Text = task.taskStatus;
            if (task.endTime.Length > 0)
            {
                endDate.IsChecked = true;
                comboBoxCheck = true;
                endDateCalendar.Text = task.endTime;
            }
        }

        public void Update(object sender, RoutedEventArgs e)
        {
            if(!TaskText.Text.Equals(task.taskContent) 
                || !priority.Text.Equals(task.taskPriority)
                || !status.Text.Equals(task.taskStatus)
                || !endDateCalendar.Text.Equals(task.endTime)
                || comboBoxCheck != endDate.IsChecked.Value)
            {
                if (TaskText.Text.Length > 0)
                {
                    string updateQuery = "Update dbo.Tasks SET Text=@text , priority=@priority , status=@status , End_Date=@Date " +
                        "Where ID=@id";
                    //Połączenie do bazy danych link
                    try
                    {
                        SqlConnection con = new SqlConnection(connect);
                        SqlCommand command = new SqlCommand(updateQuery, con);
                        command.Parameters.AddWithValue("@id", task.ID);
                        command.Parameters.AddWithValue("@text", TaskText.Text);
                        command.Parameters.AddWithValue("@priority", priority.Text);
                        command.Parameters.AddWithValue("@status", status.Text);
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
                        //Sprawdzenie czy prawidłowo zaktualizowano element
                        if (result < 0)
                        {
                            MessageBox.Show("Błąd dodawania elementu");
                        }

                        //zamknięcie połączenia
                        con.Close();
                        //Mechanizm wywołania funkcji LoadTasks() w głównym oknie po Zaktualizowaniu taska
                        ((MainWindow)this.Owner).LoadTasks();
                        MessageBox.Show("Zaktualizowano Task");

                        this.Close();

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else { MessageBox.Show("Brak treści zadania"); }
            }
            else
            {
                MessageBox.Show("Niczego nie zmieniono");
            }
        }
    }
}


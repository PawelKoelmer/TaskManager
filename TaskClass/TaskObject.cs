using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskClass
{
    public class TaskObject
    {

        // Obiekt task, obiektowo przechowywany przed samym dodaniem, zachowanie obiektowości 
        // taskPriority i taskStatus można też ustawiać poprzez enum ale skomplikuje to kod wiedząc że nadajemy te wartości z góry
        // z drop listy
        public int ID { get; set; }
        public string taskPriority { get; set; }
        public string taskStatus { get; set; }
        public string taskContent { get; set; }
        public string endTime { get; set; }
        public TaskObject() { }
        public TaskObject(int id,string content, string priority, string status, string date)
        {
            this.ID = id;
            this.taskContent = content;
            this.taskStatus = status;
            this.taskPriority = priority;
            this.endTime = date;
           
        }
    }
}

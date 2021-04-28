using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Assets
{
    public class Task
    {
        public int id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int fk_Competition_id { get; set; }

        public Task(int id, string taskName, string description, double latitude, double longitude, string question, string answer, int fk_Competition_id)
        {
            this.id = id;
            TaskName = taskName;
            Description = description;
            this.latitude = latitude;
            this.longitude = longitude;
            Question = question;
            Answer = answer;
            this.fk_Competition_id = fk_Competition_id;
        }

    }
}

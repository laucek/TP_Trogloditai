using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Assets
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int LiveType { get; set; }
        public int fk_CreatorId { get; set; }

        public Competition(int id, string name, DateTime startDate, DateTime endDate, string description, int liveType, int fk_CreatorId)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
            LiveType = liveType;
            this.fk_CreatorId = fk_CreatorId;
        }
    }
}

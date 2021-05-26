using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Assets
{
    public class ParticipationObject
    {
        public Competition Competition { get; set; }
        public List<Task> Tasks { get; set; }
        public int Score { get; set; }

        public ParticipationObject(Competition competition)
        {
            this.Competition = competition;
            Tasks = MySQLManager.GetTasksByCompetition(competition.Id);
            Score = 0;
        }
    }
}

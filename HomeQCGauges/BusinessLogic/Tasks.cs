using System;

namespace BusinessLogic
{
    public class Tasks
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public int User_ID { get; set; }
        public string User_Name { get; set; }
        public int House_ID { get; set; }
        public string House_Name { get; set; }
        public string Task_Name { get; set; }
        public string SubTasksIDs { get; set; }
        public string Description { get; set; }
        public  string Instructions  { get; set; }
        public int Frequency_days { get; set; }
        public bool BOM { get; set; }
        public string Responsible { get; set; }
        public string Comments { get; set; }

        // Add filds here for any new columns to table [Tasks]

    }
}

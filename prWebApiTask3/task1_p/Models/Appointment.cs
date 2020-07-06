using NPoco;
using System;

namespace task1_p
{
    [TableName("Appointment")]
    [PrimaryKey("Id")]
    public class Appointment
    {
        private string _comment;
        public Guid Id { get; }
        public DateTime Date { get; set; } // Дата обращения
        public Guid UserId { get; set; } // ID пользователя
        public string Comment
        {
            get { return _comment; }
            set
            {
                if ("" == value)
                    throw new ArgumentNullException("Comment");
                else
                    _comment = value;
            }
        } // Комментарий
    }
}
using NPoco;
using System;
using System.Collections.Generic;

namespace task1_p
{
    [TableName("Users")]
    [PrimaryKey("Id")]
    public class User
    {
        public Guid Id { get; }
        private string _firstname, _lastname, _phonenumber;
        public string Firstname
        {
            get { return _firstname; }
            set
            {
                if ("" == value)
                    throw new ArgumentNullException("Firstname");
                else
                    _firstname = value;
            }
        } // Имя
        public string Lastname
        {
            get { return _lastname; }
            set
            {
                if ("" == value)
                    throw new ArgumentNullException("Lastname");
                else
                    _lastname = value;
            }
        } // Имя  // Фамилия
        public string Patronymic { get; set; }// Отчество
        public string PhoneNumber
        {
            get { return _phonenumber; }
            set
            {
                if ("" == value)
                    throw new ArgumentNullException("PhoneNumber");
                else try
                    {
                        long.Parse(value);
                        _phonenumber = value;
                    }
                    catch { throw new FormatException("Wrong PhoneNumber format."); }
            }
        } // Номер телефона
        [Ignore]
        public List<Appointment> Appointments { get; set; }
    }
}

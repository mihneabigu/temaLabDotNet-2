using System;

namespace Classes {

    public class Manager : Employee {

        public Manager(int Id, String FirstName, String LastName, DateTime StartDate, DateTime EndDate, int Salary) : base (Id, FirstName, LastName, StartDate, EndDate, Salary) {
            
        }

        public override String Salutation() {
            return "Hello Manager"; 
        }
    }
}
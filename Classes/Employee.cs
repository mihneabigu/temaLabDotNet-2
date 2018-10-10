using System;

namespace Classes {

    public abstract class Employee {

        public int Id {get; private set;}
        public String FirstName {get; private set;}
        public String LastName {get; private set;}
        public DateTime StartDate {get; private set;}
        public DateTime EndDate {get; private set;}
        public int Salary {get; private set;}

        protected Employee(int Id, String FirstName, String LastName, DateTime StartDate, DateTime EndDate, int Salary)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Salary = Salary;
        }

        public DateTime GetStartDate() {
            return this.StartDate;
        }

        public void SetStartDate(DateTime dateTime) {
            this.StartDate = dateTime;
        }


        public DateTime GetEndDate() {
            return this.EndDate;
        }

        public void SetEndDate(DateTime dateTime) {
            this.EndDate = dateTime;
        }

        public virtual String GetFullName() {
            return this.FirstName + " " + this.LastName;
        }

        public virtual bool IsActive() {
            return this.StartDate <= DateTime.Today && DateTime.Today <= this.EndDate;
        }
        
        public abstract String Salutation();
    }
}
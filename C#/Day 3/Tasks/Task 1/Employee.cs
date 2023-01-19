namespace Task_1
{
    internal partial class Program
    {
        public struct Employee
        {
            private int _id;
            private SecurityLevel _security_level;
            private decimal _salary;
            private HireDate _hire_date;
            private Gender _gender;

            public Employee(int id, SecurityLevel security_level, decimal salary, HireDate hire_date, Gender gender)
            {
                this._id = id;
                this._security_level = security_level;
                this._salary = salary;
                this._hire_date = hire_date;
                this._gender = gender;
            }
            
            #region Getters

            public int GetId()
            {
                return _id;
            }
            
            public SecurityLevel GetSecurityLevel()
            {
                return _security_level;
            }
            
            public decimal GetSalary()
            {
                return _salary;
            }
            
            public HireDate GetHireDate()
            {
                return _hire_date;
            }
          
            public Gender GetGender()
            {
                return _gender;
            }

            #endregion
            
            #region Setters
            public void SetId(int id)
            {
                _id = id;
            }
            
            public void SetSecurityLevel(SecurityLevel security_level)
            {
                _security_level = security_level;
            }
            
            public void SetSalary(decimal salary)
            {
                _salary = salary;
            }
            
            public void SetHireDate(HireDate hireDate)
            {
                _hire_date = hireDate;
            }
            
            public void SetGender(Gender gender)
            {
                _gender = gender;
            }
            #endregion

            public override string ToString()
            {
                return $"ID: {_id}\n" +
                    $"Gender: {_gender}\n" +
                    $"SecurityLevel: {_security_level}\n" +
                    $"Salary: {string.Format("{0:C}", _salary)}\n" +
                    $"Hire Date: {_hire_date}\n";
            }
        }
    }
}
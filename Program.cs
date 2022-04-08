using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitwareLib
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Employee employee = new Employee();
                Console.Write("Enter Employee ID: ");
                int EmpId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Employee ID: ");
                string EmpName = Console.ReadLine();
                Console.Write("Enter Employee ID: ");
                double Salary = Convert.ToDouble(Console.ReadLine());
                employee.SetEmpNo(EmpId);
                employee.SetEmpName(EmpName);
                employee.SetSalary(Salary);
                Console.WriteLine(employee.CalculateSalary());

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    class Employee : IPrintable
    {
        protected int EmpNo;
        protected string EmpName;
        protected double Salary;
        protected double HRA;
        protected double TA;
        protected double DA;
        protected double PF;
        protected double TDS;
        protected double NetSalary;
        protected double GrossSalary;

        public void SetEmpNo(int EmpNo)
        {
            this.EmpNo = EmpNo;
        }
        public void SetEmpName(string EmpName)
        {
            this.EmpName = EmpName;
        }
        public void SetSalary(double Salary)
        {
            this.Salary = Salary;
            if (this.Salary < 500)
            {
                this.HRA = (this.Salary * 10) / 100;
                this.TA = (this.Salary * 5) / 100;
                this.DA = (this.Salary * 15) / 100;
            }
            else if (this.Salary > 5000 && this.Salary < 10000)
            {
                this.HRA = (this.Salary * 15) / 100;
                this.TA = (this.Salary * 10) / 100;
                this.DA = (this.Salary * 20) / 100;
            }
            else if (this.Salary >= 10000 && this.Salary < 15000)
            {
                this.HRA = (this.Salary * 20) / 100;
                this.TA = (this.Salary * 15) / 100;
                this.DA = (this.Salary * 25) / 100;
            }
            else if (this.Salary >= 15000 && this.Salary < 20000)
            {
                this.HRA = (this.Salary * 25) / 100;
                this.TA = (this.Salary * 20) / 100;
                this.DA = (this.Salary * 30) / 100;
            }
            else
            {
                this.HRA = (this.Salary * 30) / 100;
                this.TA = (this.Salary * 25) / 100;
                this.DA = (this.Salary * 35) / 100;
            }
            this.GrossSalary = this.Salary + this.HRA + this.TA + this.DA;
        }

        public virtual double CalculateSalary()
        {
            this.PF = (this.GrossSalary * 10) / 100;
            this.TDS = (this.GrossSalary * 18) / 100;
            this.NetSalary = this.GrossSalary - (this.PF + this.TDS);
            return this.NetSalary;
        }

        public void PrintDetails()
        {
            Console.WriteLine("Employee No: " + EmpNo + "\nEmployee Name: " + EmpName + "\nSalary: " + Salary);
            Console.WriteLine("HRA: " + HRA + "TA: " + TA + "DA: " + DA + "Gross Salary: " + GrossSalary);
            Console.WriteLine("PF:" + PF + "TDS:" + TDS + "Net Salary:" + NetSalary);
        }
    }

    class Manager : Employee, IPrintable
    {
        private double PetrolAllowance;
        private double FoodAllowance;
        private double OtherAllowances;

        public override double CalculateSalary()
        {
            PetrolAllowance = (Salary * 8) / 100;
            FoodAllowance = (Salary * 13) / 100;
            OtherAllowances = (Salary * 3) / 100;
            PF = (GrossSalary * 10) / 100;
            GrossSalary += PetrolAllowance + FoodAllowance + OtherAllowances;
            TDS = (GrossSalary * 18) / 100;
            NetSalary = GrossSalary - (PF + TDS);
            return NetSalary;
        }
    }

    class MarketingExecutive : Employee
    {
        private double KilometerTravel;
        private double TourAllowances;

        private int TelephoneAllowances = 1000;

        public void SetKilometersTravel(double Kilo)
        {
            KilometerTravel = Kilo;
            TourAllowances = KilometerTravel * 5;
        }

        public override double CalculateSalary()
        {

            PF = (GrossSalary * 10) / 100;
            TDS = (GrossSalary * 18) / 100;
            NetSalary = GrossSalary - (PF + TDS);
            GrossSalary += TourAllowances + TelephoneAllowances;
            return NetSalary;
        }
    }

    interface IPrintable
    {
        void PrintDetails();
    }
}

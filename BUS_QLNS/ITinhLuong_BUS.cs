using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
	internal interface ITinhLuong_BUS
	{
		decimal CalculateSalary(int employeeId);

        // Method to get salary details for a specific employee
        DataTable GetSalaryDetails(int employeeId);

        // Method to insert a new salary record
        bool InsertSalaryRecord(int employeeId, decimal baseSalary, decimal bonus, decimal deductions, DateTime salaryDate);

        // Method to update an existing salary record
        bool UpdateSalaryRecord(int salaryId, decimal baseSalary, decimal bonus, decimal deductions);

        // Method to delete a salary record
        bool DeleteSalaryRecord(int salaryId);
	}
}

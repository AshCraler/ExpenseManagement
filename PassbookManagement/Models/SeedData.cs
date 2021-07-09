using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PassbookManagement.Data;
using PassbookManagement.Framework;

namespace PassbookManagement.Models
{
    public class SeedData
    {
        
        public static void Initialize(IServiceProvider serviceProvider)
        {
            
            using (var context = new PassBookManagementContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PassBookManagementContext>>()))
            {
                if(!context.Employee.Any())
                {
                    context.Employee.AddRange(
                        new Employee
                        {
                            EmployeeId = "NV_01",
                            FullName = "Tran Quoc Thinh",
                            BirthDay = DateTime.Parse("2000-3-11"),
                            IdCardNumber = "385123456",
                            Email = "18521451@gm.uit.edu.vn",
                            PhoneNumber = "0768654300"
                        },
                        new Employee
                        {
                            EmployeeId = "NV_02",
                            FullName = "Do Trung Thuan",
                            BirthDay = DateTime.Parse("2000-3-11"),
                            IdCardNumber = "385123456",
                            Email = "18521468@gm.uit.edu.vn",
                            PhoneNumber = "0123456789"
                        },
                        new Employee
                        {
                            EmployeeId = "NV_03",
                            FullName = "Dang Dinh Quyen Anh",
                            BirthDay = DateTime.Parse("2000-3-11"),
                            IdCardNumber = "385123456",
                            Email = "17520000@gm.uit.edu.vn",
                            PhoneNumber = "0123456789"
                        }
                    );
                    context.SaveChanges();
                }

                if(!context.Interest.Any())
                {
                    context.Interest.AddRange(
                        new InterestValue
                        {
                            InterestId = IdAutoCreator.newInterest(),
                            Name = "1 thang",
                            StandardPeriod = 1,
                            StandardInterestRate = 3.1f,
                            
                        }, new InterestValue
                        {
                            InterestId = IdAutoCreator.newInterest(),
                            Name = "2 thang",
                            StandardPeriod = 2,
                            StandardInterestRate = 3.2f,
                            
                        }, new InterestValue
                        {
                            InterestId = IdAutoCreator.newInterest(),
                            Name = "3 thang",
                            StandardPeriod = 3,
                            StandardInterestRate = 3.3f,
                            
                        }, new InterestValue
                        {
                            InterestId = IdAutoCreator.newInterest(),
                            Name = "6 thang",
                            StandardPeriod = 6,
                            StandardInterestRate = 4.5f,
                            
                        },new InterestValue
                        {
                            InterestId = IdAutoCreator.newInterest(),
                            Name = "9 thang",
                            StandardPeriod = 9,
                            StandardInterestRate = 4.9f,
                            
                        }, new InterestValue
                        {
                            InterestId = IdAutoCreator.newInterest(),
                            Name = "12 thang",
                            StandardPeriod = 12,
                            StandardInterestRate = 5.6f,
                            
                        }, new InterestValue
                        {
                            InterestId = IdAutoCreator.newInterest(),
                            Name = "15 thang",
                            StandardPeriod = 15,
                            StandardInterestRate = 6.2f,
                            
                        },new InterestValue
                        {
                            InterestId = IdAutoCreator.newInterest(),
                            Name = "18 thang",
                            StandardPeriod = 18,
                            StandardInterestRate = 6.2f,
                            
                        }, new InterestValue
                        {
                            InterestId = IdAutoCreator.newInterest(),
                            Name = "24 thang",
                            StandardPeriod = 24,
                            StandardInterestRate = 6.2f,
                            
                        }, new InterestValue
                        {
                            InterestId = IdAutoCreator.newInterest(),
                            Name = "36 thang",
                            StandardPeriod = 36,
                            StandardInterestRate = 6.2f,
                            
                        }, new InterestValue
                        {
                            InterestId = IdAutoCreator.newInterest(),
                            Name = "Khong thoi han",
                            StandardPeriod = 0,
                            StandardInterestRate = 2.0f,
                            
                        }
                    );
                    context.SaveChanges();
                }


            }
        }
    }
}

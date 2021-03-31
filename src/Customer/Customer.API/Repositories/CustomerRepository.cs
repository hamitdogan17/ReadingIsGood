using Customer.API.Repositories.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConfiguration _configuration;

        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }       

        public async Task<IEnumerable<Entities.Customer>> GetCustomers()
        {            
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var customer = await connection.QueryAsync<Entities.Customer>
                ("SELECT * FROM Customer");

            if (customer == null)
                return null;
            return customer;
        }

        public async Task<Entities.Customer> GetCustomerByMail(string mail)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var customer = await connection.QueryFirstOrDefaultAsync<Entities.Customer>
                ("SELECT * FROM Coupon WHERE Mail = @Mail", new { Mail = mail });

            if (customer == null)
                return null;
            return customer;
        }

        public async Task<bool> CreateCustomer(Entities.Customer customer)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected =
                await connection.ExecuteAsync
                    ("INSERT INTO Customer(Name, Surname, Mail, Age, Address) VALUES (@Name, @Surname, @Mail, @Age, @Address)",
                            new { Name = customer.Name, Surname = customer.Surname, Mail = customer.Mail, Age = customer.Age, Address = customer.Address});

            if (affected == 0)
                return false;



            return true;
        }

        public async Task<bool> UpdateCustomer(Entities.Customer customer)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync
                    ("UPDATE Customer SET Name=@Name, Surname = @Surname, Mail = @Mail, Age = @Age, Address = @Address  WHERE Id = @Id",
                            new { Name = customer.Name, Surname = customer.Surname, Mail = customer.Mail, Age = customer.Age, Address = customer.Address });

            if (affected == 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync("DELETE FROM Customer WHERE Id = @Id",
                new { ProductName = id });

            if (affected == 0)
                return false;

            return true;
        }
    }
}

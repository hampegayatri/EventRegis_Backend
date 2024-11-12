using EventManagementAPI.Models;
using EventManagementAPI.Repositories;
using EventManagementAPI.Repository_Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementAPI.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;

        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreatePaymentAsync(Payment payment)
        {
            await _repository.AddAsync(payment);
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            await _repository.UpdateAsync(payment);
        }

        public async Task DeletePaymentAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

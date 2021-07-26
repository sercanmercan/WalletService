using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WalletService.Domain.Events;
using WalletService.Domain.Repository;

namespace WalletService.Application.Handler
{
    public class TransactionDomainEventHandler : INotificationHandler<TransactionDomainEvent>
    {
        private readonly IUsersRepository userRepository;

        public TransactionDomainEventHandler(IUsersRepository userRepository)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public Task Handle(TransactionDomainEvent notification, CancellationToken cancellationToken)
        {
            //if(notification.transaction.userId == 0)
            //{
            //    var user = new Domain.AggregateModels.Users.Users(notification.userFirstName, notification.userLastName, notification.userTcNo, notification.userCustomerNo, notification.userEmail, notification.userPassword);
            //   // var user = new Domain.AggregateModels.Users.Users(notification.userId);
            //    userRepository.CreateUser(user);
            //}

            return Task.CompletedTask;
        }
    }
}

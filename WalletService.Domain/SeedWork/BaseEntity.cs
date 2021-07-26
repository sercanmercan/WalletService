using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace WalletService.Domain.SeedWork
{
    public abstract class BaseEntity
    {
        [NotNull]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        private ICollection<INotification> domainEvents;

        public ICollection<INotification> DomainEvent => domainEvents;

        public void AddDomainEvents(INotification notification)
        {
            domainEvents ??= new List<INotification>();
            domainEvents.Add(notification);
        }
    }
}

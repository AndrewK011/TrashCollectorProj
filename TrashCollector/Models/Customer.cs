using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Customer
    {
        private DateTime suspendStart;
        private DateTime suspendEnd;
        private DateTime oneTimePickup;
        public Customer()
        {
            suspendStart = DateTime.Today;
            suspendEnd = DateTime.Today;
            oneTimePickup = DateTime.Today;
        }

        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int ZipCode  { get; set; }
        public DayOfWeek PickupDay  { get; set; }
        public DateTime OneTimePickup { get { return oneTimePickup; } set { oneTimePickup = value; } }
        public bool OneTimePickupUsed { get; set; }
        public double MonthlyBalanceOwed { get; set; }
        public DateTime SuspendStart { get { return suspendStart; } set { suspendStart = value; } }
        public DateTime SuspendEnd { get { return suspendEnd; } set { suspendEnd = value; } }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        
    }
}

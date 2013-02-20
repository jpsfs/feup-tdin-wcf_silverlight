using System;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Client;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using ClientApplication.Web.Resources;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ClientApplication.Models
{
    public class TransactionInfo 
    {
        [Required(ErrorMessage="Required Field")]
        [Display(Name = "Stock Type")]
        public string SockType { get; set; }

        [Required(ErrorMessage="Required Field")]
        [Display(Name = "Quantity")]
        public double Quantity { get; set; }

        [Required(ErrorMessage="Required Field")]
        [Display(Name = "Transaction Type")]
        public Server.TransactionType Type { get; set; }

    }

    public class TransactionInfoBalcon : TransactionInfo, INotifyPropertyChanged
    {
        private string clientEmail;

        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Client Email")]
        [CustomValidation(typeof(TransactionValidator), "ValidateEmail")]
        public string ClientEmail
        {
            get
            {
                return clientEmail;
            }
            set
            {
                if (clientEmail == value) return;
                var propertyName = "ClientEmail";
                Validate(value, propertyName);
                clientEmail = value;
                FirePropertyChanged(propertyName);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void FirePropertyChanged(string propertyname)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyname));
        }

        protected void Validate(object value, string propertyName)
        {
            Validator.ValidateProperty(value,
                new ValidationContext(this, null, null) { MemberName = propertyName });
        }
    }

    public static class TransactionValidator
    {
        public static ObservableCollection<string> clientsEmails { get; set; }
        public static ValidationResult ValidateEmail(string clientEmail)
        {
            if(clientsEmails.Count == 0 || clientsEmails.Contains(clientEmail))
                return ValidationResult.Success;
            else
                return new ValidationResult("The supplied email is not registered in the system");

                
        }
    }
}

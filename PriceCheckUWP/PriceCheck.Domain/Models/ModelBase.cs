using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCheck.Domain.Models
{
    public class ModelBase : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        private DateTime dateCreated;
        public DateTime DateCreated
        {
            get
            {
                return dateCreated;
            }
            set
            {
                if (dateCreated != value)
                {
                    dateCreated = value;
                    OnPropertyChanged(nameof(DateCreated));
                }
            }
        }

        private DateTime dateModified;
        public DateTime DateModified
        {
            get
            {
                return dateModified;
            }
            set
            {
                if (dateModified != value)
                {
                    dateModified = value;
                    OnPropertyChanged(nameof(DateModified));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

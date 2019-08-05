using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStarted
{
    public class ContactInfo : INotifyPropertyChanged
    {
        #region Fields

        private string contactName;
        private string contactNo;

        #endregion

        #region Constructor

        public ContactInfo()
        {
        }

        #endregion

        #region Properties

        public string ContactName
        {
            get { return contactName; }
            set
            {
                contactName = value;
                OnPropertyChanged("ContactName");
            }
        }
        public bool isDescriptionVisible;

            public bool IsDescriptionVisible
        {
            get { return isDescriptionVisible; }
            set
            {
                isDescriptionVisible = value;
                OnPropertyChanged("IsDescriptionVisible");
            }
        }
        public string ContactNo
        {
            get { return contactNo; }
            set
            {
                contactNo = value;
                OnPropertyChanged("ContactNo");
            }
        }

        public bool isButtonVisible;
        public bool IsButtonVisible
        {
            get { return isButtonVisible; }
            set
            {
                isButtonVisible = value;
                OnPropertyChanged("IsButtonVisible");
            }
        }

        public bool isChecked;
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        public bool isIndicatorVisible;
        public bool IsIndicatorVisible
        {
            get { return isIndicatorVisible; }
            set
            {
                isIndicatorVisible = value;
                OnPropertyChanged("IsIndicatorVisible");
            }
        }

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}

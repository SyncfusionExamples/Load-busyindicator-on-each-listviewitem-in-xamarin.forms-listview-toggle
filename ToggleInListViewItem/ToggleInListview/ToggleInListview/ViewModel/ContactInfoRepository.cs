using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStarted
{
    public class ContactInfoRepository : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<ContactInfo> newContactInfo;
        public event PropertyChangedEventHandler PropertyChanged;

        public string[] ContactNames = new string[]
     {
            "Albert",
            "John",
           "Cooper",
           "Hudson",
           "Evan",
           "Joshua",
           "Charlie",
           "Julian",
           "Bryce",
           "Nicholas"
     };
        public string[] ContactNos = new string[]
           {
            "121-234-4321",
            "342-333-4432",
           "222-121-2134",
           "122-234-2344",
           "223-456-4555",
           "323-453-3423",
           "523-563-4332",
           "323-673-4534",
           "523-783-5464",
           "663-893-8989"
          };

        #endregion

        #region Properties

        public ObservableCollection<ContactInfo> NewContactInfo
        {
            get { return newContactInfo; }
            set { this.newContactInfo = value; }
        }

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region Constructor

        public ContactInfoRepository()
        {
            GenerateNewContactInfo();
        }

        #endregion

        #region Properties

        internal ObservableCollection<ContactInfo> GenerateNewContactInfo()
        {
            NewContactInfo = new ObservableCollection<ContactInfo>();
            for (int i = 0; i < ContactNames.Count(); i++)
            {
                var contact = new ContactInfo()
                {
                    ContactName = ContactNames[i],
                    ContactNo = ContactNos[i],
                    IsIndicatorVisible = false,
                    IsButtonVisible = true,
                    IsDescriptionVisible = true,
                    IsChecked = false
                };
                NewContactInfo.Add(contact);
            }
            return NewContactInfo;
        }
        #endregion
    }
}

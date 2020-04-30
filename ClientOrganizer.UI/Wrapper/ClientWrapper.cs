using ClientOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClientOrganizer.UI.Wrapper
{

    public class ClientWrapper : ModelWrapper<Client>
    {

        public ClientWrapper(Client model) : base(model)
        {

        }
        
        public int Id { get { return Model.PartyId; } }

        public int PartyId
        {
            get { return Model.PartyId; }
            set
            {
                Model.PartyId = value;
                OnPropertyChanged();
            }
        }

        public string FullName
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }
       
        public int PartyCode
        {
            get { return Model.PartyCode; }
            set
            {
                Model.PartyCode = value;
                OnPropertyChanged();
            }
        }

        public DateTime RegistrationDate
        {
            get { return Model.RegistrationDate; }
            set
            {
                Model.RegistrationDate = value;
                OnPropertyChanged();
            }
        }

        public long TaxCode
        {
            get { return Model.TaxCode; }
            set
            {
                Model.TaxCode = value;
                OnPropertyChanged();
            }
        }

        public string ClientType
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }

        public string CountryCode
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(FullName):                    
                    if (FullName.All(c => Char.IsLetter(c) || (c.Equals(" "))))
                    {
                        yield return "Full name should consist only of letters and spaces";
                    }
                    break;
            }
        }

    }
}

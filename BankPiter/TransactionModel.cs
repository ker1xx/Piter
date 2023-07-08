using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankPiter
{
    internal class TransactionModel
    {
        public TransactionModel(int CardNumber, string NameSurname, int AuthorizationCode,float Price, string OrgranizationName, int AzsId, string SessionKey)
        {
            this.CardNubmer = CardNubmer;
            this.NameSurname = NameSurname;
            this.AuthorizationCode = AuthorizationCode;
            this.Price = Price;
            this.OrgranizationName = OrgranizationName;
            this.AzsId = AzsId;
            this.SessionKey = SessionKey;
        }
        public int? Id { get; set; }

        public int CardNubmer { get; set; }

        public string NameSurname { get; set; } = null;

        public int AuthorizationCode { get; set; }

        public double Price { get; set; }

        public string OrgranizationName { get; set; } = null;

        public int AzsId { get; set; }

        public string SessionKey { get; set; } = null;
    }
}

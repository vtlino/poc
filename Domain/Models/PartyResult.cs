using System.Collections.Generic;

namespace OpenBanking.POC.Domain.Models
{

    public class DocumentIDParty
    {
        public string Type { get; set; }
        public string Number { get; set; }
        public string Issuer { get; set; }
        public string IssueDate { get; set; }
    }

    public class AddressParty
    {
        public string AddressType { get; set; }
        public IList<string> AddressLine { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public string PostCode { get; set; }
        public string TownName { get; set; }
        public string CountrySubDivision { get; set; }
        public string Country { get; set; }
    }

    public class Party
    {
        public Party()
        {
            DocumentID = new DocumentIDParty();
            Address = new List<AddressParty>();
        }

        public string PartyId { get; set; }
        public string PartyNumber { get; set; }
        public string PartyType { get; set; }
        public string Name { get; set; }
        public string FullLegalName { get; set; }
        public string LegalStructure { get; set; }
        public bool BeneficialOwnership { get; set; }
        public string AccountRole { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Nationality { get; set; }
        public string BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Spouse { get; set; }
        public string Occupation { get; set; }
        public DocumentIDParty DocumentID { get; set; }
        public string CPF { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public IList<AddressParty> Address { get; set; }
    }

    public class DataParty
    {
        public DataParty()
        {
            Party = new Party();
        }

        public Party Party { get; set; }
    }

    public class PartyResult
    {
        public PartyResult()
        {
            Data = new DataParty();
            Links = new Links();
            Meta = new Meta();
        }

        public DataParty Data { get; set; }
        public Links Links { get; set; }
        public Meta Meta { get; set; }
    }
}
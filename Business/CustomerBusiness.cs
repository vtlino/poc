using Common;
using Newtonsoft.Json;
using OpenBanking.POC.Domain.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Net;

namespace Business
{
    public class CustomerBusiness
    {
        private readonly CustomerRepository _CustomerRepository = new CustomerRepository();

        public Tuple<int, string> GetCustomer(string user)
        {
            //TODO: Usuario sera pego pela conta?
            var account = AccountIM.GetAccount(user);
            if (string.IsNullOrWhiteSpace(account) || account.Equals("0"))
                return Tuple.Create((int)HttpStatusCode.NoContent, JsonConvert.SerializeObject(new PartyResult()));

            var customer = _CustomerRepository.GetCustomer(account);
            if (customer == null || string.IsNullOrEmpty(customer.AccountId) || customer.AccountId.Equals("0"))
                return Tuple.Create((int)HttpStatusCode.NoContent, JsonConvert.SerializeObject(new PartyResult()));

            var address = new List<AddressParty>();
            address.Add(new AddressParty
            {
                BuildingNumber = customer.BuildingNumber,
                StreetName = customer.StreetName,
                AddressType = customer.AdressType,
                PostCode = customer.PostCode,
                Country = customer.Country,
                CountrySubDivision = customer.CountrySubdivision,
                TownName = customer.TownName
            });

            var party = new PartyResult
            {
                Data = new DataParty
                {
                    Party = new Party
                    {
                        Address = address,
                        CPF = customer.CPF,
                        PartyId = customer.PartyId,
                        PartyType = customer.PartyType,
                        Name = customer.Name,
                        FatherName = customer.FatherName,
                        MotherName = customer.MotherName,
                        BirthDate = customer.BirthDate.ToShortDateString(),
                        BirthPlace = customer.BirthPlace,
                        MaritalStatus = customer.MaritalStatus,
                        Gender = customer.Gender,
                        Phone = customer.Phone,
                        Occupation = customer.Occupation,
                        EmailAddress = customer.EmailAdress
                    }
                }
            };

            return Tuple.Create((int)HttpStatusCode.OK, JsonConvert.SerializeObject(party));
        }
    }
}

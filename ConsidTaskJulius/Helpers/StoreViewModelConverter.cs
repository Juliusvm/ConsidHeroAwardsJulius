using ConsidTaskJulius.Models;
using ConsidTaskJulius.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsidTaskJulius.Helpers
{
    public class StoreViewModelConverter
    {

        public static StoreViewModel fromStore(Stores store, StoreViewModel storeViewModel, List<Companies> companies)
        {
            storeViewModel.ID = store.Id;
            storeViewModel.Country = store.Country;
            storeViewModel.City = store.City;
            storeViewModel.Address = store.Address;
            storeViewModel.companies = companies;
            storeViewModel.CompanyID = store.CompanyId;
            storeViewModel.Name = store.Name;
            storeViewModel.Longitude = store.Longitude;
            storeViewModel.Latitude = store.Latitude;
            storeViewModel.Zip = store.Zip;
            return storeViewModel;

        }

        public static Stores toStore(StoreViewModel storeViewModel, Stores store)
        {

            store.Id = storeViewModel.ID;
            store.CompanyId = storeViewModel.CompanyID;
            store.Address = storeViewModel.Address;
            store.City = storeViewModel.City;
            store.Country = storeViewModel.Country;
            store.Name = storeViewModel.Name;
            store.Zip = storeViewModel.Zip;
            store.Latitude = storeViewModel.Latitude;
            store.Longitude = storeViewModel.Longitude;


            return store;
        }
    }
}

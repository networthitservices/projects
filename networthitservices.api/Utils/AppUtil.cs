using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using networthitservices.models;

namespace networthitservices.api.Utils
{
    public class AppUtil
    {
        private readonly NetworthitservicesContext _context;

        public AppUtil(NetworthitservicesContext context)
        {
            _context = context;
        }

        //Get Application Settings
        public string GetApplicationSetting(string name)
        {
            string SettingValue = "";

            try
            {

                SettingValue = _context.Settings.First(x => x.Key.ToLower() == name.ToLower()).Value;
                return SettingValue;
            }

            catch (Exception error)
            {

                throw new Exception("An error occurred while fetching application settings", error);

            }
        }
    }
}

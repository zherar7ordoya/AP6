﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary.Models
{
    /// <summary>
    /// Represents one person.
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// The unique identifier for the person.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The first name of the person.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The last name of the person.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The primary emailaddress of the person.
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// The primary cellphone number of the person.
        /// </summary>
        public string CellphoneNumber { get; set; }

        public string FullName
        {
            get 
            { 
                return $"{ FirstName } { LastName }"; 
            }
        }
    }
}

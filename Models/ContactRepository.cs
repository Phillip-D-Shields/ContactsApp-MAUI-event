﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Models
{
    class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact {ContactId=0, Name="John Doe", Email = "jd00@email.com" },
            new Contact {ContactId=1, Name="Jane Doe", Email = "jd01@email.com"},
            new Contact {ContactId=2, Name="John Smith", Email = "js00@email.com"},
            new Contact {ContactId=3, Name="Jane Smith", Email = "js01@email.com"},
            new Contact {ContactId=4, Name="Phillip Shields", Email = "ps00@email.com"}
        };

        public static List<Contact> GetContacts() => _contacts;

        public static Contact GetContact(int contactId) => _contacts.FirstOrDefault(c => c.ContactId == contactId);
    }
}